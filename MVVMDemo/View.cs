using Android.App;
using Android.OS;
using Android.Runtime;
using Android.Widget;
using System;
using System.Runtime.InteropServices;

namespace MVVMDemo
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme", MainLauncher = true)]
    public class View : BaseActivity
    {
        #region Ui Component Variabless
        private EditText _searchInputEditText;
        private ImageView _searchIconImageView;
        private TextView _nameTextView, _priceTextView; 
        private ProgressBar _loader;
        #endregion

        #region ViewModel object variable
        private ViewModel _viewModel;
        #endregion
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.activity_main);
            ObjectCreationViewModel();
            UiReferences();
            UiClickEvents();
        }

        private void UiClickEvents()
        {
            _searchIconImageView.Click += _searchIconImageView_Click;
            _searchInputEditText.TextChanged += _searchInputEditText_Click;
        }

        private void _searchInputEditText_Click(object sender, EventArgs e)
        {
            _nameTextView.Visibility = Android.Views.ViewStates.Gone;
            _priceTextView.Visibility = Android.Views.ViewStates.Gone;
        }

        private void _searchIconImageView_Click(object sender, EventArgs e)
        {

            _loader.Visibility = Android.Views.ViewStates.Visible;
            _viewModel.Response += _viewModel_Response;
            _viewModel.SetSearchTerm(_searchInputEditText.Text.ToString().Trim());
            _ = _viewModel.Search();
            
        }

        private void _viewModel_Response(object sender, ActionResultEventsArgs e)
        {
            _loader.Visibility = Android.Views.ViewStates.Gone;
            if(e.Products.Count>0)
            {
                _nameTextView.Visibility = Android.Views.ViewStates.Visible;
                _priceTextView.Visibility= Android.Views.ViewStates.Visible;
                _nameTextView.Text= e.Products[0].Name; 
                _priceTextView.Text = e.Products[0].Price.ToString();
            }
            else
            {
                _priceTextView.Visibility = Android.Views.ViewStates.Visible;
                _priceTextView.Text = "No Such Item Found!";
            }
        }

        private void ObjectCreationViewModel()
        {
            _viewModel = new ViewModel();
        }

        private void UiReferences()
        {
            _searchInputEditText = FindViewById<EditText>(Resource.Id.searchInputEditText);
            _loader = FindViewById<ProgressBar>(Resource.Id.loader);
            _searchIconImageView = FindViewById<ImageView>(Resource.Id.searchIconImageView);
            _nameTextView = FindViewById<TextView>(Resource.Id.nameTextView);
            _priceTextView = FindViewById<TextView>(Resource.Id.priceTextView);
        }

        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }
    }
}