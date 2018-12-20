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
        private byte[] editImage = null;
        protected void Page_Load(object sender, EventArgs e)
        {
            editID = Request.QueryString["id"];
            if (!IsPostBack)
            {
                ddCategory.DataValueField = "Id";
                ddCategory.DataTextField = "Title";
                ddCategory.DataSource = categoryBusiness.FetchAll().ToList();
                ddCategory.DataBind();
                if (!String.IsNullOrEmpty(editID))
                {
                    var editNews = newsBusiness.GetByID(long.Parse(editID));
                    txtTitle.Text = editNews.Title;
                    txtDate.Text = editNews.Date.ToString();
                    txtDesc.Text = editNews.Description;
                    ddCategory.SelectedValue = editNews.CategoryID.ToString();
                    editImage = editNews.Image;
                }
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            byte[] uploadedImage;
            if (fuImage.HasFile)
                uploadedImage = fuImage.FileBytes;
            else
            {
                if (editImage == null)
                    uploadedImage = null;
                else
                    uploadedImage = editImage;
            }

            if (String.IsNullOrEmpty(editID))
                newsBusiness.AddNews(txtTitle.Text, DateTime.Parse(txtDate.Text), txtDesc.Text, uploadedImage, long.Parse(ddCategory.SelectedItem.Value));
            else
                newsBusiness.UpdateNews(long.Parse(editID), txtTitle.Text, DateTime.Parse(txtDate.Text), txtDesc.Text, uploadedImage, long.Parse(ddCategory.SelectedItem.Value));
            Response.Redirect("News");
        }
    }
}