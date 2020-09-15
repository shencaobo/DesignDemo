using System;
using System.Collections.Generic;
using System.Text;

namespace Demo
{
    //抽象工厂
    class User
    {
        private int _id;
        public int ID
        {
            get { return _id; }
            set { _id = value; }
        }

        private string _name;
        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

    }

    class Department
    {
        private int _id;
        public int ID
        {
            get { return _id; }
            set { _id = value; }
        }

        private string _name;
        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

    }

    interface IUser
    {
        void Insert(User user);
        User GetUser(int id);
    }

    interface IDepartment
    {
        void Insert(Department department);
        Department GetDepartment(int id);
    }

    /// <summary>
    /// sql server
    /// </summary>
    class SqlServerUser : IUser
    {
        public void Insert(User user)
        {
            Console.WriteLine("在SQL Server中User增加一条数据");
        }
        public User GetUser(int id)
        {
            Console.WriteLine("在SQL Server中根据id获得User的一条数据");
            return null;
        }
    }
    class SqlServerDepartment : IDepartment
    {
        public void Insert(Department department)
        {
            Console.WriteLine("在SQL Server中Department增加一条数据");
        }
        public Department GetDepartment(int id)
        {
            Console.WriteLine("在SQL Server中根据id获得Department的一条数据");
            return null;
        }
    }
    /// <summary>
    /// access
    /// </summary>
    class AccessDepartment : IDepartment
    {
        public void Insert(Department department)
        {
            Console.WriteLine("在Access中Department增加一条数据");
        }
        public Department GetDepartment(int id)
        {
            Console.WriteLine("在Access根据id获得Department的一条数据");
            return null;
        }
    }
    class AccessUser : IUser
    {
        public void Insert(User user)
        {
            Console.WriteLine("在Access中User增加一条数据");
        }
        public User GetUser(int id)
        {
            Console.WriteLine("在Access根据id获得User的一条数据");
            return null;
        }
    }

    interface IAbstractFactory
    {
        IUser CreateUser();

        IDepartment CreateDepartment();
    }

    class SqlServerFactory : IAbstractFactory
    {
        public IUser CreateUser()
        {
            return new SqlServerUser();
        }
        public IDepartment CreateDepartment()
        {
            return new SqlServerDepartment();
        }
    }
    class AccessFactory : IAbstractFactory
    {
        public IUser CreateUser()
        {
            return new AccessUser();
        }
        public IDepartment CreateDepartment()
        {
            return new SqlServerDepartment();
        }
    }
}
