using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace WinFormsApp8
{
    
    internal class dic
    {
        SqlConnection conn = new SqlConnection();


        public dic(string connSTR)
        {
            conn.ConnectionString= connSTR;
        }
        public DataTable returnRec (string STRSearch)
        {
            string sqlText = "select * from words where englishword like '"+STRSearch+"%'";

            DataTable t1 = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter();
            SqlCommand c1 = new SqlCommand();

            c1.CommandText = sqlText;
            c1.Connection = conn;
            da.SelectCommand = c1;

            da.Fill(t1);
            return t1;
        }

        public void EditRec(string NewVersion , string EnglishWord)
        {
            SqlCommand c1 = new SqlCommand();

            c1.CommandText = "update words set farsiword=@p1 where englishword =@p2";
            c1.Parameters.AddWithValue("p1", NewVersion);
            c1.Parameters.AddWithValue("p2", EnglishWord);
            c1.Connection= conn;

            conn.Open();
            c1.ExecuteNonQuery();
            conn.Close();
        }
    }
}
