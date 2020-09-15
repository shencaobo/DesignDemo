using System;
using System.Collections.Generic;
using System.Text;

namespace Demo
{
    class Target
    {
        public virtual void Request()
        {
            Console.WriteLine("普通请求！");
        }
    }

    /// <summary>
    /// 需要适配的类
    /// </summary>
    class Adaptee
    {
        public void SpecificRequest()
        {
            Console.WriteLine("特殊请求！");
        }
    }

    class Adapter : Target
    {
        private Adaptee adaptee = new Adaptee();
        public override void Request()
        {
            adaptee.SpecificRequest(); 
        }
    }
}
