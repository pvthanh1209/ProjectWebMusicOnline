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
    public partial class Home : System.Web.UI.Page
    {
        DataConnection data = new DataConnection();
        protected void Page_Load(object sender, EventArgs e)
        {
            musicmp3();
            videomp4();
            album();
            HienBH();
            binhluan();
            nhapbinhluan();
        }

        public void musicmp3()
        {
            string sql = "select top 20* from Music,Casi,TheLoai where Casi.MaCaSi=Music.MaCaSi and Music.MaTheLoai=TheLoai.MaTheLoai ORDER BY NgayDang Desc";
            data.connDB();
            SqlDataAdapter da = new SqlDataAdapter(sql, data.conn);
            DataSet ds = new DataSet();
            da.Fill(ds);
            Music__.DataSource = ds;
            Music__.DataBind();
            data.closeDB();
        }
        public void videomp4()
        {
            string sql = "select * from Video,Casi,TheLoai where Casi.MaCaSi=Video.MaCaSi and Video.MaTheLoai=TheLoai.MaTheLoai ";
            data.connDB();
            SqlDataAdapter da = new SqlDataAdapter(sql, data.conn);
            DataSet ds = new DataSet();
            da.Fill(ds);
            Video__.DataSource = ds;
            Video__.DataBind();
            data.closeDB();
        }
        public void album()
        {
            string sql = "select * from Album";
            data.connDB();
            SqlDataAdapter da = new SqlDataAdapter(sql, data.conn);
            DataSet ds = new DataSet();
            da.Fill(ds);
            Album__.DataSource = ds;
            Album__.DataBind();
            data.closeDB();
        }
        public void HienBH()
        {
            string sql = "select * from Music order by LuotXem desc";
            data.connDB();
            SqlDataAdapter da = new SqlDataAdapter(sql, data.conn);
            DataSet ds = new DataSet();
            da.Fill(ds);
            DataList1.DataSource = ds;
            DataList1.DataBind();
            data.closeDB();
        }
        public void binhluan()
        {
            string sql = "select * from UserDaTa,BinhLuan where UserDaTa.MaUser=BinhLuan.MaUser ORDER BY NgayDang Desc";
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
            string insert = "insert into BinhLuan (MaUser,LoiBinh,NgayDang) Values (N'" + id + "',N'" + txt_binhluan.Text + "',N'" + ngaygio.ToString("MM/dd/yyyy") + " " + tmp + "')";
            data.connDB();
            SqlCommand cmdd = new SqlCommand(insert, data.conn);
            cmdd.ExecuteNonQuery();
            data.closeDB();
            Response.Redirect("Home.aspx");
        }

    }
}