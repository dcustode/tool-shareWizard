using Microsoft.VisualBasic.Devices;
using Newtonsoft.Json;
using System.Diagnostics;
using System.Net.NetworkInformation;
using System.Threading.Tasks;

namespace hiddenShares
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private async void Form1_Load(object sender, EventArgs e)
        {
            ServerDefinitions serverDefinitions;

            // deserialize JSON directly from a file
            using (StreamReader file = File.OpenText(Path.GetDirectoryName(Application.ExecutablePath) + "\\" + "MyServers.json"))
            {
                JsonSerializer serializer = new JsonSerializer();
                serverDefinitions = (ServerDefinitions)serializer.Deserialize(file, typeof(ServerDefinitions));
            }


            foreach (ServerDefinition server in serverDefinitions.Servers)
            {
                int index = dataGridView1.Rows.Add(new object[] { server.HostName, server.Description });
                dataGridView1.Rows[index].Tag = server;

                dataGridView1.Rows[index].Cells[1].Style.BackColor = await GetStatusColor(server.HostName);

                if (server.HostName.ToLower().StartsWith("s7"))
                {
                    dataGridView1.Rows[index].DefaultCellStyle.BackColor = Color.LightYellow;
                }
                else if (server.HostName.ToLower().StartsWith("s8"))
                {
                    dataGridView1.Rows[index].DefaultCellStyle.BackColor = Color.LightSkyBlue;

                }
                else if (server.HostName.ToLower().StartsWith("s9"))
                {
                    dataGridView1.Rows[index].DefaultCellStyle.BackColor = Color.LightGray;

                }
                else
                {
                    dataGridView1.Rows[index].DefaultCellStyle.BackColor = Color.LightSalmon;
                }
            }
        }

        public async Task<Color> GetStatusColor(string hostname)
        {
            bool isReachable = await IsHostReachable(hostname);
            return isReachable ? Color.LightGreen : Color.LightPink;
        }

        public async Task<bool> IsHostReachable(string hostNameOrAddress, int timeout = 2000)
        {
            try
            {
                using (Ping ping = new Ping())
                {
                    PingReply reply = await ping.SendPingAsync(hostNameOrAddress, timeout);
                    return reply.Status == IPStatus.Success;
                }
            }
            catch
            {
                // Handle exceptions (e.g., invalid host name, network issues)
                return false;
            }
        }


        public string ServerName
        {
            get
            {
                return txtBxServer.Text;
            }
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
            if (lstVwShares.SelectedItems.Count == 0)
                return;

            string shareName = lstVwShares.SelectedItems[0].Text;
            string path = $@"\\{ServerName}\{shareName}";

            Process.Start(new ProcessStartInfo
            {
                FileName = "explorer.exe",
                Arguments = path,
                UseShellExecute = true
            });
        }


        private void button1_Click(object sender, EventArgs e)
        {
            FillShares();
        }

        private void lstVwShares_SelectedIndexChanged(object sender, EventArgs e)
        {

        }



        private void dataGridView1_DoubleClick(object sender, EventArgs e)
        {
            ServerDefinition server = dataGridView1.SelectedRows[0].Tag as ServerDefinition;

            if (server == null)
            {
                return;
            }

            txtBxServer.Text = server.HostName;
            FillShares();
        }
    }
}
