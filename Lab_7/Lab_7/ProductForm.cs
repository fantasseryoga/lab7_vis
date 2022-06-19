using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace Lab_7
{
    public partial class ProductForm : Form
    {
        StorageModel storage;
        public ProductForm(/*StorageModel storage*/)
        {
            this.storage = new StorageModel();
            InitializeComponent();
            storage.Products.Load();
            productBindingSource.DataSource = storage.Products.Local.ToBindingList();
        }

        private void productBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            productBindingSource.EndEdit();
            storage.SaveChanges();
        }

        private void imagePictureBox_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            
            openFileDialog.Filter = "jpg|*jpg|png|*.png|bmp|*.bmp";
            openFileDialog.Title = "Loading Product Image";
            openFileDialog.FileOk += OpenFileDialog_FileOk;

            openFileDialog.ShowDialog();
        }

        private void OpenFileDialog_FileOk(object sender, CancelEventArgs e)
        {
            imagePictureBox.Image = Image.FromFile((sender as OpenFileDialog).FileName);
        }

        private void priceTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(e.KeyChar >= '0' && e.KeyChar <= '9' || e.KeyChar == '\b'))
                e.Handled = true;
            if (e.KeyChar == '.')
            {
                if ((sender as TextBox).Text.Contains("."))
                    e.Handled = true;
                else
                    e.Handled = false;
            }
        }

     
    }
}
