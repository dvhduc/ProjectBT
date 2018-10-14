using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QLNhanVien
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }
        ListViewItem itemMaNV;
        ListViewItem.ListViewSubItem itemHoTen;
        ListViewItem.ListViewSubItem itemDiaChi;
        ListViewItem.ListViewSubItem itemSDT;
        ListViewItem.ListViewSubItem itemLuong;

     

        private void lvDanhSach_SelectedIndexChanged(object sender, EventArgs e)
        {
          
            txtMaNV.Text = lvDanhSach.Items[0].Text;
            txtHoTen.Text = lvDanhSach.Items[0].SubItems[1].Text;
            if (txtMaNV.Text != "" || txtHoTen.Text != "" || txtDiaChi.Text != "" || txtSDT.Text !="")
            {
                btnCapNhap.Enabled = true;
            }
            if (txtMaNV.Text == "" || txtHoTen.Text == "" || txtDiaChi.Text == "" || txtSDT.Text == "")
            {
                btnCapNhap.Enabled = false;
            }
        }

       

        private void btnThem_Click(object sender, EventArgs e)
        {

            itemMaNV = new ListViewItem(txtMaNV.Text);
            itemHoTen = new ListViewItem.ListViewSubItem(itemMaNV, txtHoTen.Text);
            itemDiaChi = new ListViewItem.ListViewSubItem(itemMaNV, txtDiaChi.Text);
            itemSDT = new ListViewItem.ListViewSubItem(itemMaNV, txtSDT.Text);

            itemMaNV.SubItems.Add(itemHoTen);
            itemMaNV.SubItems.Add(itemDiaChi);
            itemMaNV.SubItems.Add(itemSDT);
            lvDanhSach.Items.Add(itemMaNV);

            txtMaNV.Text = "";
            txtHoTen.Text = "";
            txtDiaChi.Text = "";
            txtSDT.Text = "";
        }
    
        private void btnThoat_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void Form2_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show("Bạn có muốn thoát ?", "Thoát", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                e.Cancel = true;
        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }
    }
}
