using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace InventoryManagement2._0
{
    public partial class InventoryManagementStudio : Form
    {
        DataTable inventory = new DataTable();
        public InventoryManagementStudio()
        {
            InitializeComponent();
        }

        private void resetButton_Click(object sender, EventArgs e)
        {
            idTextBox.Text = "";
            nameTextBox.Text = "";
            priceTextBox.Text = "";
            descriptionTextBox.Text = "";
            quantityTextBox.Text = "";
            categoryBox.SelectedIndex = -1;

        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            // Save all values from our fields into variables
            String sku = idTextBox.Text;
            String name = nameTextBox.Text;
            String price = priceTextBox.Text;
            String description = descriptionTextBox.Text;
            String quantity = quantityTextBox.Text;
            String catagory = (string)categoryBox.SelectedItem;

            // Add these values to the datatable
            inventory.Rows.Add(sku, name, catagory, price, description, quantity);

            //Clear fields after saving
            resetButton_Click(sender, e);
        }

        private void deleteButton_Click(object sender, EventArgs e)
        {
            try
            {
                inventory.Rows[inventoryGridView.CurrentCell.RowIndex].Delete();
            }
            catch (Exception err)
            {
                Console.WriteLine("Error: " + err);
            }
        }

        private void InventoryManagementStudio_Load(object sender, EventArgs e)
        {
            inventory.Columns.Add("ID");
            inventory.Columns.Add("Name");
            inventory.Columns.Add("Category");
            inventory.Columns.Add("Price");
            inventory.Columns.Add("Description");
            inventory.Columns.Add("Quantity");

            inventoryGridView.DataSource = inventory;
        }

        private void inventoryGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                idTextBox.Text = inventory.Rows[inventoryGridView.CurrentCell.RowIndex].ItemArray[0].ToString();
                nameTextBox.Text = inventory.Rows[inventoryGridView.CurrentCell.RowIndex].ItemArray[1].ToString();
                priceTextBox.Text = inventory.Rows[inventoryGridView.CurrentCell.RowIndex].ItemArray[3].ToString();
                descriptionTextBox.Text = inventory.Rows[inventoryGridView.CurrentCell.RowIndex].ItemArray[4].ToString();
                quantityTextBox.Text = inventory.Rows[inventoryGridView.CurrentCell.RowIndex].ItemArray[5].ToString();

                String itemToLookFor = inventory.Rows[inventoryGridView.CurrentCell.RowIndex].ItemArray[2].ToString();
                categoryBox.SelectedIndex = categoryBox.Items.IndexOf(itemToLookFor);
            }
            catch (Exception err)
            {
                Console.WriteLine("There has been an error: " + err);
            }
        }
    }
}
