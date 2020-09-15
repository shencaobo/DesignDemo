using System;
using System.Collections.Generic;
using System.Text;

namespace Demo
{
    abstract class Component
    {
        protected string name;
        public Component(string name)
        {
            this.name = name;
        }

        public abstract void Add(Component c);
        public abstract void Remove(Component c);
        public abstract void Display(int depth);
    }

    class Leaf : Component
    {
        public Leaf(string name) : base(name)
        { }

        //叶子 无需实现 add 与 remove
        public override void Add(Component c)
        {
            Console.WriteLine("Cannot add to a leaf");
        }
        public override void Remove(Component c)
        {
            Console.WriteLine("Cannot remove to a leaf");
        }
        //名称与级别
        public override void Display(int depth)
        {
            Console.WriteLine(new string('-', depth) + name);
        }

    }

    class Composite : Component
    {
        private List<Component> children = new List<Component>();
        public Composite(string name) : base(name)
        { }

        public override void Add(Component c)
        {
            children.Add(c);
        }
        public override void Remove(Component c)
        {
            children.Remove(c);
        }
        public override void Display(int depth)
        {
            Console.WriteLine(new string('-', depth) + name);
            foreach (Component com in children)
            {
                com.Display(depth + 2);
            }
        }


    }


}
