using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPFirstLab.ANTLR
{
    class ExcelCalculatorVisitor : ExcelCalculatorBaseVisitor<double>
    {
        public ExcelCalculatorVisitor() { }
        public ExcelCalculatorVisitor(Dictionary<string, DataCell> __tableIdentifier_)
        {
            _tableIdentifier = __tableIdentifier_;
        }

        private Dictionary<string, DataCell> _tableIdentifier;

        public override double VisitCompileUnit(ExcelCalculatorParser.CompileUnitContext context)
        {
            return Visit(context.expression());
        }

        public override double VisitNumberExpr(ExcelCalculatorParser.NumberExprContext context)
        {
            var result = double.Parse(context.GetText());
            //Debug.WriteLine(result);

            return result;
        }

        //IdentifierExpr
        public override double VisitIdentifierExpr(ExcelCalculatorParser.IdentifierExprContext context)
        {
            var _cellName = context.GetText();

            Debug.WriteLine(_cellName);

            //видобути значення змінної з таблиці
            if (_tableIdentifier[_cellName].Expression != "0")
            {
                Debug.WriteLine(_tableIdentifier[_cellName].Expression);
                return Calculator.Evaluate(_tableIdentifier[_cellName].Expression, _tableIdentifier);
            }
            else
            {
                return 0.0;
            }
        }
        public override double VisitNotFunctionExpr([NotNull] ExcelCalculatorParser.NotFunctionExprContext context)
        {
            var number = WalkLeft(context);

            if (context.operatorToken.Type == ExcelCalculatorLexer.NOT)
            {
                if (number == 0)
                {
                    return 1;
                }
                else
                {
                    return 0;
                }
            }

            return base.VisitNotFunctionExpr(context);
        }
        public override double VisitLogicFunctionExpr([NotNull] ExcelCalculatorParser.LogicFunctionExprContext context)
        {
            var left = WalkLeft(context);
            var right = WalkRight(context);

            if (context.operatorToken.Type == ExcelCalculatorLexer.AND)
            {
                if (left != 0 && right != 0)
                {
                    return 1;
                }
                else
                {
                    return 0;
                }
            }
            if (context.operatorToken.Type == ExcelCalculatorLexer.OR)
            {
                if (left == 0 && right == 0)
                {
                    return 0;
                }
                else
                {
                    return 1;
                }
            }

            return base.VisitLogicFunctionExpr(context);
        }
        public override double VisitLogicFunctorExpr([NotNull] ExcelCalculatorParser.LogicFunctorExprContext context)
        {
            var left = WalkLeft(context);
            var right = WalkRight(context);

            if (context.operatorToken.Type == ExcelCalculatorLexer.EQUALLITYDIGIT)
            {
                if (left == right)
                {
                    return 1;
                }
                else
                {
                    return 0;
                }
            }
            if (context.operatorToken.Type == ExcelCalculatorLexer.MOREDIGIT)
            {
                if (left > right)
                {
                    return 1;
                }
                else
                {
                    return 0;
                }
            }
            if (context.operatorToken.Type == ExcelCalculatorLexer.LESSDIGIT)
            {
                if (left < right)
                {
                    return 1;
                }
                else
                {
                    return 0;
                }
            }

            return base.VisitLogicFunctorExpr(context);
        }
        public override double VisitArithmeticFunctionExpr([NotNull] ExcelCalculatorParser.ArithmeticFunctionExprContext context)
        {
            var left = WalkLeft(context);
            var right = WalkRight(context);

            if (context.operatorToken.Type == ExcelCalculatorLexer.MOD)
            {
                return left % right;
            }
            if (context.operatorToken.Type == ExcelCalculatorLexer.DIV)
            {
                return (int)left / (int)right;
            }

            return base.VisitArithmeticFunctionExpr(context);
        }
        public override double VisitMultiplicativeExpr([NotNull] ExcelCalculatorParser.MultiplicativeExprContext context)
        {
            var left = WalkLeft(context);
            var right = WalkRight(context);

            if (context.operatorToken.Type == ExcelCalculatorLexer.MULTIPLY)
            {
                return left * right;
            }
            if (context.operatorToken.Type == ExcelCalculatorLexer.DIVIDE)
            {
                return left / right;
            }

            return base.VisitMultiplicativeExpr(context);
        }
        public override double VisitAdditiveExpr([NotNull] ExcelCalculatorParser.AdditiveExprContext context)
        {
            var left = WalkLeft(context);
            var right = WalkRight(context);

            if (context.operatorToken.Type == ExcelCalculatorLexer.ADD)
            {
                return left + right;
            }
            if (context.operatorToken.Type == ExcelCalculatorLexer.SUBTRACT)
            {
                return left - right;
            }

            return base.VisitAdditiveExpr(context);
        }

        public override double VisitParenthesizedExpr(ExcelCalculatorParser.ParenthesizedExprContext context)
        {
            return Visit(context.expression());
        }

        private double WalkLeft(ExcelCalculatorParser.ExpressionContext context)
        {
            return Visit(context.GetRuleContext<ExcelCalculatorParser.ExpressionContext>(0));
        }

        private double WalkRight(ExcelCalculatorParser.ExpressionContext context)
        {
            return Visit(context.GetRuleContext<ExcelCalculatorParser.ExpressionContext>(1));
        }
    }
}
