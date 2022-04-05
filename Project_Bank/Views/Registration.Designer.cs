
namespace Project_Bank.Views
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
            this.label4 = new System.Windows.Forms.Label();
            this.textFirstName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.textLaastName = new System.Windows.Forms.TextBox();
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
            this.label4.Location = new System.Drawing.Point(12, 65);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(73, 32);
            this.label4.TabIndex = 23;
            this.label4.Text = "Имя";
            // 
            // textFirstName
            // 
            this.textFirstName.Location = new System.Drawing.Point(163, 18);
            this.textFirstName.Name = "textFirstName";
            this.textFirstName.Size = new System.Drawing.Size(450, 38);
            this.textFirstName.TabIndex = 26;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(145, 32);
            this.label1.TabIndex = 25;
            this.label1.Text = "Фамилия";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 114);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(147, 32);
            this.label2.TabIndex = 27;
            this.label2.Text = "Отчество";
            // 
            // textLaastName
            // 
            this.textLaastName.Location = new System.Drawing.Point(163, 65);
            this.textLaastName.Name = "textLaastName";
            this.textLaastName.Size = new System.Drawing.Size(450, 38);
            this.textLaastName.TabIndex = 28;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 203);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(159, 32);
            this.label3.TabIndex = 29;
            this.label3.Text = "Тип карты";
            // 
            // textParentName
            // 
            this.textParentName.Location = new System.Drawing.Point(177, 111);
            this.textParentName.Name = "textParentName";
            this.textParentName.Size = new System.Drawing.Size(436, 38);
            this.textParentName.TabIndex = 30;
            // 
            // buttonReg
            // 
            this.buttonReg.Location = new System.Drawing.Point(14, 245);
            this.buttonReg.Name = "buttonReg";
            this.buttonReg.Size = new System.Drawing.Size(599, 57);
            this.buttonReg.TabIndex = 31;
            this.buttonReg.Text = "Создать карту";
            this.buttonReg.UseVisualStyleBackColor = true;
            this.buttonReg.Click += new System.EventHandler(this.buttonReg_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(8, 162);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(229, 32);
            this.label5.TabIndex = 32;
            this.label5.Text = "Выберите банк";
            // 
            // comboBank
            // 
            this.comboBank.Cursor = System.Windows.Forms.Cursors.Default;
            this.comboBank.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBank.FormattingEnabled = true;
            this.comboBank.Location = new System.Drawing.Point(247, 155);
            this.comboBank.Name = "comboBank";
            this.comboBank.Size = new System.Drawing.Size(366, 39);
            this.comboBank.TabIndex = 33;
            this.comboBank.DropDown += new System.EventHandler(this.comboBank_DropDown);
            this.comboBank.SelectedIndexChanged += new System.EventHandler(this.comboBank_SelectedIndexChanged);
            // 
            // comboTypeCard
            // 
            this.comboTypeCard.Cursor = System.Windows.Forms.Cursors.Default;
            this.comboTypeCard.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboTypeCard.FormattingEnabled = true;
            this.comboTypeCard.Location = new System.Drawing.Point(187, 200);
            this.comboTypeCard.Name = "comboTypeCard";
            this.comboTypeCard.Size = new System.Drawing.Size(426, 39);
            this.comboTypeCard.TabIndex = 34;
            this.comboTypeCard.DropDown += new System.EventHandler(this.comboTypeCard_DropDown);
            this.comboTypeCard.SelectedIndexChanged += new System.EventHandler(this.comboTypeCard_SelectedIndexChanged);
            // 
            // Registration
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(17F, 31F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(625, 311);
            this.Controls.Add(this.comboTypeCard);
            this.Controls.Add(this.comboBank);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.buttonReg);
            this.Controls.Add(this.textParentName);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.textLaastName);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.textFirstName);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label4);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Margin = new System.Windows.Forms.Padding(6);
            this.Name = "Registration";
            this.Text = "Registration";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textFirstName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textLaastName;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textParentName;
        private System.Windows.Forms.Button buttonReg;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox comboBank;
        private System.Windows.Forms.ComboBox comboTypeCard;
    }
}