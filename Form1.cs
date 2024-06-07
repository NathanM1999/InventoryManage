using System.Data;
using System.Text.Json.Nodes;
using System.Windows.Forms;
using Newtonsoft.Json;
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

        private void overrideEntry() {
            string json = File.ReadAllText(itemJsonPath);
            JArray jsonArray = JArray.Parse(json);

            if (dgvItemList.SelectedCells.Count == 0) {
                MessageBox.Show("Error: Nothing Selected");
                return;
            }

            string edtItem = dgvItemList.SelectedRows[0].Cells[0].Value.ToString();


            for (int i = 0; i < jsonArray.Count; i++) {
                JObject currentItem = (JObject)jsonArray[i];

                if (currentItem["Id"] != null) {
                    string currentItemId = currentItem["Id"].ToString();


                    if (currentItemId == edtItem) {

                        if (currentItem["Name"] != null) currentItem["Name"] = txtItemName.Text;
                        if (currentItem["Quantity"] != null) currentItem["Quantity"] = int.Parse(numItemQty.Value.ToString());
                        if (currentItem["Category"] != null) currentItem["Category"] = txtItemCategory.Text;
                        if (currentItem["Price"] != null) currentItem["Price"] = decimal.Parse(txtItemPrice.Text);
                        if (currentItem["Cost"] != null) currentItem["Cost"] = decimal.Parse(txtItemCost.Text);
                        if (currentItem["Profit"] != null) currentItem["Profit"] = decimal.Parse(txtItemProfit.Text);
                        if (currentItem["Description"] != null) currentItem["Description"] = txtItemDescription.Text;



                        File.WriteAllText(itemJsonPath, jsonArray.ToString());
                        MessageBox.Show("Item updated successfully.");
                        emptyForm();

                        break;

                    }
                }
            }
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

                refreshGrid();
                emptyForm();
            }
        }

        private void btnDelete_Click(object sender, EventArgs e) {
            string json = File.ReadAllText(itemJsonPath);
            JArray jsonArray = JArray.Parse(json);

            if (dgvItemList.SelectedCells.Count == 0) {
                MessageBox.Show("Error: Nothing Selected");
                return;
            }

            string dltItem = dgvItemList.SelectedRows[0].Cells[0].Value.ToString();
            bool itemFound = false;

            for (int i = 0; i < jsonArray.Count; i++) {
                JObject currentItem = (JObject)jsonArray[i];


                if (currentItem["Id"] != null) {

                    string currentItemId = currentItem["Id"].ToString();

                    if (currentItemId == dltItem) {
                        jsonArray.RemoveAt(i);
                        json = jsonArray.ToString();

                        File.WriteAllText(itemJsonPath, json);

                        if (int.Parse(currentItem["Quantity"].ToString()) > 1) MessageBox.Show(currentItem["Name"] + "(s) deleted successfully.");
                        else MessageBox.Show(currentItem["Name"] + " deleted successfully.");

                        itemFound = true;
                        refreshGrid();

                        break;
                    }
                }
            }
        }

        private void btnEdit_Click(object sender, EventArgs e) {

            //Select item from DVG
            string itemName = dgvItemList.CurrentRow.Cells[1].Value.ToString();
            int itemQuantity = int.Parse(dgvItemList.CurrentRow.Cells[2].Value.ToString());
            string itemCategory = dgvItemList.CurrentRow.Cells[3].Value.ToString();
            decimal itemPrice = decimal.Parse(dgvItemList.CurrentRow.Cells[4].Value.ToString());
            decimal itemCost = decimal.Parse(dgvItemList.CurrentRow.Cells[5].Value.ToString());
            decimal itemProfit = decimal.Parse(dgvItemList.CurrentRow.Cells[6].Value.ToString());
            string itemDescription = dgvItemList.CurrentRow.Cells[7].Value.ToString();

            //Populate fields with the data
            txtItemName.Text = itemName;
            numItemQty.Value = itemQuantity;
            txtItemCategory.Text = itemCategory;
            txtItemPrice.Text = itemPrice.ToString();
            txtItemCost.Text = itemCost.ToString();
            txtItemProfit.Text = itemProfit.ToString();
            txtItemDescription.Text = itemDescription;
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

        private void btnSaveEdit_Click(object sender, EventArgs e) {

            //Override the previous entry with the new entry
            DialogResult userChoice = MessageBox.Show("Are you sure you want to override this entry?", "Override", MessageBoxButtons.YesNo);

            if (userChoice == DialogResult.Yes) overrideEntry();

            //Refresh Grid
            refreshGrid();
        }
    }
}