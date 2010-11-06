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
            this.nudBlockSize = new System.Windows.Forms.NumericUpDown();
            this.nudConnPerInterfaces = new System.Windows.Forms.NumericUpDown();
            this.dgvThread = new System.Windows.Forms.DataGridView();
            this.nthread = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.bytesdownloaded = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.percentblock = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.part = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lblBlockSize = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.rtbURL = new System.Windows.Forms.RichTextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.lblSpeed = new System.Windows.Forms.Label();
            this.pbProgressBlock = new System.Windows.Forms.PictureBox();
            this.button2 = new System.Windows.Forms.Button();
            this.dgvInterfaces = new System.Windows.Forms.DataGridView();
            this.Adapter = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Speed = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Percent = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.nudBlockSize)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudConnPerInterfaces)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvThread)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbProgressBlock)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvInterfaces)).BeginInit();
            this.SuspendLayout();
            // 
            // nudBlockSize
            // 
            this.nudBlockSize.Location = new System.Drawing.Point(621, 286);
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
            this.nudConnPerInterfaces.Location = new System.Drawing.Point(621, 326);
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
            // dgvThread
            // 
            this.dgvThread.AllowUserToAddRows = false;
            this.dgvThread.AllowUserToDeleteRows = false;
            this.dgvThread.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvThread.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.nthread,
            this.bytesdownloaded,
            this.percentblock,
            this.part});
            this.dgvThread.Location = new System.Drawing.Point(13, 160);
            this.dgvThread.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.dgvThread.Name = "dgvThread";
            this.dgvThread.ReadOnly = true;
            this.dgvThread.RowHeadersVisible = false;
            this.dgvThread.Size = new System.Drawing.Size(425, 172);
            this.dgvThread.TabIndex = 2;
            // 
            // nthread
            // 
            this.nthread.HeaderText = "#thread";
            this.nthread.Name = "nthread";
            this.nthread.ReadOnly = true;
            this.nthread.Width = 60;
            // 
            // bytesdownloaded
            // 
            this.bytesdownloaded.HeaderText = "Bytes";
            this.bytesdownloaded.Name = "bytesdownloaded";
            this.bytesdownloaded.ReadOnly = true;
            // 
            // percentblock
            // 
            this.percentblock.HeaderText = "% Block";
            this.percentblock.Name = "percentblock";
            this.percentblock.ReadOnly = true;
            // 
            // part
            // 
            this.part.HeaderText = "part";
            this.part.Name = "part";
            this.part.ReadOnly = true;
            // 
            // lblBlockSize
            // 
            this.lblBlockSize.AutoSize = true;
            this.lblBlockSize.Location = new System.Drawing.Point(519, 288);
            this.lblBlockSize.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblBlockSize.Name = "lblBlockSize";
            this.lblBlockSize.Size = new System.Drawing.Size(90, 15);
            this.lblBlockSize.TabIndex = 3;
            this.lblBlockSize.Text = "Block Size (Mo)";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(493, 329);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(114, 15);
            this.label2.TabIndex = 4;
            this.label2.Text = "Nb Socket/Interface";
            // 
            // rtbURL
            // 
            this.rtbURL.Location = new System.Drawing.Point(14, 13);
            this.rtbURL.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.rtbURL.Multiline = false;
            this.rtbURL.Name = "rtbURL";
            this.rtbURL.Size = new System.Drawing.Size(650, 49);
            this.rtbURL.TabIndex = 5;
            this.rtbURL.Text = "";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(672, 13);
            this.button1.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(88, 49);
            this.button1.TabIndex = 6;
            this.button1.Text = "Go";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // lblSpeed
            // 
            this.lblSpeed.AutoSize = true;
            this.lblSpeed.Location = new System.Drawing.Point(12, 80);
            this.lblSpeed.Name = "lblSpeed";
            this.lblSpeed.Size = new System.Drawing.Size(60, 15);
            this.lblSpeed.TabIndex = 7;
            this.lblSpeed.Text = "0 Ko / sec";
            // 
            // pbProgressBlock
            // 
            this.pbProgressBlock.BackColor = System.Drawing.SystemColors.ControlLight;
            this.pbProgressBlock.Location = new System.Drawing.Point(13, 98);
            this.pbProgressBlock.Name = "pbProgressBlock";
            this.pbProgressBlock.Size = new System.Drawing.Size(700, 30);
            this.pbProgressBlock.TabIndex = 8;
            this.pbProgressBlock.TabStop = false;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(555, 228);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 41);
            this.button2.TabIndex = 9;
            this.button2.Text = "Delete all downloads";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // dgvInterfaces
            // 
            this.dgvInterfaces.AllowUserToAddRows = false;
            this.dgvInterfaces.AllowUserToDeleteRows = false;
            this.dgvInterfaces.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvInterfaces.ColumnHeadersVisible = false;
            this.dgvInterfaces.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Adapter,
            this.Speed,
            this.Percent});
            this.dgvInterfaces.Location = new System.Drawing.Point(13, 375);
            this.dgvInterfaces.Name = "dgvInterfaces";
            this.dgvInterfaces.ReadOnly = true;
            this.dgvInterfaces.RowHeadersVisible = false;
            this.dgvInterfaces.Size = new System.Drawing.Size(565, 82);
            this.dgvInterfaces.TabIndex = 10;
            // 
            // Adapter
            // 
            this.Adapter.HeaderText = "Adapter";
            this.Adapter.Name = "Adapter";
            this.Adapter.ReadOnly = true;
            this.Adapter.Width = 350;
            // 
            // Speed
            // 
            this.Speed.HeaderText = "Speed";
            this.Speed.Name = "Speed";
            this.Speed.ReadOnly = true;
            // 
            // Percent
            // 
            this.Percent.HeaderText = "Percent";
            this.Percent.Name = "Percent";
            this.Percent.ReadOnly = true;
            // 
            // mainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(774, 469);
            this.Controls.Add(this.dgvInterfaces);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.pbProgressBlock);
            this.Controls.Add(this.lblSpeed);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.rtbURL);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lblBlockSize);
            this.Controls.Add(this.dgvThread);
            this.Controls.Add(this.nudConnPerInterfaces);
            this.Controls.Add(this.nudBlockSize);
            this.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.Name = "mainForm";
            this.Text = "FastDL version PoC";
            this.Load += new System.EventHandler(this.mainForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.nudBlockSize)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudConnPerInterfaces)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvThread)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbProgressBlock)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvInterfaces)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.NumericUpDown nudBlockSize;
        private System.Windows.Forms.NumericUpDown nudConnPerInterfaces;
        private System.Windows.Forms.DataGridView dgvThread;
        private System.Windows.Forms.DataGridViewTextBoxColumn nthread;
        private System.Windows.Forms.DataGridViewTextBoxColumn bytesdownloaded;
        private System.Windows.Forms.DataGridViewTextBoxColumn percentblock;
        private System.Windows.Forms.DataGridViewTextBoxColumn part;
        private System.Windows.Forms.Label lblBlockSize;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.RichTextBox rtbURL;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label lblSpeed;
        private System.Windows.Forms.PictureBox pbProgressBlock;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.DataGridView dgvInterfaces;
        private System.Windows.Forms.DataGridViewTextBoxColumn Adapter;
        private System.Windows.Forms.DataGridViewTextBoxColumn Speed;
        private System.Windows.Forms.DataGridViewTextBoxColumn Percent;
    }
}

