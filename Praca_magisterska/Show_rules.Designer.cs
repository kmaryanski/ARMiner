namespace Praca_magisterska
{
    partial class Show_rules
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
            this.prev = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.arrow = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.next = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.support = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Confidence = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.prev,
            this.arrow,
            this.next,
            this.support,
            this.Confidence});
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(0, 0);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.Size = new System.Drawing.Size(745, 460);
            this.dataGridView1.TabIndex = 0;
            // 
            // prev
            // 
            this.prev.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.prev.HeaderText = "Poprzednik";
            this.prev.Name = "prev";
            this.prev.ReadOnly = true;
            // 
            // arrow
            // 
            this.arrow.HeaderText = "=>";
            this.arrow.Name = "arrow";
            this.arrow.ReadOnly = true;
            this.arrow.Width = 40;
            // 
            // next
            // 
            this.next.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.next.HeaderText = "Następnik";
            this.next.Name = "next";
            this.next.ReadOnly = true;
            // 
            // support
            // 
            this.support.HeaderText = "Wsparcie";
            this.support.Name = "support";
            this.support.ReadOnly = true;
            // 
            // Confidence
            // 
            this.Confidence.HeaderText = "Pewność";
            this.Confidence.Name = "Confidence";
            this.Confidence.ReadOnly = true;
            // 
            // Show_rules
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(745, 460);
            this.Controls.Add(this.dataGridView1);
            this.Name = "Show_rules";
            this.Text = "Show_rules";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        public System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn prev;
        private System.Windows.Forms.DataGridViewTextBoxColumn arrow;
        private System.Windows.Forms.DataGridViewTextBoxColumn next;
        private System.Windows.Forms.DataGridViewTextBoxColumn support;
        private System.Windows.Forms.DataGridViewTextBoxColumn Confidence;
    }
}