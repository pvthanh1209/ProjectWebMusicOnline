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
    public partial class ThongTin : System.Web.UI.Page
    {
        DataConnection data = new DataConnection();
        protected void Page_Load(object sender, EventArgs e)
        {
            string act = null;
            if (Request.QueryString.HasKeys())
            {
                act = Request.QueryString["TT"].ToString();
            }
            switch (act)
            {
                case "Album":
                    album();
                    break;
                case "Music":
                    musicmp3();
                    break;
                case "Video":
                    videomp4();
                    break;
                case "NgheSi":
                    casi();
                    break;

                default:
                    break;
            }
        }
        public void musicmp3()
        {
            string sql = "select top 10* from Music,Casi,TheLoai where Casi.MaCaSi=Music.MaCaSi and Music.MaTheLoai=TheLoai.MaTheLoai ORDER BY NgayDang Desc";
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
        public void casi()
        {
            string sql = "select * from Casi ORDER BY YeuThich Desc";
            data.connDB();
            SqlDataAdapter da = new SqlDataAdapter(sql, data.conn);
            DataSet ds = new DataSet();
            da.Fill(ds);
            NgheSi__.DataSource = ds;
            NgheSi__.DataBind();
            data.closeDB();
        }
    }
}