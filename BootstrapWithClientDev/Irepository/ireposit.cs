using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BootstrapWithClientDev.Models;

namespace BootstrapWithClientDev.Irepository
{
   public  interface ireposit
    {
        List<Department> DeptEf();
        List<Department> DeptAdo();

        void insertEmployeeEf(Employee emp);
        void insertEmployeeAdo(Employee emp);

        List<Employee> EmpDataEf();

        int CheckEmail(string Email);

        Employee CheckUserNamePassword(LoginModel login);

        Employee SingleEmployee(int id);

        void DeleteEmployee(int emp);

    }
}
