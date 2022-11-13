using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BZUCommon.RequestValidiation
{
    public static class Ensure
    {
        public static void IsNotNull(object obj, string nameOfObject)
        {
            if (obj == null)
            {
                throw new ArgumentNullException(nameOfObject);
            }
        }

        public static void StringIsNullOrWhiteSpace(string obj, string nameOfObject)
        {
            if (string.IsNullOrWhiteSpace(obj))
            {
                throw new ArgumentNullException(nameOfObject);
            }
        }
    }
}
