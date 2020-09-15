using System;
using System.Collections.Generic;
using System.Text;

namespace Demo
{
    //委托！
    /// <summary>
    /// 通知者接口
    /// </summary>
    interface ISubject
    {
        void Notify();
        string SubjectState { get; set; }
    }

    class GameObserver : People
    {
        private ISubject subject { get; set; }

        public GameObserver(string name, ISubject subject)
        {
            this.name = name;
            this.subject = subject;
        }
        public void CloseGame()
        {
            Console.WriteLine("观察者{0}的新状态是{1}关闭游戏", name, subject.SubjectState);
        }
    }

    class MovieObserver : People
    {
        private ISubject subject { get; set; }

        public MovieObserver(string name, ISubject subject)
        {
            this.name = name;
            this.subject = subject;
        }
        public void CloseMovie()
        {
            Console.WriteLine("观察者{0}的新状态是{1}关闭电影", name, subject.SubjectState);
        }
    }

    delegate void EventHandeler();

    class Boss : ISubject
    {
        public event EventHandeler Update;
        private string action;
        public void Notify()
        {
            Update();
        }
        public string SubjectState
        {
            get { return action; }
            set { action = value; }
        }
    }
}
