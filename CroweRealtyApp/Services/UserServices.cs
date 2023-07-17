using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CroweRealtyApp.Models;
using Newtonsoft.Json;

namespace CroweRealtyApp.Services
{
    public static class UserServices
    {

        public static async Task<bool> RegisterUser(string name, string email, string password, string phone)
        {
            var register = new Register()
            {
                Name = name,
                Email = email,
                Password = password,
                Phone = phone
            };
            var httpClient = new HttpClient();
            var json = JsonConvert.SerializeObject(register);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            var response = await httpClient.PostAsync(AppSettings.ApiUrl + "api/Account/Register", content);
            if(response.IsSuccessStatusCode) return true;
            return false;
        }

        public static async Task<bool> LoginUser(string email, string password)
        {
            var login = new Login()
            {
                Email = email,
                Password = password
            };

        }
    }
}
