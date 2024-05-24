using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QLSV
{
    internal class DBConnection
    {


        private static DBConnection instance;
        public static DBConnection Instance
        {
            get { if (instance == null) instance = new DBConnection(); return DBConnection.instance; }
            private set => DBConnection.instance = value;
        }

        public string ConnectionSTR { get => connectionSTR; set => connectionSTR = value; }

        static string connectionSTR = "Data Source=localhost;Initial Catalog=QLSV;Integrated Security=True";

        public  void DangNhap(string user, string pass)

        // Data Source=Tlocalhost;Initial Catalog=QLSV;Persist Security Info=True;User ID=sa;Password=12345
        {
            ConnectionSTR = "Data Source = localhost; Initial Catalog = QLSV;Integrated Security=True; User ID = " + user+"; Password = " + pass;
        }  

        public DataTable ExecuteQuery(string query, object[] parameter = null)
        {

            DataTable data = new DataTable();
            
            using (SqlConnection connection = new SqlConnection(ConnectionSTR))
            {
                connection.Open();

                SqlCommand command = new SqlCommand(query, connection);

                if (parameter != null)
                {
                    string[] listPara = query.Split(' ');
                    int i = 0;
                    foreach (string item in listPara)
                    {
                        if (item.Contains("@"))
                        {
                            command.Parameters.AddWithValue(item, parameter[i++]);
                        }
                    }
                }

                SqlDataAdapter adapter = new SqlDataAdapter(command);

                adapter.Fill(data);

                connection.Close();

                return data;
            }
        }

        public int ExecuteNonQuery(string query, object[] parameter = null)
        {

            int data = 0;

            using (SqlConnection connection = new SqlConnection(ConnectionSTR))
            {
                connection.Open();

                SqlCommand command = new SqlCommand(query, connection);

                if (parameter != null)
                {
                    string[] listPara = query.Split(' ');
                    int i = 0;
                    foreach (string item in listPara)
                    {
                        if (item.Contains("@"))
                        {
                            command.Parameters.AddWithValue(item, parameter[i++]);
                        }
                    }
                }
                data = command.ExecuteNonQuery();
                connection.Close();

                return data;
            }
        }
        public void Use_PROC(string query, object[] parameter = null)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionSTR))
            {
                connection.Open();

                SqlCommand command = new SqlCommand(query, connection);

                if (parameter != null)
                {
                    string[] listPara = query.Split(' ');
                    int i = 0;
                    foreach (string item in listPara)
                    {
                        if (item.Contains("@"))
                        {
                            command.Parameters.AddWithValue(item, parameter[i++]);
                        }
                    }
                }
               command.ExecuteNonQuery();
                connection.Close();
            }
        }

        public object ExecuteScalar(string query, object[] parameter = null)
        {

            object data = 0;

            using (SqlConnection connection = new SqlConnection(ConnectionSTR))
            {
                connection.Open();

                SqlCommand command = new SqlCommand(query, connection);

                if (parameter != null)
                {
                    string[] listPara = query.Split(' ');
                    int i = 0;
                    foreach (string item in listPara)
                    {
                        if (item.Contains("@"))
                        {
                            command.Parameters.AddWithValue(item, parameter[i++]);
                        }
                    }
                }
                data = command.ExecuteScalar();
                connection.Close();

                return data;
            }
        }

       





        public SqlConnection conn = new SqlConnection();
        public void ThucThi(string sqlStr)
        {
             conn = new SqlConnection(ConnectionSTR);
            try
            {
                MessageBox.Show(connectionSTR);
                conn.Open();
                SqlCommand cmd = new SqlCommand(sqlStr, conn);
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Message");
            }
            finally
            {
                conn.Close();
            }
        }
        public DataTable FormLoad(string sqlStr)
        {
             conn = new SqlConnection(ConnectionSTR);
            DataTable dataSet = new DataTable();
            try
            {
                conn.Open();
                SqlDataAdapter adapter = new SqlDataAdapter(sqlStr, conn);
                adapter.Fill(dataSet);
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message);
                return null;
            }
            finally
            {
                conn.Close();
            }
            return dataSet;
        }
        public object GetItem(string sqlStr)
        {
            conn = new SqlConnection(ConnectionSTR);
            object result = new object();
            try
            {
                conn.Open();
                SqlCommand command = new SqlCommand(sqlStr, conn);
                result = command.ExecuteScalar();
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message);
            }
            finally
            {
                conn.Close();
            }
            return result;
        }
    }
}
