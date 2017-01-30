using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using OrderManagment.BO;

namespace OrderManagment.DAL
{
    public class OrderDAL
    {
        SqlConnection cnn;
        SqlCommand cmd;
        string conString;

        void Connnection()
        {
            conString = ConfigurationManager.ConnectionStrings["cnn"].ConnectionString;
            cnn = new SqlConnection(conString);
            cmd = new SqlCommand();
            cmd.Connection = cnn;
        }
        public int AddOrder(OrderDetails objOrder)
        {
            Connnection();
            cmd.CommandText = "usp_Insert_Update_tbl_Order";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@OrderID", objOrder.OrderID);
            cmd.Parameters.AddWithValue("@ProductName", objOrder.ProductName);
            cmd.Parameters.AddWithValue("@UserId", objOrder.UserId);
            cmd.Parameters.AddWithValue("@OrderDate", Convert.ToDateTime(objOrder.OrderDate));
            cnn.Open();
            int addRes = cmd.ExecuteNonQuery();
            cnn.Close();
            return addRes;
        }
        public DataSet ViewOrder(int id)
        {
            Connnection();
            cmd.CommandText = "usp_SearchSelect_Order";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@OrderID", id);
            DataSet ds = new DataSet();
            cnn.Open();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(ds);
            cnn.Close();
            return ds;
        }
        public DataSet ViewUser(User objUser)
        {
            Connnection();
            cmd.CommandText = "usp_UserDetails";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@UserName", objUser.UserName);
            cmd.Parameters.AddWithValue("@Password", objUser.UserPwd);
            DataSet ds = new DataSet();
            cnn.Open();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(ds);
            cnn.Close();
            return ds;
        }



    }
}
