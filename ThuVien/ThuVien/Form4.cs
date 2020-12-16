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
    public partial class Form4 : Form
    {

        MongoClientSettings settings = new MongoClientSettings();

        public void LoadData()
        {
            settings.Server = new MongoServerAddress("localhost", 27017);
            MongoClient client = new MongoClient();
            var db = client.GetDatabase("QuanLyThuVien");
            var collection = db.GetCollection<NV>("NhanVien");
            var query = collection.AsQueryable<NV>().ToList();

            dataGridView1.DataSource = query;
        }

        public Form4()
        {
            InitializeComponent();
            LoadData();
        }

        private void label4_Click(object sender, EventArgs e)
        {

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
            var collection = db.GetCollection<NV>("NhanVien");
            var query = collection.AsQueryable<NV>().ToList();

            NV n = new NV();
            n.HoTen = txtHoten.Text;
            n.Ngay_sinh = txtNgaysinh.Text;
            n.SDT = txtSdt.Text;
            n.Luong = int.Parse(txtLuong.Text);

            collection.InsertOne(n);

            txtHoten.Text = "";
            txtNgaysinh.Text = "";
            txtSdt.Text = "";
            txtLuong.Text = "";
            txtSdt.Text = txtSdt.ToString();

            LoadData();
        }
    }

    public class NV
    {
        public ObjectId id { get; set; }
        public string HoTen { get; set; }
        public string Ngay_sinh { get; set; }
        public string SDT { get; set; }
        public int Luong { get; set; }
    }
}
