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
    public partial class Form2 : Form
    {

        MongoClientSettings settings = new MongoClientSettings();

        public void LoadData()
        {
            settings.Server = new MongoServerAddress("localhost", 27017);
            MongoClient client = new MongoClient();
            var db = client.GetDatabase("QuanLyThuVien");
            var collection = db.GetCollection<SV>("SinhVien");
            var query = collection.AsQueryable<SV>().ToList();

            dataGridView1.DataSource = query;
        }

        public Form2()
        {
            InitializeComponent();
            LoadData();
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            settings.Server = new MongoServerAddress("localhost", 27017);
            MongoClient client = new MongoClient();
            var db = client.GetDatabase("QuanLyThuVien");
            var collection = db.GetCollection<SV>("SinhVien");
            var query = collection.AsQueryable<SV>().ToList();

            SV s = new SV();
            s.Ho_ten = txthoten.Text;
            s.Tuoi = int.Parse(txtTuoi.Text);
            s.Lop = txtLop.Text;
            s.Khoa = txtKhoa.Text;

            collection.InsertOne(s);

            txthoten.Text = "";
            txtTuoi.Text = txtTuoi.ToString();
            txtLop.Text = "";
            txtKhoa.Text = "";

            LoadData();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }

    public class SV
    {
        public ObjectId id { get; set; }
        public string Ho_ten { get; set; }
        public int Tuoi { get; set; }
        public string Lop { get; set; }
        public string Khoa { get; set; }
    }
}
