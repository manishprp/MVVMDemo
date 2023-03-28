using Android.App;
using Android.OS;
using AndroidX.AppCompat.App;

namespace MVVMDemo
{
    [Activity(Label = "BaseActivity")]
    public class BaseActivity : AppCompatActivity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your application here
        }
    }
}