using System;
using System.Collections;
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
        private const int MAP_DIMENSION = 12;
        private const int MAP_DATA_BYTE_COUNT = MAP_DIMENSION * MAP_DIMENSION;
        private const int TOTAL_MAP_COUNT = 51;
        private const int TOTAL_MAP_DATA_SIZE = MAP_DATA_BYTE_COUNT * TOTAL_MAP_COUNT;
        private const int TILE_SIZE = 48;

        private byte[] rawMapData;

        private Cave[] caves = new Cave[TOTAL_MAP_COUNT];
        private Button[] mapTiles = new Button[MAP_DATA_BYTE_COUNT];

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

        private void button_MapTileMouseEnter(object sender, EventArgs e) {
            ((Button)sender).FlatStyle = FlatStyle.Popup;
        }

        private void button_MapTileMouseLeave(object sender, EventArgs e) {
            ((Button)sender).FlatStyle = FlatStyle.Flat;
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
                caves[i].mapData = new byte[MAP_DATA_BYTE_COUNT];
                Array.Copy(rawMapData, i * MAP_DATA_BYTE_COUNT, caves[i].mapData, 0, MAP_DATA_BYTE_COUNT);
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

            label_TensorLoadStatus.Text = "Select map and enjoy ➔";
            label_TensorLoadStatus.ForeColor = Color.Green;
            button_LocateTensorAutomaticaly.Visible = false;
            button_LocateTensorManually.Visible = false;

            ShowInfo("Tensor.xex loaded successfully");
        }

        private void CreateMapTiles() {
            for (int i = 0; i < MAP_DIMENSION; ++i) {
                for (int j = 0; j < MAP_DIMENSION; ++j) {
                    System.Windows.Forms.Button but = new System.Windows.Forms.Button();
                    but.Top = 32 + i * TILE_SIZE;
                    but.Left = 32 + j * TILE_SIZE;
                    but.Height = TILE_SIZE;
                    but.Width = TILE_SIZE;
                    but.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
                    but.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
                    but.Visible = false;
                    but.MouseEnter += new System.EventHandler(this.button_MapTileMouseEnter);
                    but.MouseLeave += new System.EventHandler(this.button_MapTileMouseLeave);
                    mapTiles[i* MAP_DIMENSION + j] = but;
                    this.Controls.Add(but);
                }
            }
        }

        private void ShowMapLayout(int index) {
            for(int i = 0; i < MAP_DIMENSION; ++i) {
                for(int j = 0; j < MAP_DIMENSION; ++j) {
                    var c = i * MAP_DIMENSION + j;
                    switch (caves[index].mapData[c]) {
                        case 5:
                            mapTiles[c].BackgroundImage = global::tensor_patcher_gui.Properties.Resources.brick05;
                            break;
                        case 5 + 64 + 64 + 64:
                            mapTiles[c].BackgroundImage = global::tensor_patcher_gui.Properties.Resources.brick05p;
                            break;
                        case 6:
                            mapTiles[c].BackgroundImage = global::tensor_patcher_gui.Properties.Resources.brick06;
                            break;
                        case 6 + 64 + 64 + 64:
                            mapTiles[c].BackgroundImage = global::tensor_patcher_gui.Properties.Resources.brick06p;
                            break;
                        case 7:
                            mapTiles[c].BackgroundImage = global::tensor_patcher_gui.Properties.Resources.brick07;
                            break;
                        case 7 + 64 + 64 + 64:
                            mapTiles[c].BackgroundImage = global::tensor_patcher_gui.Properties.Resources.brick07p;
                            break;
                        case 8:
                            mapTiles[c].BackgroundImage = global::tensor_patcher_gui.Properties.Resources.brick08;
                            break;
                        case 8 + 64 + 64 + 64:
                            mapTiles[c].BackgroundImage = global::tensor_patcher_gui.Properties.Resources.brick08p;
                            break;
                        case 9:
                            mapTiles[c].BackgroundImage = global::tensor_patcher_gui.Properties.Resources.brick09;
                            break;
                        case 9 + 64 + 64 + 64:
                            mapTiles[c].BackgroundImage = global::tensor_patcher_gui.Properties.Resources.brick09p;
                            break;
                        case 10:
                            mapTiles[c].BackgroundImage = global::tensor_patcher_gui.Properties.Resources.brick10;
                            break;
                        case 10 + 64 + 64 + 64:
                            mapTiles[c].BackgroundImage = global::tensor_patcher_gui.Properties.Resources.brick10p;
                            break;
                        case 11:
                            mapTiles[c].BackgroundImage = global::tensor_patcher_gui.Properties.Resources.brick11;
                            break;
                        case 11 + 64 + 64 + 64:
                            mapTiles[c].BackgroundImage = global::tensor_patcher_gui.Properties.Resources.brick11p;
                            break;
                        case 12:
                            mapTiles[c].BackgroundImage = global::tensor_patcher_gui.Properties.Resources.brick12;
                            break;
                        case 12 + 64 + 64 + 64:
                            mapTiles[c].BackgroundImage = global::tensor_patcher_gui.Properties.Resources.brick12p;
                            break;
                        case 13:
                            mapTiles[c].BackgroundImage = global::tensor_patcher_gui.Properties.Resources.brick13;
                            break;
                        case 13 + 64 + 64 + 64:
                            mapTiles[c].BackgroundImage = global::tensor_patcher_gui.Properties.Resources.brick13p;
                            break;
                        case 14:
                            mapTiles[c].BackgroundImage = global::tensor_patcher_gui.Properties.Resources.brick14;
                            break;
                        case 14 + 64 + 64 + 64:
                            mapTiles[c].BackgroundImage = global::tensor_patcher_gui.Properties.Resources.brick14p;
                            break;
                        case 15:
                            mapTiles[c].BackgroundImage = global::tensor_patcher_gui.Properties.Resources.brick15;
                            break;
                        case 15 + 64 + 64 + 64:
                            mapTiles[c].BackgroundImage = global::tensor_patcher_gui.Properties.Resources.brick15p;
                            break;
                        case 16:
                            mapTiles[c].BackgroundImage = global::tensor_patcher_gui.Properties.Resources.brick16;
                            break;
                        case 16 + 64 + 64 + 64:
                            mapTiles[c].BackgroundImage = global::tensor_patcher_gui.Properties.Resources.brick16p;
                            break;
                        case 17:
                            mapTiles[c].BackgroundImage = global::tensor_patcher_gui.Properties.Resources.brick17;
                            break;
                        case 17 + 64 + 64 + 64:
                            mapTiles[c].BackgroundImage = global::tensor_patcher_gui.Properties.Resources.brick17p;
                            break;
                        case 18:
                            mapTiles[c].BackgroundImage = global::tensor_patcher_gui.Properties.Resources.brick18;
                            break;
                        case 18 + 64 + 64 + 64:
                            mapTiles[c].BackgroundImage = global::tensor_patcher_gui.Properties.Resources.brick18p;
                            break;
                        default:
                            mapTiles[c].BackgroundImage = global::tensor_patcher_gui.Properties.Resources.brick_blank;
                            break;
                    }

                    mapTiles[c].Visible = true;
                }
            }
        }

        private void listCaves_SelectedIndexChanged(object sender, EventArgs e) {
            if(listCaves.SelectedIndices.Count == 0) {
                return;
            }
            var index = listCaves.SelectedIndices[0];
            ShowMapLayout(index);
        }
    }
}
