namespace StipePaymentDotNet48
{
    partial class frm_Main
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
            this.button_Payment_by_Card = new System.Windows.Forms.Button();
            this.button_Payment_by_Customer = new System.Windows.Forms.Button();
            this.button_Retrieve_All_Card = new System.Windows.Forms.Button();
            this.button_Create_Customer = new System.Windows.Forms.Button();
            this.button_Add_New_Card = new System.Windows.Forms.Button();
            this.button_Delete_Card = new System.Windows.Forms.Button();
            this.button_Update_Card = new System.Windows.Forms.Button();
            this.button_Payment_By_PayNow = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // button_Payment_by_Card
            // 
            this.button_Payment_by_Card.Location = new System.Drawing.Point(12, 12);
            this.button_Payment_by_Card.Name = "button_Payment_by_Card";
            this.button_Payment_by_Card.Size = new System.Drawing.Size(310, 25);
            this.button_Payment_by_Card.TabIndex = 0;
            this.button_Payment_by_Card.Text = "Payment by Card";
            this.button_Payment_by_Card.UseVisualStyleBackColor = true;
            this.button_Payment_by_Card.Click += new System.EventHandler(this.button_Payment_by_Card_Click);
            // 
            // button_Payment_by_Customer
            // 
            this.button_Payment_by_Customer.Location = new System.Drawing.Point(12, 74);
            this.button_Payment_by_Customer.Name = "button_Payment_by_Customer";
            this.button_Payment_by_Customer.Size = new System.Drawing.Size(310, 25);
            this.button_Payment_by_Customer.TabIndex = 1;
            this.button_Payment_by_Customer.Text = "Payment by Customer";
            this.button_Payment_by_Customer.UseVisualStyleBackColor = true;
            this.button_Payment_by_Customer.Click += new System.EventHandler(this.button_Payment_by_Customer_Click);
            // 
            // button_Retrieve_All_Card
            // 
            this.button_Retrieve_All_Card.Location = new System.Drawing.Point(12, 105);
            this.button_Retrieve_All_Card.Name = "button_Retrieve_All_Card";
            this.button_Retrieve_All_Card.Size = new System.Drawing.Size(310, 25);
            this.button_Retrieve_All_Card.TabIndex = 2;
            this.button_Retrieve_All_Card.Text = "Retrieve All Card by Customer";
            this.button_Retrieve_All_Card.UseVisualStyleBackColor = true;
            this.button_Retrieve_All_Card.Click += new System.EventHandler(this.button_Retrieve_All_Card_Click);
            // 
            // button_Create_Customer
            // 
            this.button_Create_Customer.Location = new System.Drawing.Point(12, 43);
            this.button_Create_Customer.Name = "button_Create_Customer";
            this.button_Create_Customer.Size = new System.Drawing.Size(310, 25);
            this.button_Create_Customer.TabIndex = 3;
            this.button_Create_Customer.Text = "Create Customer";
            this.button_Create_Customer.UseVisualStyleBackColor = true;
            this.button_Create_Customer.Click += new System.EventHandler(this.button_Create_Customer_Click);
            // 
            // button_Add_New_Card
            // 
            this.button_Add_New_Card.Location = new System.Drawing.Point(12, 136);
            this.button_Add_New_Card.Name = "button_Add_New_Card";
            this.button_Add_New_Card.Size = new System.Drawing.Size(310, 25);
            this.button_Add_New_Card.TabIndex = 4;
            this.button_Add_New_Card.Text = "Add New Card";
            this.button_Add_New_Card.UseVisualStyleBackColor = true;
            this.button_Add_New_Card.Click += new System.EventHandler(this.button_Add_New_Card_Click);
            // 
            // button_Delete_Card
            // 
            this.button_Delete_Card.Location = new System.Drawing.Point(12, 198);
            this.button_Delete_Card.Name = "button_Delete_Card";
            this.button_Delete_Card.Size = new System.Drawing.Size(310, 25);
            this.button_Delete_Card.TabIndex = 5;
            this.button_Delete_Card.Text = "Delete Card";
            this.button_Delete_Card.UseVisualStyleBackColor = true;
            this.button_Delete_Card.Click += new System.EventHandler(this.button_Delete_Card_Click);
            // 
            // button_Update_Card
            // 
            this.button_Update_Card.Location = new System.Drawing.Point(12, 167);
            this.button_Update_Card.Name = "button_Update_Card";
            this.button_Update_Card.Size = new System.Drawing.Size(310, 25);
            this.button_Update_Card.TabIndex = 6;
            this.button_Update_Card.Text = "Update Card";
            this.button_Update_Card.UseVisualStyleBackColor = true;
            this.button_Update_Card.Click += new System.EventHandler(this.button_Update_Card_Click);
            // 
            // button_Payment_By_PayNow
            // 
            this.button_Payment_By_PayNow.Location = new System.Drawing.Point(12, 229);
            this.button_Payment_By_PayNow.Name = "button_Payment_By_PayNow";
            this.button_Payment_By_PayNow.Size = new System.Drawing.Size(310, 25);
            this.button_Payment_By_PayNow.TabIndex = 7;
            this.button_Payment_By_PayNow.Text = "Payment by PayNow";
            this.button_Payment_By_PayNow.UseVisualStyleBackColor = true;
            this.button_Payment_By_PayNow.Click += new System.EventHandler(this.button_Payment_By_PayNow_Click);
            // 
            // frm_Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(334, 311);
            this.Controls.Add(this.button_Payment_By_PayNow);
            this.Controls.Add(this.button_Update_Card);
            this.Controls.Add(this.button_Delete_Card);
            this.Controls.Add(this.button_Add_New_Card);
            this.Controls.Add(this.button_Create_Customer);
            this.Controls.Add(this.button_Retrieve_All_Card);
            this.Controls.Add(this.button_Payment_by_Customer);
            this.Controls.Add(this.button_Payment_by_Card);
            this.Name = "frm_Main";
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button button_Payment_by_Card;
        private System.Windows.Forms.Button button_Payment_by_Customer;
        private System.Windows.Forms.Button button_Retrieve_All_Card;
        private System.Windows.Forms.Button button_Create_Customer;
        private System.Windows.Forms.Button button_Add_New_Card;
        private System.Windows.Forms.Button button_Delete_Card;
        private System.Windows.Forms.Button button_Update_Card;
        private System.Windows.Forms.Button button_Payment_By_PayNow;
    }
}

