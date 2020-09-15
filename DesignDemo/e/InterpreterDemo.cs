using System;
using System.Collections.Generic;
using System.Text;

namespace Demo
{
    abstract class AbstractExpression
    {
        public abstract void Interpret(Context context);
    }

    /// <summary>
    /// 终结符表达式，实现与文法中的终结符相关联的解释操作。
    /// </summary>
    class TerminalExpression : AbstractExpression
    {
        public override void Interpret(Context context)
        {
            Console.WriteLine("终端解释器");
        }
    }

    /// <summary>
    /// 非终结表达式，为文法中的非终结符实现解释操作。对文法中的每一条规则R1,R2。。。Rn都需要一个具体的非终结符表达式。
    /// </summary>
    class NoterminalExpression : AbstractExpression
    {
        public override void Interpret(Context context)
        {
            Console.WriteLine("非终端解释器");
        }
    }

    class Context
    {
        public string input { get; set; }
        public string output { get; set; }


    }


}
