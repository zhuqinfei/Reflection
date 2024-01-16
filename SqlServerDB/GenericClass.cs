using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SqlServerDB
{
    public class GenericClass<T,W>
    {
         public void GenericMethod<TType>()
         {
             Console.WriteLine("泛型类调用");
          }
    }
}
