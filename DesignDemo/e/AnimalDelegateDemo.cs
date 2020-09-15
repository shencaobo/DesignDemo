
using System;
using System.Collections.Generic;
using System.Text;

namespace Demo
{

    public class CatShoutEventArgs : EventArgs
    {
        public string name { get; set; }
    }
    class Cat
    {
        private string name;
        public Cat(string name)
        {
            this.name = name;
        }

        public delegate void CatShoutEventHandler(object sender, CatShoutEventArgs args);

        public event CatShoutEventHandler CatShout;


        public void Shout()
        {
            Console.WriteLine("喵，我是{0}", name);
            if (CatShout != null)
            {
                CatShoutEventArgs e = new CatShoutEventArgs();
                e.name = this.name;
                CatShout(this, e);
            }
        }
    }

    class Mouse
    {
        private string name;
        public Mouse(string name)
        {
            this.name = name;
        }
        public void Run(object sender,CatShoutEventArgs args)
        {
            Console.WriteLine("老猫{0}来了，{1}快跑！",args.name, name);
        }

    }

}
