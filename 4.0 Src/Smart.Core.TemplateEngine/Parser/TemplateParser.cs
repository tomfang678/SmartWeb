﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Smart.Core.TemplateEngine.Parser
{
    /// <summary>
    /// 模板解析器。
    /// </summary>
    public class TemplateParser
    {
        #region 私有字段

        private TemplateLexer _Lexer;
        private Token _Current;
        private List<Element> _Elements;

        #endregion

        #region 构造函数

        /// <summary>
        /// 初始化模板解析器。
        /// </summary>
        /// <param name="lexer">指定一个模板词汇分析器的实例。</param>
        public TemplateParser(TemplateLexer lexer)
        {
            _Lexer = lexer;
            _Elements = new List<Element>();

        }

        #endregion

        #region 私有方法

        private Token _Consume()
        {
            Token old = _Current;
            _Current = _Lexer.Next();
            return old;
        }

        private Token _Consume(TokenKind kind)
        {
            Token old = _Current;
            _Current = _Lexer.Next();

            if (old.TokenKind != kind)
                throw new ParseException("意外的 Token：" + _Current.TokenKind.ToString() + "。未找到：" + kind, _Current.Line, _Current.Col);

            return old;
        }

        private Element _ReadElement()
        {
            switch (Current.TokenKind)
            {
                case TokenKind.EOF:
                    return null;
                case TokenKind.TagStart:
                    return _ReadTag();
                case TokenKind.TagClose:
                    return _ReadCloseTag();
                case TokenKind.ExpStart:
                    return _ReadExpression();
                case TokenKind.TextData:
                    Text text = new Text(Current.Line, Current.Col, Current.Data);
                    _Consume();
                    return text;
                default:
                    throw new ParseException("无效的 Token：" + Current.TokenKind.ToString(), Current.Line, Current.Col);
            }
        }

        private TagClose _ReadCloseTag()
        {
            _Consume(TokenKind.TagClose);
            Token IDToken = _Consume(TokenKind.id);
            _Consume(TokenKind.TagEnd);

            return new TagClose(IDToken.Line, IDToken.Col, IDToken.Data);
        }

        private Expression _ReadExpression()
        {
            _Consume(TokenKind.ExpStart);

            Expression exp = _TopExpression();

            _Consume(TokenKind.ExpEnd);

            return exp;
        }

        private Tag _ReadTag()
        {
            _Consume(TokenKind.TagStart);
            Token name = _Consume(TokenKind.id);
            Tag tag = new Tag(name.Line, name.Col, name.Data);

            while (true)
            {
                if (Current.TokenKind == TokenKind.id)
                    tag.Attributes.Add(_ReadAttribute());
                else if (Current.TokenKind == TokenKind.TagEnd)
                {
                    _Consume();
                    break;
                }
                else if (Current.TokenKind == TokenKind.TagEndClose)
                {
                    _Consume();
                    tag.IsClosed = true;
                    break;
                }
                else
                    throw new ParseException("无效的 Token 标记：" + Current.TokenKind, Current.Line, Current.Col);

            }

            return tag;

        }

        private TagAttribute _ReadAttribute()
        {
            Token name = _Consume(TokenKind.id);
            _Consume(TokenKind.TagEquals);

            Expression exp = null;

            if (Current.TokenKind == TokenKind.StringStart)
                exp = _ReadString();
            else
                throw new ParseException("意外的 Token ：" + Current.TokenKind + "。未找到 '\"'", Current.Line, Current.Col);

            return new TagAttribute(name.Data, exp);
        }

        private Expression _ReadString()
        {
            Token start = _Consume(TokenKind.StringStart);
            StringExpression exp = new StringExpression(start.Line, start.Col);

            while (true)
            {
                Token tok = Current;

                if (tok.TokenKind == TokenKind.StringEnd)
                {
                    _Consume();
                    break;
                }
                else if (tok.TokenKind == TokenKind.EOF)
                    throw new ParseException("文档意外终止。", tok.Line, tok.Col);
                else if (tok.TokenKind == TokenKind.StringText)
                {
                    _Consume();
                    exp.Add(new StringLiteral(tok.Line, tok.Col, tok.Data));
                }
                else if (tok.TokenKind == TokenKind.ExpStart)
                    exp.Add(_ReadExpression());
                else
                    throw new ParseException("意外的 Token 字符串：" + tok.TokenKind, tok.Line, tok.Col);
            }

            if (exp.ExpCount == 1)
                return exp[0];
            else
                return exp;
        }

        private Expression _TopExpression()
        {
            return _OrExpression();
        }

        private Expression _OrExpression()
        {
            Expression ret = _AndExpression();

            while (Current.TokenKind == TokenKind.OpOr)
            {
                _Consume(); // Or
                Expression rhs = _AndExpression();
                ret = new BinaryExpression(ret.Line, ret.Col, ret, TokenKind.OpOr, rhs);
            }

            return ret;
        }

        private Expression _AndExpression()
        {
            Expression ret = _EqualityExpression();

            while (Current.TokenKind == TokenKind.OpAnd)
            {
                _Consume(); // Or
                Expression rhs = _EqualityExpression();
                ret = new BinaryExpression(ret.Line, ret.Col, ret, TokenKind.OpAnd, rhs);
            }

            return ret;
        }

        private Expression _EqualityExpression()
        {
            Expression ret = _RelationalExpression();
            while (Current.TokenKind == TokenKind.OpIs
                || Current.TokenKind == TokenKind.OpIsNot)
            {
                Token tok = _Consume(); // consume operator
                Expression rhs = _RelationalExpression();

                ret = new BinaryExpression(ret.Line, ret.Col, ret, tok.TokenKind, rhs);
            }

            return ret;
        }

        private Expression _RelationalExpression()
        {
            Expression ret = _PrimaryExpression();

            while (Current.TokenKind == TokenKind.OpLt
                || Current.TokenKind == TokenKind.OpLte
                || Current.TokenKind == TokenKind.OpGt
                || Current.TokenKind == TokenKind.OpGte)
            {
                Token tok = _Consume(); // consume operator
                Expression rhs = _PrimaryExpression();
                ret = new BinaryExpression(ret.Line, ret.Col, ret, tok.TokenKind, rhs);
            }

            return ret;
        }

        private Expression _PrimaryExpression()
        {
            if (Current.TokenKind == TokenKind.StringStart)
                return _ReadString();
            else if (Current.TokenKind == TokenKind.id)
            {
                Token id = _Consume();

                Expression exp = null;

                // if ( follows ID, we have a function call
                if (Current.TokenKind == TokenKind.LParen)
                {
                    _Consume();	// consume LParen
                    Expression[] args = _ReadArguments();
                    _Consume(TokenKind.RParen);

                    exp = new FCall(id.Line, id.Col, id.Data, args);
                }
                else  // else, we just have id
                    exp = new Name(id.Line, id.Col, id.Data);

                // while we have ".", keep chaining up field access or method call
                while (Current.TokenKind == TokenKind.Dot || Current.TokenKind == TokenKind.LBracket)
                {
                    if (Current.TokenKind == TokenKind.Dot)
                    {
                        _Consume();	// consume DOT
                        Token field = _Consume(TokenKind.id);	// consume ID after dot

                        // if "(" after ID, then it's a method call
                        if (Current.TokenKind == TokenKind.LParen)
                        {
                            _Consume(); // consume "("
                            Expression[] args = _ReadArguments();
                            _Consume(TokenKind.RParen); // read ")"

                            exp = new MethodCall(field.Line, field.Col, exp, field.Data, args);
                        }
                        else
                            exp = new FieldAccess(field.Line, field.Col, exp, field.Data);
                    }
                    else // must be LBracket
                    {
                        // array access
                        Token bracket = Current;
                        _Consume(); // consume [
                        Expression indexExp = _TopExpression();
                        _Consume(TokenKind.RBracket);

                        exp = new ArrayAccess(bracket.Line, bracket.Col, exp, indexExp);
                    }

                }

                return exp;

            }
            else if (Current.TokenKind == TokenKind.Integer)
            {
                int value = Int32.Parse(Current.Data);
                IntLiteral intLiteral = new IntLiteral(Current.Line, Current.Col, value);
                _Consume(); // consume int
                return intLiteral;
            }
            else if (Current.TokenKind == TokenKind.Double)
            {
                double value = Double.Parse(Current.Data);
                DoubleLiteral dLiteral = new DoubleLiteral(Current.Line, Current.Col, value);
                _Consume(); // consume int
                return dLiteral;
            }
            else if (Current.TokenKind == TokenKind.LParen)
            {
                _Consume(); // eat (
                Expression exp = _TopExpression();
                _Consume(TokenKind.RParen); // eat )

                return exp;
            }
            else
                throw new ParseException("意外的 Token 表达式：" + Current.TokenKind + "。Token类型 即非 ID 也非 string。", Current.Line, Current.Col);
        }

        private Expression[] _ReadArguments()
        {
            List<Expression> exps = new List<Expression>();

            int index = 0;
            while (true)
            {
                if (Current.TokenKind == TokenKind.RParen)
                    break;

                if (index > 0)
                    _Consume(TokenKind.Comma);

                exps.Add(_TopExpression());

                index++;
            }

            return exps.ToArray();
        }

        #endregion

        #region 公有方法

        /// <summary>
        /// 执行解析。
        /// </summary>
        /// <returns>List&lt;Element&gt;</returns>
        public List<Element> Parse()
        {
            _Elements.Clear();

            _Consume();

            while (true)
            {
                Element elem = _ReadElement();
                if (elem == null)
                    break;
                else
                    _Elements.Add(elem);
            }
            return _Elements;
        }

        #endregion

        #region 公有属性

        public Token Current
        {
            get { return _Current; }
        }

        #endregion
    }
}
