using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MusicWebOnline
{
    public partial class Login : System.Web.UI.Page
    {
        DataConnection data = new DataConnection();
        string sql = "";
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
        {
            string user = txt_user.Text;
            string pass = txt_pass.Text;
            sql = "select * from UserDaTa where TenDangNhap='" + user + "' and MatKhau='" + pass + "'";
            data.connDB();
            SqlCommand cmd = new SqlCommand(sql, data.conn);
            SqlDataReader dr = cmd.ExecuteReader();
            dr.Read();
            if(dr.HasRows == false)
            {
                Response.Write("<script>alert('Tài khoản này không tồn tại. Bạn nên kiểm tra lại')</script>");
            }
            else
            {
                string quyen = null;
                quyen = dr["MaQuyen"].ToString();
                string mQuyen = "1";
                if(quyen != mQuyen)
                {
                    Session.Add("Dangnhap", txt_user.Text);
                    Response.Redirect("admin/Admin.aspx");
                }
                else
                {
                    Session.Add("Dangnhap", txt_user.Text);
                    Response.Redirect("Home.aspx");
                }
            }
            data.closeDB();
        }
    }
}