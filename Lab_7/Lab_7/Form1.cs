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

namespace Lab_7
{
    public partial class Form1 : Form
    {
        StorageModel StorageModel;// = new StorageModel();
        public Form1()
        {
            InitializeComponent();
            Load += Form1_Load;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
           StorageModel=new StorageModel();
            StorageModel.Waybills.Load();
            waybillBindingSource.DataSource=StorageModel.Waybills.Local.ToBindingList();

            StorageModel.Products.Load();
            productBindingSource.DataSource = StorageModel.Products.Local.ToBindingList();

            StorageModel.Providers.Load();
            providerBindingSource.DataSource = StorageModel.Providers.Local.ToBindingList();

        }

        private void productToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                ProductForm productForm = new ProductForm();
                productForm.ShowDialog();
                StorageModel.Products.Load();
            }
            catch (Exception ex)
            { }
        } 

        private void providerToolStripMenuItem_Click(object sender, EventArgs e)
        { 
            ProviderForm providerForm = new ProviderForm(); 
            providerForm.ShowDialog();
            StorageModel.Providers.Load();
        }

        //private void waybillsToolStripMenuItem_Click(object sender, EventArgs e)
        //{
        //    WaybillsForm waybillsForm = new WaybillsForm(StorageModel);
        //    waybillsForm.ShowDialog();
          
        //}

        private void waybillBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            waybillBindingSource.EndEdit();
            StorageModel.SaveChanges();
        }

        private void bindingNavigatorAddNewItem_Click(object sender, EventArgs e)
        {
            providerComboBox.SelectedIndex = -1;
            productComboBox.SelectedIndex = -1; 
        }

        private void providerComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
