using System;
using System.Collections.Generic;
using System.Text;

namespace Demo
{
    /// <summary>
    /// 装饰类，装饰动物。 为动物实现各种 功能
    /// </summary>
    public abstract class Decorator : Animal
    {
        private Animal animal;

        public Decorator(Animal a)
        {
            animal = a;
        }
        public override void Print()
        {
            if (animal != null)
            {
                animal.Print();
            }
        }

    }

    /// <summary>
    /// 走。
    /// </summary>
    public class Walk : Decorator
    {
        public Walk(Animal p) : base(p)
        {
        }
        public override void Print()
        {
            base.Print();
            AddWalk();
        }

        public void AddWalk()
        {
            Console.WriteLine("现在走路");
        }
    }


    /// <summary>
    /// 跑。
    /// </summary>
    public class Run : Decorator
    {
        public Run(Animal p) : base(p)
        {
        }
        public override void Print()
        {
            base.Print();
            AddRun();
        }

        public void AddRun()
        {
            Console.WriteLine("现在跑");
        }
    }

    /// <summary>
    /// 讲话。
    /// </summary>
    public class Talk : Decorator
    {
        public string talk;
        public Talk(Animal p,string say) : base(p)
        {
            talk = say;
        }
        public override void Print()
        {
            base.Print();
            AddTalk(talk);
        }

        public void AddTalk(string talk)
        {
            Console.WriteLine("现在讲话:"+ talk);
        }
    }
}
