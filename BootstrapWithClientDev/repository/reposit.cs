using BootstrapWithClientDev.Irepository;
using BootstrapWithClientDev.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace BootstrapWithClientDev.repository
{
    public class reposit : ireposit
    {
        string Con = ConfigurationManager.ConnectionStrings["ConStr"].ConnectionString;
        public int CheckEmail(string Email)
        {
            int Count;
            using (SqlConnection cn = new SqlConnection(Con))
            {
                cn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = cn;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "Sp_CheckEmail";
                cmd.Parameters.AddWithValue("@Email", Email);
                Count = Convert.ToInt32(cmd.ExecuteScalar());
            }
            return Count;
        }

        public Employee CheckUserNamePassword(LoginModel login)
        {
            Employee emp = new Employee();
            using (SqlConnection cn = new SqlConnection(Con))
            {
                cn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = cn;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "Sp_checkemail";
                cmd.Parameters.AddWithValue("@Email", login.Email);
                cmd.Parameters.AddWithValue("@Password", login.Password);
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    emp.Eid = Convert.ToInt32(dr["Eid"]);
                    emp.Ename = dr["Ename"].ToString();
                    emp.Gender = dr["Gender"].ToString();
                    emp.Email = dr["Email"].ToString();
                    emp.Password = dr["Password"].ToString();
                    emp.Phone = dr["Phone"].ToString();
                    emp.salary = Convert.ToDecimal(dr["salary"]);
                    emp.Address = dr["Address"].ToString();
                    emp.DeptID = Convert.ToInt32(dr["DeptID"]);

                }
            }
            return emp;
        }

        public void DeleteEmployee(int Eid)
        {
            //Employee emp = new Employee();
            using (SqlConnection cn = new SqlConnection(Con))
            {
                cn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = cn;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "Sp_DeleteEmp";
               
                cmd.Parameters.AddWithValue("@Eid", Eid);
                cmd.ExecuteNonQuery();
                cn.Close();
            }
        }

        public List<Department> DeptAdo()
        {
            throw new NotImplementedException();
        }

        public List<Department> DeptEf()
        {
            List<Department> DeptList = new List<Department>();
            using (SqlConnection cn = new SqlConnection(Con))
            {
                cn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = cn;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "Sp_ShowDeptData";
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    Department dept = new Department();
                    dept.DeptID = Convert.ToInt32(dr["DeptID"]);
                    dept.DName = dr["DName"].ToString();
                    dept.Dlocation = dr["Dlocation"].ToString();
                    DeptList.Add(dept);
                }
            }
            return DeptList;
        }
        public List<Employee> EmpDataEf()
        {
            List<Employee> EmpList = new List<Employee>();
            using (SqlConnection cn = new SqlConnection(Con))
            {
                cn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = cn;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "Sp_DisplyEmp";
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    Employee emp = new Employee();
                    emp.Ename = dr["Ename"].ToString();
                    emp.Gender = dr["Gender"].ToString();
                    emp.Email = dr["Email"].ToString();
                    emp.Password = dr["Password"].ToString();
                    emp.Phone = dr["Phone"].ToString();
                    emp.salary = Convert.ToDecimal(dr["salary"]);
                    emp.Address = dr["Address"].ToString();
                    emp.DeptID = Convert.ToInt32(dr["DeptID"]);
                    EmpList.Add(emp);
                }
            }
            return EmpList;
        }

      
        public void insertEmployeeAdo(Employee emp)
        {
            throw new NotImplementedException();
        }

        public void insertEmployeeEf(Employee emp)
        {
            using (SqlConnection cn = new SqlConnection(Con))
            {
                cn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = cn;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "Sp_InsertEmp";
                cmd.Parameters.AddWithValue("@Ename", emp.Ename);
                cmd.Parameters.AddWithValue("@Email", emp.Email);
                cmd.Parameters.AddWithValue("@Gender", emp.Gender);
                cmd.Parameters.AddWithValue("@Phone", emp.Phone);
                cmd.Parameters.AddWithValue("@Salary", emp.salary);
                cmd.Parameters.AddWithValue("@Address", emp.Address);
                cmd.Parameters.AddWithValue("@DeptID", emp.DeptID);
                cmd.Parameters.AddWithValue("@Password", emp.Password);
                cmd.ExecuteNonQuery();

            }
        }

        public Employee SingleEmployee(int id)
        {
            Employee emp = new Employee();
            using (SqlConnection cn = new SqlConnection(Con))
            {
                cn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = cn;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "Sp_DisplyEmpByID";
                cmd.Parameters.AddWithValue("@Eid", id);
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    emp.Ename = dr["Ename"].ToString();
                    emp.Gender = dr["Gender"].ToString();
                    emp.Email = dr["Email"].ToString();
                    emp.Password = dr["Password"].ToString();
                    emp.Phone = dr["Phone"].ToString();
                    emp.salary = Convert.ToDecimal(dr["salary"]);
                    emp.Address = dr["Address"].ToString();
                    emp.DeptID = Convert.ToInt32(dr["DeptID"]);

                }
            }
            return emp;
        }
    }
}