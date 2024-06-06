namespace InventoryManage {
    partial class Form1 {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            txtItemName = new TextBox();
            numItemQty = new NumericUpDown();
            lblItemName = new Label();
            lblItemQty = new Label();
            lblItemCategory = new Label();
            txtItemCategory = new TextBox();
            lblItemCost = new Label();
            txtItemCost = new TextBox();
            lblTitle = new Label();
            lblItemDesc = new Label();
            txtItemDescription = new TextBox();
            btnSave = new Button();
            btnNew = new Button();
            btnDelete = new Button();
            txtItemPrice = new TextBox();
            lblItemPrice = new Label();
            dgvItemList = new DataGridView();
            txtItemProfit = new TextBox();
            label1 = new Label();
            btnEdit = new Button();
            ((System.ComponentModel.ISupportInitialize)numItemQty).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvItemList).BeginInit();
            SuspendLayout();
            // 
            // txtItemName
            // 
            txtItemName.Location = new Point(35, 116);
            txtItemName.Name = "txtItemName";
            txtItemName.PlaceholderText = "E.x, Water Bottle 500ml";
            txtItemName.Size = new Size(346, 23);
            txtItemName.TabIndex = 0;
            // 
            // numItemQty
            // 
            numItemQty.Location = new Point(35, 171);
            numItemQty.Name = "numItemQty";
            numItemQty.Size = new Size(74, 23);
            numItemQty.TabIndex = 1;
            numItemQty.ValueChanged += numItemQty_ValueChanged;
            // 
            // lblItemName
            // 
            lblItemName.AutoSize = true;
            lblItemName.ForeColor = Color.White;
            lblItemName.Location = new Point(35, 98);
            lblItemName.Name = "lblItemName";
            lblItemName.Size = new Size(66, 15);
            lblItemName.TabIndex = 2;
            lblItemName.Text = "Item Name";
            // 
            // lblItemQty
            // 
            lblItemQty.AutoSize = true;
            lblItemQty.ForeColor = Color.White;
            lblItemQty.Location = new Point(35, 153);
            lblItemQty.Name = "lblItemQty";
            lblItemQty.Size = new Size(80, 15);
            lblItemQty.TabIndex = 3;
            lblItemQty.Text = "Item Quantity";
            // 
            // lblItemCategory
            // 
            lblItemCategory.AutoSize = true;
            lblItemCategory.ForeColor = Color.White;
            lblItemCategory.Location = new Point(35, 210);
            lblItemCategory.Name = "lblItemCategory";
            lblItemCategory.Size = new Size(82, 15);
            lblItemCategory.TabIndex = 5;
            lblItemCategory.Text = "Item Category";
            // 
            // txtItemCategory
            // 
            txtItemCategory.Location = new Point(35, 228);
            txtItemCategory.Name = "txtItemCategory";
            txtItemCategory.PlaceholderText = "E.x, Drink";
            txtItemCategory.Size = new Size(346, 23);
            txtItemCategory.TabIndex = 4;
            // 
            // lblItemCost
            // 
            lblItemCost.AutoSize = true;
            lblItemCost.ForeColor = Color.White;
            lblItemCost.Location = new Point(555, 98);
            lblItemCost.Name = "lblItemCost";
            lblItemCost.Size = new Size(56, 15);
            lblItemCost.TabIndex = 7;
            lblItemCost.Text = "Unit Cost";
            // 
            // txtItemCost
            // 
            txtItemCost.Location = new Point(555, 116);
            txtItemCost.Name = "txtItemCost";
            txtItemCost.PlaceholderText = "E.x, 1.25";
            txtItemCost.Size = new Size(94, 23);
            txtItemCost.TabIndex = 8;
            txtItemCost.TextChanged += txtItemCost_TextChanged;
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("Lucida Fax", 36F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblTitle.ForeColor = Color.White;
            lblTitle.ImageAlign = ContentAlignment.TopCenter;
            lblTitle.Location = new Point(104, 9);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(755, 55);
            lblTitle.TabIndex = 9;
            lblTitle.Text = "Inventory Management Studio";
            // 
            // lblItemDesc
            // 
            lblItemDesc.AutoSize = true;
            lblItemDesc.ForeColor = Color.White;
            lblItemDesc.Location = new Point(421, 155);
            lblItemDesc.Name = "lblItemDesc";
            lblItemDesc.Size = new Size(94, 15);
            lblItemDesc.TabIndex = 11;
            lblItemDesc.Text = "Item Description";
            // 
            // txtItemDescription
            // 
            txtItemDescription.Location = new Point(421, 173);
            txtItemDescription.Multiline = true;
            txtItemDescription.Name = "txtItemDescription";
            txtItemDescription.PlaceholderText = "E.x, A 500ml bottle of drinking water";
            txtItemDescription.Size = new Size(487, 78);
            txtItemDescription.TabIndex = 10;
            // 
            // btnSave
            // 
            btnSave.BackColor = Color.LightGray;
            btnSave.FlatStyle = FlatStyle.Flat;
            btnSave.ForeColor = SystemColors.ActiveCaptionText;
            btnSave.Location = new Point(311, 305);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(90, 39);
            btnSave.TabIndex = 12;
            btnSave.Text = "Save";
            btnSave.UseVisualStyleBackColor = false;
            btnSave.Click += btnSave_Click;
            // 
            // btnNew
            // 
            btnNew.BackColor = Color.LightGray;
            btnNew.FlatStyle = FlatStyle.Flat;
            btnNew.ForeColor = SystemColors.ActiveCaptionText;
            btnNew.Location = new Point(115, 305);
            btnNew.Name = "btnNew";
            btnNew.Size = new Size(90, 39);
            btnNew.TabIndex = 13;
            btnNew.Text = "New";
            btnNew.UseVisualStyleBackColor = false;
            btnNew.Click += btnNew_Click;
            // 
            // btnDelete
            // 
            btnDelete.BackColor = Color.LightGray;
            btnDelete.FlatStyle = FlatStyle.Flat;
            btnDelete.ForeColor = SystemColors.ActiveCaptionText;
            btnDelete.Location = new Point(703, 305);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(90, 39);
            btnDelete.TabIndex = 14;
            btnDelete.Text = "Delete";
            btnDelete.UseVisualStyleBackColor = false;
            btnDelete.Click += btnDelete_Click;
            // 
            // txtItemPrice
            // 
            txtItemPrice.Location = new Point(425, 116);
            txtItemPrice.Name = "txtItemPrice";
            txtItemPrice.PlaceholderText = "E.x, 1.50";
            txtItemPrice.Size = new Size(94, 23);
            txtItemPrice.TabIndex = 16;
            txtItemPrice.TextChanged += txtItemPrice_TextChanged;
            // 
            // lblItemPrice
            // 
            lblItemPrice.AutoSize = true;
            lblItemPrice.ForeColor = Color.White;
            lblItemPrice.Location = new Point(425, 98);
            lblItemPrice.Name = "lblItemPrice";
            lblItemPrice.Size = new Size(58, 15);
            lblItemPrice.TabIndex = 15;
            lblItemPrice.Text = "Unit Price";
            // 
            // dgvItemList
            // 
            dgvItemList.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvItemList.Location = new Point(35, 399);
            dgvItemList.Name = "dgvItemList";
            dgvItemList.Size = new Size(854, 266);
            dgvItemList.TabIndex = 17;
            // 
            // txtItemProfit
            // 
            txtItemProfit.Location = new Point(685, 116);
            txtItemProfit.Name = "txtItemProfit";
            txtItemProfit.ReadOnly = true;
            txtItemProfit.Size = new Size(94, 23);
            txtItemProfit.TabIndex = 19;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.ForeColor = Color.White;
            label1.Location = new Point(685, 98);
            label1.Name = "label1";
            label1.Size = new Size(64, 15);
            label1.TabIndex = 18;
            label1.Text = "Total Profit";
            // 
            // btnEdit
            // 
            btnEdit.BackColor = Color.LightGray;
            btnEdit.FlatStyle = FlatStyle.Flat;
            btnEdit.ForeColor = SystemColors.ActiveCaptionText;
            btnEdit.Location = new Point(507, 305);
            btnEdit.Name = "btnEdit";
            btnEdit.Size = new Size(90, 39);
            btnEdit.TabIndex = 20;
            btnEdit.Text = "Edit";
            btnEdit.UseVisualStyleBackColor = false;
            btnEdit.Click += btnEdit_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(18, 18, 18);
            ClientSize = new Size(924, 720);
            Controls.Add(btnEdit);
            Controls.Add(txtItemProfit);
            Controls.Add(label1);
            Controls.Add(dgvItemList);
            Controls.Add(txtItemPrice);
            Controls.Add(lblItemPrice);
            Controls.Add(btnDelete);
            Controls.Add(btnNew);
            Controls.Add(btnSave);
            Controls.Add(lblItemDesc);
            Controls.Add(txtItemDescription);
            Controls.Add(lblTitle);
            Controls.Add(txtItemCost);
            Controls.Add(lblItemCost);
            Controls.Add(lblItemCategory);
            Controls.Add(txtItemCategory);
            Controls.Add(lblItemQty);
            Controls.Add(lblItemName);
            Controls.Add(numItemQty);
            Controls.Add(txtItemName);
            Name = "Form1";
            Text = "Form1";
            Load += Form1_Load;
            ((System.ComponentModel.ISupportInitialize)numItemQty).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgvItemList).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox txtItemName;
        private NumericUpDown numItemQty;
        private Label lblItemName;
        private Label lblItemQty;
        private Label lblItemCategory;
        private TextBox txtItemCategory;
        private Label lblItemCost;
        private TextBox txtItemCost;
        private Label lblTitle;
        private Label lblItemDesc;
        private TextBox txtItemDescription;
        private Button btnSave;
        private Button btnNew;
        private Button btnDelete;
        private TextBox txtItemPrice;
        private Label lblItemPrice;
        private DataGridView dgvItemList;
        private TextBox txtItemProfit;
        private Label label1;
        private Button btnEdit;
    }
}
