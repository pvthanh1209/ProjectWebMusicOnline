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
    public partial class Search : System.Web.UI.Page
    {
        DataConnection data = new DataConnection();
        protected void Page_Load(object sender, EventArgs e)
        {
            timnhac();
            timvideo();
        }
        public void timnhac()
        {
            string sql = "select * from Music,Casi,TheLoai where Casi.MaCaSi=Music.MaCaSi and Music.MaTheLoai=TheLoai.MaTheLoai and TenKhongDau like '%" + Session["txtname"] + "%'";
            data.connDB();
;            SqlDataAdapter da = new SqlDataAdapter(sql, data.conn);
            DataSet ds = new DataSet();
            da.Fill(ds);
            Music__.DataSource = ds;
            Music__.DataBind();
            data.closeDB();
        }
        public void timvideo()
        {
            string sql = "select * from Video,Casi,TheLoai where Casi.MaCaSi=Video.MaCaSi and Video.MaTheLoai=TheLoai.MaTheLoai and TenKhongDau like '%" + Session["txtname"] + "%'";
            data.connDB();
            SqlDataAdapter da = new SqlDataAdapter(sql, data.conn);
            DataSet ds = new DataSet();
            da.Fill(ds);
            Video__.DataSource = ds;
            Video__.DataBind();
            data.closeDB();
        }
    }
}