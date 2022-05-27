using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MusicWebOnline
{
    public partial class Chat : System.Web.UI.Page
    {
        DataConnection data = new DataConnection();
        protected void Page_Load(object sender, EventArgs e)
        {
            binhluan();
            nhapbinhluan();
        }

        public void binhluan()
        {
            string sql = "select * from UserDaTa,Chat where UserDaTa.MaUser=Chat.MaUsert ORDER BY NgayDang Desc";
            data.connDB();
            SqlDataAdapter da = new SqlDataAdapter(sql, data.conn);
            DataSet ds = new DataSet();
            da.Fill(ds);
            DataList_binhluan.DataSource = ds;
            DataList_binhluan.DataBind();
            data.closeDB();
        }
        public void nhapbinhluan()
        {
            if (Session["DangNhap"] != null)
            {
                string imL = null;
                string insertquery = "Select * From  UserDaTa Where TenDangNhap ='" + Session["DangNhap"] + "'";
                data.connDB();
                SqlCommand cmd = new SqlCommand(insertquery, data.conn);
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    imL = dr["Hinh"].ToString();
                    lab_tenuser.Text = dr["HoTen"].ToString();
                }
                string imgL = "img_user/" + imL;
                Image_user.ImageUrl = imgL;
                data.closeDB();
            }
        }
        protected void btn_gui_Click(object sender, EventArgs e)
        {
            if (Session["DangNhap"] != null)
            {
                string insertquery = "Select * From  UserDaTa Where TenDangNhap ='" + Session["DangNhap"] + "'";
                data.connDB();
                SqlCommand cmd = new SqlCommand(insertquery, data.conn);
                SqlDataReader dr = cmd.ExecuteReader();
                dr.Read();
                string id = dr["MaUser"].ToString();
                data.closeDB();
                xacnhan(id);
            }
            else
                Response.Redirect("Login.aspx");
        }
        public void xacnhan(string id)
        {
            DateTime ngaygio = DateTime.Now;
            string tmp = null;
            int gio = DateTime.Now.Hour;
            int phut = DateTime.Now.Minute;
            tmp = gio + ":" + phut;
            string insert = "insert into Chat (MaUsert,LoiBinh,NgayDang) Values (N'" + id + "',N'" + txt_binhluan.Text + "',N'" + ngaygio.ToString("MM/dd/yyyy") + " " + tmp + "')";
            data.connDB();
            SqlCommand cmdd = new SqlCommand(insert, data.conn);
            cmdd.ExecuteNonQuery();
            data.closeDB();
            Response.Redirect("Chat.aspx");
        }
    }
}