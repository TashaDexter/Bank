
namespace Bank.Views
{
    partial class CardRegistration
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CardRegistration));
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.buttonReg = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.comboBank = new System.Windows.Forms.ComboBox();
            this.comboTypeCard = new System.Windows.Forms.ComboBox();
            this.comboClient = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(92, 26);
            this.label1.TabIndex = 25;
            this.label1.Text = "Клиент";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 179);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(124, 26);
            this.label3.TabIndex = 29;
            this.label3.Text = "Тип карты";
            // 
            // buttonReg
            // 
            this.buttonReg.Location = new System.Drawing.Point(708, 248);
            this.buttonReg.Name = "buttonReg";
            this.buttonReg.Size = new System.Drawing.Size(218, 42);
            this.buttonReg.TabIndex = 31;
            this.buttonReg.Text = "Создать карту";
            this.buttonReg.UseVisualStyleBackColor = true;
            this.buttonReg.Click += new System.EventHandler(this.buttonReg_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 97);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(65, 26);
            this.label5.TabIndex = 32;
            this.label5.Text = "Банк";
            // 
            // comboBank
            // 
            this.comboBank.Cursor = System.Windows.Forms.Cursors.Default;
            this.comboBank.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBank.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.comboBank.FormattingEnabled = true;
            this.comboBank.Location = new System.Drawing.Point(12, 126);
            this.comboBank.Name = "comboBank";
            this.comboBank.Size = new System.Drawing.Size(381, 32);
            this.comboBank.TabIndex = 33;
            this.comboBank.DropDown += new System.EventHandler(this.comboBank_DropDown);
            this.comboBank.SelectedIndexChanged += new System.EventHandler(this.comboBank_SelectedIndexChanged);
            // 
            // comboTypeCard
            // 
            this.comboTypeCard.Cursor = System.Windows.Forms.Cursors.Default;
            this.comboTypeCard.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboTypeCard.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.comboTypeCard.FormattingEnabled = true;
            this.comboTypeCard.Location = new System.Drawing.Point(12, 208);
            this.comboTypeCard.Name = "comboTypeCard";
            this.comboTypeCard.Size = new System.Drawing.Size(381, 32);
            this.comboTypeCard.TabIndex = 34;
            this.comboTypeCard.DropDown += new System.EventHandler(this.comboTypeCard_DropDown);
            this.comboTypeCard.SelectedIndexChanged += new System.EventHandler(this.comboTypeCard_SelectedIndexChanged);
            // 
            // comboClient
            // 
            this.comboClient.Cursor = System.Windows.Forms.Cursors.Default;
            this.comboClient.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboClient.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.comboClient.FormattingEnabled = true;
            this.comboClient.Location = new System.Drawing.Point(12, 50);
            this.comboClient.Name = "comboClient";
            this.comboClient.Size = new System.Drawing.Size(914, 32);
            this.comboClient.TabIndex = 35;
            // 
            // CardRegistration
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(14F, 26F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(944, 302);
            this.Controls.Add(this.comboClient);
            this.Controls.Add(this.comboTypeCard);
            this.Controls.Add(this.comboBank);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.buttonReg);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(6);
            this.Name = "CardRegistration";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Регистрация";
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private System.Windows.Forms.ComboBox comboClient;

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button buttonReg;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox comboBank;
        private System.Windows.Forms.ComboBox comboTypeCard;
    }
}