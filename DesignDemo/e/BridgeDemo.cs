using System;
using System.Collections.Generic;
using System.Text;

namespace Demo
{
    /// <summary>
    /// 相当于手机软件的抽象类
    /// </summary>
    public abstract class Implementor
    {
        public abstract void Operation();
    }

    /// <summary>
    /// 相当于手机软件A
    /// </summary>
    public class ConcreteImplmentorA : Implementor
    {
        public override void Operation()
        {
            Console.WriteLine("具体实现A的方法执行:手机软件A");
        }
    }

    /// <summary>
    /// 相当于手机软件B
    /// </summary>
    public class ConcreteImplmentorB : Implementor
    {
        public override void Operation()
        {
            Console.WriteLine("具体实现B的方法执行:手机软件B");
        }
    }


    public class Abstraction
    {
        protected Implementor implementor;
        public void SetImplementor(Implementor implementor)
        {
            this.implementor = implementor;
        }

        public virtual void Operation()
        {
            implementor.Operation();
        }
    }

    public class RefinedAbstraction : Abstraction
    {
        public override void Operation()
        {
            implementor.Operation();
        }
    }
}
