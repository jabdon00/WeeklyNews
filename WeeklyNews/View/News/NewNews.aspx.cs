using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WeeklyNews.Business;
using WeeklyNews.DAL;

namespace WeeklyNews.View.News
{
    public partial class NewNews : System.Web.UI.Page
    {
        private CategoryBusiness categoryBusiness = (CategoryBusiness)UnityConfig.unityContainer.Resolve(typeof(CategoryBusiness), typeof(CategoryBusiness).Name);
        private NewsBusiness newsBusiness = (NewsBusiness)UnityConfig.unityContainer.Resolve(typeof(NewsBusiness), typeof(NewsBusiness).Name);
        private string editID = String.Empty;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ddCategory.DataValueField = "Id";
                ddCategory.DataTextField = "Title";
                ddCategory.DataSource = categoryBusiness.FetchAll().ToList();
                ddCategory.DataBind();
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            byte[] uploadedImage;
            if (fuImage.HasFile)
                uploadedImage = fuImage.FileBytes;
            else
                uploadedImage = null;

            newsBusiness.AddNews(txtTitle.Text, DateTime.Parse(txtDate.Text), txtDesc.Text, uploadedImage, long.Parse(ddCategory.SelectedItem.Value));
            Response.Redirect("News");
        }
    }
}