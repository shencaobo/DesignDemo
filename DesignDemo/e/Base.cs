using System;
using System.Collections.Generic;
using System.Text;

namespace Demo
{
    /// <summary>
    /// 抽象类   以动物为基础
    /// </summary>
    public abstract class Animal
    {
        public abstract void Print();
    }


    /// <summary>
    /// 实现人   装饰者模式中的具体类型。 工厂模式的筛选。
    /// </summary>
    public class People : Animal, IStragety
    {
        public string name { get; set; }
        public People()
        {
            name = "people";
            Console.WriteLine("I am people");
        }

        public override void Print()
        {
            Console.WriteLine("people");
        }

        public void Think(string value)
        {
            Console.WriteLine("people:" + value);
        }


    }

    /// <summary>
    /// 实现狗   装饰者模式中的具体类型。
    /// </summary>
    public class Dog : Animal, IStragety
    {
        public Dog()
        {
            Console.WriteLine("I am Dog");
        }
        public override void Print()
        {
            Console.WriteLine("dog");
        }

        public void Think(string value)
        {
            Console.WriteLine("dog:" + value);
        }
    }

    /// <summary>
    /// 实现 男士，代理模式，男士 通过 朋友  向 心仪的女士 送东西
    /// </summary>
    public class Man : People, IGiveGift
    {
        Woman woman;
        public Man(Woman wo)
        {
            Console.WriteLine("I am man");
            this.name = "man";
            woman = wo;
        }
        public void GiveFlower()
        {
            Console.WriteLine(name + ":give a Flower");
        }

        public void GiveMoney()
        {
            Console.WriteLine(name + ":give a Money");
        }
    }

    /// <summary>
    /// 女士
    /// </summary>
    public class Woman : People
    {
        public Woman()
        {
            Console.WriteLine("I am woman");
            this.name = "woman";
        }
    }

}
