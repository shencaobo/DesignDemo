
using System;
using System.Collections.Generic;
using System.Text;

namespace Demo
{
    abstract class Manager
    {
        protected Manager superior;

        protected string name;

        public Manager(string name)
        {
            this.name = name;
        }
        //继承者设置。
        public void SetSuccessor(Manager superior)
        {
            this.superior = superior;
        }

        //处理请求。
        public abstract void RequestApplications(Request request);

    }

    //经理权限
    class CommonManager : Manager
    {
        public CommonManager(string name) : base(name)
        {

        }
        public override void RequestApplications(Request request)
        {
            if (request.RequestType == "请假" && request.Number <= 2)
            {
                Console.WriteLine("{0}:{1}数量{2}被批准", name, request.RequestContent,request.Number);
            }
            else if (superior != null)
            {
                superior.RequestApplications(request);
            }
        }
    }

    //总监权限
    class Majordomo : Manager
    {
        public Majordomo(string name) : base(name)
        {

        }
        public override void RequestApplications(Request request)
        {
            if (request.RequestType == "请假" && request.Number <= 5)
            {
                Console.WriteLine("{0}:{1}数量{2}被批准", name, request.RequestContent, request.Number);
            }
            else if (superior != null)
            {
                superior.RequestApplications(request);
            }
        }
    }


    //总经理权限
    class GeneralManager : Manager
    {
        public GeneralManager(string name) : base(name)
        {

        }
        public override void RequestApplications(Request request)
        {
            if (request.RequestType == "请假")
            {
                Console.WriteLine("{0}:{1}数量{2}被批准", name, request.RequestContent, request.Number);
            }
            else if (request.RequestType == "加薪" && request.Number <= 500)
            {
                Console.WriteLine("{0}:{1}数量{2}被批准", name, request.RequestContent, request.Number);
            }
            else if (request.RequestType == "加薪" && request.Number > 500)
            {
                Console.WriteLine("{0}:{1}数量{2}再说吧", name, request.RequestContent, request.Number);
            }
        }
    }


    public class Request
    {
        public string RequestType { get; set; }
        public int Number { get; set; }
        public string RequestContent{ get; set; }
}




}
