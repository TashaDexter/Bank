
namespace Bank.Views
{
    partial class Registration
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Registration));
            this.label4 = new System.Windows.Forms.Label();
            this.textFirstName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.textLastName = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.textParentName = new System.Windows.Forms.TextBox();
            this.buttonReg = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.comboBank = new System.Windows.Forms.ComboBox();
            this.comboTypeCard = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(14, 59);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(59, 26);
            this.label4.TabIndex = 23;
            this.label4.Text = "Имя";
            // 
            // textFirstName
            // 
            this.textFirstName.Location = new System.Drawing.Point(163, 18);
            this.textFirstName.Name = "textFirstName";
            this.textFirstName.Size = new System.Drawing.Size(450, 32);
            this.textFirstName.TabIndex = 26;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(115, 26);
            this.label1.TabIndex = 25;
            this.label1.Text = "Фамилия";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 97);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(116, 26);
            this.label2.TabIndex = 27;
            this.label2.Text = "Отчество";
            // 
            // textLastName
            // 
            this.textLastName.Location = new System.Drawing.Point(163, 56);
            this.textLastName.Name = "textLastName";
            this.textLastName.Size = new System.Drawing.Size(450, 32);
            this.textLastName.TabIndex = 28;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(14, 184);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(124, 26);
            this.label3.TabIndex = 29;
            this.label3.Text = "Тип карты";
            // 
            // textParentName
            // 
            this.textParentName.Location = new System.Drawing.Point(163, 94);
            this.textParentName.Name = "textParentName";
            this.textParentName.Size = new System.Drawing.Size(450, 32);
            this.textParentName.TabIndex = 30;
            // 
            // buttonReg
            // 
            this.buttonReg.Location = new System.Drawing.Point(12, 234);
            this.buttonReg.Name = "buttonReg";
            this.buttonReg.Size = new System.Drawing.Size(601, 42);
            this.buttonReg.TabIndex = 31;
            this.buttonReg.Text = "Создать карту";
            this.buttonReg.UseVisualStyleBackColor = true;
            this.buttonReg.Click += new System.EventHandler(this.buttonReg_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(14, 144);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(65, 26);
            this.label5.TabIndex = 32;
            this.label5.Text = "Банк";
            // 
            // comboBank
            // 
            this.comboBank.Cursor = System.Windows.Forms.Cursors.Default;
            this.comboBank.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBank.FormattingEnabled = true;
            this.comboBank.Location = new System.Drawing.Point(163, 141);
            this.comboBank.Name = "comboBank";
            this.comboBank.Size = new System.Drawing.Size(450, 34);
            this.comboBank.TabIndex = 33;
            this.comboBank.DropDown += new System.EventHandler(this.comboBank_DropDown);
            this.comboBank.SelectedIndexChanged += new System.EventHandler(this.comboBank_SelectedIndexChanged);
            // 
            // comboTypeCard
            // 
            this.comboTypeCard.Cursor = System.Windows.Forms.Cursors.Default;
            this.comboTypeCard.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboTypeCard.FormattingEnabled = true;
            this.comboTypeCard.Location = new System.Drawing.Point(163, 181);
            this.comboTypeCard.Name = "comboTypeCard";
            this.comboTypeCard.Size = new System.Drawing.Size(450, 34);
            this.comboTypeCard.TabIndex = 34;
            this.comboTypeCard.DropDown += new System.EventHandler(this.comboTypeCard_DropDown);
            this.comboTypeCard.SelectedIndexChanged += new System.EventHandler(this.comboTypeCard_SelectedIndexChanged);
            // 
            // Registration
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(14F, 26F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(625, 289);
            this.Controls.Add(this.comboTypeCard);
            this.Controls.Add(this.comboBank);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.buttonReg);
            this.Controls.Add(this.textParentName);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.textLastName);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.textFirstName);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label4);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(6);
            this.Name = "Registration";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Регистрация";
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textFirstName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textLastName;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textParentName;
        private System.Windows.Forms.Button buttonReg;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox comboBank;
        private System.Windows.Forms.ComboBox comboTypeCard;
    }
}