using BUS;
using DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

using System.Windows.Forms;
using System.Data.SqlClient;

namespace BanVeMayBay
{
    public partial class frm_ThongKe : Form
    {
        public frm_ThongKe()
        {
            InitializeComponent();
        }

        private void guna2ButtonTK_Click(object sender, EventArgs e)
        {
            DateTime d1 = guna2DateTimePicker1.Value;
            DateTime d2 = guna2DateTimePicker2.Value;
            HoaDonBUS hdbus=new HoaDonBUS();
            DataTable dt = new DataTable();
            DataSet ds = new DataSet();
            hdbus.ThongKe(d1, d2,dt);
            guna2DataGridView1.DataSource = dt;
            chart1.DataSource = dt;
            chart1.ChartAreas["ChartArea1"].AxisX.Title = "NgayLap";
            chart1.ChartAreas["ChartArea1"].AxisY.Title = "TongTien";
            chart1.Series[0].XValueMember = "Ngaylap";
            chart1.Series[0].YValueMembers = "TongTien";
            chart1.Series[0].XValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.Date;
            chart1.DataBind();
        }
    }
}
