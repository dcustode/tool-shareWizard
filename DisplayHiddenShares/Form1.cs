using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace DisplayHiddenShares
{
    public partial class Form1 : Form
    {
        public string ServerName
        {
            get
            {
                return txtBxServer.Text;
            }
        }
        public Form1()
        {
            InitializeComponent();

        }

        private void txtBxServer_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                FillShares();
            }
        }

        private void FillShares()
        {
            lstVwShares.Items.Clear();

            List<string> shares = new List<string>();

            shares = GetNetworkShareFoldersList(ServerName);

            foreach (string shareName in shares)
            {
                lstVwShares.Items.Add(shareName);
            }
        }

        private static List<string> GetNetworkShareFoldersList(string serverName)
        {
            List<string> shares = new List<string>();

            Process proc = new Process
            {
                StartInfo = new ProcessStartInfo
                {
                    FileName = "cmd.exe",
                    Arguments = string.Format(@"/c net view \\{0} /all", serverName),
                    UseShellExecute = false,
                    RedirectStandardOutput = true,
                    CreateNoWindow = true
                }
            };
            // then start the process and read from it:

            proc.Start();

            string line = string.Empty;

            while (!proc.StandardOutput.EndOfStream)
            {
                line = proc.StandardOutput.ReadLine().ToUpper();
                if (line.Contains("PLATTE") || line.Contains("DISQUE") || line.Contains("DISK"))
                {
                    shares.Add(line.Split(' ').First());
                }
            }

            shares.Sort();
            return shares;
        }

        private void lstVwShares_DoubleClick(object sender, EventArgs e)
        {
            ListViewItem selectedItem = sender as ListViewItem;
            string shareName = lstVwShares.SelectedItems[0].Text;

            Process.Start(string.Format(@"\\{0}\{1}", ServerName, shareName));
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FillShares();
        }

        private void lstVwShares_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            ServerDefinitions definitions = XmlHandler.DeserializeFromFile<ServerDefinitions>(Path.GetDirectoryName(Application.ExecutablePath) + "\\" + "MyServers.xml");

            foreach (ServerDefinition server in definitions.Servers)
            {
              int index =  dataGridView1.Rows.Add(new object[] { server.HostName, server.Description });
                dataGridView1.Rows[index].Tag = server;
            }
        }

        private void dataGridView1_DoubleClick(object sender, EventArgs e)
        {
            ServerDefinition server = dataGridView1.SelectedRows[0].Tag as ServerDefinition;
            txtBxServer.Text = server.HostName;
            FillShares();
        }
    }
}
