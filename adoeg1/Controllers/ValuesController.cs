using adoeg1.Models;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web.Http;

namespace adoeg1.Controllers
{
    public class ValuesController : ApiController
    {
        public SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["myconnection"].ConnectionString);
        // GET api/values
        [HttpGet]
        public List<adoModel> Get()
        {
            SqlDataAdapter da = new SqlDataAdapter("spAllStudents ", con);
            DataTable dt = new DataTable();
            da.Fill(dt);
            var query = from q in dt.AsEnumerable()
                        select new
                        {
                            id = q["id"],
                            name = q["name"],
                            //age = (int)q["age"]
                            age = q["age"] //== null ? 0 : q["age"]
                        };

            //var query = from q in dt.AsEnumerable()
            //            select (string)q["name"];
            string strjson = JsonConvert.SerializeObject(query);
            List<adoModel> lslist = JsonConvert.DeserializeObject<List<adoModel>>(strjson);
            return lslist;
        }
        // GET api/values/5
        public List<adoModel> Get(int id)
        {
            SqlDataAdapter da = new SqlDataAdapter("spAllStudents ", con);
            DataTable dt = new DataTable();
            da.Fill(dt);

            var query = from q in dt.AsEnumerable()
                        where (int)q["id"] == id
                        select new
                        {
                            id = q["id"],
                            name = q["name"],
                            //age = (int)q["age"]
                            age = q["age"]// == null ? 0 : q["age"]
                        };


            //list.AddRange(query);
            string strjson = JsonConvert.SerializeObject(query);
            List<adoModel> lslist = JsonConvert.DeserializeObject<List<adoModel>>(strjson);
            return lslist;
        }

        // POST api/values
        public void Post([FromBody] string value)
        {
        }

        // PUT api/values/5
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        public void Delete(int id)
        {
        }
    }
}
