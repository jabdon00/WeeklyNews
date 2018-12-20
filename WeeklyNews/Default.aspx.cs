using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WeeklyNews.Business;
using WeeklyNews.DAL;

namespace WeeklyNews
{
    public partial class _Default : Page
    {
        private NewsBusiness newsBusiness = (NewsBusiness)UnityConfig.unityContainer.Resolve(typeof(NewsBusiness), typeof(NewsBusiness).Name);
        public string GetImage(object img)
        {
            return img != null ? "data:image/jpg;base64," + Convert.ToBase64String((byte[])img) : "";
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            gvTopFive.DataSource = newsBusiness.FetchTopFive();
            gvTopFive.DataBind();
        }
    }
}