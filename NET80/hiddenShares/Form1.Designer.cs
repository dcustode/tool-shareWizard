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
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            grpBxServers = new GroupBox();
            dataGridView1 = new DataGridView();
            clmHostName = new DataGridViewTextBoxColumn();
            Status = new DataGridViewTextBoxColumn();
            grpBxShares = new GroupBox();
            lstVwShares = new ListView();
            grpBxSelServer = new GroupBox();
            txtBxServer = new TextBox();
            btnClose = new Button();
            grpBxServers.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            grpBxShares.SuspendLayout();
            grpBxSelServer.SuspendLayout();
            SuspendLayout();
            // 
            // grpBxServers
            // 
            grpBxServers.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
            grpBxServers.AutoSize = true;
            grpBxServers.Controls.Add(dataGridView1);
            grpBxServers.Location = new Point(12, 4);
            grpBxServers.Margin = new Padding(3, 4, 3, 4);
            grpBxServers.Name = "grpBxServers";
            grpBxServers.Padding = new Padding(3, 4, 3, 4);
            grpBxServers.Size = new Size(567, 896);
            grpBxServers.TabIndex = 0;
            grpBxServers.TabStop = false;
            grpBxServers.Text = "Servers";
            // 
            // dataGridView1
            // 
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.AllowUserToDeleteRows = false;
            dataGridView1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Columns.AddRange(new DataGridViewColumn[] { clmHostName, Status });
            dataGridView1.Location = new Point(6, 28);
            dataGridView1.Margin = new Padding(3, 4, 3, 4);
            dataGridView1.MultiSelect = false;
            dataGridView1.Name = "dataGridView1";
            dataGridView1.ReadOnly = true;
            dataGridView1.RowHeadersWidth = 51;
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView1.Size = new Size(550, 852);
            dataGridView1.TabIndex = 0;
            dataGridView1.DoubleClick += dataGridView1_DoubleClick;
            // 
            // clmHostName
            // 
            clmHostName.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            clmHostName.HeaderText = "Hostname";
            clmHostName.MinimumWidth = 6;
            clmHostName.Name = "clmHostName";
            clmHostName.ReadOnly = true;
            // 
            // Status
            // 
            dataGridViewCellStyle1.BackColor = Color.FromArgb(255, 224, 192);
            Status.DefaultCellStyle = dataGridViewCellStyle1;
            Status.HeaderText = "Function";
            Status.MinimumWidth = 100;
            Status.Name = "Status";
            Status.ReadOnly = true;
            Status.Width = 250;
            // 
            // grpBxShares
            // 
            grpBxShares.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            grpBxShares.Controls.Add(lstVwShares);
            grpBxShares.Location = new Point(590, 166);
            grpBxShares.Margin = new Padding(3, 4, 3, 4);
            grpBxShares.Name = "grpBxShares";
            grpBxShares.Padding = new Padding(3, 4, 3, 4);
            grpBxShares.Size = new Size(450, 734);
            grpBxShares.TabIndex = 1;
            grpBxShares.TabStop = false;
            grpBxShares.Text = "Shares";
            // 
            // lstVwShares
            // 
            lstVwShares.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            lstVwShares.Location = new Point(7, 29);
            lstVwShares.Margin = new Padding(3, 4, 3, 4);
            lstVwShares.Name = "lstVwShares";
            lstVwShares.Size = new Size(436, 695);
            lstVwShares.TabIndex = 0;
            lstVwShares.UseCompatibleStateImageBehavior = false;
            lstVwShares.View = View.List;
            lstVwShares.DoubleClick += lstVwShares_DoubleClick;
            // 
            // grpBxSelServer
            // 
            grpBxSelServer.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            grpBxSelServer.Controls.Add(txtBxServer);
            grpBxSelServer.Location = new Point(597, 19);
            grpBxSelServer.Margin = new Padding(3, 4, 3, 4);
            grpBxSelServer.Name = "grpBxSelServer";
            grpBxSelServer.Padding = new Padding(3, 4, 3, 4);
            grpBxSelServer.Size = new Size(443, 139);
            grpBxSelServer.TabIndex = 0;
            grpBxSelServer.TabStop = false;
            grpBxSelServer.Text = "Selected Server";
            // 
            // txtBxServer
            // 
            txtBxServer.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            txtBxServer.Location = new Point(13, 27);
            txtBxServer.Margin = new Padding(3, 4, 3, 4);
            txtBxServer.Name = "txtBxServer";
            txtBxServer.Size = new Size(423, 27);
            txtBxServer.TabIndex = 0;
            txtBxServer.KeyDown += txtBxServer_KeyDown;
            // 
            // btnClose
            // 
            btnClose.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnClose.Location = new Point(952, 915);
            btnClose.Margin = new Padding(3, 4, 3, 4);
            btnClose.Name = "btnClose";
            btnClose.Size = new Size(86, 31);
            btnClose.TabIndex = 2;
            btnClose.Text = "Close";
            btnClose.UseVisualStyleBackColor = true;
            btnClose.Click += btnClose_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1052, 962);
            Controls.Add(grpBxServers);
            Controls.Add(grpBxSelServer);
            Controls.Add(grpBxShares);
            Controls.Add(btnClose);
            Margin = new Padding(3, 4, 3, 4);
            Name = "Form1";
            Text = "Share wizard";
            Load += Form1_Load;
            grpBxServers.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            grpBxShares.ResumeLayout(false);
            grpBxSelServer.ResumeLayout(false);
            grpBxSelServer.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private GroupBox grpBxServers;
        private GroupBox grpBxShares;
        private GroupBox grpBxSelServer;
        private Button btnClose;
        private DataGridView dataGridView1;
        private ListView lstVwShares;
        private TextBox txtBxServer;
        private DataGridViewTextBoxColumn clmHostName;
        private DataGridViewTextBoxColumn Status;
    }
}
