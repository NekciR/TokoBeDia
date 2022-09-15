using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TokoBeDia.Controllers;
using TokoBeDia.Models;
using TokoBeDia.Repositories;

namespace TokoBeDia.Views
{
    public partial class ViewUser : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {
                BindGridList();
            }
            if (Session["user"] != null)
            {

                if (!isAdmin())
                {
                    Response.Redirect("home.aspx");
                }
                LbName.Text = (Session["user"] as Users).Name;

            }
            else
            {
                Response.Redirect("home.aspx");
            }



        }

        protected void BindGridList()
        {
            List<Users> userList = UserController.GetAllUser();

            GvUserList.DataSource = userList;
            
            GvUserList.DataBind();

        }

        protected bool isAdmin()
        {
            return (Session["user"] as Users).Roles.Name == "Administrator" ? true : false;
        }


        protected void GvUserList_RowDataBound(object sender, GridViewRowEventArgs e)
        {

            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                int id = Convert.ToInt32(e.Row.Cells[0].Text);

                e.Row.Cells[4].Text = RoleController.getRoleById(id).ToString();

                List<Roles> roleList = RoleController.GetAllRole();
                DropDownList ddlRole = (e.Row.FindControl("ddlRole") as DropDownList);
                if ((Session["user"] as Users).ID == id)
                {
                    ddlRole.Enabled = false;
                }


                ddlRole.DataSource = roleList;
                ddlRole.DataTextField = "Name";
                ddlRole.DataValueField = "ID";
                ddlRole.DataBind();
                ddlRole.SelectedValue = RoleController.getRoleById(id).ToString();




                DropDownList ddlStatus = (e.Row.FindControl("ddlStatus") as DropDownList);
                if ((Session["user"] as Users).ID == id)
                {
                    ddlStatus.Enabled = false;
                }

                List<string> statusList = new List<string>()
                {
                    "Active","Banned"
                };

                ddlStatus.DataSource = statusList;
                ddlStatus.DataBind();
                ddlStatus.SelectedValue = UserController.GetUserStatusById(id);




            }

        }

        protected void ddlRole_SelectedIndexChanged(object sender, EventArgs e)
        {
            DropDownList ddl = (DropDownList)sender;
            GridViewRow row = (GridViewRow)ddl.Parent.Parent;
            int idx = row.RowIndex;
            int userId = int.Parse(row.Cells[0].Text);
            int roleId = int.Parse(ddl.SelectedValue);


            if ((Session["user"] as Users).ID != userId)
            {
                Users a = UserController.UpdateUserRole(userId, roleId);
            }
            BindGridList();


            //Debug.WriteLine(userId);
            //Debug.WriteLine(roleId);
            //if (a != null)
            //{
            //    Debug.WriteLine(a.Name);
            //    Debug.WriteLine(a.Roles.Name);
            //}


        }

        protected void ddlStatus_SelectedIndexChanged(object sender, EventArgs e)
        {

            DropDownList ddl = (DropDownList)sender;
            GridViewRow row = (GridViewRow)ddl.Parent.Parent;
            int idx = row.RowIndex;
            int userId = int.Parse(row.Cells[0].Text);
            string status = ddl.SelectedValue;


            if ((Session["user"] as Users).ID != userId)
            {
                Users a = UserController.UpdateUserStatus(userId, status);
            }
            BindGridList();



        }
    }
}