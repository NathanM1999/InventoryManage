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
            txtItemDescription.Text = string.Empty;
        }

        public string generateID() {
            Guid identification = Guid.NewGuid();

            return identification.ToString();
        }

        private void btnNew_Click(object sender, EventArgs e) {
            emptyForm();
        }

        private void btnSave_Click(object sender, EventArgs e) {
            Item newItem = new Item {
                Id = generateID(),
                Name = txtItemName.Text,
                Quantity = (int)numItemQty.Value,
                Category = txtItemCategory.Text,
                Price = Int32.Parse(txtItemPrice.Text),
                Cost = Int32.Parse(txtItemCost.Text),
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
}
