using Microsoft.AspNetCore.Components;
using Review.WebApp.Global.Nav.Model;
using Review.WebApp.Utils;

namespace Review.WebApp.Shared
{
    public partial class Favorite
    {
        List<int> _favoriteMenus = new() { 5, 2, 15 };

        protected override void OnInitialized()
        {
      
        }

        [Inject]
        private NavigationManager NavigationManager { get; set; } = default!;

        public List<NavModel> SameLevelNavs { get; } = new();

        List<NavModel> GetFavoriteMenus() => GetNavs(null);

        List<NavModel> GetNavs(string? search)
        {
            var output = new List<NavModel>();

            output.Add(new NavModel(1,"/home","", "Review.Home",null));
            return output;
        }

        public void NavigateTo(NavModel nav)
        {
            Active(nav);
            NavigationManager.NavigateTo(nav.Href ?? "");
        }

        public void Active(NavModel nav)
        {
            SameLevelNavs.ForEach(n => n.Active = false);
            nav.Active = true;
            if (nav.ParentId != 0) SameLevelNavs.First(n => n.Id == nav.ParentId).Active = true;
        }

        public void Dispose()
        {
        }
    }
}
