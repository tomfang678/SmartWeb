using System;
using System.Collections.Generic;
using System.Text;

namespace Smart.Core.TemplateEngine.Parser
{
	/// <summary>
	/// 表示整形数字表达式。
	/// </summary>
	public class IntLiteral : Expression
	{
		#region 私有字段
		
		private int _Value;

		#endregion

		#region 构造函数
		
		/// <summary>
		/// 初始化整形数字表达式。
		/// </summary>
		/// <param name="line">指定整形数字表达式所在位置的行数。</param>
		/// <param name="col">指定整形数字表达式所在位置的列数。</param>
		/// <param name="value">指定整形数字表达式的值。</param>
		public IntLiteral(int line, int col, int value)
			: base(line, col)
		{
			_Value = value;
		}

		#endregion

		#region 公有属性
		
		/// <summary>
		/// 获取整形数字表达式的值。
		/// </summary>
		public int Value
		{
			get { return _Value; }
		}

		#endregion
	}
}
