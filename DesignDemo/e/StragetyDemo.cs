using System;
using System.Collections.Generic;
using System.Text;

namespace Demo
{
    /// <summary>
    /// 策略模式，策略接口。
    /// </summary>
    public interface IStragety
    {
        void Think(string value);
    }

    /// <summary>
    /// 基础版本策略模式，在客户端处理。
    /// </summary>
    public class Stragety
    {
        private IStragety animal;
        public Stragety(IStragety a)
        {
            animal = a;
        }

        public void DoThink(string value)
        {
            animal.Think(value);
        }
    }
}
