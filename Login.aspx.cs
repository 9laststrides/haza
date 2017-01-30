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
    public partial class Login : System.Web.UI.Page
    {
        OrderBLL obj = new OrderBLL();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            User objUser = new User();
            objUser.UserName = txtUserName.Text;
            objUser.UserPwd = txtPwd.Text;

            DataSet ds = new DataSet();
            ds = obj.ViewUser(objUser);
            if (ds.Tables[0].Rows.Count > 0)
            {
                objUser.UserId=Convert.ToInt32(ds.Tables[0].Rows[0]["UserId"]);
                Session["User"] = objUser;
                Response.Redirect("View.aspx");
            }
        }
    }
}