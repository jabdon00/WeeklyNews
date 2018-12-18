using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WeeklyNews.Business;

namespace WeeklyNews.View.Category
{
    public partial class NewCategory : System.Web.UI.Page
    {
        private CategoryBusiness categoryBusiness;
        private string editID = String.Empty;
        protected void Page_Load(object sender, EventArgs e)
        {
            categoryBusiness = new CategoryBusiness();
            editID = Request.QueryString["id"];
            if (editID != null)
                if (!IsPostBack)
                    txtTitle.Text = categoryBusiness.GetByID(long.Parse(editID)).Title;
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            if (editID != String.Empty)
                categoryBusiness.UpdateCategory(long.Parse(editID), txtTitle.Text);
            else
                categoryBusiness.AddCategory(txtTitle.Text);
            Response.Redirect("Categorys.aspx");
        }
    }
}