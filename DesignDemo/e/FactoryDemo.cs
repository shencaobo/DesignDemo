using System;

namespace Demo
{
    /// <summary>
    /// 工厂
    /// </summary>
    interface IFactory
    {
        Animal CreateAnimal();
    }
        
    /// <summary>
    /// 人  工厂类
    /// </summary>
    public class PeopleFactory: IFactory
    {
        public Animal CreateAnimal()
        {
            return new People();
        }
    }

    /// <summary>
    /// 狗 工厂类
    /// </summary>
    public class DogFactory : IFactory
    {
        public Animal CreateAnimal()
        {
            return new Dog();
        }
    }
}
