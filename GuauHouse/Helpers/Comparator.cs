using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GuauHouse.Helpers
{
    public class Comparator
    {
        public static bool ComparePasswordString(String a, String b)
        {
            bool res = true;
            if (a.Length != b.Length)
            {
                return false;
            }
            for (int i = 0; i < a.Length; i++)
            {
                if (a[i].Equals(b[i]) == false)
                {
                    res = false;
                    break;
                }
            }
            return res;
        }

        public static bool ComparePasswordByte(byte[] a, byte[] b)
        {
            bool res = true;
            if (a.Length != b.Length)
            {
                return false;
            }
            for (int i = 0; i < a.Length; i++)
            {
                if (a[i].Equals(b[i]) == false)
                {
                    res = false;
                    break;
                }
            }
            return res;
        }
    }
}
