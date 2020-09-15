using System;
using System.Collections.Generic;
using System.Text;

namespace Demo
{
    class SingletonDemo
    {
        private static SingletonDemo instance;
        private SingletonDemo()
        {
        }

        public static SingletonDemo GetInstance()
        {
            if (instance == null)
            {
                instance = new SingletonDemo();
            }
            return instance;
        }
    }

    //懒汉式单例类
    class SingletonLockDemo
    {
        private static SingletonLockDemo instance;
        private static readonly object syncRoot = new object();

        private SingletonLockDemo()
        {
        }

        public static SingletonLockDemo GetInstance()
        {
            if (instance == null)
            {
                lock (syncRoot)
                {
                    if (instance == null)
                    {
                        instance = new SingletonLockDemo();
                    }

                }
            }
            return instance;
        }
    }


    //饿汉式单利类型
    public sealed class Singleton
    {
        private static readonly Singleton instance = new Singleton();
        private Singleton()
        { }

        public static Singleton GetSingleton()
        {
            return instance;
        }
    }
}
