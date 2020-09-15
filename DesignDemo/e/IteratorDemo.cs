using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace Demo
{
    //基本迭代器 IEnumerable 以及 IEumerator  foreach 就是基于这个的
    public abstract class Iterator
    {
        public abstract object First();
        public abstract object Next();
        //用于得到开始对象下一对象以及是否到结尾。
        public abstract bool IsDone();
        public abstract object CurrentItem();

    }

    public abstract class Aggregate
    {
        //创建迭代器、
        public abstract Iterator CreateIterator();

    }

    /// <summary>
    /// 顺序的迭代器，如果要改成倒序的，直接修改访问就可以
    /// </summary>
    public class ConcreteIterator : Iterator
    {
        //聚集对象
        private ConcreteAggregate aggregate;
        private int current = 0;

        public ConcreteIterator(ConcreteAggregate aggregate)
        {
            this.aggregate = aggregate;
        }


        public override object First()
        {
            return aggregate[0];
        }
        public override object CurrentItem()
        {
            return aggregate[current];
        }

        public override bool IsDone()
        {
            return current >= aggregate.Count ? true : false;
        }

        public override object Next()
        {
            object ret = null;
            current++;
            if (current < aggregate.Count)
            {
                ret = aggregate[current];
            }
            return ret;
        }

    }

    public class ConcreteAggregate : Aggregate
    {
        private List<object> items = new List<object>();
        public override Iterator CreateIterator()
        {
            return new ConcreteIterator(this);
        }

        public int Count
        {
            get { return items.Count; }
        }

        public object this[int index]
        {
            get { return items[index]; }
            set { items.Insert(index, value); }
        }


    }
}