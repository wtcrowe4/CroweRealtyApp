using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using CroweRealtyApp.Models;
using Newtonsoft.Json;

namespace CroweRealtyApp.Services
{
    public static class BookmarkServices
    {
        public static async Task<List<BookmarkList>> GetBookmarkList ()
        {
            var httpClient = new HttpClient();
            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("bearer", Preferences.Get("accesstoken", string.Empty));
            var response = await httpClient.GetStringAsync(AppSettings.ApiUrl + "bookmarks");
            return JsonConvert.DeserializeObject<List<BookmarkList>>(response);
        }

        public static async Task<bool> AddBookmark(AddBookmark addBookmark)
        {
            var httpClient = new HttpClient();
            var json = JsonConvert.SerializeObject(addBookmark);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("bearer", Preferences.Get("accesstoken", string.Empty));
            var response = await httpClient.PostAsync(AppSettings.ApiUrl + "bookmarks", content);
            if (response.IsSuccessStatusCode) return true;
            return false;
        }

        public static async Task<bool> DeleteBookmark(int bookmarkId)
        {
            var httpClient = new HttpClient();
            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("bearer", Preferences.Get("accesstoken", string.Empty));
            var response = await httpClient.DeleteAsync(AppSettings.ApiUrl + "bookmarks/" + bookmarkId);
            if (response.IsSuccessStatusCode) return true;
            return false;
        }
    }
}
