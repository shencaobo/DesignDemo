using System;
using System.Collections.Generic;
using System.Text;

namespace Demo
{
    public class Work
    {
        private StateDemo current;
        public Work()
        {
            //初始化上午工作
            this.current = new ForenoonState();
        }
        private double hour;
        public double Hour
        {
            get { return hour; }
            set { hour = value;}
        }
        private bool finish = false;
        public bool TaskFinished
        {
            get { return finish; }
            set { finish = value; }
        }

        public void SetState(StateDemo s)
        {
            current = s;
        }

        public void WriteProgram()
        {
            current.WtiteProGram(this);
        }
    }
   
    /// <summary>
    /// 抽象工作状态
    /// </summary>
    public abstract class StateDemo
    {
        public abstract void WtiteProGram(Work work);
    }

    /// <summary>
    /// 上午工作
    /// </summary>
    public class ForenoonState : StateDemo
    {
        public override void WtiteProGram(Work w)
        {
            if (w.Hour < 12)
            {
                Console.WriteLine("当前时间：{0}点 上午工作，精神百倍", w.Hour);
            }
            else
            {
                w.SetState(new NoonState());
                w.WriteProgram();
            }
        }
    }
    class NoonState : StateDemo
    {
        public override void WtiteProGram(Work w)
        {
            if (w.Hour < 13)
            {
                Console.WriteLine("当前时间：{0}点 饿了，午饭：犯困，午休。", w.Hour);
            }
            else
            {
                w.SetState(new AfternoonState());
                w.WriteProgram();
            }
        }
    }
    class AfternoonState : StateDemo
    {
        public override void WtiteProGram(Work w)
        {
            if (w.Hour < 17)
            {
                Console.WriteLine("当前时间：{0}点 下午不错。", w.Hour);
            }
            else
            {
                w.SetState(new EveningState());
                w.WriteProgram();
            }
        }
    }

    class EveningState : StateDemo
    {
        public override void WtiteProGram(Work w)
        {
            if (w.TaskFinished)
            {
                w.SetState(new RestState());
                w.WriteProgram();
            }
            else
            {
                if (w.Hour < 21)
                {
                    Console.WriteLine("当前时间：{0}点 加班。", w.Hour);
                }
                else
                {
                    w.SetState(new SleepingState());
                    w.WriteProgram();
                }
            }
        
        }
    }

    class SleepingState : StateDemo
    {
        public override void WtiteProGram(Work w)
        {
            Console.WriteLine("当前时间：{0}点 困睡觉。", w.Hour);    
        }
    }

    class RestState : StateDemo
    {
        public override void WtiteProGram(Work w)
        {
            Console.WriteLine("当前时间：{0}点 下班回家。", w.Hour);
        }
    }
}
