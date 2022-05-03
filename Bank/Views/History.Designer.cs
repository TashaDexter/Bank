
namespace Bank.Views
{
    partial class History
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

        private void InitializeComponent()
{
    System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(History));
    this.dataGridViewHistory = new System.Windows.Forms.DataGridView();
    ((System.ComponentModel.ISupportInitialize)(this.dataGridViewHistory)).BeginInit();
    this.SuspendLayout();
    // 
    // dataGridViewHistory
    // 
    this.dataGridViewHistory.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
    this.dataGridViewHistory.Dock = System.Windows.Forms.DockStyle.Fill;
    this.dataGridViewHistory.Location = new System.Drawing.Point(0, 0);
    this.dataGridViewHistory.Margin = new System.Windows.Forms.Padding(2);
    this.dataGridViewHistory.Name = "dataGridViewHistory";
    this.dataGridViewHistory.RowHeadersWidth = 51;
    this.dataGridViewHistory.RowTemplate.Height = 24;
    this.dataGridViewHistory.Size = new System.Drawing.Size(824, 498);
    this.dataGridViewHistory.TabIndex = 0;
    // 
    // History
    // 
    this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
    this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
    this.ClientSize = new System.Drawing.Size(824, 498);
    this.Controls.Add(this.dataGridViewHistory);
    this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
    this.Margin = new System.Windows.Forms.Padding(2);
    this.Name = "History";
    this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
    this.Text = "История платежей";
    ((System.ComponentModel.ISupportInitialize)(this.dataGridViewHistory)).EndInit();
    this.ResumeLayout(false);
}

        #endregion

        public System.Windows.Forms.DataGridView dataGridViewHistory;
    }
}