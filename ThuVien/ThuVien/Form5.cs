using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MongoDB.Bson;
using MongoDB.Driver;

namespace ThuVien
{
    public partial class Form5 : Form
    {
        MongoClientSettings settings = new MongoClientSettings();

        public void LoadData()
        {
            settings.Server = new MongoServerAddress("localhost", 27017);
            MongoClient client = new MongoClient();
            var db = client.GetDatabase("QuanLyThuVien");
            var collection = db.GetCollection<PM>("PhieuMuon");
            var query = collection.AsQueryable<PM>().ToList();

            dataGridView1.DataSource = query;
        }

        public Form5()
        {
            InitializeComponent();
            LoadData();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            settings.Server = new MongoServerAddress("localhost", 27017);
            MongoClient client = new MongoClient();
            var db = client.GetDatabase("QuanLyThuVien");
            var collection = db.GetCollection<PM>("PhieuMuon");
            var query = collection.AsQueryable<PM>().ToList();

            PM p = new PM();
            p.Nguoi_muon = txtNguoimuon.Text;
            p.Ten_sach = txtTensach.Text;
            p.Ngay_muon = txtNgaymuon.Text;
            p.Ngay_tra = txtNgaytra.Text;

            collection.InsertOne(p);

            txtNguoimuon.Text = "";
            txtTensach.Text = "";
            txtNgaymuon.Text = "";
            txtNgaytra.Text = "";

            LoadData();
        }
    }

    public class PM
    {
        public ObjectId id { get; set; }
        public string Nguoi_muon { get; set; }
        public string Ten_sach { get; set; }
        public string Ngay_muon { get; set; }
        public string Ngay_tra { get; set; }
    }
}
