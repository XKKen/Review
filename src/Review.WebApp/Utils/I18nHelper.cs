using BlazorComponent.Components;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net.Http.Json;
using System.Reflection;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Review.WebApp.Utils
{
    public class I18nHelper
    {
        public static void AddLang()
        {
            var content = File.ReadAllText("wwwroot/locale/languages.json");
            var languageDict = JsonSerializer.Deserialize<Dictionary<string, string[]>>(content);
            if (languageDict?.Count > 0)
            {
                string[] languages = languageDict["SupportLanguages"];
                var defaultLanguage = CultureInfo.CurrentCulture.Name;

                foreach (var language in languages)
                {
                    var languageContent = File.ReadAllText($"wwwroot/locale/{language}.json");

                    var isDefaultLanguage = defaultLanguage == language;

                    I18n.AddLang(language, JsonSerializer.Deserialize<Dictionary<string, string>>(languageContent), isDefaultLanguage);
                }
            }
        }
    }
}
