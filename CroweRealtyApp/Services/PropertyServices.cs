using CroweRealtyApp.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace CroweRealtyApp.Services
{
    public class PropertyServices
    {
        public static async Task<List<Category>> GetCategories()
        {
            var httpClient = new HttpClient();
            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("bearer", Preferences.Get("accesstoken", string.Empty));
            var response = await httpClient.GetStringAsync(AppSettings.ApiUrl + "categories");
            return JsonConvert.DeserializeObject<List<Category>>(response);
        }

        public static async Task<List<TrendingProperty>> GetTrendingProperties()
        {
            var httpClient = new HttpClient();
            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("bearer", Preferences.Get("accesstoken", string.Empty));
            var response = await httpClient.GetStringAsync(AppSettings.ApiUrl + "api/Properties/TrendingProperties");
            return JsonConvert.DeserializeObject<List<TrendingProperty>>(response);
        }

        public static async Task<List<SearchProperty>> FindProperties(string address)
        {
            var httpClient = new HttpClient();
            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("bearer", Preferences.Get("accesstoken", string.Empty));
            var response = await httpClient.GetStringAsync(AppSettings.ApiUrl + "Properties/FindProperties?address=" + address);
            return JsonConvert.DeserializeObject<List<SearchProperty>>(response);
        }

        public static async Task<List<PropertyByCategory>> GetPropertyByCategory(int categoryId)
        {
            var httpClient = new HttpClient();
            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("bearer", Preferences.Get("accesstoken", string.Empty));
            var response = await httpClient.GetStringAsync(AppSettings.ApiUrl + "Properties/PropertyByCategory?categoryId=" + categoryId);
            return JsonConvert.DeserializeObject<List<PropertyByCategory>>(response);
        }

        public static async Task<PropertyDetail> GetPropertyDetail(int propertyId)
        {
            var httpClient = new HttpClient();
            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("bearer", Preferences.Get("accesstoken", string.Empty));
            var response = await httpClient.GetStringAsync(AppSettings.ApiUrl + "Properties/PropertyDetail?propertyId=" + propertyId);
            return JsonConvert.DeserializeObject<PropertyDetail>(response);
        }
    }
}
