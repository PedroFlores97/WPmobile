using WPmobile.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace WPmobile.Service
{
    public interface IRestService
    {
        Task<Employee> GetEmployeeInfoAsync(string emplID);
    }
}