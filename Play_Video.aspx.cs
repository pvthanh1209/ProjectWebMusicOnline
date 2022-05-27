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
    public partial class Play_Video : System.Web.UI.Page
    {
        DataConnection data = new DataConnection();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                Tenvideo();
                showVideo();


            }
        }

        public void showVideo()
        {
            string V = null;
            if (Request.QueryString.HasKeys())
            {
                V = Request.QueryString["V"].ToString();
                string sql = "select * from Video where MaVideo='" + V + "'";
                data.connDB();
                SqlCommand cmd = new SqlCommand(sql, data.conn);
                SqlDataReader dr = cmd.ExecuteReader();
                dr.Read();
                string tenvideo = dr["TenFile"].ToString();
                string hinhvideo = dr["Hinh"].ToString();
                string video_img = "../MusicWebOnline/img_video/" + hinhvideo;
                string video_mp4 = "/img_video/" + tenvideo;
                // string video_webm = "../MusicWebOnline/video-js/" + tenvideo + ".webm";
                //string video_ogv = "../MusicWebOnline/video-js/" + tenvideo + ".ogv";
                data.closeDB();
                Play__.InnerHtml = "<video id='example_video_1' class='video-js vjs-default-skin' controls preload='none' width='100%' height='310' poster='" + video_img + "' data-setup='{}'>";
                Play__.InnerHtml += "<source src='" + video_mp4 + "' type='video/mp4'>";
                Play__.InnerHtml += "<track kind='captions' src='/video-js/demo.captions.vtt' srclang='en' label='English'></track>";
                Play__.InnerHtml += "<track kind='subtitles' src='/video-js/demo.captions.vtt' srclang='en' label='English'></track>";
                Play__.InnerHtml += "</video>";
            }
        }
        public void Tenvideo()
        {
            string V = null;
            if (Request.QueryString.HasKeys())
            {
                V = Request.QueryString["V"].ToString();
                data.connDB();
                string video = null;
                string Casi = null;
                string TheLoai = null;
                string macasi = null;
                string sql = "select * from Video,Casi,TheLoai where Casi.MaCaSi=Video.MaCaSi and Video.MaTheLoai=TheLoai.MaTheLoai and MaVideo='" + V + "'";
                SqlCommand cmd = new SqlCommand(sql, data.conn);
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    video = dr["TenVideo"].ToString();
                    Casi = dr["TenCaSi"].ToString();
                    TheLoai = dr["TenTheLoai"].ToString();
                    macasi = dr["MaCaSi"].ToString();
                }
                lblTenvideo.Text = video;
                lblCasy.Text = Casi;
                lblTheLoai.Text = TheLoai;
                Lab_casi.Text = Casi;
                data.closeDB();
                videolienquan(macasi);
            }
        }
        public void videolienquan(string macasi)
        {
            string sql = "select * from Video,Casi,TheLoai where Casi.MaCaSi=Video.MaCaSi and Video.MaTheLoai=TheLoai.MaTheLoai and Casi.MaCaSi ='" + macasi + "' order by LuotXem desc";
            data.connDB();
            SqlDataAdapter da = new SqlDataAdapter(sql, data.conn);
            DataSet ds = new DataSet();
            da.Fill(ds);
            Video__.DataSource = ds;
            Video__.DataBind();
            data.closeDB();
            //showVideo();
        }

    }
}