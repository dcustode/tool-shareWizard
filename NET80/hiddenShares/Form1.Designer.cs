namespace hiddenShares
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            grpBxServers = new GroupBox();
            dataGridView1 = new DataGridView();
            clmHostName = new DataGridViewTextBoxColumn();
            splitContainer1 = new SplitContainer();
            grpBxShares = new GroupBox();
            lstVwShares = new ListView();
            grpBxSelServer = new GroupBox();
            txtBxServer = new TextBox();
            btnClose = new Button();
            grpBxServers.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)splitContainer1).BeginInit();
            splitContainer1.Panel1.SuspendLayout();
            splitContainer1.Panel2.SuspendLayout();
            splitContainer1.SuspendLayout();
            grpBxShares.SuspendLayout();
            grpBxSelServer.SuspendLayout();
            SuspendLayout();
            // 
            // grpBxServers
            // 
            grpBxServers.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            grpBxServers.AutoSize = true;
            grpBxServers.Controls.Add(dataGridView1);
            grpBxServers.Location = new Point(3, 3);
            grpBxServers.Name = "grpBxServers";
            grpBxServers.Size = new Size(272, 560);
            grpBxServers.TabIndex = 0;
            grpBxServers.TabStop = false;
            grpBxServers.Text = "Servers";
            // 
            // dataGridView1
            // 
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.AllowUserToDeleteRows = false;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Columns.AddRange(new DataGridViewColumn[] { clmHostName });
            dataGridView1.Dock = DockStyle.Fill;
            dataGridView1.Location = new Point(3, 19);
            dataGridView1.MultiSelect = false;
            dataGridView1.Name = "dataGridView1";
            dataGridView1.ReadOnly = true;
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView1.Size = new Size(266, 538);
            dataGridView1.TabIndex = 0;
            dataGridView1.DoubleClick += dataGridView1_DoubleClick;
            // 
            // clmHostName
            // 
            clmHostName.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            clmHostName.HeaderText = "Hostname";
            clmHostName.Name = "clmHostName";
            clmHostName.ReadOnly = true;
            // 
            // splitContainer1
            // 
            splitContainer1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            splitContainer1.Location = new Point(12, 12);
            splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            splitContainer1.Panel1.Controls.Add(grpBxServers);
            splitContainer1.Panel1MinSize = 250;
            // 
            // splitContainer1.Panel2
            // 
            splitContainer1.Panel2.Controls.Add(grpBxShares);
            splitContainer1.Panel2.Controls.Add(grpBxSelServer);
            splitContainer1.Size = new Size(834, 566);
            splitContainer1.SplitterDistance = 278;
            splitContainer1.SplitterWidth = 5;
            splitContainer1.TabIndex = 1;
            // 
            // grpBxShares
            // 
            grpBxShares.Controls.Add(lstVwShares);
            grpBxShares.Location = new Point(3, 113);
            grpBxShares.Name = "grpBxShares";
            grpBxShares.Size = new Size(546, 450);
            grpBxShares.TabIndex = 1;
            grpBxShares.TabStop = false;
            grpBxShares.Text = "Shares";
            // 
            // lstVwShares
            // 
            lstVwShares.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            lstVwShares.Location = new Point(6, 22);
            lstVwShares.Name = "lstVwShares";
            lstVwShares.Size = new Size(534, 422);
            lstVwShares.TabIndex = 0;
            lstVwShares.UseCompatibleStateImageBehavior = false;
            lstVwShares.View = View.List;
            lstVwShares.DoubleClick += lstVwShares_DoubleClick;
            // 
            // grpBxSelServer
            // 
            grpBxSelServer.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            grpBxSelServer.Controls.Add(txtBxServer);
            grpBxSelServer.Location = new Point(3, 3);
            grpBxSelServer.Name = "grpBxSelServer";
            grpBxSelServer.Size = new Size(541, 104);
            grpBxSelServer.TabIndex = 0;
            grpBxSelServer.TabStop = false;
            grpBxSelServer.Text = "Selected Server";
            // 
            // txtBxServer
            // 
            txtBxServer.Location = new Point(11, 20);
            txtBxServer.Name = "txtBxServer";
            txtBxServer.Size = new Size(526, 23);
            txtBxServer.TabIndex = 0;
            txtBxServer.KeyDown += txtBxServer_KeyDown;
            // 
            // btnClose
            // 
            btnClose.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnClose.Location = new Point(771, 586);
            btnClose.Name = "btnClose";
            btnClose.Size = new Size(75, 23);
            btnClose.TabIndex = 2;
            btnClose.Text = "Close";
            btnClose.UseVisualStyleBackColor = true;
            btnClose.Click += btnClose_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(858, 621);
            Controls.Add(btnClose);
            Controls.Add(splitContainer1);
            Name = "Form1";
            Text = "Share wizard";
            Load += Form1_Load;
            grpBxServers.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            splitContainer1.Panel1.ResumeLayout(false);
            splitContainer1.Panel1.PerformLayout();
            splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)splitContainer1).EndInit();
            splitContainer1.ResumeLayout(false);
            grpBxShares.ResumeLayout(false);
            grpBxSelServer.ResumeLayout(false);
            grpBxSelServer.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private GroupBox grpBxServers;
        private SplitContainer splitContainer1;
        private GroupBox grpBxShares;
        private GroupBox grpBxSelServer;
        private Button btnClose;
        private DataGridView dataGridView1;
        private DataGridViewTextBoxColumn clmHostName;
        private ListView lstVwShares;
        private TextBox txtBxServer;
    }
}
