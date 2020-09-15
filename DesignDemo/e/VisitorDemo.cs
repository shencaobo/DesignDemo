using System;
using System.Collections.Generic;
using System.Text;

namespace Demo
{
    abstract class Person : People
    {
        //接受
        public abstract void Accept(Action visitor);
    }

    /// <summary>
    /// 传this 双分派技术
    /// </summary>
    class ManPerson : Person
    {
        public override void Accept(Action visitor)
        {
            visitor.GetManConclusion(this);
        }
    }

    class WoManPerson : Person
    {
        public override void Accept(Action visitor)
        {
            visitor.GetWomanConclusion(this);
        }
    }
    abstract class Action
    {
        /// <summary>
        /// 得到男人结论或反应
        /// </summary>
        /// <param name="concreteElementA"></param>
        public abstract void GetManConclusion(ManPerson concreteElementA);

        public abstract void GetWomanConclusion(WoManPerson concreteElementB);
    }

    class Success : Action
    {
        public override void GetManConclusion(ManPerson concreteElementA)
        {
            Console.WriteLine("{0},{1}成功", concreteElementA.GetType().Name, this.GetType().Name);
        }

        public override void GetWomanConclusion(WoManPerson concreteElementB)
        {
            Console.WriteLine("{0},{1}成功", concreteElementB.GetType().Name, this.GetType().Name);
        }
    }


    class Failing : Action
    {
        public override void GetManConclusion(ManPerson concreteElementA)
        {
            Console.WriteLine("{0},{1}失败", concreteElementA.GetType().Name, this.GetType().Name);
        }

        public override void GetWomanConclusion(WoManPerson concreteElementB)
        {
            Console.WriteLine("{0},{1}失败", concreteElementB.GetType().Name, this.GetType().Name);
        }
    }


    class ObjectStructure
    {
        private IList<Person> elements = new List<Person>();

        //增加
        public void Attach(Person element)
        {
            elements.Add(element);
        }

        //移除
        public void Detach(Person element)
        {
            elements.Remove(element);
        }

        //查看显示
        public void Display(Action visitor)
        {
            foreach (Person e in elements)
            {
                e.Accept(visitor);
            }
        }
    }





    #region //访问者模式正统代码
    /// <summary>
    /// 相当于 成功失败的状态
    /// </summary>
    abstract class Visitor
    {
        public abstract void VisitConcreteElementA(ConcreteElementA concreteElementA);
        public abstract void VisitConcreteElementB(ConcreteElementB concreteElementB);
    }
    class ConcreteVisitor1 : Visitor
    {
        public override void VisitConcreteElementA(ConcreteElementA concreteElementA)
        {
            Console.WriteLine("{0},{1}访问", concreteElementA.GetType().Name, this.GetType().Name);
        }

        public override void VisitConcreteElementB(ConcreteElementB concreteElementB)
        {
            Console.WriteLine("{0},{1}成功", concreteElementB.GetType().Name, this.GetType().Name);
        }
    }
    class ConcreteVisitor2 : Visitor
    {
        public override void VisitConcreteElementA(ConcreteElementA concreteElementA)
        {
            Console.WriteLine("{0},{1}访问", concreteElementA.GetType().Name, this.GetType().Name);
        }

        public override void VisitConcreteElementB(ConcreteElementB concreteElementB)
        {
            Console.WriteLine("{0},{1}成功", concreteElementB.GetType().Name, this.GetType().Name);
        }
    }


    abstract class Element
    {

        public abstract void Accept(Visitor visitor);
    }

    class ConcreteElementA : Element
    {
        public override void Accept(Visitor visitor)
        {
            visitor.VisitConcreteElementA(this);
        }
        public void OperationA()
        { }
    }

    class ConcreteElementB : Element
    {
        public override void Accept(Visitor visitor)
        {
            visitor.VisitConcreteElementB(this);
        }
        public void OperationB()
        { }
    }


    class ObjectStructureVisitor
    {
        private IList<Element> elements = new List<Element>();

        //增加
        public void Attach(Element element)
        {
            elements.Add(element);
        }

        //移除
        public void Detach(Element element)
        {
            elements.Remove(element);
        }

        //查看显示
        public void Accept(Visitor visitor)
        {
            foreach (Element e in elements)
            {
                e.Accept(visitor);
            }
        }
    }


    #endregion
}
