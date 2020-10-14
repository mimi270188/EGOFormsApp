using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace GymApp.Common
{
    public static class Reflection
    {
        public static object GetValue(object obj, string propName)
        {
            return obj.GetType().GetProperties().First(x => x.Name == propName).GetValue(obj);
        }

        public static void SetValue(ref object obj, string propName, object value)
        {
            obj.GetType().GetProperties().First(x => x.Name == propName).SetValue(obj, value);
        }
    }
}
