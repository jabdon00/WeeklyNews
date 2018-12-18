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
        protected void Page_Load(object sender, EventArgs e)
        {
            categoryBusiness = new CategoryBusiness();
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            categoryBusiness.AddCategory(TextBox1.Text);
        }
    }
}