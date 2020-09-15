using System;
using System.Collections.Generic;
using System.Text;

namespace Demo
{
    /// <summary>
    /// 厨师类，负责烧烤
    /// </summary>
    public class Barbecuer
    {
        public void BakeMutton()
        {
            Console.WriteLine("烤羊肉串！");
        }

        public void BakeChicken()
        {
            Console.WriteLine("烤鸡翅！");
        }
    }


    public abstract class CommandDemo
    {
        protected Barbecuer receiver;

        public CommandDemo(Barbecuer barbecuer)
        {
            this.receiver = barbecuer;
        }

        abstract public void ExcuteCommand();
    }

    public class BakeMuttonCommand : CommandDemo
    {
        public BakeMuttonCommand(Barbecuer barbecuer) : base(barbecuer)
        {
        }

        public override void ExcuteCommand()
        {
            receiver.BakeMutton();
        }
    }

    public class BakeChickenCommand : CommandDemo
    {
        public BakeChickenCommand(Barbecuer barbecuer) : base(barbecuer)
        {
        }

        public override void ExcuteCommand()
        {
            receiver.BakeChicken();
        }
    }


    public class Waiter
    {
        private IList<CommandDemo> orders = new List<CommandDemo>();
        public void SetOrder(CommandDemo command)
        {
            if (command.ToString() == "Demo.BakeChickenCommand")
            {
                Console.WriteLine("服务员：没有鸡翅！");
            }
            else
            {
                orders.Add(command);
                Console.WriteLine("增加订单：" + command.ToString() + " 时间：" + DateTime.Now.ToString());
            }

        }

        public void CancelOrder(CommandDemo command)
        {
            orders.Remove(command);
            Console.WriteLine("取消订单：" + command.ToString() + " 时间：" + DateTime.Now.ToString());
        }
        public void Notify()
        {
            foreach (CommandDemo command in orders)
            {
                command.ExcuteCommand();
            }
        }
    }



    abstract class Command
    {
        protected Receiver receiver;
        public Command(Receiver receiver)
        {
            this.receiver = receiver;
        }
        abstract public void Execute();
    }

    class ConcreteCommand : Command
    {
        public ConcreteCommand(Receiver receiver):base(receiver)
        { }

        public override void Execute()
        {
            receiver.Action();
        }
    }

    class Invoker
    {
        private Command command;
        public void SetCommand(Command command)
        {
            this.command = command;
        }

        public void ExecuteCommand()
        {
            command.Execute();
        }
    }

    class Receiver
    {
        public void Action()
        {
            Console.WriteLine("执行请求。");
        }
    }


}
