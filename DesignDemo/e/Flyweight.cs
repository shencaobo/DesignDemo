using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace Demo
{
    abstract class Flyweight
    {
        public abstract void Operationg(int extrinsicstate);
    }

    class ConcreteFlyweight : Flyweight
    {
        public override void Operationg(int extrinsicstate)
        {
            Console.WriteLine("具体Flyweight:" + extrinsicstate);
        }
    }

    class UnsharedConcreteFlyweight : Flyweight
    {
        public override void Operationg(int extrinsicstate)
        {
            Console.WriteLine("不共享的具体Flyweight:" + extrinsicstate);
        }
    }

    class FlyweightFactory
    {
        private Hashtable flyweights = new Hashtable();

        public FlyweightFactory()
        {
            flyweights.Add("X", new ConcreteFlyweight());
            flyweights.Add("Y", new ConcreteFlyweight());
            flyweights.Add("Z", new ConcreteFlyweight());
        }

        public Flyweight GetFlyweight(string key)
        {
            return ((Flyweight)flyweights[key]);
        }
    }



    abstract class WebSite
    {
        public abstract void Use(WebSiteUser user);
    }

    class ConcreteWebSite : WebSite
    {
        private string name = "";
        public ConcreteWebSite(string name)
        {
            this.name = name;
        }
        public override void Use(WebSiteUser user)
        {
            Console.WriteLine("网站分类：" + name + "用户：" + user.name);
        }
    }

    class WebSiteFactory
    {
        private Hashtable flyweights = new Hashtable();
        //获得网站分类
        public WebSite GetWebSiteCategory(string key)
        {
            if (!flyweights.ContainsKey(key))
                flyweights.Add(key, new ConcreteWebSite(key));
            return ((WebSite)flyweights[key]);
        }
        //网站总数量
        public int GetWebSiteCount()
        {
            return flyweights.Count;
        }
    }



    public class WebSiteUser
    {
        public string name;
        public WebSiteUser(string name)
        {
            this.name = name;
        }
    }
}
