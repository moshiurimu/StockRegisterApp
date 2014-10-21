using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using StockRegisterApp.BLL;
using StockRegisterApp.DAL.DAO;

namespace StockRegisterApp
{
    public partial class ProductEntryUI : Form
    {
        private ProductBLL aProductBll= new ProductBLL();
        private Product aProduct;
        private List<Product> products;
        public ProductEntryUI()
        {
            InitializeComponent();
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            aProduct = new Product(productCodeTextBox.Text, productNameTextBox.Text, Convert.ToInt32(quentityTextBox.Text));
            string msg = aProductBll.Save(aProduct);
            MessageBox.Show(msg);
        }

        private void viewAllButton_Click(object sender, EventArgs e)
        {
            ShowAllProductInGrid();
            totalQuentityTextBox.Text= aProductBll.GetTotalQuentity().ToString();
        }


        private void ShowAllProductInGrid()
        {

            products = aProductBll.ShowAllProductInGrid();
            productListGridView.DataSource = products;
        }

        
    }
}
