using System;
using System.Collections.Generic;
using System.Text;

namespace SortLib
{
    public class SortUtil
    {
        public bool ValidateByType(object item, object key, object current)
        {
            switch (item)
            {
                case int i:
                    return (Convert.ToInt32(key) < Convert.ToInt32(current));
                case string str:
                    return string.Compare(key.ToString(), current.ToString()) < 0;
                default:
                    throw new ArgumentException("I can't handle the type of your values.");
            }
        }

        public bool ValidateEqual(object obj1, object obj2)
        {
            switch (obj1)
            {
                case int i:
                    return (Convert.ToInt32(obj1) == Convert.ToInt32(obj2));
                case string str:
                    return string.Compare(obj1.ToString(), obj2.ToString()) == 0;
                default:
                    throw new ArgumentException("I can't handle the type of your values.");
            }
        }

    }
}
