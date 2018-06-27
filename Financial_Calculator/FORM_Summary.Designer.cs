namespace Financial_Calculator
{
    partial class FORM_Summary
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
            this.uxButton_add_transactions = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // uxButton_add_transactions
            // 
            this.uxButton_add_transactions.Location = new System.Drawing.Point(32, 1142);
            this.uxButton_add_transactions.Name = "uxButton_add_transactions";
            this.uxButton_add_transactions.Size = new System.Drawing.Size(162, 35);
            this.uxButton_add_transactions.TabIndex = 0;
            this.uxButton_add_transactions.Text = "Add Transactions";
            this.uxButton_add_transactions.UseVisualStyleBackColor = true;
            this.uxButton_add_transactions.Click += new System.EventHandler(this.uxButton_add_transactions_Click);
            // 
            // FORM_Summary
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(951, 1274);
            this.Controls.Add(this.uxButton_add_transactions);
            this.Name = "FORM_Summary";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button uxButton_add_transactions;
    }
}

