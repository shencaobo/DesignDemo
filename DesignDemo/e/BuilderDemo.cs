using System;
using System.Collections.Generic;
using System.Text;

namespace Demo
{
    /// <summary>
    /// 建造人的指挥者
    /// </summary>
    class PersonDirector
    {
        private BuilderPeopleDemo bp;
        public PersonDirector(BuilderPeopleDemo bp)
        {
            this.bp = bp;
        }

        public void CreatePerson()
        {
            bp.BuildHead();
            bp.BuildBody();
            bp.BuildArm();
            bp.BuildLeg();
        }
    }

    /// <summary>
    /// 建造者模式，建造 人。
    /// </summary>
    abstract class BuilderPeopleDemo
    {
        protected People people;

        public BuilderPeopleDemo(People people)
        {
            this.people = people;
        }
        public abstract void BuildHead();
        public abstract void BuildBody();
        public abstract void BuildArm();
        public abstract void BuildLeg();
    }

    class ThinPeople : BuilderPeopleDemo
    {
        public ThinPeople(People people) : base(people)
        {
        }

        public override void BuildHead()
        {
            Console.WriteLine("头");
        }

        public override void BuildBody()
        {
            Console.WriteLine("瘦子");
        }

        public override void BuildArm()
        {
            Console.WriteLine("手");
        }

        public override void BuildLeg()
        {
            Console.WriteLine("脚");
        }
    }
    class FatPeople : BuilderPeopleDemo
    {
        public FatPeople(People people) : base(people)
        {
        }

        public override void BuildHead()
        {
            Console.WriteLine("头");
        }

        public override void BuildBody()
        {
            Console.WriteLine("胖子");
        }

        public override void BuildArm()
        {
            Console.WriteLine("手");
        }

        public override void BuildLeg()
        {
            Console.WriteLine("脚");
        }
    }

    /// <summary>
    /// 另一种 创建者模式，产品类。
    /// </summary>
    public class Product
    {
        List<string> parts = new List<string>();
        /// <summary>
        /// 产品部件
        /// </summary>
        /// <param name="part"></param>
        public void Add(string part)
        {
            parts.Add(part);
        }

        public void Show()
        {
            Console.WriteLine("\n 产品 创建 ----");
            foreach (string part in parts)
            {
                Console.WriteLine(part);
            }
        }
    }

    abstract class Builder
    {
        public abstract void BuildPartA();
        public abstract void BuildPartB();
        public abstract Product GetResult();
    }


}
