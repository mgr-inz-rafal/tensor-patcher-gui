using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace tensor_patcher_gui {
    public partial class MainForm : Form {
        const int MAP_DIMENSION = 12;
        const int MAP_DATA_BYTE_COUNT = MAP_DIMENSION * MAP_DIMENSION;
        const int TOTAL_MAP_COUNT = 51;
        const int TOTAL_MAP_DATA_SIZE = MAP_DATA_BYTE_COUNT * TOTAL_MAP_COUNT;

        byte[] rawMapData;

        Cave[] caves = new Cave[TOTAL_MAP_COUNT];

        public MainForm() {
            InitializeComponent();
            SetupForm();
        }

        private void MainForm_Load(object sender, EventArgs e) {
            ShowInfo("Ready for action!");
        }

        private void button_LocateTensorAutomaticaly_Click(object sender, EventArgs e) {
            ShowError("Not implemented... yet!");
        }

        private Tuple<bool, String> ValidateTensorBinary(String file) {
            const int EXPECTED_FILE_SIZE = 49506;

            // Size validation would be enough
            var len = new System.IO.FileInfo(file).Length;
            if(len != EXPECTED_FILE_SIZE) {
                return new Tuple<bool, String>(false, String.Format("Incorrect file size ({1} bytes expected, {0} bytes found)", len, EXPECTED_FILE_SIZE));
            }

            return new Tuple<bool, String>(true, "");
        }

        private void ShowError(String msg) {
            this.sbar.Items[0].Text = msg;
            this.sbar.Items[0].Image = tensor_patcher_gui.Properties.Resources.icon_error;
            SystemSounds.Hand.Play();
        }

        private void ShowInfo(String msg) {
            this.sbar.Items[0].Text = msg;
            this.sbar.Items[0].Image = tensor_patcher_gui.Properties.Resources.icon_ok;
        }

        private void LoadTensor(String fileName) {
            const int MAP_DATA_OFFSET = 0xA022;
            var reader = new System.IO.BinaryReader(File.Open(fileName, FileMode.Open));
            reader.BaseStream.Seek(MAP_DATA_OFFSET, SeekOrigin.Begin);
            rawMapData = reader.ReadBytes(TOTAL_MAP_DATA_SIZE);
        }

        private void ParseMapData() {
            for(int i = 0; i < TOTAL_MAP_COUNT; ++i) {
                caves[i] = new Cave(String.Format("Map {0} title", i + 1));
//                Array.Copy(rawMapData, i * MAP_DATA_BYTE_COUNT, caves[i].mapData, 0, MAP_DATA_BYTE_COUNT);
            }
        }

        private void PopulateMapList() {
            for(int i = 0; i < TOTAL_MAP_COUNT; ++i) {
                var item = listCaves.Items.Add(String.Format("{0}", i+1));
                item.SubItems.Add(caves[i].Name);
            }
            this.columnHeader3.Width = -2;
        }

        private void button_LocateTensorManually_Click(object sender, EventArgs e) {
            if (openFileDialog.ShowDialog() != DialogResult.OK) {
                return;
            }

            var valid = ValidateTensorBinary(openFileDialog.FileName);
            if (!valid.Item1) {
                ShowError(valid.Item2);
                return;
            }

            LoadTensor(openFileDialog.FileName);
            ParseMapData();
            PopulateMapList();

            ShowInfo("Tensor.xex loaded successfully");
        }
    }
}
