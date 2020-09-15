using System;
using System.Collections.Generic;
using System.Text;

namespace Demo
{
    /// <summary>
    /// 代理接口
    /// </summary>
    public interface IGiveGift
    {
        void GiveMoney();
        void GiveFlower();

    }
    /// <summary>
    /// 代理类。 朋友，代 男士 送女生礼物。
    /// </summary>
    public class Friend : People, IGiveGift
    {
        Man man;
        public Friend(Woman me)
        {
            Console.WriteLine("I am friend");
            man = new Man(me);
            this.name = "friend";
        }

        /// <summary>
        /// 送花
        /// </summary>
        public void GiveFlower()
        {
            //用装饰类，再送花时， 讲一句话
            Decorator manTalk = new Talk(man, man.name + " say love");
            manTalk.Print();
            Console.WriteLine("----------------------\n");

            man.GiveFlower();
        }

        /// <summary>
        /// 送钱
        /// </summary>
        public void GiveMoney()
        {
            man.GiveMoney();
        }
    }
}
