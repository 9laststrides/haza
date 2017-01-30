using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using OrderManagment.BLL;
using OrderManagment.BO;
using System.Data;

namespace OrderManagement
{
    public partial class Add : System.Web.UI.Page
    {
        OrderBLL obj = new OrderBLL();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["User"] == null)
                {
                    Response.Redirect("Login.aspx");

                }
                else
                {
                    if (Session["OrderId"] != null)
                    {
                        BindById(Convert.ToInt32(Session["OrderId"]));
                    }
                }
            }
        }

        private void BindById(int id)
        {
            DataSet ds = new DataSet();
            ds = obj.ViewOrder(id);
            if (ds.Tables[0].Rows.Count > 0)
            {
                txtProductName.Text = Convert.ToString(ds.Tables[0].Rows[0]["ProductName"]);
                txtDate.Text = Convert.ToString(ds.Tables[0].Rows[0]["OrderDate"]);
            }
           
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            OrderDetails objOrder = new OrderDetails();
            User objUser = (User)Session["User"];
            if (Session["OrderId"] != null)
            {
                objOrder.OrderID = Convert.ToInt32(Session["OrderId"]);
            }
            else
            {
                objOrder.OrderID = 0;
            }
            objOrder.UserId = objUser.UserId;
            objOrder.ProductName = txtProductName.Text;
            objOrder.OrderDate = txtDate.Text;

            int addresult = obj.AddOrder(objOrder);
            Response.Redirect("View.aspx");

        }
    }
}