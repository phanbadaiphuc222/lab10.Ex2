using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Drawing;
using System.Diagnostics;

namespace Student
{
    public partial class wfrStudent : System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                loadData();
            }
        }

        protected void loadData()
        {
            clsDatabase.OpenConnection();
            SqlDataAdapter sqlDa = new SqlDataAdapter("select masv, tensv, phai, lop from sinhvien", clsDatabase.con);
            DataTable dt = new DataTable();
            sqlDa.Fill(dt);
            grvStudent.DataSource = dt;
            grvStudent.DataBind();
        }

        protected void grvStudent_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            grvStudent.PageIndex = e.NewPageIndex;
            loadData();
        }

        protected void grvStudent_RowEditing(object sender, GridViewEditEventArgs e)
        {
            //NewEditIndex property used to determine the index of the row being edited.  
            grvStudent.EditIndex = e.NewEditIndex;
            loadData();
        }

        protected void grvStudent_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {

            String id = Convert.ToString(e.NewValues["masv"]);
            String name = Convert.ToString(e.NewValues["tensv"]);
            String clss = Convert.ToString(e.NewValues["lop"]);
            int gender = Convert.ToInt32(e.NewValues["phai"]);
            clsDatabase.OpenConnection();

            Debug.Print(gender.ToString());

            SqlCommand cmd = new SqlCommand("update sinhvien set " +
                "tensv = @name, " +
                "lop = @clss, " +
                "phai = @gender" +
                " where masv = @id", clsDatabase.con);
            cmd.Parameters.AddWithValue("clss", clss);
            cmd.Parameters.AddWithValue("name", name);
            cmd.Parameters.AddWithValue("id", id);
            cmd.Parameters.AddWithValue("gender", gender);
            cmd.ExecuteNonQuery();
            clsDatabase.CloseConnection();
            grvStudent.EditIndex = -1;
            loadData();
        }


        protected void grvStudent_OnRowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            String id = grvStudent.Rows[e.RowIndex].Cells[1].Text;
            clsDatabase.OpenConnection();

            SqlCommand query = new SqlCommand("delete from sinhvien where masv = @id", clsDatabase.con);
            query.Parameters.AddWithValue("id", id);
            query.ExecuteNonQuery();

            clsDatabase.CloseConnection();
            loadData();
        }

        protected void grvStudent_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            grvStudent.EditIndex = -1;
            loadData();
        }

        protected void grvStudent_OnSelectedIndexChange(object sender, GridViewSelectEventArgs e)
        {
            grvStudent.DataKeys[e.NewSelectedIndex].Value.ToString();
        }

        protected void grvStudent_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataSet ds = new DataSet();

            String res = grvStudent.SelectedDataKey.Value.ToString();

            int CodeImmo = Convert.ToInt32(res);
            String query = "select masv as " +
                "'Mã Sinh Viên', " +
                "tensv as 'Tên Sinh Viên'," +
                " phai as 'Phái'," +
                " lop as 'Lớp', " +
                "sdt as 'Số Điện Thoại', " +
                "email as 'Email' from sinhvien where masv = '" + CodeImmo + "'";
            SqlDataAdapter da = new SqlDataAdapter(query, clsDatabase.con);
            da.Fill(ds, "test");

            grvStudent2.DataSource = ds.Tables["test"];
            grvStudent2.DataBind();
        }
    }
}