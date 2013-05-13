using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace TeraPlayerExp
{
    public partial class Form1 : Form
    {
        public static List<long> PlayerExperience = new List<long>();
        public static List<long> PlayerExp = new List<long>();
        public static string hexData;

        public Form1()
        {
            InitializeComponent();
        }

        public void prepareLevels()
        {
            Experience exper = new Experience();

            int expCount = exper.PlayerExp.Count;
            for( int i = 0; i < expCount; i++ )
            {
                PlayerExp.Add(Int64.Parse(exper.PlayerExp[i]));
            }
        }

        OpenFileDialog ofd = new OpenFileDialog();
        SaveFileDialog sfd = new SaveFileDialog();

        public void loadFile()
        {
            using (FileStream stream = File.OpenRead(ofd.FileName))
            {
                using (BinaryReader reader = new BinaryReader(stream))
                {
                    int count = reader.ReadInt32();
                    for (int i = 0; i < count; i++)
                        listBox1.Items.Add("Level -  " + i + " / " + reader.ReadInt64());
                }
             }

        }

        private void btnLoadExp_Click(object sender, EventArgs e)
        {
            DialogResult openResult = ofd.ShowDialog();
            if (openResult == DialogResult.Cancel)
            {
                return;
            }
            loadFile();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnLoadNewExp_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            prepareLevels();

            int count = PlayerExp.Count;
            for (int i = 0; i < count; i++)
            {
                listBox1.Items.Add("Level - " + i + " / " + PlayerExp[i]);
                
            }
        }

        private void btnSaveNewExp_Click(object sender, EventArgs e)
        {
            DialogResult saveResult = sfd.ShowDialog();

            sfd.FileName = sfd.FileName + ".dat";

            if (saveResult == DialogResult.Cancel)
            {
                return;
            }

            string filename = sfd.FileName;

            BinaryWriter bw = new BinaryWriter(File.OpenWrite(sfd.FileName));

            byte[] emptyByte = new byte[] { 0x00 };

            int count = PlayerExp.Count();
            for (int i = 0; i < count; i++)
            {
                if (i == 0)
                {
                    bw.Write(PlayerExp[i]);
                    bw.Write(emptyByte[0]);
                    bw.Write(emptyByte[0]);
                    bw.Write(emptyByte[0]);
                    bw.Write(emptyByte[0]);
                }
                else
                {
                    bw.Write(PlayerExp[i]);
                }
            }
            bw.Close();
            Application.Exit();
        }

        void sfd_Disposed(object sender, EventArgs e)
        {
            MessageBox.Show("TEST");
            return;
        }

        void sfd_FileOk(object sender, CancelEventArgs e)
        {
            if (sfd.FileName == "")
            {
                MessageBox.Show("You must give the file a name!");
                e.Cancel = true;
            }
            if (!sfd.FileName.EndsWith(".dat"))
            {
                MessageBox.Show("Your file must end with .dat");
                e.Cancel = true;
            }
        }

        private string HexAsciiConvert(string hex)
        {
            StringBuilder sb = new StringBuilder();

            for (int i = 0; i <= hex.Length - 2; i += 2)
            {
                sb.Append(Convert.ToString(Convert.ToChar(Int32.Parse(hex.Substring(i, 2),
                    System.Globalization.NumberStyles.HexNumber))));
            }
            return sb.ToString();
        }
    }
}
