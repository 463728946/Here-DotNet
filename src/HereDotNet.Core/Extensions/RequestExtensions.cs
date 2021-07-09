using HereDotNet.Core.Request;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;

namespace HereDotNet.Core.Extensions
{
    internal static class RequestExtensions
    {
        public static Dictionary<string, object> ToParameter(this IRequest request)
        {
            var result = new Dictionary<string, object>();
            var props = request.GetType().GetProperties();
            foreach (var prop in props)
            {
                var value = prop.GetValue(request);
                var attr = (DescriptionAttribute[])prop.GetCustomAttributes(typeof(DescriptionAttribute), false);
                if (attr.Length != 1 || value == null) continue;
                var name = attr[0].Description;
                var type = value.GetType();
                if (type == typeof(DateTime))
                {
                    var sp = name.Split("|");
                    if (sp.Length == 2)
                    {
                        result.Add(sp[0], ((DateTime)value).ToString(sp[1]));
                    }
                }
                else if(type.GetInterfaces().Any(x=>x== typeof(IList)))
                {
                    var array = (IList)value;
                    var i = 1;
                    foreach (var item in array)
                    {
                        result.Add(string.Format(name, i), item.ToString());
                        i++;
                    }                      
                }                     
                else
                {
                    result.Add(name, value);
                }
            }
            return result;
        }



    }
}
