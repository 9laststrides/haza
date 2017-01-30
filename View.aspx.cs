using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using OrderManagment.BLL;

namespace OrderManagement
{
    public partial class View : System.Web.UI.Page
    {
        OrderBLL obj = new OrderBLL();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindOrder();
            }
        }

        private void BindOrder()
        {
            grvOrder.DataSource = obj.ViewOrder(0);
            grvOrder.DataBind();
        }

        protected void grvOrder_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "cmdEdit")
            {
                Session["OrderId"] = e.CommandArgument;
                Response.Redirect("Add.aspx");
            }
            if (e.CommandName=="cmdDelete")
            {
                Session["OrderID"]=e.CommandArgument;
                Response.Redirect("Delete.aspx");
            }

        }

        protected void grvOrder_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}