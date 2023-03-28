using Android.App;
using Android.OS;
using System;
using System.Threading.Tasks;

namespace MVVMDemo
{
    public class ViewModel 
    {
        private static Repo _repo;
        private string _searchterm;

        //EventHandlers
        
        public event EventHandler<ActionResultEventsArgs> Response;
        public ViewModel() 
        {
            if(_repo==null)
            _repo= new Repo();
        }

        public void SetSearchTerm(string searchTerm)
        {
            _searchterm = searchTerm;
        }

        public async Task Search()
        {
            if(!string.IsNullOrEmpty(_searchterm))
            {
                var result = await _repo.SearchProducts(_searchterm);
                if(!result.isError)
                {
                    Response?.Invoke(this, result);
                }
            }

           
        }
    }
}