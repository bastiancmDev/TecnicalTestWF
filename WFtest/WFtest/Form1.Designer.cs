namespace WFtest
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            browseButton = new Button();
            ordersGridView = new DataGridView();
            productsGridView = new DataGridView();
            searchOrdersTextBox = new TextBox();
            searchOrdersButton = new Button();
            nextButtonOrders = new Button();
            previewsOrdersButton = new Button();
            previousProductsButton = new Button();
            nextButtonProducts = new Button();
            searchProductsButton = new Button();
            searchProductsTextBox = new TextBox();
            saveButton = new Button();
            ((System.ComponentModel.ISupportInitialize)ordersGridView).BeginInit();
            ((System.ComponentModel.ISupportInitialize)productsGridView).BeginInit();
            SuspendLayout();
            // 
            // browseButton
            // 
            browseButton.Location = new Point(3, 1);
            browseButton.Name = "browseButton";
            browseButton.Size = new Size(153, 47);
            browseButton.TabIndex = 0;
            browseButton.Text = "LoadForm";
            browseButton.UseVisualStyleBackColor = true;
            // 
            // ordersGridView
            // 
            ordersGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            ordersGridView.Location = new Point(3, 54);
            ordersGridView.Name = "ordersGridView";
            ordersGridView.Size = new Size(470, 267);
            ordersGridView.TabIndex = 1;
            // 
            // productsGridView
            // 
            productsGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            productsGridView.Location = new Point(518, 54);
            productsGridView.Name = "productsGridView";
            productsGridView.Size = new Size(470, 267);
            productsGridView.TabIndex = 2;
            // 
            // searchOrdersTextBox
            // 
            searchOrdersTextBox.Location = new Point(8, 327);
            searchOrdersTextBox.Name = "searchOrdersTextBox";
            searchOrdersTextBox.Size = new Size(223, 23);
            searchOrdersTextBox.TabIndex = 3;
            // 
            // searchOrdersButton
            // 
            searchOrdersButton.Location = new Point(237, 327);
            searchOrdersButton.Name = "searchOrdersButton";
            searchOrdersButton.Size = new Size(75, 23);
            searchOrdersButton.TabIndex = 4;
            searchOrdersButton.Text = "Search";
            searchOrdersButton.UseVisualStyleBackColor = true;
            // 
            // nextButtonOrders
            // 
            nextButtonOrders.Location = new Point(318, 327);
            nextButtonOrders.Name = "nextButtonOrders";
            nextButtonOrders.Size = new Size(75, 23);
            nextButtonOrders.TabIndex = 5;
            nextButtonOrders.Text = "Next";
            nextButtonOrders.UseVisualStyleBackColor = true;
            // 
            // previewsOrdersButton
            // 
            previewsOrdersButton.Location = new Point(399, 327);
            previewsOrdersButton.Name = "previewsOrdersButton";
            previewsOrdersButton.Size = new Size(75, 23);
            previewsOrdersButton.TabIndex = 6;
            previewsOrdersButton.Text = "Previews";
            previewsOrdersButton.UseVisualStyleBackColor = true;
            // 
            // previousProductsButton
            // 
            previousProductsButton.Location = new Point(909, 327);
            previousProductsButton.Name = "previousProductsButton";
            previousProductsButton.Size = new Size(75, 23);
            previousProductsButton.TabIndex = 10;
            previousProductsButton.Text = "Previews";
            previousProductsButton.UseVisualStyleBackColor = true;
            // 
            // nextButtonProducts
            // 
            nextButtonProducts.Location = new Point(828, 327);
            nextButtonProducts.Name = "nextButtonProducts";
            nextButtonProducts.Size = new Size(75, 23);
            nextButtonProducts.TabIndex = 9;
            nextButtonProducts.Text = "Next";
            nextButtonProducts.UseVisualStyleBackColor = true;
            // 
            // searchProductsButton
            // 
            searchProductsButton.Location = new Point(747, 327);
            searchProductsButton.Name = "searchProductsButton";
            searchProductsButton.Size = new Size(75, 23);
            searchProductsButton.TabIndex = 8;
            searchProductsButton.Text = "Search";
            searchProductsButton.UseVisualStyleBackColor = true;
            // 
            // searchProductsTextBox
            // 
            searchProductsTextBox.Location = new Point(518, 327);
            searchProductsTextBox.Name = "searchProductsTextBox";
            searchProductsTextBox.Size = new Size(223, 23);
            searchProductsTextBox.TabIndex = 7;
            // 
            // saveButton
            // 
            saveButton.Location = new Point(455, 396);
            saveButton.Name = "saveButton";
            saveButton.Size = new Size(75, 23);
            saveButton.TabIndex = 11;
            saveButton.Text = "SAVE";
            saveButton.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1006, 431);
            Controls.Add(saveButton);
            Controls.Add(previousProductsButton);
            Controls.Add(nextButtonProducts);
            Controls.Add(searchProductsButton);
            Controls.Add(searchProductsTextBox);
            Controls.Add(previewsOrdersButton);
            Controls.Add(nextButtonOrders);
            Controls.Add(searchOrdersButton);
            Controls.Add(searchOrdersTextBox);
            Controls.Add(productsGridView);
            Controls.Add(ordersGridView);
            Controls.Add(browseButton);
            Name = "Form1";
            Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)ordersGridView).EndInit();
            ((System.ComponentModel.ISupportInitialize)productsGridView).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button browseButton;
        private DataGridView ordersGridView;
        private DataGridView productsGridView;
        private TextBox searchOrdersTextBox;
        private Button searchOrdersButton;
        private Button nextButtonOrders;
        private Button previewsOrdersButton;
        private Button previousProductsButton;
        private Button nextButtonProducts;
        private Button searchProductsButton;
        private TextBox searchProductsTextBox;
        private Button saveButton;
    }
}
