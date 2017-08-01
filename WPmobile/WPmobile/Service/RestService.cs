using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using WPmobile.Models;

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
            client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Basic", authHeaderValue);
            

            //var t = client.GetAsync("/api/employee/15036246").Result;

        }

        public async Task<Employee> GetAllEmployeesAsync(string emplID)
        {
            List<Employee> emplList = new List<Employee>();

            //string Url = "https://wpapi.guttman.cuny.edu";
            //var uri = new Uri(string.Format(Url, string.Empty));

            try
            {
                var response = client.GetAsync("/api/employee/getallemployees/").Result;
                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    emplList = JsonConvert.DeserializeObject<EmployeeList>(content).Employees;
                }
            }
            catch (Exception ex)
            {

            }

            return emplList;
        }

        
    }
}
