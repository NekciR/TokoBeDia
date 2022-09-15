using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TokoBeDia.Controllers;
using TokoBeDia.Handlers;
using TokoBeDia.Models;

namespace TokoBeDia.Views
{
    public partial class ViewTransaction : System.Web.UI.Page
    {
        int userId;
        protected void Page_Load(object sender, EventArgs e)
        {

            
            if (!IsPostBack)
            {
                AdminControl.Visible = false;
                if (Session["user"] != null)
                {
                    LbName.Text = (Session["user"] as Users).Name;
                    userId = (Session["user"] as Users).ID;

                    if (isAdmin())
                    {
                        AdminControl.Visible = true;
                    }
                    else
                    {
                        AdminControl.Visible = false;
                    }
                }

                BindGridList();
            }

        }

        protected void BindGridList()
        {
            if (isAdmin())
            {
                GvViewTransaction.DataSource = TransactionController.GetTransaction();
            }else
            {
                GvViewTransaction.DataSource = TransactionController.GetTransaction(userId);
            }
            
            GvViewTransaction.DataBind();
        }


        protected bool isAdmin()
        {
            return (Session["user"] as Users).Roles.Name == "Administrator" ? true : false;
        }

    }
}