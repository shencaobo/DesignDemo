using System;
using System.Collections.Generic;
using System.Text;

namespace Demo
{
    /// <summary>
    /// 枚举类
    /// </summary>
    enum AnimalType
    {
        people,
        dog
    }

    /// <summary>
    /// 简单工厂策略模式结合
    /// </summary>
    public class SimpleFactoryAndStragetyDemo
    {
        private Animal animal;
        public SimpleFactoryAndStragetyDemo(string Type)
        {
            AnimalType type = (AnimalType)Enum.Parse(typeof(AnimalType), Type);
            switch (type)
            {
                case AnimalType.people:
                    animal = new People();
                    break;
                case AnimalType.dog:
                    animal = new Dog();
                    break;
                default:
                    animal = new People();
                    break;
            }
        }

        public void Print()
        {
            animal.Print();
        }

        /// <summary>
        /// 策略 附加 装饰
        /// </summary>
        public void DoWalk()
        {
            Decorator Walk = new Walk(animal);
            Walk.Print();
            Console.WriteLine("----------------------\n");
        }

    }
}
