using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

public partial class _Default : System.Web.UI.Page 
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if(!IsPostBack)
        {
            bool IsMenu = BuildMenu(GetTestMenuData());
        }
    }

    /// This is a helper method to create a MenuItem
    /// object from the specified parameters.
    MenuItem CreateMenuItem(String textField, String itemValue)
    {
        // Create a new MenuItem object.
        MenuItem menuItem = new MenuItem();

        // Set the properties of the MenuItemBinding object.
        menuItem.Selectable = true;
        menuItem.Text = textField;
        menuItem.Value = itemValue;

        return menuItem;
    }

    protected bool BuildMenu(DataSet1 data)
    {
        foreach (DataSet1.ReportsByRoleRow dRow in data.ReportsByRole.Rows)
        {
            // Create the menu item bindings for the Menu control.
            MenuItem menuItem;
            menuItem = CreateMenuItem(dRow.display_name,dRow.report_name);
            Menu1.Items.Add(menuItem);
        }
        return true;
    }

    protected DataSet1 GetMenuSourceData()
    {
        DataSet1 menudata = new DataSet1();

        menudata = GetTestMenuData();

        return menudata;
    }

    private DataSet1 GetTestMenuData()
    {
        DataSet1 menudata = new DataSet1();
        menudata.ReportsByRole.AddReportsByRoleRow("Report1", "Report 1", 1);
        menudata.ReportsByRole.AddReportsByRoleRow("Report2", "Report 2", 1);
        return menudata;
    }

}
