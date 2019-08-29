using BootstrapWithClientDev.Bussiness_access_Layer;
using System.ComponentModel.DataAnnotations;
using BootstrapWithClientDev.repository;

namespace BootstrapWithClientDev.CustomValidations
{
    public class EmailCheckAttribute : ValidationAttribute
    {
        BAL objBal = new BAL(new repository.reposit());
       

        public override bool IsValid(object value)
        {
            bool flag;
           flag= objBal.CheckEmail(value.ToString());
            return flag;
        }
    }
}