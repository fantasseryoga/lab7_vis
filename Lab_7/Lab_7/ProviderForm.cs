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
    public partial class ProviderForm : Form
    {
        StorageModel storage;
        public ProviderForm(/*StorageModel storage*/)
        {
            this.storage = new StorageModel();
            InitializeComponent();
            storage.Providers.Load();
            providerBindingSource.DataSource = storage.Providers.Local.ToBindingList();
        }

        private void providerBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {

            providerDataGridView.EndEdit();
            providerBindingSource.EndEdit();
            storage.SaveChanges();
        }
    }
}
