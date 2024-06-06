using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.IO;
using System.Data;
using static Item;
using System.Text.Json;
using Newtonsoft.Json;
using System.Windows.Forms;
using Newtonsoft.Json.Linq;


namespace InventoryManage {

    public partial class Form1 : Form {

        //Absolute path to Items.JSON
        //Change this to relative path
        string itemJsonPath = @"X:\Programming\C#\InventoryManage\Data\Items.json";

        public Form1() {
            InitializeComponent();
        }

        public void refreshGrid() {
            if (File.Exists(itemJsonPath)) {
                string itemJson = File.ReadAllText(itemJsonPath);

                if (itemJson != null) {
                    dgvItemList.DataSource = JsonConvert.DeserializeObject<DataTable>(itemJson);
                }
            }
        }

        //Method to empty all user input textboxes
        public void emptyForm() {
            txtItemName.Text = string.Empty;
            numItemQty.Value = 0;
            txtItemCategory.Text = string.Empty;
            txtItemCost.Text = string.Empty;
            txtItemPrice.Text = string.Empty;
            txtItemProfit.Text = string.Empty;
            txtItemDescription.Text = string.Empty;
        }

        //Method to calculate profit for a record
        //profit = (price - cost) * quantity
        public string calculateProfit() {
            decimal profit = 0;

            if (txtItemPrice.Text != "" && txtItemCost.Text != "" && numItemQty.Value != 0) {
                profit = (decimal.Parse(txtItemPrice.Text) - decimal.Parse(txtItemCost.Text))
                    * numItemQty.Value;
            }

            return profit.ToString();
        }

        //Upon the form loading, import data from JSON and display it
        private void Form1_Load(object sender, EventArgs e) {
            refreshGrid();
        }

        private void btnNew_Click(object sender, EventArgs e) {
            emptyForm();
        }

        private void btnSave_Click(object sender, EventArgs e) {
            decimal itemPrice, itemCost;
            Guid identification = Guid.NewGuid();

            //If price or cost aren't decimal values, show an error
            if (!decimal.TryParse(txtItemPrice.Text, out itemPrice)) MessageBox.Show("Error: Item Price value must be numeric");
            else if (!decimal.TryParse(txtItemCost.Text, out itemCost)) MessageBox.Show("Error: Item Cost value must be numeric");

            else {
                Item newItem = new Item {
                    Id = identification.ToString(),
                    Name = txtItemName.Text,
                    Quantity = (int)numItemQty.Value,
                    Category = txtItemCategory.Text,
                    Price = decimal.Parse(txtItemPrice.Text),
                    Cost = decimal.Parse(txtItemCost.Text),
                    Profit = decimal.Parse(txtItemProfit.Text),
                    Description = txtItemDescription.Text,
                };

                string itemsJSON = File.ReadAllText(itemJsonPath);
                string json = JsonConvert.SerializeObject(newItem);

                if (itemsJSON.Length == 0) {
                    itemsJSON = "[" + json + "]";
                } else {
                    itemsJSON.TrimEnd(']');
                    itemsJSON = itemsJSON.Replace("]", ",") + json + "]";
                }

                File.WriteAllText(itemJsonPath, itemsJSON);

                emptyForm();
                refreshGrid();
            }
        }

        private void btnDelete_Click(object sender, EventArgs e) {
            string json = File.ReadAllText(itemJsonPath);
            JArray jsonArray = JArray.Parse(json);

            if (dgvItemList.SelectedCells.Count == 0) {
                MessageBox.Show("Error: Nothing Selected");
                return;
            }

            string dltItem = dgvItemList.SelectedCells[0].Value.ToString();
            bool itemFound = false;

            for (int i = 0; i < jsonArray.Count; i++) {
                JObject currentItem = (JObject)jsonArray[i];

                
                if (currentItem["Id"] != null) {
                    
                    string currentItemId = currentItem["Id"].ToString();

                    if (currentItemId == dltItem) {
                        jsonArray.RemoveAt(i);
                        json = jsonArray.ToString();
                    
                        File.WriteAllText(itemJsonPath, json); 
                        
                        if (Int32.Parse(currentItem["Quantity"].ToString()) > 1) MessageBox.Show(currentItem["Name"] + "(s) deleted successfully.");
                        else MessageBox.Show(currentItem["Name"] + " deleted successfully.");
                        
                        itemFound = true;
                        refreshGrid();
                        
                        break;
                    }
                } else {
                    MessageBox.Show("Error: Item not found", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

            if (!itemFound) {
                MessageBox.Show("Error: Item not found", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }




        private void txtItemPrice_TextChanged(object sender, EventArgs e) {
            txtItemProfit.Text = calculateProfit();
        }

        private void txtItemCost_TextChanged(object sender, EventArgs e) {
            txtItemProfit.Text = calculateProfit();
        }

        private void numItemQty_ValueChanged(object sender, EventArgs e) {
            txtItemProfit.Text = calculateProfit();
        }
          
        private void btnTest_Click(object sender, EventArgs e) {

        }
    }
}