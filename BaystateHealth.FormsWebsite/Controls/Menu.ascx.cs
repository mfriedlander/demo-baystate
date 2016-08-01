using System;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BaystateHealth.FormsWebsite.Controls
{
    public partial class Menu1 : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string[] times = new string[]
            {
                "1",
                "2",
                "3"
            };

            rptTimes.DataSource = times;
            rptTimes.DataBind();
        }

        protected void rptTimes_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == System.Web.UI.WebControls.ListItemType.Item || e.Item.ItemType == System.Web.UI.WebControls.ListItemType.AlternatingItem)
            {
                string data = e.Item.DataItem as string;
                Literal litTime = (Literal)e.Item.FindControl("litTime");
                litTime.Text = data;
            }
        }

        // Frank, give me a call back


        //protected void rptTime_ItemDataBound()
    }
}