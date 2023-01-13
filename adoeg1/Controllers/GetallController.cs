using adoeg1.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Configuration;

namespace adoeg1.Controllers
{
    public class GetallController : ApiController
    {
        public SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["myconnection"].ConnectionString);
        public List<adoModel> GetAll()
        {
            SqlDataAdapter da = new SqlDataAdapter("spAllStudents ", con);
            DataTable dt = new DataTable();
            da.Fill(dt);
            string strjson = JsonConvert.SerializeObject(dt);
            List<adoModel> list = JsonConvert.DeserializeObject<List<adoModel>>(strjson);
            return list;
        }
    }
}
