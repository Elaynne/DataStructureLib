using System;
using System.Text;

namespace SortLib
{
    public class DSUtil
    {
        public StringBuilder Log { get; set; }

        public bool ValidateLess(object item, object obj1, object obj2)
        {
            switch (item)
            {
                case int i:
                    return (Convert.ToInt32(obj1) < Convert.ToInt32(obj2));
                case string str:
                    return string.Compare(obj1.ToString(), obj2.ToString()) < 0;
                default:
                    throw new ArgumentException("I can't handle the type of your values.");
            }
        }
        
        public bool ValidateLessEqual( object obj1, object obj2)
        {
            switch (obj1)
            {
                case int i:
                    return (Convert.ToInt32(obj1) <= Convert.ToInt32(obj2));
                case string str:
                    return (string.Compare(obj1.ToString(), obj2.ToString()) < 0) || (string.Compare(obj1.ToString(), obj2.ToString()) == 0);
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
