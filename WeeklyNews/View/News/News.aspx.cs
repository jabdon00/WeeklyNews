using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WeeklyNews.Business;
using WeeklyNews.DAL;

namespace WeeklyNews.View.News
{
    public partial class News : System.Web.UI.Page
    {
        private NewsBusiness newsBusiness = (NewsBusiness)UnityConfig.unityContainer.Resolve(typeof(NewsBusiness), typeof(NewsBusiness).Name);

        protected void Page_Load(object sender, EventArgs e)
        {
            RefreshGird();

        }
        private void RefreshGird()
        {
            gvNews.DataSource = newsBusiness.FetchJoined().ToList();
            gvNews.DataBind();
        }
        public string GetImage(object img)
        {
            return img != null ? "data:image/jpg;base64," + Convert.ToBase64String((byte[])img) : "";
        }

        protected void gvNews_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int index = 0;
            GridViewRow row;
            GridView grid = sender as GridView;
            switch (e.CommandName)
            {
                case "Delete":
                    index = Convert.ToInt32(e.CommandArgument);
                    row = grid.Rows[index];

                    newsBusiness.DeleteNews(long.Parse(((HyperLink)row.Cells[0].Controls[0]).Text));

                    break;
            }
        }

        protected void gvNews_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            RefreshGird();
        }
    }
}