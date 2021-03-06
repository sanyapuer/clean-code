﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework.Constraints;

namespace Markdown.Rules
{
    internal class Header : MarkupRule
    {
        public new string MarkdownTag { get; } = "#";
        public new string HtmlTag { get; } = "h1";
        public new bool HaveClosingHtmlTag { get; } = true;
        public new bool HaveClosingMarkdownTag { get; } = false;
        
        public new IEnumerable<ParsedSubline> ParseLineWithRule(string s)
        {
            var result = new List<ParsedSubline>();
            if (s.StartsWith($"{MarkdownTag} "))
                result.Add(
                    new ParsedSubline()
                    {
                        LeftBorderOfSubline = 0, 
                        RightBorderOfSubline = MarkdownTag.Length - 1, 
                        MarkupRule = this
                    });
            return result;
        }
        
    }
}
