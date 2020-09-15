using System;
using System.Collections.Generic;

namespace Demo
{
    class Program
    {
        static void Main(string[] args)
        {
            #region//策略模式 
            //来创建 
            //策略是行为型模式,它的作用是让一个对象在许多行为中选择一种行为;
            IStragety peo = new People();
            Stragety stragety = new Stragety(peo);
            stragety.DoThink("think");

            Stragety stragetyDog = new Stragety(new Dog());
            stragetyDog.DoThink("think");
            #endregion

            #region//简单工厂来创建
            //简单工厂来创建  具体是何种动物
            //工厂是创建型模式,它的作用就是创建对象； 
            Animal animal = null;
            animal = SimpleFactory.ChooseAnimal("people");
            #endregion

            #region//策略模式 结合工厂模式 
            // 选择需要说话的动物
            SimpleFactoryAndStragetyDemo SimpleFactoryAndStragetyDemo = new SimpleFactoryAndStragetyDemo("people");
            SimpleFactoryAndStragetyDemo.Print();
            #endregion

            #region//策略模式 内对象 使用装饰
            SimpleFactoryAndStragetyDemo.DoWalk();
            #endregion

            #region//装饰模式
            //装饰模式，动态地给一个对象添加一些额外的职责，就增加功能来说，装饰模式比生成子类更为灵活。
            //装饰模式来装饰人的动作
            //现在走路
            Decorator manWalk = new Walk(animal);
            //扩展走路行为
            manWalk.Print();
            Console.WriteLine("----------------------\n");

            Decorator manRun = new Walk(animal);
            //扩展跑步行为
            manRun.Print();
            Console.WriteLine("----------------------\n");

            //边走边跑
            Walk walk = new Walk(animal);
            Run runAndwalk = new Run(walk);
            runAndwalk.Print();
            Console.WriteLine("----------------------\n");
            #endregion

            #region//代理模式
            //代理模式，为其他对象提供一种代理以控制对这个对象的访问。
            //（远程代理webservice，虚拟代理（html懒加载），安全代理访问权限，智能指引代理处理其他的事）
            //代理模式    隐藏了男士。
            //逻辑 男士 找 朋友 送花给女士
            Woman beautifulGirl = new Woman();
            beautifulGirl.name = "beautiful";

            Friend friend = new Friend(beautifulGirl);
            #endregion

            #region //代理模式增加装饰
            //用装饰 给他加个说话功能
            Decorator friendTalk = new Talk(friend, friend.name + " say ");
            friendTalk.Print();
            Console.WriteLine("----------------------\n");

            friend.GiveFlower();
            friend.GiveMoney();
            Console.WriteLine("----------------------\n");
            #endregion

            #region//简单工厂
            //简单工厂 直接使用  接口 IFactory 来展示
            //工厂方法模式，定义一个用于创建对象的接口，让子类决定实例化哪一个类。工厂方法使一个类的实例
            //化延迟到其子类、
            IFactory factory = new PeopleFactory();
            Animal animalfactory = factory.CreateAnimal();
            animalfactory.Print();
            #endregion

            #region //原型模式 克隆模式 深复制与浅复制
            //原型模式，用原型实例指定创建对象的种类，并且通过拷贝这些原型创建新的对象。
            //克隆模式  浅复制 ， string等引用类型直接复制原来的引用
            //浅复制，被复制对象的所有变量都含有与原来的对象相同的值，
            //而所有的对其他对象的引用都仍然指向原来的对象。
            ClonePeople clonePeople1 = new ClonePeople();
            ClonePeople clonePeople2 = (ClonePeople)clonePeople1.clone();
            Console.WriteLine(clonePeople1.name + "-" + clonePeople2.name + "\n");

            //C# 克隆接口  浅复制
            _ClonePeople _clonePeople = new _ClonePeople();
            _clonePeople.SetPeopleInfo("scb", "man", "24");
            _ClonePeople _clonePeople2 = (_ClonePeople)_clonePeople.Clone();
            //浅复制，被复制对象的所有变量都含有与原来的对象相同的值，
            //而所有的对其他对象的引用都仍然指向原来的对象。
            //原来的值也发生了变化
            _clonePeople.SetPeopleInfo("zcy", "woman", "22");
            _clonePeople.GetPeopleInfo();
            _clonePeople2.GetPeopleInfo();

            //C# 克隆接口  深复制  需要些虚拟方法，需要重写Clone函数。
            _ClonePeopleDeep _clonePeopleDeep = new _ClonePeopleDeep();
            _clonePeopleDeep.SetPeopleInfo("scb", "man", "24");
            _ClonePeopleDeep _clonePeopleDeep2 = (_ClonePeopleDeep)_clonePeopleDeep.Clone();
            _clonePeopleDeep2.SetPeopleInfo("zcy", "woman", "22");
            _clonePeopleDeep.GetPeopleInfoDeep();
            _clonePeopleDeep2.GetPeopleInfoDeep();
            Console.WriteLine(_clonePeopleDeep.name + "-" + _clonePeopleDeep2.name + "\n");
            #endregion

            #region//模板模式
            //模板模式 paper1的试卷  重写paper2
            //模板方法模式，定义一个操作中的算法的骨架，而将一些步骤延迟到子类中。模板方法使得子类可以
            //不改变一个算法的结构即可重定义该算法的某些特定步骤。
            TestPaper paper1 = new PaperA();
            paper1.Question1();
            paper1.Question2();
            paper1.Question3();

            AbstractClass ABC;
            ABC = new ClassA();
            ABC.TemplateMethod();
            ABC = new ClassB();
            ABC.TemplateMethod();
            #endregion

            #region//外观模式
            FacadeDemo facade = new FacadeDemo();
            facade.MethodA();
            facade.MethodB();
            #endregion

            #region//建造者模式
            ThinPeople thinPeople = new ThinPeople(new People());
            PersonDirector pdthin = new PersonDirector(thinPeople);
            pdthin.CreatePerson();

            FatPeople fatPeople = new FatPeople(new People());
            PersonDirector pdfat = new PersonDirector(fatPeople);
            pdfat.CreatePerson();
            #endregion

            #region//观察者模式  
            //观察者
            ConcreteSubject Subject = new ConcreteSubject();
            //用户2个
            ConcreteObserver scbObserver = new ConcreteObserver("scb", Subject);
            ConcreteObserver zcyObserver = new ConcreteObserver("zcy", Subject);

            Subject.Attach(scbObserver);
            Subject.Attach(zcyObserver);
            //观察者 通知。
            Subject.SubjectState = "老板回来了！";
            Subject.Notify();
            #endregion

            #region//委托
            //委托 
            Boss huhansan = new Boss();
            GameObserver game = new GameObserver("scb", huhansan);
            MovieObserver movie = new MovieObserver("zcy", huhansan);

            huhansan.Update += new EventHandeler(game.CloseGame);
            huhansan.Update += new EventHandeler(movie.CloseMovie);
            //老板回来
            huhansan.SubjectState = "我胡汉三回来了";
            //通知
            huhansan.Notify();
            #endregion

            #region//抽象工厂模式
            User user = new User();
            Department dept = new Department();
            IAbstractFactory fa = new SqlServerFactory();
            //IAbstractFactory fa = new AccessFactory();
            IUser iu = fa.CreateUser();
            iu.Insert(user);
            iu.GetUser(1);

            IDepartment id = fa.CreateDepartment();
            id.Insert(dept);
            id.GetDepartment(1);
            #endregion

            #region//用简单工厂 改造 上面的  抽象工厂
            Console.WriteLine("---------下面是简单工厂改造-----\n");
            
            IUser ius = DataBaseDemo.CreateUser();
            ius.Insert(user);
            ius.GetUser(1);
            #endregion

            #region//反射
            Console.WriteLine("---------下面是反射-------------\n");
            //反射
            IUser iuser = ReflexDataBaseDemo.CreateUser();
            iuser.Insert(user);
            iuser.GetUser(1);
            #endregion

            #region//状态模式
            //状态模式  将每个状态都分成类。
            Work project = new Work();
            project.Hour = 9;
            project.WriteProgram();
            project.Hour = 12;
            project.WriteProgram();
            project.Hour = 14;
            project.WriteProgram();
            project.Hour = 17;

            project.TaskFinished = true;
            project.WriteProgram();

            project.Hour = 19;
            project.WriteProgram();
            project.Hour = 22;
            project.WriteProgram();
            #endregion

            #region//适配器模式
            Target target = new Adapter();
            target.Request();
            #endregion

            #region//备忘录模式
            GameRole boss = new GameRole();
            boss.GetInitState();
            boss.StateDisplay();
       

            //备份
            RoleStateCaretaker bossbackup = new RoleStateCaretaker();
            bossbackup.memnto = boss.SaveState();
            //消耗
            boss.Fight();
            boss.StateDisplay();
            //读取备份
            boss.RecoveryState(bossbackup.memnto);
            boss.StateDisplay();
            #endregion

            #region//组合模式
            Composite root = new Composite("root");
            root.Add(new Leaf("Leaf A"));
            root.Add(new Leaf("Leaf B"));

            Composite comp = new Composite("Composite X");
            comp.Add(new Leaf("Leaf XA"));
            comp.Add(new Leaf("Leaf XB"));
            root.Add(comp);

            Composite comp2 = new Composite("Composite XY");
            comp2.Add(new Leaf("Leaf XYA"));
            comp2.Add(new Leaf("Leaf XYB"));
            root.Add(comp2);

            root.Add(new Leaf("Leaf C"));
            Leaf leaf = new Leaf("Leaf D");
            root.Add(leaf);
            root.Remove(leaf);
            root.Display(1);
            #endregion

            #region //迭代器模式
            ConcreteAggregate a = new ConcreteAggregate();
            
            a[0] = "a1";
            a[1] = "a2";
            a[2] = "a3";
            a[3] = "a4";
            a[4] = "a5";
            a[5] = "a6";

            //一直新增
            //申明迭代器
            Iterator i = new ConcreteIterator(a);
            object item = i.First();
            while (!i.IsDone())
            {
                Console.Write("{0} buy!", i.CurrentItem());
                i.Next();
            }
            Console.WriteLine("\n");
            #endregion

            #region //单例模式  
            //类里面写多中方法，包括C#自带的方法，以及懒汉式与饿汉式的单例类
            //懒汉式 在第一次被引用的时候，将自己实例化。
            //饿汉式 在自己被加载的时候就将自己实例化。
            SingletonDemo s1 = SingletonDemo.GetInstance();
            SingletonDemo s2 = SingletonDemo.GetInstance();
            if (s1 == s2)
            {
                Console.WriteLine("两个对象是相同的实例。\n");
            }

            #endregion

            #region//桥接模式
            //桥接模式，将抽象部分与它的实现部分分离，使他们都可以独立的变化。
            //实现系统有多角度分类，每一种分类都可能变化，那么就把这种多角度分离出来让它们独立变化，减少它们之间的耦合。
            Abstraction ab = new RefinedAbstraction();

            ab.SetImplementor(new ConcreteImplmentorA());
            ab.Operation();

            ab.SetImplementor(new ConcreteImplmentorB());
            ab.Operation();
            #endregion

            #region //命令模式
            //命令模式，Command ，将一个请求封装为一个对象，从而使你可用不同的请求对客户进行参数化；
            //对请求排队或记录请求日志，以及支持可撤销的操作
            //开店烧烤 DEMO
            Barbecuer boy = new Barbecuer();
            CommandDemo bakeMuttonCommand1 = new BakeMuttonCommand(boy);
            CommandDemo bakeMuttonCommand2 = new BakeMuttonCommand(boy);
            CommandDemo backChickenWingCommand1 = new BakeChickenCommand(boy);
            Waiter girl = new Waiter();

            //开门营业
            girl.SetOrder(bakeMuttonCommand1);
            girl.SetOrder(bakeMuttonCommand2);
            girl.SetOrder(backChickenWingCommand1);

            girl.Notify();

            //正规代码示例
            Receiver r = new Receiver();
            Command c = new ConcreteCommand(r);
            Invoker invoker = new Invoker();

            invoker.SetCommand(c);
            invoker.ExecuteCommand();


            #endregion

            #region//职责链模式
            //使多个对象都有机会处理请求，从而避免请求的发送者和接受者之间的耦合关系。
            //将这个对象连成一条链，并沿着这条链传递该请求，直到有一个对象处理它为止。

            CommonManager jingli = new CommonManager("经理");
            Majordomo zongjian = new Majordomo("总监");
            GeneralManager zongjingli = new GeneralManager("总经理");
            //设置上级可以随意控制
            jingli.SetSuccessor(zongjian);
            zongjian.SetSuccessor(zongjingli);


            //发送具体请求
            Request request = new Request();
            request.RequestType = "请假";
            request.RequestContent = "scb请假";
            request.Number = 1;
            jingli.RequestApplications(request);

            Request request2 = new Request();
            request2.RequestType = "请假";
            request2.RequestContent = "scb请假";
            request2.Number = 4;
            jingli.RequestApplications(request2);

            Request request3 = new Request();
            request3.RequestType = "加薪";
            request3.RequestContent = "scb请求加薪";
            request3.Number = 500;
            jingli.RequestApplications(request3);

            Request request4 = new Request();
            request4.RequestType = "加薪";
            request4.RequestContent = "scb请求加薪";
            request4.Number = 1000;
            jingli.RequestApplications(request4);
            #endregion

            #region//中介者模式
            //中介对象
            ConcreteMediator m = new ConcreteMediator();
            //都知道中介对象
            ConcreteColleague1 c1 = new ConcreteColleague1(m);
            ConcreteColleague2 c2 = new ConcreteColleague2(m);

            //中介者认识对象
            m.colleague1 = c1;
            m.colleague2 = c2;

            c1.Send("吃饭了吗？");
            c2.Send("没有，你要请客吗？");



            #endregion

            #region //享元模式
            int extrinsicstate = 22;

            FlyweightFactory f = new FlyweightFactory();

            Flyweight fx = f.GetFlyweight("X");
            fx.Operationg(--extrinsicstate);


            Flyweight fy = f.GetFlyweight("Y");
            fx.Operationg(--extrinsicstate);


            Flyweight fz = f.GetFlyweight("Z");
            fx.Operationg(--extrinsicstate);

            UnsharedConcreteFlyweight uf = new UnsharedConcreteFlyweight();
            uf.Operationg(--extrinsicstate);


            WebSiteFactory fw = new WebSiteFactory();
            WebSite fwx = fw.GetWebSiteCategory("产品展示");
            fwx.Use(new WebSiteUser("scb"));

            WebSite fwy= fw.GetWebSiteCategory("产品展示");
            fwx.Use(new WebSiteUser("six"));

            WebSite fwz = fw.GetWebSiteCategory("博客");
            fwx.Use(new WebSiteUser("666"));

            Console.WriteLine("得到网站分类总数为{0}", fw.GetWebSiteCount());

            #endregion

            #region //解释器模式
            Context context = new Context();

            IList<AbstractExpression> list = new List<AbstractExpression>();

            list.Add(new TerminalExpression());
            list.Add(new NoterminalExpression());
            list.Add(new TerminalExpression());
            list.Add(new TerminalExpression());

            foreach (AbstractExpression exp in list)
            {
                exp.Interpret(context);
            }

            #endregion

            #region //访问器模式

            ObjectStructure o = new ObjectStructure();
            o.Attach(new ManPerson());
            o.Attach(new WoManPerson());

            //成功反应
            Success v1 = new Success();
            o.Display(v1);

            //失败时的反应
            Failing v2 = new Failing();
            o.Display(v2);

            ObjectStructureVisitor oVisitor = new ObjectStructureVisitor();
            oVisitor.Attach(new ConcreteElementA());
            oVisitor.Attach(new ConcreteElementB());
            ConcreteVisitor1 vc1 = new ConcreteVisitor1();
            ConcreteVisitor2 vc2 = new ConcreteVisitor2();

            oVisitor.Accept(vc1);
            oVisitor.Accept(vc2);



            #endregion

            #region//委托实例。
            Cat cat = new Cat("Tom");
            Mouse mouse1 = new Mouse("Jerry");
            Mouse mouse2 = new Mouse("Jack");

            cat.CatShout += new Cat.CatShoutEventHandler(mouse1.Run);
            cat.CatShout += new Cat.CatShoutEventHandler(mouse2.Run);

            cat.Shout();
            
            #endregion

            Console.ReadLine();

        }
    }

}
