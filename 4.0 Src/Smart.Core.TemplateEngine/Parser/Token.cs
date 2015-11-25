using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Smart.Core.TemplateEngine.Parser
{
    public class Token
    {
        public Token(TokenKind kind, string data, int line, int col)
        {
            this.TokenKind = kind;
            this.Data = data;
            this.Line = line;
            this.Col = col;
        }

        public TokenKind TokenKind { get; set; }

        public string Data { get; set; }

        public int Line { get; set; }

        public int Col { get; set; }
    }
}
