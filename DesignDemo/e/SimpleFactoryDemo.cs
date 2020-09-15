using System;

namespace Demo
{
    /// <summary>
    /// 简单工厂
    /// </summary>
    public class SimpleFactory
    {
        public static Animal ChooseAnimal(string Type)
        {
            Animal animal = null;
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
            return animal;
        }
    }
}
