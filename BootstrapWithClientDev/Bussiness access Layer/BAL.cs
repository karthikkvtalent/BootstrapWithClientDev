using BootstrapWithClientDev.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BootstrapWithClientDev.Irepository;
using BootstrapWithClientDev.repository;

namespace BootstrapWithClientDev.Bussiness_access_Layer
{
    public class BAL
    {
        ireposit Iobj;
        public BAL(reposit _Iobj)
        {
            Iobj = _Iobj;
        }
        public List<Department> DeptEf()
        {
            return Iobj.DeptEf();
        }
        public void insertEmployeeEf(Employee emp)
        {
            Iobj.insertEmployeeEf(emp);
        }
        public List<Employee> EmpDataEf()
        {
            return Iobj.EmpDataEf();
        }
        public bool CheckEmail(string Email)
        {
            if (Iobj.CheckEmail(Email) > 0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
        public Employee CheckUserNamePassword(LoginModel login)
        {
            return Iobj.CheckUserNamePassword(login);
        }
        public Employee SingleEmployee(int id)
        {
            return Iobj.SingleEmployee(id);
        }
        public void DeleteEmployee(int id)
        {
            Iobj.DeleteEmployee(id);
        }
    }
}