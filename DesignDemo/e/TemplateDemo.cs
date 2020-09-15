using System;
using System.Collections.Generic;
using System.Text;

namespace Demo
{
    /// <summary>
    /// 考卷类
    /// </summary>
    public class TestPaper
    {
        public void Question1()
        {
            Console.Write("1+1=?");
            Console.Write("答案:"+ Answer1());
        }
        public void Question2()
        {
            Console.Write("2+2=?");
            Console.Write("答案:" + Answer2());
        }
        public void Question3()
        {
            Console.Write("3+3=?");
            Console.Write("答案:" + Answer3());
        }
        protected virtual string Answer1()
        {
            return "";
        }
        protected virtual string Answer2()
        {
            return "";
        }
        protected virtual string Answer3()
        {
            return "";
        }
    }

    /// <summary>
    /// 模板A。
    /// </summary>
    public class PaperA : TestPaper
    {
        protected override string Answer1()
        {
            return "2";
        }
        protected override string Answer2()
        {
            return "3";
        }
        protected override string Answer3()
        {
            return "4";
        }
    }


    /// <summary>
    /// 模板抽象类
    /// </summary>
    abstract class AbstractClass
    {
        /// <summary>
        /// 抽象行为 放子类实现
        /// </summary>
        public abstract void Operation1();
        public abstract void Operation2();
        
        /// <summary>
        /// 模板方法，给出了逻辑骨架，都推迟到子类实现。
        /// </summary>
        public void TemplateMethod()
        {
            Operation1();
            Operation2();
            Console.Write("");
        }
    }

    class ClassA : AbstractClass
    {
        public override void Operation1()
        {
            Console.Write("A方法实现1");
        }
        public override void Operation2()
        {
            Console.Write("A方法实现2");
        }
    }


    class ClassB : AbstractClass
    {
        public override void Operation1()
        {
            Console.Write("B方法实现1");
        }
        public override void Operation2()
        {
            Console.Write("B方法实现2");
        }
    }



}
