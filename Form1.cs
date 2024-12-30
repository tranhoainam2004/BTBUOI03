using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BTBUOI03
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            string lastName = txtLastName.Text;
            string firstName = txtFirstName.Text;
            string phone = txtPhone.Text;

            if (string.IsNullOrWhiteSpace(lastName) || string.IsNullOrWhiteSpace(firstName) || string.IsNullOrWhiteSpace(phone))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            ListViewItem item = new ListViewItem(lastName);
            item.SubItems.Add(firstName);
            item.SubItems.Add(phone);
            lvDetails.Items.Add(item);


        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Size = new Size(670, 429);
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (lvDetails.CheckedItems.Count > 0)
            {

                foreach (ListViewItem item in lvDetails.CheckedItems)
                {
                    lvDetails.Items.Remove(item);
                    MessageBox.Show("Thông tin của bạn đã được xóa!", "Thông tin", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                MessageBox.Show("Vui lòng chọn một ô để xóa!", "Thông tin", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (lvDetails.CheckedItems.Count > 0)
            {
                ListViewItem selectedItem = lvDetails.CheckedItems[0];

                if (!string.IsNullOrEmpty(txtLastName.Text) && !string.IsNullOrEmpty(txtFirstName.Text) && !string.IsNullOrEmpty(txtPhone.Text))
                {
                    selectedItem.SubItems[0].Text = txtLastName.Text;
                    selectedItem.SubItems[1].Text = txtFirstName.Text;
                    selectedItem.SubItems[2].Text = txtPhone.Text;

                    MessageBox.Show("Thông tin đã được cập nhật!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    txtLastName.Text = selectedItem.SubItems[0].Text;
                    txtFirstName.Text = selectedItem.SubItems[1].Text;
                    txtPhone.Text = selectedItem.SubItems[2].Text;

                    MessageBox.Show("Vui lòng sửa thông tin và nhấn 'Edit' để lưu.", "Thông tin", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                MessageBox.Show("Chọn ít nhất một mục với checkbox để sửa!", "Thông tin", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void label7_Click(object sender, EventArgs e)
        {

        }
    }
}
