
namespace Bank.Views
{
    partial class ShowBalance
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ShowBalance));
            this.labelBal = new System.Windows.Forms.Label();
            this.labelNum = new System.Windows.Forms.Label();
            this.labelDate = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // labelBal
            // 
            this.labelBal.AutoSize = true;
            this.labelBal.Location = new System.Drawing.Point(5, 20);
            this.labelBal.Margin = new System.Windows.Forms.Padding(11, 0, 11, 0);
            this.labelBal.Name = "labelBal";
            this.labelBal.Size = new System.Drawing.Size(285, 26);
            this.labelBal.TabIndex = 5;
            this.labelBal.Text = "Ваш баланс составляет:";
            // 
            // labelNum
            // 
            this.labelNum.AutoSize = true;
            this.labelNum.Location = new System.Drawing.Point(5, 66);
            this.labelNum.Margin = new System.Windows.Forms.Padding(11, 0, 11, 0);
            this.labelNum.Name = "labelNum";
            this.labelNum.Size = new System.Drawing.Size(165, 26);
            this.labelNum.TabIndex = 6;
            this.labelNum.Text = "Номер карты:";
            // 
            // labelDate
            // 
            this.labelDate.AutoSize = true;
            this.labelDate.Location = new System.Drawing.Point(5, 115);
            this.labelDate.Margin = new System.Windows.Forms.Padding(11, 0, 11, 0);
            this.labelDate.Name = "labelDate";
            this.labelDate.Size = new System.Drawing.Size(184, 26);
            this.labelDate.TabIndex = 7;
            this.labelDate.Text = "Дата создания:";
            // 
            // ShowBalance
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(14F, 26F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(512, 174);
            this.Controls.Add(this.labelDate);
            this.Controls.Add(this.labelNum);
            this.Controls.Add(this.labelBal);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(6);
            this.Name = "ShowBalance";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Информация о карте";
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        public System.Windows.Forms.Label labelBal;
        public System.Windows.Forms.Label labelNum;
        public System.Windows.Forms.Label labelDate;
    }
}