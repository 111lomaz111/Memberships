using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Memberships.Extensions
{
    public static class ReflectionExtensions
    {
        /// <summary>
        /// This method is for getting value from T object property
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="item">Type of item</param>
        /// <param name="propertyName">Name of property</param>
        /// <returns>Value from item property as string</returns>
        public static string GetPropertyValue<T>(this T item, string propertyName)
        {
            return 
                item.GetType()
                .GetProperty(propertyName)
                .GetValue(item, null).ToString();
        }
    }
}