using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WeeklyNews.Business;

namespace WeeklyNews.View.Category
{
    public partial class Categorys : System.Web.UI.Page
    {
        private CategoryBusiness categoryBusiness;
        protected void Page_Load(object sender, EventArgs e)
        {
            categoryBusiness = new CategoryBusiness();
            gvCategory.DataSource = categoryBusiness.ListView().ToList();
            gvCategory.DataBind();

        }

        protected void gvCategory_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int index = 0;
            GridViewRow row;
            GridView grid = sender as GridView;
            switch (e.CommandName)
            {
                case "Delete":
                    index = Convert.ToInt32(e.CommandArgument);
                    row = grid.Rows[index];

                    categoryBusiness.DeleteCategory(long.Parse(row.Cells[0].Text));
                    
                    break;
            }
        }
    
    }
}