﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http.Headers;
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
            var response = await httpClient.PostAsync(AppSettings.ApiUrl + "Users/Register", content);
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
            var httpClient = new HttpClient();
            var json = JsonConvert.SerializeObject(login);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            Debug.WriteLine(content);
            Debug.WriteLine(json);
            //dev tunnel authorization
            httpClient.DefaultRequestHeaders.Add("WWW-Authenticate", "tunnel");
            httpClient.DefaultRequestHeaders.Add("Cookie", $".Tunnels.Relay.WebForwarding.Cookies={AppSettings.TunnelCookie}");
            httpClient.DefaultRequestHeaders.Add("X-Tunnel-Authorziation", AppSettings.tunnelHeader);
            Debug.WriteLine(httpClient.DefaultRequestHeaders);
            Debug.WriteLine(httpClient.ToString());

            var response = await httpClient.PostAsync(AppSettings.ApiUrl + "Users/Login", content);
            if (response.IsSuccessStatusCode)
            {
                var jsonResult = await response.Content.ReadAsStringAsync();
                var result = JsonConvert.DeserializeObject<Token>(jsonResult);
                Preferences.Set("accessToken", result.AccessToken);
                Preferences.Set("userId", result.UserId);
                Preferences.Set("userName", result.UserName);
                Debug.WriteLine(result);
                return true;
            }
            else
            {

                Debug.WriteLine(response);
                return false;
            }
        }
    }
}
