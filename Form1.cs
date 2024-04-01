using System.IO;
using static Item;
using System.Text.Json;
using System.Reflection;

namespace InventoryManage {

    public partial class Form1 : Form {

        string itemJsonPath = @"X:\Programming\C#\InventoryManage\Data\Items.json";

        public Form1() {
            InitializeComponent();
        }

        public void emptyForm() {
            txtItemName.Text = string.Empty;
            numItemQty.Value = 0;
            txtItemCategory.Text = string.Empty;
            txtItemCost.Text = string.Empty;
            txtItemPrice.Text = string.Empty;
            txtItemProfit.Text = string.Empty;
            txtItemDescription.Text = string.Empty;
        }

        public string generateID() {
            Guid identification = Guid.NewGuid();

            return identification.ToString();
        }

        public string calculateProfit() {
            decimal profit = 0;

            if (txtItemPrice.Text != "" && txtItemCost.Text != "" && numItemQty.Value != 0) {
                profit = (decimal.Parse(txtItemPrice.Text) - decimal.Parse(txtItemCost.Text))
                    * numItemQty.Value;
            }

            return profit.ToString();
        }

        private void btnNew_Click(object sender, EventArgs e) {
            emptyForm();
        }

        private void btnSave_Click(object sender, EventArgs e) {
            decimal itemPrice, itemCost;

            if (!decimal.TryParse(txtItemPrice.Text, out itemPrice)) MessageBox.Show("Error: Item Price value must be numeric");
            else if (!decimal.TryParse(txtItemCost.Text, out itemCost)) MessageBox.Show("Error: Item Cost value must be numeric");

            else {
                Item newItem = new Item {
                    Id = generateID(),
                    Name = txtItemName.Text,
                    Quantity = (int)numItemQty.Value,
                    Category = txtItemCategory.Text,
                    Price = decimal.Parse(txtItemPrice.Text),
                    Cost = decimal.Parse(txtItemCost.Text),
                    Profit = decimal.Parse(txtItemProfit.Text),
                    Description = txtItemDescription.Text,
                };

                string ItemJSON = JsonSerializer.Serialize(newItem);

                if (!File.Exists(itemJsonPath)) {
                    using (File.Create(itemJsonPath)) { }
                }

                File.WriteAllText(itemJsonPath, ItemJSON);

                emptyForm();
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
    }
}