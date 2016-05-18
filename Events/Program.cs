using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Events
{
    public class Program
    {
        public static void Main(string[] args)
        {

        }

        private static void Foo(ref MyNode value)
        {
            value = value.Field;
        }
    }

    public class MyNode
    {
        public MyNode Field;
        public string Name;

        public MyNode(MyNode field)
        {
            this.Field = field;
        }
    }
}
