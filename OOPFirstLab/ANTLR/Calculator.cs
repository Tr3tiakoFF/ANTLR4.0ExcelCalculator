using Antlr4.Runtime;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPFirstLab.ANTLR
{
    public static class Calculator
    {
        public static double Evaluate(string expression, Dictionary<string, DataCell> _tableIdentifier)
        {
            var lexer = new ExcelCalculatorLexer(new AntlrInputStream(expression));

            var tokens = new CommonTokenStream(lexer);
            var parser = new ExcelCalculatorParser(tokens);

            var tree = parser.compileUnit();
            var visitor = new ExcelCalculatorVisitor(_tableIdentifier);

            return visitor.Visit(tree);
        }
        public static double Evaluate(string expression)
        {
            var lexer = new ExcelCalculatorLexer(new AntlrInputStream(expression));

            var tokens = new CommonTokenStream(lexer);
            var parser = new ExcelCalculatorParser(tokens);

            var tree = parser.compileUnit();
            var visitor = new ExcelCalculatorVisitor();

            return visitor.Visit(tree);
        }
    }
}
