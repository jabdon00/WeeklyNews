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
            gvNews.DataSource = newsBusiness.FetchJoined().ToList();
            gvNews.DataBind();

        }

    }
}