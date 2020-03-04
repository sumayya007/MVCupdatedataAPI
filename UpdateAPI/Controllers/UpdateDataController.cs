using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Data;
using System.Data.SqlClient;

namespace UpdateAPI.Controllers
{
    public class UpdateDataController : ApiController
    {
        [HttpGet]
        public string GetSearchdata(string rollno)
        {
            var data = "";
           
            SqlConnection conn = new SqlConnection(@"Data Source=co\sqlexpress;Initial Catalog=dataAPI;Integrated Security=true");
            conn.Open();
            
                SqlCommand obj = new SqlCommand("select * from details where rollno=" + Convert.ToInt32(rollno), conn);
                SqlDataAdapter myobj = new SqlDataAdapter(obj);
                DataSet ds = new DataSet();
                myobj.Fill(ds);
                if (ds.Tables[0].Rows.Count > 0)
                {
                     data = ds.Tables[0].Rows[0]["sname"].ToString();
                      data =data+"||"+ ds.Tables[0].Rows[0]["fathername"].ToString();
                data = data + "||" + ds.Tables[0].Rows[0]["mothername"];

                   

                }
            else
            {
                data = "Data not found";

            }
            conn.Close();
            return (data);
                
           
            

           
        }
        [HttpGet]
        public string GetUpdateData(string updaterollno,string sname,string fname,string mname)
        {
            
            SqlConnection conn1 = new SqlConnection(@"Data Source=co\sqlexpress;Initial Catalog=dataAPI;Integrated Security=true");
            conn1.Open();
            SqlCommand obj1 = new SqlCommand("update details set sname='" + sname + "', fathername='" + fname + "', mothername='" + mname + "' where rollno='" + Convert.ToInt32(updaterollno)+"'", conn1);
            obj1.ExecuteNonQuery();
            conn1.Close();
            return "Data has been updated successfully with roll no=" + updaterollno;
        }
    }

}
