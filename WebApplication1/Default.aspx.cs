using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication1
{
    public partial class _Default : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(this.DropDown.Items.Count == 0)
            {
                this.DropDown.Items.Add(new ListItem("全て", "0"));
                this.DropDown.Items.Add(new ListItem("果物", "1"));
                this.DropDown.Items.Add(new ListItem("野菜", "2"));
                this.DropDown.Items.Add(new ListItem("精肉", "3"));
            }

            //var dt = new DataTable();
            //dt.Columns.Add("DATE");
            //dt.Columns.Add("BMCD");
            //dt.Columns.Add("ORNM");

            var list = new List<Dto>();

            list.Add(new Dto { DATE = "202001", BMCD = "1", ORNM = "店９" });
            list.Add(new Dto { DATE = "202002", BMCD = "2", ORNM = "店８" });
            list.Add(new Dto { DATE = "202003", BMCD = "3", ORNM = "店７" });
            list.Add(new Dto { DATE = "202003", BMCD = "4", ORNM = "店６" });
            list.Add(new Dto { DATE = "202003", BMCD = "5", ORNM = "店５" });
            list.Add(new Dto { DATE = "202003", BMCD = "6", ORNM = "店４" });
            list.Add(new Dto { DATE = "202003", BMCD = "7", ORNM = "店３" });
            list.Add(new Dto { DATE = "202003", BMCD = "8", ORNM = "店２" });
            list.Add(new Dto { DATE = "202003", BMCD = "9", ORNM = "店１" });

            this.GridList.DataSource = list;
            this.GridList.DataBind();

            if (Session["SortDirection"] == null)
            {
                Session["SortDirection"] = SortDirection.Descending;
                Session["SortExpression"] = "BMCD";
            }

        }

        protected void DropDown_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                var selectedId = int.Parse(this.DropDown.SelectedValue);

            } catch(Exception ex)
            {
                Response.Write(ex);
            }
        }



        private class Dto
        {
            public string DATE { get; set; }

            public string BMCD { get; set; }

            public string ORNM { get; set; }
        }

        protected void GridList_Sorting(object sender, GridViewSortEventArgs e)
        {

            var sortDirection = (SortDirection) Session["SortDirection"];

            var list = GridList.DataSource as List<Dto>;
            if (sortDirection == SortDirection.Ascending)
            {
                GridList.DataSource = list.OrderByDescending(x => typeof(Dto).GetProperty(e.SortExpression).GetValue(x)).ToList();
                sortDirection = SortDirection.Descending;
            }
            else
            {
                GridList.DataSource = list.OrderBy(x => typeof(Dto).GetProperty(e.SortExpression).GetValue(x)).ToList();
                sortDirection = SortDirection.Ascending;
            }

            Session["SortExpression"] = e.SortExpression;
            Session["SortDirection"] = sortDirection;

            GridList.DataBind();
        }

        public SortDirection direction
        {
            get
            {
                if (ViewState["directionState"] == null)
                {
                    ViewState["directionState"] = SortDirection.Ascending;
                }
                return (SortDirection)ViewState["directionState"];
            }
            set
            {
                ViewState["directionState"] = value;
            }
        }
    }
}