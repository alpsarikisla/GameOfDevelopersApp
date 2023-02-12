using DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GameOfDevelopersBlog
{
    public partial class Default : System.Web.UI.Page
    {
        DataModel dm = new DataModel();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString.Count == 0)
            {
                rp_makaleler.DataSource = dm.MakaleListele(true);
                rp_makaleler.DataBind();
            }
            else
            {
                int id = Convert.ToInt32(Request.QueryString["kid"]);
                rp_makaleler.DataSource = dm.MakaleListele(id, true);
                rp_makaleler.DataBind();
            }
        }
    }
}