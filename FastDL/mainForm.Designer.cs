namespace FastDL
{
    partial class mainForm
    {
        /// <summary>
        /// Variable nécessaire au concepteur.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Nettoyage des ressources utilisées.
        /// </summary>
        /// <param name="disposing">true si les ressources managées doivent être supprimées ; sinon, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Code généré par le Concepteur Windows Form

        /// <summary>
        /// Méthode requise pour la prise en charge du concepteur - ne modifiez pas
        /// le contenu de cette méthode avec l'éditeur de code.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.nudBlockSize = new System.Windows.Forms.NumericUpDown();
            this.nudConnPerInterfaces = new System.Windows.Forms.NumericUpDown();
            this.lblBlockSize = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.rtbURL = new System.Windows.Forms.RichTextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.dgvSearch = new System.Windows.Forms.DataGridView();
            this.Filename = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Description = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.url = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnSearch = new System.Windows.Forms.Button();
            this.tbSearch = new System.Windows.Forms.RichTextBox();
            this.tcMain = new System.Windows.Forms.TabControl();
            this.tpDownloads = new System.Windows.Forms.TabPage();
            this.dgvDownloads = new System.Windows.Forms.DataGridView();
            this.name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.downloaded = new System.Windows.Forms.DataGridViewImageColumn();
            this.size = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.speed = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.status = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Link = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.lblNbInterfaces = new System.Windows.Forms.Label();
            this.cmsConfiguration = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.nbSocketInterfaceToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem3 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem4 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem5 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem6 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem7 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem8 = new System.Windows.Forms.ToolStripMenuItem();
            this.blockSizeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mbToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mbToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.mbToolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.mbToolStripMenuItem3 = new System.Windows.Forms.ToolStripMenuItem();
            this.mbToolStripMenuItem4 = new System.Windows.Forms.ToolStripMenuItem();
            this.mbToolStripMenuItem5 = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.nudBlockSize)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudConnPerInterfaces)).BeginInit();
            this.tabPage3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSearch)).BeginInit();
            this.tcMain.SuspendLayout();
            this.tpDownloads.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDownloads)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.cmsConfiguration.SuspendLayout();
            this.SuspendLayout();
            // 
            // nudBlockSize
            // 
            this.nudBlockSize.Location = new System.Drawing.Point(431, 440);
            this.nudBlockSize.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.nudBlockSize.Name = "nudBlockSize";
            this.nudBlockSize.Size = new System.Drawing.Size(140, 23);
            this.nudBlockSize.TabIndex = 0;
            this.nudBlockSize.Value = new decimal(new int[] {
            5,
            0,
            0,
            0});
            // 
            // nudConnPerInterfaces
            // 
            this.nudConnPerInterfaces.Location = new System.Drawing.Point(156, 440);
            this.nudConnPerInterfaces.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.nudConnPerInterfaces.Name = "nudConnPerInterfaces";
            this.nudConnPerInterfaces.Size = new System.Drawing.Size(140, 23);
            this.nudConnPerInterfaces.TabIndex = 1;
            this.nudConnPerInterfaces.Value = new decimal(new int[] {
            2,
            0,
            0,
            0});
            // 
            // lblBlockSize
            // 
            this.lblBlockSize.AutoSize = true;
            this.lblBlockSize.Location = new System.Drawing.Point(329, 442);
            this.lblBlockSize.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblBlockSize.Name = "lblBlockSize";
            this.lblBlockSize.Size = new System.Drawing.Size(36, 15);
            this.lblBlockSize.TabIndex = 3;
            this.lblBlockSize.Text = " (Mo)";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(28, 443);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(114, 15);
            this.label2.TabIndex = 4;
            this.label2.Text = "Nb Socket/Interface";
            // 
            // rtbURL
            // 
            this.rtbURL.Location = new System.Drawing.Point(12, 13);
            this.rtbURL.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.rtbURL.Multiline = false;
            this.rtbURL.Name = "rtbURL";
            this.rtbURL.Size = new System.Drawing.Size(457, 34);
            this.rtbURL.TabIndex = 5;
            this.rtbURL.Text = "";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(532, 13);
            this.button1.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(88, 49);
            this.button1.TabIndex = 6;
            this.button1.Text = "Go";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(607, 440);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(148, 23);
            this.button2.TabIndex = 9;
            this.button2.Text = "Delete all downloads";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.dgvSearch);
            this.tabPage3.Controls.Add(this.btnSearch);
            this.tabPage3.Controls.Add(this.tbSearch);
            this.tabPage3.Location = new System.Drawing.Point(4, 24);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(753, 338);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Recherche";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // dgvSearch
            // 
            this.dgvSearch.BackgroundColor = System.Drawing.Color.Black;
            this.dgvSearch.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvSearch.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Filename,
            this.Description,
            this.url});
            this.dgvSearch.Location = new System.Drawing.Point(9, 73);
            this.dgvSearch.Name = "dgvSearch";
            this.dgvSearch.RowHeadersVisible = false;
            this.dgvSearch.Size = new System.Drawing.Size(730, 234);
            this.dgvSearch.TabIndex = 2;
            // 
            // Filename
            // 
            this.Filename.HeaderText = "Filename";
            this.Filename.Name = "Filename";
            this.Filename.Width = 170;
            // 
            // Description
            // 
            this.Description.HeaderText = "Description";
            this.Description.Name = "Description";
            this.Description.Width = 250;
            // 
            // url
            // 
            this.url.HeaderText = "URL";
            this.url.Name = "url";
            this.url.Width = 300;
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(486, 24);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(96, 31);
            this.btnSearch.TabIndex = 1;
            this.btnSearch.Text = "Search";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // tbSearch
            // 
            this.tbSearch.Location = new System.Drawing.Point(101, 24);
            this.tbSearch.Name = "tbSearch";
            this.tbSearch.Size = new System.Drawing.Size(352, 31);
            this.tbSearch.TabIndex = 0;
            this.tbSearch.Text = "radiohead";
            // 
            // tcMain
            // 
            this.tcMain.Controls.Add(this.tabPage3);
            this.tcMain.Controls.Add(this.tpDownloads);
            this.tcMain.Location = new System.Drawing.Point(12, 68);
            this.tcMain.Name = "tcMain";
            this.tcMain.SelectedIndex = 0;
            this.tcMain.Size = new System.Drawing.Size(761, 366);
            this.tcMain.TabIndex = 12;
            // 
            // tpDownloads
            // 
            this.tpDownloads.Controls.Add(this.dgvDownloads);
            this.tpDownloads.Location = new System.Drawing.Point(4, 24);
            this.tpDownloads.Name = "tpDownloads";
            this.tpDownloads.Padding = new System.Windows.Forms.Padding(3);
            this.tpDownloads.Size = new System.Drawing.Size(753, 338);
            this.tpDownloads.TabIndex = 3;
            this.tpDownloads.Text = "Téléchargements";
            this.tpDownloads.UseVisualStyleBackColor = true;
            // 
            // dgvDownloads
            // 
            this.dgvDownloads.AllowUserToAddRows = false;
            this.dgvDownloads.AllowUserToDeleteRows = false;
            this.dgvDownloads.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDownloads.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.name,
            this.downloaded,
            this.size,
            this.speed,
            this.status,
            this.Link});
            this.dgvDownloads.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvDownloads.Location = new System.Drawing.Point(3, 3);
            this.dgvDownloads.Name = "dgvDownloads";
            this.dgvDownloads.ReadOnly = true;
            this.dgvDownloads.RowHeadersVisible = false;
            this.dgvDownloads.Size = new System.Drawing.Size(747, 332);
            this.dgvDownloads.TabIndex = 0;
            // 
            // name
            // 
            this.name.HeaderText = "Name";
            this.name.Name = "name";
            this.name.ReadOnly = true;
            this.name.Width = 350;
            // 
            // downloaded
            // 
            this.downloaded.HeaderText = "Progress";
            this.downloaded.Name = "downloaded";
            this.downloaded.ReadOnly = true;
            this.downloaded.Width = 130;
            // 
            // size
            // 
            this.size.HeaderText = "Size";
            this.size.Name = "size";
            this.size.ReadOnly = true;
            // 
            // speed
            // 
            this.speed.HeaderText = "Speed";
            this.speed.Name = "speed";
            this.speed.ReadOnly = true;
            // 
            // status
            // 
            this.status.HeaderText = "Status";
            this.status.Name = "status";
            this.status.ReadOnly = true;
            this.status.Width = 60;
            // 
            // Link
            // 
            this.Link.HeaderText = "Link";
            this.Link.Name = "Link";
            this.Link.ReadOnly = true;
            this.Link.Visible = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::FastDL.Properties.Resources.Network_Internet;
            this.pictureBox1.Location = new System.Drawing.Point(671, 25);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(32, 32);
            this.pictureBox1.TabIndex = 13;
            this.pictureBox1.TabStop = false;
            // 
            // lblNbInterfaces
            // 
            this.lblNbInterfaces.AutoSize = true;
            this.lblNbInterfaces.Font = new System.Drawing.Font("Calibri", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNbInterfaces.Location = new System.Drawing.Point(709, 23);
            this.lblNbInterfaces.Name = "lblNbInterfaces";
            this.lblNbInterfaces.Size = new System.Drawing.Size(33, 39);
            this.lblNbInterfaces.TabIndex = 14;
            this.lblNbInterfaces.Text = "1";
            // 
            // cmsConfiguration
            // 
            this.cmsConfiguration.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.nbSocketInterfaceToolStripMenuItem,
            this.blockSizeToolStripMenuItem});
            this.cmsConfiguration.Name = "contextMenuStrip1";
            this.cmsConfiguration.Size = new System.Drawing.Size(180, 48);
            this.cmsConfiguration.Text = "Configuration";
            // 
            // nbSocketInterfaceToolStripMenuItem
            // 
            this.nbSocketInterfaceToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem2,
            this.toolStripMenuItem3,
            this.toolStripMenuItem4,
            this.toolStripMenuItem5,
            this.toolStripMenuItem6,
            this.toolStripMenuItem7,
            this.toolStripMenuItem8});
            this.nbSocketInterfaceToolStripMenuItem.Name = "nbSocketInterfaceToolStripMenuItem";
            this.nbSocketInterfaceToolStripMenuItem.Size = new System.Drawing.Size(179, 22);
            this.nbSocketInterfaceToolStripMenuItem.Text = "Nb Socket/Interface";
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(152, 22);
            this.toolStripMenuItem2.Text = "1";
            // 
            // toolStripMenuItem3
            // 
            this.toolStripMenuItem3.Name = "toolStripMenuItem3";
            this.toolStripMenuItem3.Size = new System.Drawing.Size(152, 22);
            this.toolStripMenuItem3.Text = "2";
            // 
            // toolStripMenuItem4
            // 
            this.toolStripMenuItem4.Name = "toolStripMenuItem4";
            this.toolStripMenuItem4.Size = new System.Drawing.Size(152, 22);
            this.toolStripMenuItem4.Text = "5";
            // 
            // toolStripMenuItem5
            // 
            this.toolStripMenuItem5.Name = "toolStripMenuItem5";
            this.toolStripMenuItem5.Size = new System.Drawing.Size(152, 22);
            this.toolStripMenuItem5.Text = "10";
            // 
            // toolStripMenuItem6
            // 
            this.toolStripMenuItem6.Name = "toolStripMenuItem6";
            this.toolStripMenuItem6.Size = new System.Drawing.Size(152, 22);
            this.toolStripMenuItem6.Text = "20";
            // 
            // toolStripMenuItem7
            // 
            this.toolStripMenuItem7.Name = "toolStripMenuItem7";
            this.toolStripMenuItem7.Size = new System.Drawing.Size(152, 22);
            this.toolStripMenuItem7.Text = "50";
            // 
            // toolStripMenuItem8
            // 
            this.toolStripMenuItem8.Name = "toolStripMenuItem8";
            this.toolStripMenuItem8.Size = new System.Drawing.Size(152, 22);
            this.toolStripMenuItem8.Text = "100";
            // 
            // blockSizeToolStripMenuItem
            // 
            this.blockSizeToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mbToolStripMenuItem,
            this.mbToolStripMenuItem1,
            this.mbToolStripMenuItem2,
            this.mbToolStripMenuItem3,
            this.mbToolStripMenuItem4,
            this.mbToolStripMenuItem5});
            this.blockSizeToolStripMenuItem.Name = "blockSizeToolStripMenuItem";
            this.blockSizeToolStripMenuItem.Size = new System.Drawing.Size(179, 22);
            this.blockSizeToolStripMenuItem.Text = "Block Size";
            // 
            // mbToolStripMenuItem
            // 
            this.mbToolStripMenuItem.Name = "mbToolStripMenuItem";
            this.mbToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.mbToolStripMenuItem.Text = "1 Mb";
            // 
            // mbToolStripMenuItem1
            // 
            this.mbToolStripMenuItem1.Name = "mbToolStripMenuItem1";
            this.mbToolStripMenuItem1.Size = new System.Drawing.Size(152, 22);
            this.mbToolStripMenuItem1.Text = "2 Mb";
            // 
            // mbToolStripMenuItem2
            // 
            this.mbToolStripMenuItem2.Name = "mbToolStripMenuItem2";
            this.mbToolStripMenuItem2.Size = new System.Drawing.Size(152, 22);
            this.mbToolStripMenuItem2.Text = "5 Mb";
            // 
            // mbToolStripMenuItem3
            // 
            this.mbToolStripMenuItem3.Name = "mbToolStripMenuItem3";
            this.mbToolStripMenuItem3.Size = new System.Drawing.Size(152, 22);
            this.mbToolStripMenuItem3.Text = "10 Mb";
            // 
            // mbToolStripMenuItem4
            // 
            this.mbToolStripMenuItem4.Name = "mbToolStripMenuItem4";
            this.mbToolStripMenuItem4.Size = new System.Drawing.Size(152, 22);
            this.mbToolStripMenuItem4.Text = "50 Mb";
            // 
            // mbToolStripMenuItem5
            // 
            this.mbToolStripMenuItem5.Name = "mbToolStripMenuItem5";
            this.mbToolStripMenuItem5.Size = new System.Drawing.Size(152, 22);
            this.mbToolStripMenuItem5.Text = "100 Mb";
            // 
            // mainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(785, 510);
            this.ContextMenuStrip = this.cmsConfiguration;
            this.Controls.Add(this.tcMain);
            this.Controls.Add(this.lblNbInterfaces);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.rtbURL);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lblBlockSize);
            this.Controls.Add(this.nudConnPerInterfaces);
            this.Controls.Add(this.nudBlockSize);
            this.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.Name = "mainForm";
            this.Text = "FastDL version poc";
            this.Load += new System.EventHandler(this.mainForm_Load);
            this.Enter += new System.EventHandler(this.linkGrabber);
            ((System.ComponentModel.ISupportInitialize)(this.nudBlockSize)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudConnPerInterfaces)).EndInit();
            this.tabPage3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvSearch)).EndInit();
            this.tcMain.ResumeLayout(false);
            this.tpDownloads.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDownloads)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.cmsConfiguration.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.NumericUpDown nudBlockSize;
        private System.Windows.Forms.NumericUpDown nudConnPerInterfaces;
        private System.Windows.Forms.Label lblBlockSize;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.RichTextBox rtbURL;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.DataGridView dgvSearch;
        private System.Windows.Forms.DataGridViewTextBoxColumn Filename;
        private System.Windows.Forms.DataGridViewTextBoxColumn Description;
        private System.Windows.Forms.DataGridViewTextBoxColumn url;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.RichTextBox tbSearch;
        public System.Windows.Forms.TabControl tcMain;
        private System.Windows.Forms.TabPage tpDownloads;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label lblNbInterfaces;
        public System.Windows.Forms.DataGridView dgvDownloads;
        private System.Windows.Forms.DataGridViewTextBoxColumn name;
        private System.Windows.Forms.DataGridViewImageColumn downloaded;
        private System.Windows.Forms.DataGridViewTextBoxColumn size;
        private System.Windows.Forms.DataGridViewTextBoxColumn speed;
        private System.Windows.Forms.DataGridViewTextBoxColumn status;
        private System.Windows.Forms.DataGridViewTextBoxColumn Link;
        private System.Windows.Forms.ContextMenuStrip cmsConfiguration;
        private System.Windows.Forms.ToolStripMenuItem nbSocketInterfaceToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem3;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem4;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem5;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem6;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem7;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem8;
        private System.Windows.Forms.ToolStripMenuItem blockSizeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem mbToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem mbToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem mbToolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem mbToolStripMenuItem3;
        private System.Windows.Forms.ToolStripMenuItem mbToolStripMenuItem4;
        private System.Windows.Forms.ToolStripMenuItem mbToolStripMenuItem5;
    }
}

