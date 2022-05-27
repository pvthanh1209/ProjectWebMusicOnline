using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MusicWebOnline
{
    public partial class QL_Music : System.Web.UI.Page
    {
        DataConnection data = new DataConnection();
        protected void Page_Load(object sender, EventArgs e)
        {
            string act = null;
            if (Session["DangNhap"] == null)
                Response.Redirect("~/login.aspx");
            if (Request.QueryString.HasKeys())
            {
                act = Request.QueryString["Ms"].ToString();
            }
            switch (act)
            {
                case "Xem":
                    MultiView1.ActiveViewIndex = 0;
                    break;

                case "Sua":
                    MultiView1.ActiveViewIndex = 1;
                    break;

                case "Them":
                    MultiView1.ActiveViewIndex = 2;
                    break;

                default:
                    break;
            }
        }

        protected void btn__Click(object sender, EventArgs e)
        {
            string tim = txt_.Text;
            string insertquery = "Select * From  Music Where MaBaiHat ='" + tim + "'";
            data.connDB();
            SqlCommand cmd = new SqlCommand(insertquery, data.conn);
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                txt_tenbaihat.Text = dr["TenBaiHat"].ToString();
                txt_matheloai.Text = dr["MaTheLoai"].ToString();
                txt_manhacsi.Text = dr["MaNhacSi"].ToString();
                txt_macasi.Text = dr["MaCaSi"].ToString();
                txt_maalbum.Text = dr["MaAlbum"].ToString();
                txt_noidung.Text = dr["NoiDung"].ToString();
                txt_tenkhongdau.Text = dr["TenKhongDau"].ToString();
            }
        }
        protected void btn_add_Click(object sender, EventArgs e)
        {
            string updatequery = "Update  Music Set TenBaiHat=N'" + txt_tenbaihat.Text + "',MaTheLoai=N'" + txt_matheloai.Text + "',MaNhacSi=N'" + txt_manhacsi.Text + "',MaCaSi=N'" + txt_macasi.Text + "',MaAlbum=N'" + txt_maalbum.Text + "',NoiDung=N'" + txt_noidung.Text + "',TenKhongDau=N'" + txt_tenkhongdau.Text + "' Where MaBaiHat ='" + txt_.Text + "'";
            data.connDB();
            SqlCommand cmd = new SqlCommand(updatequery, data.conn);
            cmd.ExecuteNonQuery();
            data.closeDB();
            Response.Redirect("QL_Music.aspx?Ms=Xem");
        }
        protected void btn_xoa_Click(object sender, EventArgs e)
        {
            string insertquery = "Delete From  Music Where MaBaiHat ='" + txt_xoa.Text + "'";
            SqlCommand cmd = new SqlCommand(insertquery, data.conn);
            data.connDB();
            cmd.ExecuteNonQuery();
            data.closeDB();
            Response.Write("<script>alert('Xóa Thành Công')</script>");
            Response.Redirect("QL_Music.aspx?Ms=Xem");
        }
        protected void btn_add_music_Click(object sender, EventArgs e)
        {
            int luotxem = 0;
            string tmp = null;
            int d = DateTime.Now.Day;
            int m = DateTime.Now.Month;
            int y = DateTime.Now.Year;
            tmp = DateTime.Now.DayOfWeek.ToString();
            // String filePath = "MusicWeb/AudioPlayer/audio/" + FileUpload_nhac.FileName;
            //FileUpload_nhac.SaveAs(MapPath(filePath));
            string insert = "insert into Music (MaTheLoai,MaNhacSi,MaCaSi,MaAlbum,TenBaiHat,TenFile,NoiDung,NgayDang,LuotXem,TenKhongDau) Values (N'" + txt_add_matheloai.Text + "',N'" + txt_add_manhacsi.Text + "',N'" + txt_add_macasi.Text + "',N'" + txt_add_maalbum.Text + "',N'" + txt_add_tenbaihat.Text + "',N'" + FileUpload_nhac.FileName + "',N'" + txt_add_noidung.Text + "',N'" + tmp + "',N'" + luotxem + "',N'" + txt_add_tenkhongdau.Text + "')";
            data.connDB();
            SqlCommand cmd = new SqlCommand(insert, data.conn);
            cmd.ExecuteNonQuery();
            data.closeDB();
            //Response.Redirect("QL_Music.aspx?Ms=Xem");
        }
        bool CheckFileType(string fileName)
        {
            string ext = Path.GetExtension(fileName);
            switch (ext.ToLower())
            {
                case ".mp3":
                    return true;
                default:
                    return false;
            }
        }
    }
}