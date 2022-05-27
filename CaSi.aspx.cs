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
    public partial class Casi : System.Web.UI.Page
    {
        DataConnection data = new DataConnection();
        protected void Page_Load(object sender, EventArgs e)
        {
            videomp4();
            HienDSNhacofCasy();
            casi();
        }

        public void videomp4()
        {
            string macasi = Request.QueryString["L"].ToString();
            string sql = "select * from Video,Casi,TheLoai where Casi.MaCaSi=Video.MaCaSi and Video.MaTheLoai=TheLoai.MaTheLoai and Casi.MaCaSi='" + macasi + "'";
            data.connDB();
            SqlDataAdapter da = new SqlDataAdapter(sql, data.conn);
            DataSet ds = new DataSet();
            da.Fill(ds);
            Video__.DataSource = ds;
            Video__.DataBind();
            data.closeDB();
        }
        public void HienDSNhacofCasy()
        {
            string macasi = Request.QueryString["L"].ToString();
            string sql = "select * from Music,Casi,TheLoai where Casi.MaCaSi=Music.MaCaSi and Music.MaTheLoai=TheLoai.MaTheLoai and Casi.MaCaSi='" + macasi + "'";
            data.connDB();
            SqlDataAdapter da = new SqlDataAdapter(sql, data.conn);
            DataSet ds = new DataSet();
            da.Fill(ds);
            DataList1.DataSource = ds;
            DataList1.DataBind();
            data.closeDB();
        }
        public void casi()
        {
            string macasi = Request.QueryString["L"].ToString();
            string sql = "select * from Casi Where MaCaSi='" + macasi + "'";
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