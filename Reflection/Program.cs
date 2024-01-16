using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using SqlServerDB;

namespace Reflection
{
    class Program
    ///<summary>
    /// 泛型:代码重用
    /// 反射: 就是操作d11文件的一个类库
    /// 怎么使用:1--查找DLL文件，2--通过Reflection反射类库里的各种方法来操作d11文件
    /// </summary>
    {
        static void Main(string[] args)
        {
            #region 普通类+各种方法调用

            ////【1】加载DLL文件
            ////Assembly assembly1 = Assembly.Load("SqlServerDB");//方式一:这个DLL文件要在启动项目下
            ////Assembly assembly2 = Assembly.LoadFile(@"D:\c#练习项目\Reflection\Reflection\bin\Debug\SqlServerDB.dll");//方式二:完整路径
            ////Assembly assembly3 = Assembly.LoadFrom(@"D:\c#练习项目\Reflection\Reflection\bin\Debug\SqlServerDB.dll");//方式三:完整路径
            //Assembly assembly4 = Assembly.LoadFrom(@"SqlServerDB.dll");//方式三:完整路径

            ////【2】获取指定类型
            //Type type = assembly4.GetType("SqlServerDB.ReflectionTest");

            //foreach (var item in assembly4.GetTypes()) //查找所有的类型1，注意这里的GetTypes是复数
            //{
            //    Console.WriteLine(item.Name);
            //}

            //// 查找所有的类型2
            ////Type[] types = assembly4.GetTypes();
            ////foreach (Type item in types)
            ////{
            ////    Console.WriteLine(item.Name);
            ////}

            //foreach (var ctor in type.GetConstructors(BindingFlags.Instance | BindingFlags.NonPublic
            //    | BindingFlags.Public))
            //{
            //    Console.WriteLine($"构造方法:{ctor.Name}");
            //    foreach (var param in ctor.GetParameters())
            //    {
            //        Console.WriteLine($"构造方法的参数:{param.Name}");
            //        Console.WriteLine($"构造方法的参数类型:{param.ParameterType}");
            //    }
            //}

            ////【3】实例化
            ////ReflectionTest reflectionTest = new ReflectionTest();//这种实例化是知道具体类型--静态(所以这里要用动态的)
            ////object objTest1 = Activator.CreateInstance(type);//动态实例化--调用我们的无参数构造方法
            ////object objTest2 = Activator.CreateInstance(type,new object[] { "Ant编程"});//动态实例化--调用我们的有参数构造方法

            ////调用私有构造函数
            ////ReflectionTest reflectionTest = new ReflectionTest();//私有的方法不能通过这种方法调用
            //object objTest2 = Activator.CreateInstance(type, true);//动态实例化--调用私有无参数构造方法

            ////调用普通方法
            //ReflectionTest reflectionTest = objTest2 as ReflectionTest;//as转换的好处是不报错，类型不对的话就返回null
            //reflectionTest.Show1();

            ////调用私有方法
            //var method = type.GetMethod("Show2", BindingFlags.Instance | BindingFlags.NonPublic);
            //method.Invoke(objTest2, new object[] { });

            //Console.WriteLine("-------------------泛型方法的调用--------------------");
            ////方法1
            ////ReflectionTest reflectionTest1 = objTest2 as ReflectionTest;//as转换的好处是不报错，类型不对的话就返回null
            ////reflectionTest1.Show3<string>();
            ////reflectionTest1.Show4<string>(123,"ant编程");

            ////方法2：调用无参数
            //var method2 = type.GetMethod("Show3");
            //var genericMethod = method2.MakeGenericMethod(new Type[] { typeof(int) });//指定泛型参数类型T
            //genericMethod.Invoke(objTest2, new object[] { });

            ////方法2：调用有参数
            //var method3 = type.GetMethod("Show4");
            //var genericMethod3 = method3.MakeGenericMethod(new Type[] { typeof(string) });//指定泛型参数类型T
            //genericMethod3.Invoke(objTest2, new object[] { 123, "ant编程" });

            //Console.Read();

            #endregion

            #region 泛型类+泛型方法

            ////【1】加载DLL文件
            //Assembly assembly5 = Assembly.LoadFrom(@"SqlServerDB.dll");//方式三:完整路径

            ////【2】获取指定类型
            //Type type = assembly5.GetType("SqlServerDB.GenericClass`2").MakeGenericType(typeof(int),typeof(string));

            ////【3】实例化
            //object objTest3 = Activator.CreateInstance(type);//动态实例化

            //var method = type.GetMethod("GenericMethod").MakeGenericMethod(typeof(int));

            //method.Invoke(objTest3,new object[] { });

            //Console.Read();

            #endregion

            #region 操作属性和字段

            //【1】加载DLL文件
            Assembly assembly6 = Assembly.LoadFrom(@"SqlServerDB.dll");//方式三:完整路径

            //【2】获取指定类型
            Type type2 = assembly6.GetType("SqlServerDB.PropertyClass");
            object obj = Activator.CreateInstance(type2);

            //操作属性
            foreach (var property in type2.GetProperties())
            {
                Console.WriteLine(property.Name);
                //给属性设置值
                if (property.Name.Equals("Id"))
                {
                    property.SetValue(obj,1);
                }
                else if (property.Name.Equals("Name"))
                {
                    property.SetValue(obj, "Ant编程");
                }
                else if (property.Name.Equals("Phone"))
                {
                    property.SetValue(obj, "123456789");
                }
                //获取属性值
                Console.WriteLine(property.GetValue(obj));
            }

            // 操作字段
            foreach (var field in type2.GetFields())
            {
                Console.WriteLine(field.Name);
                //给字段设置值
                if (field.Name.Equals("Age"))
                {
                    field.SetValue(obj, 18);
                }
                else if (field.Name.Equals("Model"))
                {
                    field.SetValue(obj, "Big");
                }
                //获取字段值
                Console.WriteLine(field.GetValue(obj));
            }
            #endregion
        }
    }
}
