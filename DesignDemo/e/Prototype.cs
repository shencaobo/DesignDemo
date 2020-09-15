using System;
using System.Collections.Generic;
using System.Text;

namespace Demo
{

    /// <summary>
    /// 克隆人 原型继承人。 含克隆方法、
    /// </summary>
    public abstract class PrototypePeople : People
    {
        public abstract PrototypePeople clone();
    }

    /// <summary>
    /// 具体克隆人类，可以复制、
    /// </summary>
    public class ClonePeople : PrototypePeople
    {
        public ClonePeople()
        {
            Console.WriteLine("I am clonePeople");
            name = "clonePeople";
        }

        public override PrototypePeople clone()
        {
            return (PrototypePeople)this.MemberwiseClone();
        }
    }

    /// <summary>
    /// 使用c#自带的 克隆接口
    /// </summary>
    public class _ClonePeople : People, ICloneable
    {
        private Info peopleInfo;
        public _ClonePeople()
        {
            Console.WriteLine("I am _clonePeople");
            this.name = "_clonePeople";
            peopleInfo = new Info();
        }

        public void SetPeopleInfo(string name, string sex, string age)
        {
            peopleInfo.Name = name;
            peopleInfo.Sex = sex;
            peopleInfo.Age = age;
        }

        public void GetPeopleInfo()
        {
            Console.WriteLine(peopleInfo.Name + " - " + peopleInfo.Sex + " - " + peopleInfo.Age + "\n");
        }
        public object Clone()
        {
            return MemberwiseClone();
        }
    }


    /// <summary>
    /// 浅复制信息类。
    /// </summary>
    public class Info
    {
        public string Name { get; set; }
        public string Sex { get; set; }
        public string Age { get; set; }
    }

    /// <summary>
    /// 深复制
    /// </summary>
    public class InfoDeep : ICloneable
    {
        public string Name { get; set; }
        public string Sex { get; set; }
        public string Age { get; set; }

        public object Clone()
        {
            return MemberwiseClone();
        }
    }


    /// <summary>
    /// 使用c#自带的 克隆接口
    /// </summary>
    public class _ClonePeopleDeep : People, ICloneable
    {
        private InfoDeep peopleDeepInfo;
        public _ClonePeopleDeep()
        {
            Console.WriteLine("I am _clonePeople");
            this.name = "_clonePeople";
            peopleDeepInfo = new InfoDeep();
        }

        private _ClonePeopleDeep(InfoDeep DeepInfo)
        {
            peopleDeepInfo = (InfoDeep)DeepInfo.Clone();
        }

        public void SetPeopleInfo(string name, string sex, string age)
        {
            peopleDeepInfo.Name = name;
            peopleDeepInfo.Sex = sex;
            peopleDeepInfo.Age = age;
        }
        public void GetPeopleInfoDeep()
        {
            Console.WriteLine(peopleDeepInfo.Name + " - " + peopleDeepInfo.Sex + " - " + peopleDeepInfo.Age + "\n");
        }
        public object Clone()
        {
            _ClonePeopleDeep _clonePeople_new = new _ClonePeopleDeep(peopleDeepInfo);
            _clonePeople_new.name = "_clonePeopleDeep";
            //return MemberwiseClone();
            return _clonePeople_new;
        }
    }

}
