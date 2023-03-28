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

namespace MVVMDemo.Database
{
    public class ProductModel
    {
        //Just a numeric identifier
        public int Id { get; set; }
        //Name of the product
        public string Name { get; set; }
        //Price of the product
        public float Price { get; set; } 

    }
}