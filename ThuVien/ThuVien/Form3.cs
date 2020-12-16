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
    public partial class Form3 : Form
    {
        MongoClientSettings settings = new MongoClientSettings();

        public void LoadData()
        {
            settings.Server = new MongoServerAddress("localhost", 27017);
            MongoClient client = new MongoClient();
            var db = client.GetDatabase("QuanLyThuVien");
            var collection = db.GetCollection<SA>("Sach");
            var query = collection.AsQueryable<SA>().ToList();

            dataGridView1.DataSource = query;
        }

        public Form3()
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
            var collection = db.GetCollection<SA>("Sach");
            var query = collection.AsQueryable<SA>().ToList();

            SA s = new SA();
            s.Ten_sach = txtTensach.Text;
            s.Tac_gia = txtTacgia.Text;
            s.The_loai = txtTheloai.Text;
            s.Nha_xuat_ban = txtNxb.Text;
            s.Nam_xuat_ban = int.Parse(txtNamxb.Text);

            collection.InsertOne(s);

            txtTensach.Text = "";
            txtTacgia.Text = "";
            txtTheloai.Text = "";
            txtNxb.Text = "";
            txtNamxb.Text = txtNamxb.ToString();

            LoadData();
        }
    }

    public class SA
    {
        public ObjectId id { get; set; }
        public string Ten_sach { get; set; }
        public string Tac_gia { get; set; }
        public string The_loai { get; set; }
        public string Nha_xuat_ban { get; set; }
        public int Nam_xuat_ban { get; set; }
    }
}
