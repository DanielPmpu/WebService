using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace WcfService2
{
    public class Service1 : IService1
    {
        public Dictionary<string, int> tryline(StringBuilder line)
        {
            Dictionary<string, int> mynewDIct = new Dictionary<string, int>();
            Assembly asm = Assembly.LoadFile("C:\\ProjectsC#\\Library.dll");
            Type typereader = asm.GetType("Library.dll");
            ConstructorInfo readerConstructor = typereader.GetConstructor(Type.EmptyTypes);
            object readerObject = readerConstructor.Invoke(new object[] { });
            MethodInfo readerMethod = typereader.GetMethod("reader3", BindingFlags.Public | BindingFlags.Instance);
            mynewDIct = (Dictionary<string, int>)readerMethod.Invoke(readerObject, new object[] { line });
            mynewDIct.Remove("");
            mynewDIct = mynewDIct.OrderByDescending(x => x.Value).ToDictionary(x => x.Key, x => x.Value);
            return mynewDIct;
        }
    }
}

