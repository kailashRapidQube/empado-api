using empado.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Web.Http;

namespace empado.Controllers
{
    public class EmployeeController : ApiController
    {

        public SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["myconnection"].ConnectionString);
        // GET api/employee
        public List<EmployeeModel> Get()
        {

            SqlDataAdapter da = new SqlDataAdapter("spAllEmp", con);
            DataTable dt = new DataTable();
            da.Fill(dt);
            string strjson = JsonConvert.SerializeObject(dt);
            List<EmployeeModel> listemployee = JsonConvert.DeserializeObject<List<EmployeeModel>>(strjson);
            return listemployee;
            //SqlCommand cm = new SqlCommand("spAllEmp", con);
            //con.Open();
            //SqlDataReader sdr = cm.ExecuteReader();
            //List<EmployeeModel> listemployee = new List<EmployeeModel>();
            //while (sdr.Read())
            //{
            //    EmployeeModel emp = new EmployeeModel();
            //    emp.Id = Convert.ToInt32(sdr.GetValue(0));
            //    emp.Empname = sdr.GetValue(1).ToString();
            //    emp.Contactno = sdr.GetValue(2).ToString();
            //    emp.City = sdr.GetValue(3).ToString();
            //    listemployee.Add(emp);
            //}
            //return listemployee;
            //SqlCommand cm = new SqlCommand("spAllEmp", con);
            //con.Open();
            //SqlDataReader sdr = cm.ExecuteReader();
            //List<EmployeeModel> listemployee = new List<EmployeeModel>();
            //while (sdr.Read())
            //{
            //    EmployeeModel emp = new EmployeeModel();
            //    emp.Id = (int)sdr["id"];
            //    emp.Empname = (string)sdr["empname"];
            //    emp.Contactno = (string)sdr["contactno"];
            //    emp.City = (string)sdr["city"];
            //    listemployee.Add(emp);
            //}
            //return listemployee;

            //SqlDataAdapter da = new SqlDataAdapter("spAllEmp", con);
            //DataTable dt = new DataTable();
            //da.Fill(dt);
            //List<EmployeeModel> listemployee = new List<EmployeeModel>();
            //for (int i = 0; i < dt.Rows.Count; i++)
            //{
            //    EmployeeModel emp = new EmployeeModel();
            //    emp.Id = Convert.ToInt32(dt.Rows[i]["id"]);
            //    emp.Empname = Convert.ToString(dt.Rows[i]["empname"]);
            //    emp.Contactno = Convert.ToString(dt.Rows[i]["contactno"]);
            //    emp.City = Convert.ToString(dt.Rows[i]["city"]);
            //    listemployee.Add(emp);
            //}
            //return listemployee;
        }
        public EmployeeModel Get(int id)
        {
            SqlDataAdapter da = new SqlDataAdapter("spEmpbyid", con);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;
            da.SelectCommand.Parameters.AddWithValue("@id", id);
            DataTable dt = new DataTable();
            da.Fill(dt);
            //string strjson = JsonConvert.SerializeObject(dt);
            //List<EmployeeModel> emp = JsonConvert.DeserializeObject<List<EmployeeModel>>(strjson);
            EmployeeModel emp = new EmployeeModel();
            emp.id = Convert.ToInt32(dt.Rows[0]["id"]);
            emp.empname = Convert.ToString(dt.Rows[0]["empname"]);
            emp.contactno = Convert.ToString(dt.Rows[0]["contactno"]);
            emp.city = Convert.ToString(dt.Rows[0]["city"]);
            return emp;
        }
            // GET api/employee/5
        //    public List<EmployeeModel> Get(int id)
        //{
        //    SqlDataAdapter da = new SqlDataAdapter("spEmpbyid", con);
        //    da.SelectCommand.CommandType = CommandType.StoredProcedure;
        //    da.SelectCommand.Parameters.AddWithValue("@id", id);
        //    DataTable dt = new DataTable();
        //    da.Fill(dt);
        //    string strjson = JsonConvert.SerializeObject(dt);
        //    List<EmployeeModel> emp = JsonConvert.DeserializeObject<List<EmployeeModel>>(strjson);
        //    //EmployeeModel emp = new EmployeeModel();
        //    //emp.Id = Convert.ToInt32(dt.Rows[0]["id"]);
        //    //emp.Empname = Convert.ToString(dt.Rows[0]["empname"]);
        //    //emp.Contactno = Convert.ToString(dt.Rows[0]["contactno"]);
        //    //emp.City = Convert.ToString(dt.Rows[0]["city"]);
        //    return emp;
        //    //SqlCommand cm = new SqlCommand("spEmpbyid", con);
        //    //cm.CommandType = CommandType.StoredProcedure;
        //    //cm.Parameters.AddWithValue("@id", id);
        //    //con.Open();
        //    //SqlDataReader sdr = cm.ExecuteReader();
        //    //sdr.Read();
        //    //EmployeeModel emp = new EmployeeModel();
        //    //emp.id = (int)sdr["id"];
        //    //emp.empname = (string)sdr["empname"];
        //    //emp.contactno = (string)sdr["contactno"];
        //    //emp.city = (string)sdr["city"];
        //    //return emp;
        //    //SqlDataAdapter da = new SqlDataAdapter("spEmpbyid", con);
        //    //da.SelectCommand.CommandType = CommandType.StoredProcedure;
        //    //da.SelectCommand.Parameters.AddWithValue("@id", id);
        //    //DataTable dt = new DataTable();
        //    //da.Fill(dt);
        //    //EmployeeModel emp = new EmployeeModel();
        //    //emp.Id = Convert.ToInt32(dt.Rows[0]["id"]);
        //    //emp.Empname = Convert.ToString(dt.Rows[0]["empname"]);
        //    //emp.Contactno = Convert.ToString(dt.Rows[0]["contactno"]);
        //    //emp.City = Convert.ToString(dt.Rows[0]["city"]);
        //    //return emp;
        //}

        // POST api/employee
        public void Post(EmployeeModel employee)
        {
            SqlCommand cmd = new SqlCommand("spAddEmp", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@id", employee.id);
            cmd.Parameters.AddWithValue("@name", employee.empname);
            cmd.Parameters.AddWithValue("@contactno", employee.contactno);
            cmd.Parameters.AddWithValue("@city", employee.city);
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();

        }

        // PUT api/employee/1
        public void Put(EmployeeModel employee, int id)
        {
            //string msg = " ";
            SqlCommand cmd = new SqlCommand("spUpdateEmp", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@id", id);
            cmd.Parameters.AddWithValue("@name", employee.empname);
            cmd.Parameters.AddWithValue("@contactno", employee.contactno);
            cmd.Parameters.AddWithValue("@city", employee.city);
            con.Open();
            int i = cmd.ExecuteNonQuery();
            con.Close();
            //if (i > 0)
            //{
            //    msg = "Values are updated";

            //}
            //else
            //{
            //    msg = "error while updating";
            //}
            //return msg;

        }

        // DELETE api/employee/4
        public string Delete(int id)
        {
            string msg = "";
            SqlCommand cmd = new SqlCommand("spDeleteEmp", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@id", id);
            con.Open();
            int i = cmd.ExecuteNonQuery();
            con.Close();
            if (i > 0)
            {
                msg = "record deleted";
            }
            else
            {
                msg = "error while updating";
            }
            return msg;
        }
    }
}
