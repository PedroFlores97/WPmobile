using WPmobile.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace WPmobile.Service
{
    public class RestService : IRestService
    {
        HttpClient client;

        public RestService(string username, string password)
        {
            var authData = string.Format("{0}:{1}", username, password);
            var authHeaderValue = Convert.ToBase64String(Encoding.UTF8.GetBytes(authData));

            client = new HttpClient();

            client.BaseAddress = new Uri("https://wpapi.guttman.cuny.edu");
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", authHeaderValue);
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            //var t = client.GetAsync("/api/employee/15036246").Result;

        }

        public async Task<Employee> GetEmployeeInfoAsync(string emplID)
        {
            Employee empl = new Employee();

            //string Url = "https://wpapi.guttman.cuny.edu/api/employee";
            //var uri = new Uri(string.Format(Url, string.Empty));

            try
            {
                var response = client.GetAsync("/api/employee/getemployee/" + emplID).Result;
                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    empl = JsonConvert.DeserializeObject<Employee>(content);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return empl;
        }

    }
}
