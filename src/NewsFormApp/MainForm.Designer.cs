namespace News.FormApp
{
    partial class MainForm
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
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.colDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colUrl = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTicker = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colStartPrice = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colEndPrice = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colChange = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colStatus = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AllowUserToResizeColumns = false;
            this.dataGridView1.AllowUserToResizeRows = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colDate,
            this.colUrl,
            this.colTicker,
            this.colStartPrice,
            this.colEndPrice,
            this.colChange,
            this.colStatus});
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Enabled = false;
            this.dataGridView1.Location = new System.Drawing.Point(0, 0);
            this.dataGridView1.MultiSelect = false;
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(684, 462);
            this.dataGridView1.TabIndex = 1;
            this.dataGridView1.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dataGridView1_CellFormatting);
            // 
            // colDate
            // 
            this.colDate.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.colDate.DataPropertyName = "SourceTime";
            this.colDate.HeaderText = "Kp";
            this.colDate.Name = "colDate";
            this.colDate.ReadOnly = true;
            this.colDate.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            // 
            // colUrl
            // 
            this.colUrl.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colUrl.DataPropertyName = "SourceUrl";
            this.colUrl.HeaderText = "Url";
            this.colUrl.Name = "colUrl";
            this.colUrl.ReadOnly = true;
            this.colUrl.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            // 
            // colTicker
            // 
            this.colTicker.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.colTicker.DataPropertyName = "ResultTicker";
            this.colTicker.HeaderText = "Tähis";
            this.colTicker.Name = "colTicker";
            this.colTicker.ReadOnly = true;
            this.colTicker.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            // 
            // colStartPrice
            // 
            this.colStartPrice.DataPropertyName = "ResultStartPrice";
            this.colStartPrice.HeaderText = "Alghind";
            this.colStartPrice.Name = "colStartPrice";
            this.colStartPrice.ReadOnly = true;
            this.colStartPrice.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            // 
            // colEndPrice
            // 
            this.colEndPrice.DataPropertyName = "ResultEndPrice";
            this.colEndPrice.HeaderText = "Lõpphind";
            this.colEndPrice.Name = "colEndPrice";
            this.colEndPrice.ReadOnly = true;
            this.colEndPrice.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            // 
            // colChange
            // 
            this.colChange.DataPropertyName = "ResultChange";
            this.colChange.HeaderText = "Muutus";
            this.colChange.Name = "colChange";
            this.colChange.ReadOnly = true;
            this.colChange.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            // 
            // colStatus
            // 
            this.colStatus.DataPropertyName = "Status";
            this.colStatus.HeaderText = "Status";
            this.colStatus.Name = "colStatus";
            this.colStatus.ReadOnly = true;
            this.colStatus.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(684, 462);
            this.Controls.Add(this.dataGridView1);
            this.Name = "MainForm";
            this.Text = "News";
            this.Load += new System.EventHandler(this.MainForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn colUrl;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTicker;
        private System.Windows.Forms.DataGridViewTextBoxColumn colStartPrice;
        private System.Windows.Forms.DataGridViewTextBoxColumn colEndPrice;
        private System.Windows.Forms.DataGridViewTextBoxColumn colChange;
        private System.Windows.Forms.DataGridViewTextBoxColumn colStatus;
    }
}

