using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using System.Configuration;

namespace Demo
{
    /// <summary>
    /// 简单工厂来改造抽象工厂 AbstractFactoryDemo
    /// </summary>
    class DataBaseDemo
    {
        private static readonly string db = "Sqlserver";
        //private static readonly string db = "Access";

        public static IUser CreateUser()
        {
            IUser result = null;
            switch (db)
            {
                case "Sqlserver":result = new SqlServerUser();break;
                case "Access": result = new AccessUser(); break;
            }
            return result;
        }

        public static IDepartment CreateDepartment()
        {
            IDepartment result = null;
            switch (db)
            {
                case "Sqlserver": result = new SqlServerDepartment(); break;
                case "Access": result = new AccessDepartment(); break;
            }
            return result;
        }
    }

    /// <summary>
    /// 使用反射技术，除去switch
    /// </summary>
    class ReflexDataBaseDemo
    {
        private static readonly string AssemblyName = "Demo";
        //private static readonly string db = ConfigurationManager.AppSettings["DB"];
        private static readonly string db = "SqlServer";

        public static IUser CreateUser()
        {
            string className = AssemblyName + "." + db + "User";
            return (IUser)Assembly.Load(AssemblyName).CreateInstance(className);
        }

        public static IDepartment CreateDepartment()
        {
            string className=AssemblyName + "." + db + "Department";
            return (IDepartment)Assembly.Load(AssemblyName).CreateInstance(className);
        }
    }
}
