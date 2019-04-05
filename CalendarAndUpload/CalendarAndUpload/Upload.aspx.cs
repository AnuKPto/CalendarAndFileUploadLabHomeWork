using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using System.Web.Configuration;
using System.Data.SqlClient;
using System.Data;

public partial class Upload : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Request.QueryString["date"] != null )
        {
            DateTime date = Convert.ToDateTime(Request.QueryString["date"]);
            GetData(date);
        }
        else
        {
            Response.Redirect("Calendar.aspx");

        }
    }
    public void GetData(DateTime date)
    {
        string StrConn = WebConfigurationManager.ConnectionStrings["MyWorkConnectionString"].ConnectionString;
        using (SqlConnection ObjConn = new SqlConnection(StrConn))
        {
            ObjConn.Open();
            using (SqlCommand ObjCM = new SqlCommand())
            {
                ObjCM.Connection = ObjConn;
                ObjCM.CommandType = CommandType.StoredProcedure;
                ObjCM.CommandText = "spUploadView";
                ObjCM.Parameters.AddWithValue("@Date", date);
                SqlDataReader ObjDR = ObjCM.ExecuteReader();
                GridView1.DataSource = ObjDR;
                GridView1.DataBind();
                //ObjCM.ExecuteNonQuery(); for Update Delete Insert
            }
            ObjConn.Close();
        }
    }


    protected void Button1_Click(object sender, EventArgs e)

    {
        LabelUploaded.Visible = true;
        if (FileUpload1.HasFile && Request.QueryString["date"] != null)
        {
            string Ext = System.IO.Path.GetExtension(FileUpload1.PostedFile.FileName);
            string OldFileName = FileUpload1.FileName;
            string NewName = Guid.NewGuid().ToString();
            string cNewName = string.Format("{0}{1}", NewName, Ext);
            string Path = string.Format("Upload/{0}", cNewName);
            string cPath = Server.MapPath(Path);
            FileUpload1.SaveAs(cPath);
            DateTime Date = Convert.ToDateTime(Request.QueryString["date"]);
            InsertFileDB(OldFileName, Path,Date);
            LabelUploaded.ForeColor = System.Drawing.Color.Green;
        }
        else
        {
            LabelUploaded.Text = "กรุณาอัพโหลดไฟล์ด้วย";

        }
    }

    private void InsertFileDB(string OldFileName, string cPath, DateTime Date)
    {
        string StrConn = WebConfigurationManager.ConnectionStrings["MyWorkConnectionString"].ConnectionString;
        using (SqlConnection ObjConn = new SqlConnection(StrConn))
        {
            ObjConn.Open();
            using (SqlCommand ObjCM = new SqlCommand())
            {
                ObjCM.Connection = ObjConn;
                ObjCM.CommandType = CommandType.StoredProcedure;
                ObjCM.CommandText = "spInsertedFile";
                ObjCM.Parameters.AddWithValue("@Name", OldFileName);
                ObjCM.Parameters.AddWithValue("@FilePath", cPath);
                ObjCM.Parameters.AddWithValue("@Date", Date);
                ObjCM.ExecuteNonQuery();
            }
            ObjConn.Close();
        }
    }
}