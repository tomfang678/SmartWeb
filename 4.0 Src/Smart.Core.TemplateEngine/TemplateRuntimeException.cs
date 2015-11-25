using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Smart.Core.TemplateEngine
{
    /// <summary>
    /// 表示模板引擎执行期间发生的错误。
    /// </summary>
    public sealed class TemplateRuntimeException : Exception
    {
        #region 私有字段

        private int _Line;
        private int _Col;

        #endregion

        #region 构造函数

        /// <summary>
        /// 初始化模板引擎运行时错误。
        /// </summary>
        /// <param name="msg">错误内容。</param>
        /// <param name="line">引发异常的代码所在的行数。</param>
        /// <param name="col">引发异常的代码所在的列数。</param>
        public TemplateRuntimeException(string msg, int line, int col)
            : base(msg)
        {
            _Line = line;
            _Col = col;
        }

        /// <summary>
        /// 初始化模板引擎运行时错误。
        /// </summary>
        /// <param name="msg">错误消息内容。</param>
        /// <param name="innerException">导致当前异常的异常。</param>
        /// <param name="line">引发异常的代码所在的行数。</param>
        /// <param name="col">引发异常的代码所在的列数。</param>
        public TemplateRuntimeException(string msg, Exception innerException, int line, int col)
            : base(msg, innerException)
        {
            _Line = line;
            _Col = col;
        }

        #endregion

        #region 公有属性

        /// <summary>
        /// 获取引发异常的代码所在的列数。
        /// </summary>
        public int Col
        {
            get { return _Col; }
        }

        /// <summary>
        /// 获取引发异常的代码所在的行数。
        /// </summary>
        public int Line
        {
            get { return _Line; }
        }

        #endregion
    }
}
