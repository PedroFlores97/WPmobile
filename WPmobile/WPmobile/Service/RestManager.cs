using WPmobile.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace WPmobile.Service
{
    public class RestManager
    {
        IRestService restService;

        public RestManager(IRestService service)
        {
            restService = service;
        }

        public Task<Employee> GetEmployeeInfoAsync(string emplID)
        {
            return restService.GetEmployeeInfoAsync(emplID);
        }
    }
}
