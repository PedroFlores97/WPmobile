using System;
using System.Collections.Generic;
using System.Text;

namespace WPmobile.Models
{
    public class Employee
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string DisplayName { get; set; }
        public string EmplID { get; set; }
        public string PhoneNum { get; set; }
        public string Email { get; set; }
        public string Location { get; set; }
        public string Title { get; set; }
        public string Department { get; set; }
        public string Bio { get; set; }
        public byte[] Picture { get; set; }
    }
    public class EmployeeList
    {
        public List<Employee> Employees { get; set; }
    }
}
