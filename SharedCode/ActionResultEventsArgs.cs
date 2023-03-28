using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using MVVMDemo.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MVVMDemo
{
    public class ActionResultEventsArgs: EventArgs
    {
        public List<ProductModel> Products { get; set; }
        public bool isError { get; set; }

        public static ActionResultEventsArgs Response(List<ProductModel> productsResponse)
        {
            return new ActionResultEventsArgs
            {
                Products = productsResponse,
                isError = false
            };
            
        }
    }
}