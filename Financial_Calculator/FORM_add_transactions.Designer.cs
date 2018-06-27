namespace Financial_Calculator
{
    partial class FORM_add_transactions
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.uxTextBox_transaction_file_location = new System.Windows.Forms.TextBox();
            this.uxButton_Browse = new System.Windows.Forms.Button();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.uxParseTransactions = new System.Windows.Forms.Button();
            this.uxTransactionList = new System.Windows.Forms.ListView();
            this.uxTransactionsToDatabase = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // uxTextBox_transaction_file_location
            // 
            this.uxTextBox_transaction_file_location.Location = new System.Drawing.Point(79, 58);
            this.uxTextBox_transaction_file_location.Margin = new System.Windows.Forms.Padding(2);
            this.uxTextBox_transaction_file_location.Name = "uxTextBox_transaction_file_location";
            this.uxTextBox_transaction_file_location.Size = new System.Drawing.Size(405, 20);
            this.uxTextBox_transaction_file_location.TabIndex = 0;
            // 
            // uxButton_Browse
            // 
            this.uxButton_Browse.Location = new System.Drawing.Point(11, 54);
            this.uxButton_Browse.Margin = new System.Windows.Forms.Padding(2);
            this.uxButton_Browse.Name = "uxButton_Browse";
            this.uxButton_Browse.Size = new System.Drawing.Size(64, 26);
            this.uxButton_Browse.TabIndex = 1;
            this.uxButton_Browse.Text = "Browse";
            this.uxButton_Browse.UseVisualStyleBackColor = true;
            this.uxButton_Browse.Click += new System.EventHandler(this.uxButton_Browse_Click);
            // 
            // uxParseTransactions
            // 
            this.uxParseTransactions.Location = new System.Drawing.Point(488, 54);
            this.uxParseTransactions.Margin = new System.Windows.Forms.Padding(2);
            this.uxParseTransactions.Name = "uxParseTransactions";
            this.uxParseTransactions.Size = new System.Drawing.Size(121, 26);
            this.uxParseTransactions.TabIndex = 2;
            this.uxParseTransactions.Text = "Parse Transactions";
            this.uxParseTransactions.UseVisualStyleBackColor = true;
            this.uxParseTransactions.Click += new System.EventHandler(this.uxParseTransactions_Click);
            // 
            // uxTransactionList
            // 
            this.uxTransactionList.Location = new System.Drawing.Point(12, 85);
            this.uxTransactionList.Name = "uxTransactionList";
            this.uxTransactionList.Size = new System.Drawing.Size(966, 748);
            this.uxTransactionList.TabIndex = 3;
            this.uxTransactionList.UseCompatibleStateImageBehavior = false;
            // 
            // uxTransactionsToDatabase
            // 
            this.uxTransactionsToDatabase.Enabled = false;
            this.uxTransactionsToDatabase.Location = new System.Drawing.Point(788, 843);
            this.uxTransactionsToDatabase.Name = "uxTransactionsToDatabase";
            this.uxTransactionsToDatabase.Size = new System.Drawing.Size(190, 23);
            this.uxTransactionsToDatabase.TabIndex = 4;
            this.uxTransactionsToDatabase.Text = "Copy Transactions To Database";
            this.uxTransactionsToDatabase.UseVisualStyleBackColor = true;
            this.uxTransactionsToDatabase.Click += new System.EventHandler(this.uxTransactionsToDatabase_Click);
            // 
            // FORM_add_transactions
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(990, 878);
            this.Controls.Add(this.uxTransactionsToDatabase);
            this.Controls.Add(this.uxTransactionList);
            this.Controls.Add(this.uxParseTransactions);
            this.Controls.Add(this.uxButton_Browse);
            this.Controls.Add(this.uxTextBox_transaction_file_location);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "FORM_add_transactions";
            this.Text = "Form2";
            this.Load += new System.EventHandler(this.FORM_add_transactions_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox uxTextBox_transaction_file_location;
        private System.Windows.Forms.Button uxButton_Browse;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Button uxParseTransactions;
        private System.Windows.Forms.ListView uxTransactionList;
        private System.Windows.Forms.Button uxTransactionsToDatabase;
    }
}