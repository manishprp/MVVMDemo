using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MVVMDemo
{
    public static class ServiceCounter
    {
        private static Dictionary<Type, Lazy<Object>> services = new Dictionary<Type, Lazy<Object>>();
        //Register
        public static void Register<T>(Func<T> function)
        {
            services[typeof(T)] = new Lazy<object> (()=> function());
        }

        public static T Resolve<T>()
        {
            return (T)Resolve(typeof(T));
        }

        private static object Resolve(Type type)
        {
            Lazy<Object> service;
            if(services.TryGetValue(type, out service))
            {
                return service.Value;
            }
            else
            {
                return null;
            }
                
        }
    }
}