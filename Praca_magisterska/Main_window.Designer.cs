namespace Praca_magisterska
{
    partial class main_window
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(main_window));
            this.data_browse_button = new System.Windows.Forms.Button();
            this.textBox_data = new System.Windows.Forms.TextBox();
            this.groupBox_apriori = new System.Windows.Forms.GroupBox();
            this.button_save_apriori = new System.Windows.Forms.Button();
            this.generate_rules_apriori_button = new System.Windows.Forms.Button();
            this.label_apriori_time = new System.Windows.Forms.Label();
            this.start_apriori_button = new System.Windows.Forms.Button();
            this.button_show_litemsetsApriori = new System.Windows.Forms.Button();
            this.button_rulesApriori = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.groupBox_aprioriTiD = new System.Windows.Forms.GroupBox();
            this.button_save_TiD = new System.Windows.Forms.Button();
            this.generate_rules_TiD_button = new System.Windows.Forms.Button();
            this.label_aprioriTiD_time = new System.Windows.Forms.Label();
            this.start_TiD_button = new System.Windows.Forms.Button();
            this.button_litemsets_TiD = new System.Windows.Forms.Button();
            this.button_rules_aprioriTid = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.button_save_eclat = new System.Windows.Forms.Button();
            this.generate_rules_eclat_button = new System.Windows.Forms.Button();
            this.label_eclat_time = new System.Windows.Forms.Label();
            this.start_eclat_button = new System.Windows.Forms.Button();
            this.button_itemset_eclat = new System.Windows.Forms.Button();
            this.button_rules_eclat = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.support_setbox = new System.Windows.Forms.NumericUpDown();
            this.confidence_setbox = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.data_FileDialog = new System.Windows.Forms.OpenFileDialog();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.groupBox_apriori.SuspendLayout();
            this.groupBox_aprioriTiD.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.support_setbox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.confidence_setbox)).BeginInit();
            this.SuspendLayout();
            // 
            // data_browse_button
            // 
            resources.ApplyResources(this.data_browse_button, "data_browse_button");
            this.data_browse_button.Name = "data_browse_button";
            this.data_browse_button.UseVisualStyleBackColor = true;
            this.data_browse_button.Click += new System.EventHandler(this.data_browse_button_Click);
            // 
            // textBox_data
            // 
            resources.ApplyResources(this.textBox_data, "textBox_data");
            this.textBox_data.Name = "textBox_data";
            this.textBox_data.ReadOnly = true;
            // 
            // groupBox_apriori
            // 
            resources.ApplyResources(this.groupBox_apriori, "groupBox_apriori");
            this.groupBox_apriori.Controls.Add(this.button_save_apriori);
            this.groupBox_apriori.Controls.Add(this.generate_rules_apriori_button);
            this.groupBox_apriori.Controls.Add(this.label_apriori_time);
            this.groupBox_apriori.Controls.Add(this.start_apriori_button);
            this.groupBox_apriori.Controls.Add(this.button_show_litemsetsApriori);
            this.groupBox_apriori.Controls.Add(this.button_rulesApriori);
            this.groupBox_apriori.Controls.Add(this.label4);
            this.groupBox_apriori.Name = "groupBox_apriori";
            this.groupBox_apriori.TabStop = false;
            // 
            // button_save_apriori
            // 
            resources.ApplyResources(this.button_save_apriori, "button_save_apriori");
            this.button_save_apriori.Name = "button_save_apriori";
            this.button_save_apriori.UseVisualStyleBackColor = true;
            this.button_save_apriori.Click += new System.EventHandler(this.button_save_apriori_Click);
            // 
            // generate_rules_apriori_button
            // 
            resources.ApplyResources(this.generate_rules_apriori_button, "generate_rules_apriori_button");
            this.generate_rules_apriori_button.Name = "generate_rules_apriori_button";
            this.generate_rules_apriori_button.UseVisualStyleBackColor = true;
            this.generate_rules_apriori_button.Click += new System.EventHandler(this.generate_rules_apriori_button_Click);
            // 
            // label_apriori_time
            // 
            resources.ApplyResources(this.label_apriori_time, "label_apriori_time");
            this.label_apriori_time.Name = "label_apriori_time";
            // 
            // start_apriori_button
            // 
            resources.ApplyResources(this.start_apriori_button, "start_apriori_button");
            this.start_apriori_button.Name = "start_apriori_button";
            this.start_apriori_button.UseVisualStyleBackColor = true;
            this.start_apriori_button.Click += new System.EventHandler(this.start_apriori_button_Click);
            // 
            // button_show_litemsetsApriori
            // 
            resources.ApplyResources(this.button_show_litemsetsApriori, "button_show_litemsetsApriori");
            this.button_show_litemsetsApriori.Name = "button_show_litemsetsApriori";
            this.button_show_litemsetsApriori.UseVisualStyleBackColor = true;
            this.button_show_litemsetsApriori.Click += new System.EventHandler(this.button_show_litemsetsApriori_Click);
            // 
            // button_rulesApriori
            // 
            resources.ApplyResources(this.button_rulesApriori, "button_rulesApriori");
            this.button_rulesApriori.Name = "button_rulesApriori";
            this.button_rulesApriori.UseVisualStyleBackColor = true;
            this.button_rulesApriori.Click += new System.EventHandler(this.button_rulesApriori_Click);
            // 
            // label4
            // 
            resources.ApplyResources(this.label4, "label4");
            this.label4.Name = "label4";
            // 
            // groupBox_aprioriTiD
            // 
            resources.ApplyResources(this.groupBox_aprioriTiD, "groupBox_aprioriTiD");
            this.groupBox_aprioriTiD.Controls.Add(this.button_save_TiD);
            this.groupBox_aprioriTiD.Controls.Add(this.generate_rules_TiD_button);
            this.groupBox_aprioriTiD.Controls.Add(this.label_aprioriTiD_time);
            this.groupBox_aprioriTiD.Controls.Add(this.start_TiD_button);
            this.groupBox_aprioriTiD.Controls.Add(this.button_litemsets_TiD);
            this.groupBox_aprioriTiD.Controls.Add(this.button_rules_aprioriTid);
            this.groupBox_aprioriTiD.Controls.Add(this.label5);
            this.groupBox_aprioriTiD.Name = "groupBox_aprioriTiD";
            this.groupBox_aprioriTiD.TabStop = false;
            // 
            // button_save_TiD
            // 
            resources.ApplyResources(this.button_save_TiD, "button_save_TiD");
            this.button_save_TiD.Name = "button_save_TiD";
            this.button_save_TiD.UseVisualStyleBackColor = true;
            this.button_save_TiD.Click += new System.EventHandler(this.button_save_TiD_Click);
            // 
            // generate_rules_TiD_button
            // 
            resources.ApplyResources(this.generate_rules_TiD_button, "generate_rules_TiD_button");
            this.generate_rules_TiD_button.Name = "generate_rules_TiD_button";
            this.generate_rules_TiD_button.UseVisualStyleBackColor = true;
            this.generate_rules_TiD_button.Click += new System.EventHandler(this.generate_rules_TiD_button_Click);
            // 
            // label_aprioriTiD_time
            // 
            resources.ApplyResources(this.label_aprioriTiD_time, "label_aprioriTiD_time");
            this.label_aprioriTiD_time.Name = "label_aprioriTiD_time";
            // 
            // start_TiD_button
            // 
            resources.ApplyResources(this.start_TiD_button, "start_TiD_button");
            this.start_TiD_button.Name = "start_TiD_button";
            this.start_TiD_button.UseVisualStyleBackColor = true;
            this.start_TiD_button.Click += new System.EventHandler(this.start_TiD_button_Click);
            // 
            // button_litemsets_TiD
            // 
            resources.ApplyResources(this.button_litemsets_TiD, "button_litemsets_TiD");
            this.button_litemsets_TiD.Name = "button_litemsets_TiD";
            this.button_litemsets_TiD.UseVisualStyleBackColor = true;
            this.button_litemsets_TiD.Click += new System.EventHandler(this.button_litemsets_TiD_Click);
            // 
            // button_rules_aprioriTid
            // 
            resources.ApplyResources(this.button_rules_aprioriTid, "button_rules_aprioriTid");
            this.button_rules_aprioriTid.Name = "button_rules_aprioriTid";
            this.button_rules_aprioriTid.UseVisualStyleBackColor = true;
            this.button_rules_aprioriTid.Click += new System.EventHandler(this.button_rules_aprioriTid_Click);
            // 
            // label5
            // 
            resources.ApplyResources(this.label5, "label5");
            this.label5.Name = "label5";
            // 
            // groupBox3
            // 
            resources.ApplyResources(this.groupBox3, "groupBox3");
            this.groupBox3.Controls.Add(this.button_save_eclat);
            this.groupBox3.Controls.Add(this.generate_rules_eclat_button);
            this.groupBox3.Controls.Add(this.label_eclat_time);
            this.groupBox3.Controls.Add(this.start_eclat_button);
            this.groupBox3.Controls.Add(this.button_itemset_eclat);
            this.groupBox3.Controls.Add(this.button_rules_eclat);
            this.groupBox3.Controls.Add(this.label6);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.TabStop = false;
            // 
            // button_save_eclat
            // 
            resources.ApplyResources(this.button_save_eclat, "button_save_eclat");
            this.button_save_eclat.Name = "button_save_eclat";
            this.button_save_eclat.UseVisualStyleBackColor = true;
            this.button_save_eclat.Click += new System.EventHandler(this.button_save_eclat_Click);
            // 
            // generate_rules_eclat_button
            // 
            resources.ApplyResources(this.generate_rules_eclat_button, "generate_rules_eclat_button");
            this.generate_rules_eclat_button.Name = "generate_rules_eclat_button";
            this.generate_rules_eclat_button.UseVisualStyleBackColor = true;
            this.generate_rules_eclat_button.Click += new System.EventHandler(this.generate_rules_eclat_button_Click);
            // 
            // label_eclat_time
            // 
            resources.ApplyResources(this.label_eclat_time, "label_eclat_time");
            this.label_eclat_time.Name = "label_eclat_time";
            // 
            // start_eclat_button
            // 
            resources.ApplyResources(this.start_eclat_button, "start_eclat_button");
            this.start_eclat_button.Name = "start_eclat_button";
            this.start_eclat_button.UseVisualStyleBackColor = true;
            this.start_eclat_button.Click += new System.EventHandler(this.start_eclat_button_Click);
            // 
            // button_itemset_eclat
            // 
            resources.ApplyResources(this.button_itemset_eclat, "button_itemset_eclat");
            this.button_itemset_eclat.Name = "button_itemset_eclat";
            this.button_itemset_eclat.UseVisualStyleBackColor = true;
            this.button_itemset_eclat.Click += new System.EventHandler(this.button_itemset_eclat_Click);
            // 
            // button_rules_eclat
            // 
            resources.ApplyResources(this.button_rules_eclat, "button_rules_eclat");
            this.button_rules_eclat.Name = "button_rules_eclat";
            this.button_rules_eclat.UseVisualStyleBackColor = true;
            this.button_rules_eclat.Click += new System.EventHandler(this.button_rules_eclat_Click);
            // 
            // label6
            // 
            resources.ApplyResources(this.label6, "label6");
            this.label6.Name = "label6";
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.Name = "label1";
            // 
            // support_setbox
            // 
            resources.ApplyResources(this.support_setbox, "support_setbox");
            this.support_setbox.Name = "support_setbox";
            this.support_setbox.ValueChanged += new System.EventHandler(this.support_setbox_ValueChanged);
            // 
            // confidence_setbox
            // 
            resources.ApplyResources(this.confidence_setbox, "confidence_setbox");
            this.confidence_setbox.Name = "confidence_setbox";
            this.confidence_setbox.ValueChanged += new System.EventHandler(this.confidence_setbox_ValueChanged);
            // 
            // label2
            // 
            resources.ApplyResources(this.label2, "label2");
            this.label2.Name = "label2";
            // 
            // label3
            // 
            resources.ApplyResources(this.label3, "label3");
            this.label3.Name = "label3";
            // 
            // label7
            // 
            resources.ApplyResources(this.label7, "label7");
            this.label7.Name = "label7";
            // 
            // label8
            // 
            resources.ApplyResources(this.label8, "label8");
            this.label8.Name = "label8";
            // 
            // backgroundWorker1
            // 
            this.backgroundWorker1.WorkerSupportsCancellation = true;
            this.backgroundWorker1.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker1_DoWork);
            this.backgroundWorker1.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorker1_RunWorkerCompleted);
            // 
            // main_window
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.confidence_setbox);
            this.Controls.Add(this.support_setbox);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox_aprioriTiD);
            this.Controls.Add(this.groupBox_apriori);
            this.Controls.Add(this.textBox_data);
            this.Controls.Add(this.data_browse_button);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "main_window";
            this.groupBox_apriori.ResumeLayout(false);
            this.groupBox_apriori.PerformLayout();
            this.groupBox_aprioriTiD.ResumeLayout(false);
            this.groupBox_aprioriTiD.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.support_setbox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.confidence_setbox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button data_browse_button;
        private System.Windows.Forms.TextBox textBox_data;
        private System.Windows.Forms.GroupBox groupBox_apriori;
        private System.Windows.Forms.GroupBox groupBox_aprioriTiD;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown support_setbox;
        private System.Windows.Forms.NumericUpDown confidence_setbox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button button_rulesApriori;
        private System.Windows.Forms.Button button_rules_aprioriTid;
        private System.Windows.Forms.Button button_rules_eclat;
        private System.Windows.Forms.Button button_show_litemsetsApriori;
        private System.Windows.Forms.Button button_litemsets_TiD;
        private System.Windows.Forms.Button start_apriori_button;
        private System.Windows.Forms.Button button_itemset_eclat;
        private System.Windows.Forms.OpenFileDialog data_FileDialog;
        private System.Windows.Forms.Button start_TiD_button;
        private System.Windows.Forms.Button start_eclat_button;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.Label label_apriori_time;
        private System.Windows.Forms.Label label_aprioriTiD_time;
        private System.Windows.Forms.Label label_eclat_time;
        private System.Windows.Forms.Button generate_rules_apriori_button;
        private System.Windows.Forms.Button generate_rules_TiD_button;
        private System.Windows.Forms.Button generate_rules_eclat_button;
        private System.Windows.Forms.Button button_save_apriori;
        private System.Windows.Forms.Button button_save_TiD;
        private System.Windows.Forms.Button button_save_eclat;
        public System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
    }
}

