using BlazorComponent;
using Microsoft.AspNetCore.Http;
using Review.WebApp.Global.Nav.Model;

namespace Review.WebApp.Utils
{
    public class GlobalConfigs
    {
        private CookieStorage? _cookieStorage;
        private NavModel? _currentNav;

        public GlobalConfigs()
        {

        }

        public GlobalConfigs(CookieStorage cookieStorage)
        {
            _cookieStorage = cookieStorage;
        }

        public static string LanguageCookieKey { get; set; } = "GlobalConfigs_Language";

        public static string? StaticLanguage { get; set; }

        public string? Language { get; set; }

        public delegate void GlobalConfigChanged();
        public event GlobalConfigChanged? OnCurrentNavChanged;

        public void Initialize(IRequestCookieCollection cookies)
        {
            Language = cookies[LanguageCookieKey];
        }

        public void SaveChanges()
        {
            _cookieStorage?.SetItemAsync(LanguageCookieKey, Language);
        }

        public void Bind(GlobalConfigs globalConfig)
        {
            Language = globalConfig?.Language;
        }

        public NavModel? CurrentNav
        {
            get => _currentNav;
            set
            {
                _currentNav = value;
                OnCurrentNavChanged?.Invoke();
            }
        }
    }
}
