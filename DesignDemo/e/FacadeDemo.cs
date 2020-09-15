using System;
using System.Collections.Generic;
using System.Text;

namespace Demo
{
    class FacadeDemo
    {
        SystemOne one;
        SystemTwo two;
        SystemThree three;

        public FacadeDemo()
        {
            one = new SystemOne();
            two = new SystemTwo();
            three = new SystemThree();
        }
        /// <summary>
        /// 包装方法
        /// </summary>
        public void MethodA()
        {
            Console.WriteLine("\n 方法组A（）----");
            one.MethodOne();
            two.MethodTwo();
        }
        public void MethodB()
        {
            Console.WriteLine("\n 方法组B（）----");
            one.MethodOne();
            three.MethodThree();
        }
    }

    class SystemOne
    {
        public void MethodOne()
        {
            Console.WriteLine("子系统方法一");
        }
    }
    class SystemTwo
    {
        public void MethodTwo()
        {
            Console.WriteLine("子系统方法二");
        }
    }
    class SystemThree
    {
        public void MethodThree()
        {
            Console.WriteLine("子系统方法三");
        }
    }
}
