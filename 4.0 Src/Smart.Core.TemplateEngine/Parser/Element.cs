using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Smart.Core.TemplateEngine.Parser
{
    public class Element
    {
        public Element(int line, int col)
        {
            Line = line;
            Col = col;
        }

        public int Col { get; set; }

        public int Line { get; set; }
    }
}
