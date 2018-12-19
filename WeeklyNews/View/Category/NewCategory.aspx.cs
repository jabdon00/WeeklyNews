using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WeeklyNews.Business;
using WeeklyNews.DAL;

namespace WeeklyNews.View.Category
{
    public partial class NewCategory : System.Web.UI.Page
    {
        private CategoryBusiness categoryBusiness = (CategoryBusiness)UnityConfig.unityContainer.Resolve(typeof(CategoryBusiness), typeof(CategoryBusiness).Name);
        private string editID = String.Empty;
        protected void Page_Load(object sender, EventArgs e)
        {
            editID = Request.QueryString["id"];
            if (editID != null)
                if (!IsPostBack)
                    txtTitle.Text = categoryBusiness.GetByID(long.Parse(editID)).Title;
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(editID))
                categoryBusiness.UpdateCategory(long.Parse(editID), txtTitle.Text);
            else
                categoryBusiness.AddCategory(txtTitle.Text);
            Response.Redirect("Categorys.aspx");
        }
    }
}