using System;
using System.Collections.Generic;
using System.Text;

namespace Demo
{
    abstract class Mediator
    {
        public abstract void Send(string message, Colleague colleague);
    }

    class ConcreteMediator : Mediator
    {
        public ConcreteColleague1 colleague1 { get; set; }
        public ConcreteColleague2 colleague2 { get; set; }


        public override void Send(string message, Colleague colleague)
        {
            if (colleague == colleague1)
            {
                colleague2.Notify(message);
            }
            else
            {
                colleague1.Notify(message);
            }
        }
    }

    abstract class Colleague
    {
        public Mediator mediator;
        public Colleague(Mediator mediator)
        {
            this.mediator = mediator;
        }
    }

    class ConcreteColleague1 : Colleague
    {
        public ConcreteColleague1(Mediator mediator)
            : base(mediator)
        {

        }
        public void Send(string message)
        {
            mediator.Send(message, this);
        }
        public void Notify(string message)
        {
            Console.WriteLine("同事1得到信息：" + message);
        }
    }

    class ConcreteColleague2 : Colleague
    {
        public ConcreteColleague2(Mediator mediator)
            : base(mediator)
        {
        }

        public void Send(string message)
        {
            mediator.Send(message, this);
        }

        public void Notify(string message)
        {
            Console.WriteLine("同事2得到信息：" + message);
        }
    }

}
