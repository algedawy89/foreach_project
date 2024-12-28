using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Antlr4.Runtime;
using Antlr4.Runtime.Misc;
using System.IO;
using System.Linq;
using System.Text;

namespace Graammar
{


    class Varib
    {
        public string name { set; get; }
        public object value { set; get; }

        public string type { set; get; }



    }

    public class GrammarVisitor : GrammarBaseVisitor<object>
    {
        private readonly Dictionary<string, object> _variables = new Dictionary<string, object>(); // متغيرات
        //private readonly Action<string> _output; // وظيفة الطباعة
        RichTextBox _output;
        RichTextBox _input;
        Form1 _form;
        public GrammarVisitor(RichTextBox r, RichTextBox input, Form1 f)
        {
            _output = r;
            _input = input;
            _form = f;
        }
        Varib v = new Varib();

        bool isvalid(string type, object val)
        {

            switch (type)
            {
                case "int": return val is int;
                case "string": return val is string;
                case "bool": return val is bool;

            }

            return false;
        }


        string getType(object val)
        {

            if (val is int)
            {
                return "int";
            }
            else if (val is string)
            {
                return "string";
            }
            else if (val is bool)
            {

                return "bool";

            }
            else
            {
                return null;
            }



            return null;
        }


        object visitArrayliteral(object o, string type)
        {


            if (type == "string")
            {

                return o as List<string>;
            }

            else if (type == "int")
            {


            }
            else if (type == "bool")
            {


            }

            return null;
        }


        // Visit variable declarations
        public override object VisitVariableDeclaration([NotNull] GrammarParser.VariableDeclarationContext context)
        {


            var typeContext = context.type();

            try
            {
                if (typeContext == null)
                    throw new Exception("Variable type is missing or not recognized.");


                string type = typeContext.GetText();
                string name = context.IDENTIFIER().GetText();


                if (Tools.KEYWORDS.Contains(name))
                {
                    Tools.HighlightErrorSyntax(_input, name, "you can't use key word to identfier");

                    return null;
                }
                else
                {


                }

                if (_variables.ContainsKey(name))
                    throw new Exception($"Variable '{name}' is already declared.");

                // Handle array declarations
                if (context.arrayLiteral() != null || context.GetText().Contains("[]"))
                {


                    _variables[name] = new List<object>();
                    if (context.arrayLiteral() != null)
                        _variables[name] = VisitArrayLiteral(context.arrayLiteral());







                }
                else
                {
                    // Handle scalar declarations
                    object value = context.expression() != null ? Visit(context.expression()) : GetDefaultValue(type);
                    if (isvalid(type, value))
                        _variables[name] = value;
                    else
                    {
                        throw new Exception($"you cant assign {getType(value)} to {type}");
                    }
                }












            }
            catch (Exception e)
            {
                Tools.show(_form, "Error", e.Message);

                //MessageBox.Show(e.Message);
            }



            return null;
        }


        // Visit array literal
        public override object VisitArrayLiteral([NotNull] GrammarParser.ArrayLiteralContext context)
        {
            var values = new List<object>();
            foreach (var expr in context.expression())
            {
                values.Add(Visit(expr));
            }
            return values;
        }



        public override object VisitAssignment([NotNull] GrammarParser.AssignmentContext context)
        {

            try
            {
                string name = context.IDENTIFIER().GetText();


                if (!_variables.ContainsKey(name))
                    throw new Exception($"Variable '{name}' is not declared.");

                if (context.expression() != null)
                {


                    if (context.expression(0) == null && context.expression(1) != null)
                    {

                        var value = Visit(context.expression(1));


                        if (context.GetText().Contains("[") && context.GetText().Contains("]"))
                        {
                            // Handle array index assignment
                            int index = Convert.ToInt32(Visit(context.expression(0)));
                            var array = _variables[name] as List<object>;
                            if (array == null || index < 0 || index >= array.Count)
                                throw new Exception($"Invalid array access for variable '{name}'.");

                            array[index] = value;
                        }
                        else
                        {
                            _variables[name] = value;
                        }


                    }
                    else if (context.expression(0) != null && context.expression(1) == null)
                    {
                        var value = Visit(context.expression(0));

                        if (context.GetText().Contains("[") && context.GetText().Contains("]"))
                        {
                            // Handle array index assignment
                            int index = Convert.ToInt32(Visit(context.expression(0)));
                            var array = _variables[name] as List<object>;
                            if (array == null || index < 0 || index >= array.Count)
                                throw new Exception($"Invalid array access for variable '{name}'.");

                            array[index] = value;
                        }
                        else
                        {
                            // Scalar assignment
                            _variables[name] = value;
                        }



                    }




                }
            }




            catch (Exception ex)
            {
                Tools.show(_form, "Error", ex.Message);
                //MessageBox.Show(ex.Message);
            }



            return null;
        }

        // Visit expressions


        public override object VisitCondition([NotNull] GrammarParser.ConditionContext context)
        {

            try
            {
                // ابدأ بتقييم أول شرط بسيط
                bool result = Convert.ToBoolean(VisitSingleCondition(context.singleCondition(0)));

                // قم بمعالجة الشروط الإضافية المتصلة بـ LOGIC (إن وجدت)
                for (int i = 0; i < context.LOGIC().Length; i++)
                {
                    string logicOp = context.LOGIC(i).GetText(); // العملية المنطقية (and / or)
                    bool nextCondition = Convert.ToBoolean(VisitSingleCondition(context.singleCondition(i + 1))); // الشرط التالي

                    // طبق العملية المنطقية
                    switch (logicOp)
                    {
                        case "and":
                        case "&&":
                            result = result && nextCondition;
                            break;
                        case "or":
                        case "||":
                            result = result || nextCondition;
                            break;
                        default:
                            throw new Exception($"Unknown logical operator: {logicOp}");
                    }
                }
                return result;

            }
            catch (Exception ex)
            {
                Tools.show(_form, "Error", ex.Message);

            }

            return false;
        }

        private bool VisitSingleCondition(GrammarParser.SingleConditionContext context)
        {
            try
            {
                var left = Visit(context.expression(0)); // تقييم التعبير الأول
                var right = Visit(context.expression(1)); // تقييم التعبير الثاني
                string comparisonOp = context.COMPARISON_OP().GetText(); // الحصول على عامل المقارنة

                // تحقق من النوع والمقارنة
                switch (comparisonOp)
                {
                    case "==":
                        return Equals(left, right);
                    case "!=":
                        return !Equals(left, right);
                    case ">":
                        return Convert.ToDouble(left) > Convert.ToDouble(right);
                    case "<":
                        return Convert.ToDouble(left) < Convert.ToDouble(right);
                    case ">=":
                        return Convert.ToDouble(left) >= Convert.ToDouble(right);
                    case "<=":
                        return Convert.ToDouble(left) <= Convert.ToDouble(right);
                    default:
                        throw new Exception($"Unknown comparison operator: {comparisonOp}");
                }
            }
            catch (Exception ex)
            {
                Tools.show(_form, "Error", ex.Message);

            }
            return false;
        }

        //public override object VisitIfStatement([NotNull] GrammarParser.IfStatementContext context)
        //{
        //    try
        //    {
        //        // تقييم أول شرط
        //        bool conditionResult = Convert.ToBoolean(Visit(context.condition(0)));

        //        // معالجة الشروط الإضافية المترابطة بـ LOGIC
        //        for (int i = 0; i < context.LOGIC().Length; i++)
        //        {
        //            string logicOp = context.LOGIC(i).GetText(); // الحصول على العامل المنطقي (and / or)
        //            bool nextCondition = Convert.ToBoolean(Visit(context.condition(i + 1))); // تقييم الشرط التالي

        //            // تطبيق العامل المنطقي
        //            switch (logicOp)
        //            {
        //                case "and":
        //                case "&&":
        //                    conditionResult = conditionResult && nextCondition;
        //                    break;
        //                case "or":
        //                case "||":
        //                    conditionResult = conditionResult || nextCondition;
        //                    break;
        //                default:
        //                    throw new Exception($"Unknown logical operator: {logicOp}");
        //            }
        //        }

        //        // إذا كانت النتيجة النهائية للشرط صحيحة، نفّذ الجمل
        //        if (conditionResult)
        //        {
        //            foreach (var statement in context.statement())
        //            {
        //                Visit(statement);
        //            }
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        Tools.show(_form, "Error", ex.Message);
        //    }

        //    return null;
        //}


        public override object VisitDoWhileStatement([NotNull] GrammarParser.DoWhileStatementContext context)
        {
            try
            {
                // تنفيذ الجمل داخل الكتلة على الأقل مرة واحدة
                do
                {
                    foreach (var statement in context.statement())
                    {
                        Visit(statement); // زيارة كل جملة
                    }
                } while (Convert.ToBoolean(Visit(context.condition()))); // تقييم الشرط
            }
            catch (Exception ex)
            {
                Tools.show(_form, "Error", ex.Message); // عرض رسالة خطأ عند حدوث استثناء
            }

            return null;
        }



        public override object VisitIfStatement([NotNull] GrammarParser.IfStatementContext context)
        {
            try
            {
                int statementIndex = 0;

                // 1. تقييم الشرط الرئيسي
                bool conditionResult = Convert.ToBoolean(Visit(context.condition(0)));

                if (conditionResult)
                {
                    // تنفيذ الجمل داخل كتلة if
                    for (int i = 0; i < context.statement().Length; i++)
                    {
                        Visit(context.statement(statementIndex));
                        statementIndex++;
                    }
                    return null; // التوقف عند تنفيذ كتلة if
                }

                // 2. معالجة كتل else if
                for (int i = 0; i < context.ELSE_IF().Length; i++)
                {
                    bool elseIfConditionResult = Convert.ToBoolean(Visit(context.condition(i + 1)));

                    if (elseIfConditionResult)
                    {
                        for (int j = 0; j < context.statement().Length; j++)
                        {
                            Visit(context.statement(statementIndex));
                            statementIndex++;
                        }
                        return null; // التوقف عند تنفيذ كتلة else if
                    }
                }

                // 3. معالجة كتلة else
                if (context.ELSE() != null)
                {
                    for (int i = statementIndex; i < context.statement().Length; i++)
                    {
                        Visit(context.statement(statementIndex));
                        statementIndex++;
                    }
                }
            }
            catch (Exception ex)
            {
                Tools.show(_form, "Error", ex.Message);
            }

            return null;
        }


        public override object VisitExpression([NotNull] GrammarParser.ExpressionContext context)
        {

            try
            {

                if (context.INTEGER() != null)
                    return int.Parse(context.INTEGER().GetText());

                if (context.STRING() != null)
                    return context.STRING().GetText().Trim('"');

                if (context.IDENTIFIER() != null)
                {
                    string name = context.IDENTIFIER().GetText();
                    if (!_variables.ContainsKey(name))
                        throw new Exception($"Variable '{name}' is not declared.");

                    if (context.GetText().Contains("["))
                    {
                        // Array element access
                        int index = Convert.ToInt32(Visit(context.expression(0)));
                        var array = _variables[name] as List<object>;
                        if (array == null || index < 0 || index >= array.Count)
                            throw new Exception($"Invalid array access for variable '{name}'.");

                        return array[index];
                    }
                   
                    return _variables[name];
                }

                if (context.ChildCount == 3)
                {
                    // Handle binary operations
                    var left = Convert.ToInt32(Visit(context.GetChild(0)));
                    var right = Convert.ToInt32(Visit(context.GetChild(2)));
                    string op = context.GetChild(1).GetText();

                    switch (op)
                    {
                        case "+":
                            return left + right;
                        case "-":
                            return left - right;
                        case "*":
                            return left * right;
                        case "/":
                            {
                                if (right == 0)
                                {
                                    throw new Exception("you cant divide by 0");
                                    return null;

                                }
                                else return left / right;
                            }


                        default:
                            throw new Exception($"Unknown type: {op}");
                    }
                }

                if (context.ChildCount == 1)
                {
                    return Visit(context.GetChild(0));
                }

                throw new Exception("Invalid expression.");
            }
            catch (Exception ex)
            {
                Tools.show(_form, "Error", ex.Message);

                //MessageBox.Show(ex.Message);
            }
            return null;
        }

        // Visit print statements
        public override object VisitPrintStatement([NotNull] GrammarParser.PrintStatementContext context)
        {
            try
            {
                if (context.expression() != null)
                {
                    // تقييم التعبير

                    foreach (var d in context.expression())
                    {

                        var value = Visit(d);
                        if (value != null)
                            _output.AppendText(value.ToString());

                    }

                    // إضافة القيمة إلى _output

                }
                else
                {
                    throw new Exception("the Expresion is not valid");
                }
            }
            catch (Exception e)
            {
                Tools.show(_form, "Error", e.Message);

            }
            return null;
        }



        public override object VisitPrintLineStatement(GrammarParser.PrintLineStatementContext context)
        {


            try
            {
                if (context.expression() != null)
                {
                    foreach (var d in context.expression())
                    {

                        var value = Visit(d);

                        if (value != null)
                            _output.AppendText(value.ToString());

                    }
                    _output.AppendText(Environment.NewLine);



                }
                else
                {
                    _output.AppendText(Environment.NewLine);

                }
            }
            catch (Exception e)
            {
                Tools.show(_form, "Error", e.Message);

            }
            return null;
        }


        // Visit foreach statements


        public override object VisitForeachStatement([NotNull] GrammarParser.ForeachStatementContext context)
        {

            try
            {

                string type = context.type().GetText();
                string variable = context.IDENTIFIER(0).GetText();
                string arrayName = context.IDENTIFIER(1).GetText();

                if (variable == arrayName)
                {
                    throw new Exception($"Variable '{variable}' you can't pass like {arrayName} ");
                }

                if (_variables.ContainsKey(variable))
                {
                    variable = variable + variable + "blockkkk";
                }

                // تحقق أن المصفوفة موجودة وصحيحة
                if (!_variables.ContainsKey(arrayName) || !(_variables[arrayName] is List<object> array))
                    throw new Exception($"Variable '{arrayName}' is not declared or is not an array.");

                // تحقق من وجود الجمل داخل التكرار
                if (context.statement() == null || context.statement().Length == 0)
                    throw new Exception($"No statements found inside foreach block.");

                // التكرار على عناصر المصفوفة
                foreach (var item in array)
                {
                    _variables[variable] = item; // تحديث المتغير بالقيمة الحالية

                    // زيارة جميع الجمل داخل التكرار
                    foreach (var statement in context.statement())
                    {
                        Visit(statement);
                    }
                }
                _variables.Remove(variable);



            }

            catch (Exception ex)
            {

                //MessageBox.Show(ex.Message);
                Tools.show(_form, "Error", ex.Message);

            }

            return null;
        }



        // Helper: Get default value based on type
        private static object GetDefaultValue(string type)
        {

            try
            {
                switch (type)
                {
                    case "int":
                        return 0;
                    case "string":
                        return "";
                    case "bool":
                        return false;
                    default:
                        throw new Exception($"Unknown type: {type}");
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
            return null;
        }

    }
}
