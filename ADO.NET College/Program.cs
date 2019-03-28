using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADO.NET_College
{
    class Program
    {
        public static string connStr = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
        public static SqlConnection conn = new SqlConnection(connStr);
        public static SqlCommand cmd = null;

        static void Main(string[] args)
        {
            InsertData();
            GetData();
            UpdateData();
            GetData();
            DeleteData();
            GetData();
        }

        public void CreateTable()
        {

            try
            {
                cmd = new SqlCommand("create table student(id int not null, name varchar(100), email varchar(50), join_date date)", conn);
                conn.Open();
                cmd.ExecuteNonQuery();
                Console.WriteLine("Table created successfully");
            }
            catch (Exception e)
            {
                Console.WriteLine("Ops, smthng went wrong." + e);
            }
            finally
            {
                conn.Close();
            }
        }
        public static void InsertData()
        {
            try
            {
                cmd = new SqlCommand("insert into student (id, name, email, join_date) values('101', 'Ronald Trump', 'dasik.osp@mail.ru', '3/12/2019')", conn);
                conn.Open();
                cmd.ExecuteNonQuery();
                Console.WriteLine("Record Inserted Successfully");
            }
            catch (Exception e)
            {
                Console.WriteLine("smth went wrong" + e);
            }
            finally
            {
                conn.Close();
            }
        }
        public static void UpdateData()
        {
            try
            {
                cmd = new SqlCommand("update student set name = 'Donald Trump' where name = 'Ronald Trump'", conn);
                conn.Open();
                cmd.ExecuteNonQuery();
                Console.WriteLine("Record updated Successfully");
            }
            catch (Exception e)
            {
                Console.WriteLine("smth went wrong" + e);
            }
            finally
            {
                conn.Close();
            }
        }
        public static void DeleteData()
        {
            try
            {
                cmd = new SqlCommand("delete from student where name = 'Donald Trump'", conn);
                conn.Open();
                cmd.ExecuteNonQuery();
                Console.WriteLine("Record deleted Successfully");
            }
            catch (Exception e)
            {
                Console.WriteLine("smth went wrong" + e);
            }
            finally
            {
                conn.Close();
            }
        }
        public static void GetData()
        {

            SqlDataReader rdr = null;

            try
            {
                conn.Open();
                cmd = new SqlCommand("select * from student", conn);
                rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    Console.WriteLine(rdr[0] + ") " + rdr[1] + " " + rdr[2] + " " + Convert.ToString(rdr[3]));
                }
            }
            finally
            {
                if (rdr != null)
                {
                    rdr.Close();
                }
                if (conn != null)
                {
                    conn.Close();
                }
            }
        }

        public static void spDeleteData()
        {
            try
            {
                conn.Open();
                cmd = new SqlCommand("spDeleteData");
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@name", SqlDbType.NVarChar).Value = "Donald";
                cmd.ExecuteNonQuery();
            }
            finally
            {
                conn.Close();
            }
        }
        public static void spGetData()
        {
            try
            {
                conn.Open();
                cmd = new SqlCommand("spGetData");
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.ExecuteNonQuery();
            }
            finally
            {
                conn.Close();
            }
        }
        public static void spUpdateData()
        {
            try
            {
                conn.Open();
                cmd = new SqlCommand("spUpdateData");
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@id", SqlDbType.Int).Value = 101;
                cmd.Parameters.Add("@name", SqlDbType.VarChar).Value = "Donald Trump";
                cmd.Parameters.Add("@email", SqlDbType.VarChar).Value = "dasik.osp@mail.ru";
                cmd.ExecuteNonQuery();
            }
            finally
            {
                conn.Close();
            }
        }
        public static void spInsertData()
        {
            try
            {
                conn.Open();
                cmd = new SqlCommand("spUpdateData");
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@id", SqlDbType.Int).Value = 999;
                cmd.Parameters.Add("@name", SqlDbType.VarChar).Value = "Diass";
                cmd.Parameters.Add("@email", SqlDbType.VarChar).Value = "Asslan@mail.ru";
                cmd.Parameters.Add("@date", SqlDbType.VarChar).Value = DateTime.Now;
                cmd.ExecuteNonQuery();
            }
            finally
            {
                conn.Close();
            }
        }
    }
}
