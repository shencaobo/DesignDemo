using System;
using System.Collections.Generic;
using System.Text;

namespace Demo
{
    //观察者模式
    /// <summary>
    /// 此处可以用接口
    /// </summary>
    interface IObserver
    {
        void Update();
    }


    //通知者
    abstract class Subject
    {
        //同事列表
        private IList<IObserver> ovservers = new List<IObserver>();

        /// <summary>
        /// 增加需要观察者的人
        /// </summary>
        /// <param name="man"></param>
        public void Attach(IObserver man)
        {
            ovservers.Add(man);
        }

        public void Detach(IObserver man)
        {
            ovservers.Add(man);
        }
        //通知
        public void Notify()
        {
            foreach (IObserver man in ovservers)
            {
                man.Update();
            }
        }
    }

    class ConcreteSubject : Subject
    {
        public string SubjectState { get; set; }
    }

    class ConcreteObserver : People, IObserver
    {
        private string observerState;
        private ConcreteSubject subject { get; set; }

        public ConcreteObserver(string name, ConcreteSubject subject)
        {
            this.name = name;
            this.subject = subject;
        }
        public void Update()
        {
            observerState = subject.SubjectState;
            Console.WriteLine("观察者{0}的新状态是{1}", name, observerState);
        }
    }
}
