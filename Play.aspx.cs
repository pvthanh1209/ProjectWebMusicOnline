using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;

namespace MusicWebOnline
{
    public partial class Play : System.Web.UI.Page
    {
        DataConnection data = new DataConnection();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                playnhac();
                Tenbaihat();
            }
        }

        public void playnhac()
        {
            //string M = null;
            if (Request.QueryString.HasKeys())
            {
                string M = Request.QueryString["M"].ToString();
                string sql = "select * from Music where MaBaiHat='" + M + "'";
                data.connDB();
                SqlCommand cmd = new SqlCommand(sql, data.conn);
                SqlDataReader dr = cmd.ExecuteReader();
                dr.Read();
                int LuotXem = dr["LuotXem"].GetHashCode();
                int LuotXem2 = Convert.ToInt32(LuotXem);
                int LuotXem3 = LuotXem2 + 1;
                string tencakhuc = dr["TenFile"].ToString();
                string song_url = "/AudioPlayer/audio/" + tencakhuc;
                data.closeDB();
                Play__.InnerHtml = "<audio preload='auto' controls><source src='" + song_url + "'></audio>	";
                Play__.InnerHtml += "<script src='/AudioPlayer/js/jquery.js'></script>";
                Play__.InnerHtml += "<script src='/AudioPlayer/js/audioplayer.js'></script>";
                Play__.InnerHtml += "<script>$(function () { $('audio').audioPlayer(); });</script>";
                update(LuotXem3);
            }
        }
        public void update(int LuotXem3)
        {
            string M = Request.QueryString["M"].ToString();
            string updatequery = "Update  Music Set LuotXem =N'" + LuotXem3 + "' Where MaBaiHat ='" + M + "'";
            data.connDB();
            SqlCommand cmd = new SqlCommand(updatequery, data.conn);
            cmd.ExecuteNonQuery();
            data.closeDB();
        }
        public void Tenbaihat()
        {
            string M = null;
            if (Request.QueryString.HasKeys())
            {
                M = Request.QueryString["M"].ToString();
                data.connDB();
                string Baihat = null;
                string Casi = null;
                string TheLoai = null;
                string macasi = null;
                string sql = "select * from Music,Casi,TheLoai where Casi.MaCaSi=Music.MaCaSi and Music.MaTheLoai=TheLoai.MaTheLoai and MaBaiHat='" + M + "'";
                SqlCommand cmd = new SqlCommand(sql, data.conn);
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    Baihat = dr["TenBaiHat"].ToString();
                    Casi = dr["TenCaSi"].ToString();
                    TheLoai = dr["TenTheLoai"].ToString();
                    macasi = dr["MaCaSi"].ToString();
                }
                lblTenCaKhuc.Text = Baihat;
                lblCasy.Text = Casi;
                lblTheLoai.Text = TheLoai;
                Lab_casi.Text = Casi;
                data.closeDB();
                baihatlienquan(macasi);
            }
        }
        public void baihatlienquan(string macasi)
        {

            string sql = "select * from Music,Casi,TheLoai where Casi.MaCaSi=Music.MaCaSi and Music.MaTheLoai=TheLoai.MaTheLoai and Casi.MaCaSi ='" + macasi + "' order by LuotXem desc";
            data.connDB();
            SqlDataAdapter da = new SqlDataAdapter(sql, data.conn);
            DataSet ds = new DataSet();
            da.Fill(ds);
            Music__.DataSource = ds;
            Music__.DataBind();
            data.closeDB();
        }

    }
}