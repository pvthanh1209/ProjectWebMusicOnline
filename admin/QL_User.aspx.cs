using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MusicWebOnline.admin
{
    public partial class QL_User : System.Web.UI.Page
    {
        DataConnection data = new DataConnection();
        protected void Page_Load(object sender, EventArgs e)
        {
            string act = null;
            if (Session["DangNhap"] == null)
                Response.Redirect("~/login.aspx");
            if (Request.QueryString.HasKeys())
            {
                act = Request.QueryString["Us"].ToString();
            }
            switch (act)
            {
                case "Xem":
                    MultiView1.ActiveViewIndex = 0;
                    break;

                case "Them":
                    MultiView1.ActiveViewIndex = 1;
                    break;

                default:
                    break;
            }
        }

        protected void btn_xoa_user_Click(object sender, EventArgs e)
        {
            string insertquery = "Delete From  UserDaTa Where MaUser ='" + txt_xoa_user.Text + "'";
            SqlCommand cmd = new SqlCommand(insertquery, data.conn);
            data.connDB();
            cmd.ExecuteNonQuery();
            data.closeDB();
            Response.Write("<script>alert('Xóa Thành Công')</script>");
            Response.Redirect("QL_User.aspx?Us=Xem");
        }

        protected void btn_add_user_Click(object sender, EventArgs e)
        {
            string username = txt_add_user.Text;
            string password = txt_add_pass.Text;
            string ten = txt_add_ten.Text;
            string gioitinh = Drop_Gioitinh.SelectedValue.ToString();
            int maquyen = 1;
            string th = Drop_thang.SelectedValue.ToString();
            string ng = Drop_ngay.SelectedValue.ToString();
            string nam = txt_namsinh.Text;
            string ns = th + "/" + ng + "/" + nam;
            string email = txt_add_mail.Text;
            string mail = Drop_mail.SelectedValue.ToString();
            string m = email + "@" + mail;
            string hochieu = txt_add_chungminh.Text;
            String filePath = "~/img_user/" + FileUp_hinhuser.FileName;
            FileUp_hinhuser.SaveAs(MapPath(filePath));
            if (password.Length >= 6)
            {
                string insert = "insert into UserDaTa (TenDangNhap,MatKhau,MaQuyen,HoTen,CMT,Email,Hinh,Gioitinh,NamSinh) Values (N'" + username + "',N'" + password + "',N'" + maquyen + "',N'" + ten + "',N'" + hochieu + "',N'" + m + "',N'" + FileUp_hinhuser.FileName + "',N'" + gioitinh + "',N'" + ns + "')";
                data.connDB();
                SqlCommand cmdd = new SqlCommand(insert, data.conn);
                cmdd.ExecuteNonQuery();
                data.closeDB();
                Response.Redirect("QL_User.aspx?Us=Xem");
            }
            else
                Response.Write("<script>alert('Mật khẩu quá ngắn')</script>");
        }
    }
}