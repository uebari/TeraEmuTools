using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Data;
using Data.Structures.Npc;
using Data.Structures.Creature;
using Data.Structures.Template;
using Data.Interfaces;
using Utils;
using ProtoBuf;
using System.IO;
using Data.DAO;
using System.Xml;


namespace TeraNPCSpawn
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        public OpenFileDialog ofd = new OpenFileDialog();
        public SaveFileDialog sfd = new SaveFileDialog();
        public List<NpcTemplate> NpcTemplates = new List<NpcTemplate>();
        public static Dictionary<int, List<SpawnTemplate>> Spawns = new Dictionary<int, List<SpawnTemplate>>();
        public static List<SpawnTemplate> SpawnsList = new List<SpawnTemplate>();

        public void LoadNPCList()
        {

        }

        public void AddNPC()
        {

        }

        public void SaveNPCList()
        {

        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult dr = ofd.ShowDialog();
            if (dr == DialogResult.Cancel)
                return;

            listBox1.Items.Clear();

            Spawns = new Dictionary<int, List<SpawnTemplate>>();

            using (FileStream stream = File.OpenRead(ofd.FileName))
            {
                while (stream.Position < stream.Length)
                {
                    SpawnTemplate spawnTemplate = Serializer.DeserializeWithLengthPrefix<SpawnTemplate>(stream, PrefixStyle.Fixed32);

                    if (!Spawns.ContainsKey(spawnTemplate.MapId))
                        Spawns.Add(spawnTemplate.MapId, new List<SpawnTemplate>());

                    Spawns[spawnTemplate.MapId].Add(spawnTemplate);

                    listBox1.Items.Add(spawnTemplate.NpcId);
                    SpawnsList.Add(spawnTemplate);
                }
            }

        }

        private void LoadSpawnInfo()
        {

        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult ds = sfd.ShowDialog();
            if (ds == DialogResult.Cancel)
                return;

            using (FileStream fs = File.OpenRead(ofd.FileName))
            {
                SpawnTemplate spawnTemplate = Serializer.DeserializeWithLengthPrefix<SpawnTemplate>(fs, PrefixStyle.Fixed32);
                using (FileStream stream = File.OpenWrite(sfd.FileName))
                {
                    foreach (var sp in SpawnsList)
                    {
                        //Serializer.SerializeWithLengthPrefix(stream, sp, PrefixStyle.Fixed32);
                    }
                }
                using (StreamWriter writer = new StreamWriter(sfd.FileName))
                {
                    foreach (var sp in SpawnsList)
                    {
                        string XMLFormat = "<NPC ID=\"" + sp.NpcId + "\" FULLID=\"" + ReturnNPCFullId(sp.NpcId, sp.Type) + "\""
                            + " Type=\"" + sp.Type + "\" MapId=\"" + sp.MapId + "\""
                            + " X=\"" + sp.X + "\" Y=\"" + sp.Y + "\" Z=\"" + sp.Z + "\""
                            + " Heading=\"" + sp.Heading + "\"></NPC>";
                        writer.WriteLine(XMLFormat);
                    }
                }
                SpawnsList.Clear();
            }
        }

        private void exotToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void listBox1_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            //object NpcID = listBox1.SelectedItem;
            //tbNpcId.Text = NpcID.ToString();
            //int NpcIDInt = int.Parse(NpcID.ToString());
            //MessageBox.Show(SpawnsList[NpcIDInt].NpcId.ToString());
        }

        private void saveNPCToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult dr = ofd.ShowDialog();
            if (dr == DialogResult.Cancel)
                return;
            SpawnsList.Clear();
            XmlReaderSettings xrset = new XmlReaderSettings();
            xrset.ConformanceLevel = ConformanceLevel.Fragment;
            using (XmlReader reader = XmlReader.Create(ofd.FileName, xrset))
            {
                while (reader.Read())
                {
                    if (reader.NodeType == XmlNodeType.Element && reader.Name == "NPC")
                    {
                        SpawnsList.Add(new SpawnTemplate
                        {
                            NpcId = int.Parse(reader.GetAttribute(0)),
                            Type = short.Parse(reader.GetAttribute(2)),
                            MapId = int.Parse(reader.GetAttribute(3)),
                            X = float.Parse(reader.GetAttribute(4)),
                            Y = float.Parse(reader.GetAttribute(5)),
                            Z = float.Parse(reader.GetAttribute(6)),
                            Heading = short.Parse(reader.GetAttribute(7)),
                            FullId = int.Parse(reader.GetAttribute(1))
                        });
                    }
                }
                reader.Close();

                DialogResult ds = sfd.ShowDialog();
                if (ds == DialogResult.Cancel)
                    return;

                using (FileStream stream = File.OpenWrite(sfd.FileName))
                {
                    foreach ( var sp in SpawnsList )
                    {
                        Serializer.SerializeWithLengthPrefix(stream, sp, PrefixStyle.Fixed32);
                    }
               }
            }
        }

        public static int ReturnNPCFullId(int NpcID, short Type)
        {
            return (NpcID) + (Type * 100000);
        }
    }
}
