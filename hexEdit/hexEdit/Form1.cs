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

namespace hexEdit
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            lblWordCount.Text = "0 Characters Written";
            tbURL.TextChanged += tbURL_TextChanged;
        }

        void tbURL_TextChanged(object sender, EventArgs e)
        {
            lblWordCount.Text = tbURL.Text.Length.ToString() + " Characters Written";
        }

        OpenFileDialog ofd = new OpenFileDialog();
        SaveFileDialog sfd = new SaveFileDialog();

        private void btnOpenFile_Click(object sender, EventArgs e)
        {
            ofd.ShowDialog();
            BinaryReader br = new BinaryReader(File.OpenRead(ofd.FileName));
            string selectHex = null;
            for (int i = 0x4E69B4; i <= 0x4E69E4; i++)
            {
                br.BaseStream.Position = i;
                selectHex += br.ReadByte().ToString("X2");
            }
            br.Close();
            tbURL.Text = HexAsciiConvert(selectHex);
        }

        private void btnSaveFile_Click(object sender, EventArgs e)
        {
            if (tbURL.Text.Length != 49)
            {
                MessageBox.Show("Length of url must be 49 characters!");
                return;
            }

            int x = -1;
            ASCIIEncoding asen = new ASCIIEncoding();
            byte[] ba = asen.GetBytes(tbURL.Text);
            BinaryWriter bw = new BinaryWriter(File.OpenWrite(ofd.FileName));
            for (int i = 0x4E69B4; i <= 0x4E69E4; i++)
            {
                x++;
                bw.BaseStream.Position = i;
                bw.Write(ba[x]);
            }
            bw.Close();
            MessageBox.Show("Your launcher has been saved!");
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

        private void btnClose_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

    }
}
