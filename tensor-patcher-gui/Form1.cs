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
        // Map
        private const int MAP_DIMENSION = 12;
        private const int MAP_DATA_BYTE_COUNT = MAP_DIMENSION * MAP_DIMENSION;
        private const int TOTAL_MAP_COUNT = 51;
        private const int TOTAL_MAP_DATA_SIZE = MAP_DATA_BYTE_COUNT * TOTAL_MAP_COUNT;
        private const int TILE_SIZE = 48;

        // Toolbox
        private const int TOTAL_BRICKS = 14;
        private const int TOTAL_BRICK_ROWS = 2;
        private const int TOOLBOX_TILE_SIZE = 42;

        // TODO: Move consts and dictionaries to separate file
        private static Dictionary<int, Bitmap> brownBricks = new Dictionary<int, Bitmap> {
            { 0, Properties.Resources.brick05 },
            { 1, Properties.Resources.brick06 },
            { 2, Properties.Resources.brick07 },
            { 3, Properties.Resources.brick08 },
            { 4, Properties.Resources.brick09 },
            { 5, Properties.Resources.brick10 },
            { 6, Properties.Resources.brick11 },
            { 7, Properties.Resources.brick12 },
            { 8, Properties.Resources.brick13 },
            { 9, Properties.Resources.brick14 },
            { 10, Properties.Resources.brick15 },
            { 11, Properties.Resources.brick16 },
            { 12, Properties.Resources.brick17 },
            { 13, Properties.Resources.brick18 },
        };
        private static Dictionary<int, Bitmap> pinkBricks = new Dictionary<int, Bitmap> {
            { 0, Properties.Resources.brick05p },
            { 1, Properties.Resources.brick06p },
            { 2, Properties.Resources.brick07p },
            { 3, Properties.Resources.brick08p },
            { 4, Properties.Resources.brick09p },
            { 5, Properties.Resources.brick10p },
            { 6, Properties.Resources.brick11p },
            { 7, Properties.Resources.brick12p },
            { 8, Properties.Resources.brick13p },
            { 9, Properties.Resources.brick14p },
            { 10, Properties.Resources.brick15p },
            { 11, Properties.Resources.brick16p },
            { 12, Properties.Resources.brick17p },
            { 13, Properties.Resources.brick18p },
        };
        private static Dictionary<int, Bitmap> blueBricks = new Dictionary<int, Bitmap> {
            { 0, Properties.Resources.brick05b },
            { 1, Properties.Resources.brick06b },
            { 2, Properties.Resources.brick07b },
            { 3, Properties.Resources.brick08b },
            { 4, Properties.Resources.brick09b },
            { 5, Properties.Resources.brick10b },
            { 6, Properties.Resources.brick11b },
            { 7, Properties.Resources.brick12b },
            { 8, Properties.Resources.brick13b },
            { 9, Properties.Resources.brick14b },
            { 10, Properties.Resources.brick15b },
            { 11, Properties.Resources.brick16b },
            { 12, Properties.Resources.brick17b },
            { 13, Properties.Resources.brick18b },
        };
        private static Dictionary<int, Bitmap> amygdalaBricks = new Dictionary<int, Bitmap> {
            { 0, Properties.Resources.brick05a },
            { 1, Properties.Resources.brick06a },
            { 2, Properties.Resources.brick07a },
            { 3, Properties.Resources.brick08a },
            { 4, Properties.Resources.brick09a },
            { 5, Properties.Resources.brick10a },
            { 6, Properties.Resources.brick11a },
            { 7, Properties.Resources.brick12a },
            { 8, Properties.Resources.brick13a },
            { 9, Properties.Resources.brick14a },
            { 10, Properties.Resources.brick15a },
            { 11, Properties.Resources.brick16a },
            { 12, Properties.Resources.brick17a },
            { 13, Properties.Resources.brick18a },
        };
        private static Dictionary<int, Bitmap> currentBrickSet = brownBricks;

        private static Dictionary<byte, Bitmap> caveByteMap = new Dictionary<byte, Bitmap> {
            { 5, Properties.Resources.brick05 },
            { 5 + 64, Properties.Resources.brick05a },
            { 5 + 64 + 64, Properties.Resources.brick05b },
            { 5 + 64 + 64 + 64, Properties.Resources.brick05p },
            { 6, Properties.Resources.brick06 },
            { 6 + 64, Properties.Resources.brick06a },
            { 6 + 64 + 64, Properties.Resources.brick06b },
            { 6 + 64 + 64 + 64, Properties.Resources.brick06p },
            { 7, Properties.Resources.brick07 },
            { 7 + 64, Properties.Resources.brick07a },
            { 7 + 64 + 64, Properties.Resources.brick07b },
            { 7 + 64 + 64 + 64, Properties.Resources.brick07p },
            { 8, Properties.Resources.brick08 },
            { 8 + 64, Properties.Resources.brick08a },
            { 8 + 64 + 64, Properties.Resources.brick08b },
            { 8 + 64 + 64 + 64, Properties.Resources.brick08p },
            { 9, Properties.Resources.brick09 },
            { 9 + 64, Properties.Resources.brick09a },
            { 9 + 64 + 64, Properties.Resources.brick09b },
            { 9 + 64 + 64 + 64, Properties.Resources.brick09p },
            { 10, Properties.Resources.brick10 },
            { 10 + 64, Properties.Resources.brick10a },
            { 10 + 64 + 64, Properties.Resources.brick10b },
            { 10 + 64 + 64 + 64, Properties.Resources.brick10p },
            { 11, Properties.Resources.brick11 },
            { 11 + 64, Properties.Resources.brick11a },
            { 11 + 64 + 64, Properties.Resources.brick11b },
            { 11 + 64 + 64 + 64, Properties.Resources.brick11p },
            { 12, Properties.Resources.brick12 },
            { 12 + 64, Properties.Resources.brick12a },
            { 12 + 64 + 64, Properties.Resources.brick12b },
            { 12 + 64 + 64 + 64, Properties.Resources.brick12p },
            { 13, Properties.Resources.brick13 },
            { 13 + 64, Properties.Resources.brick13a },
            { 13 + 64 + 64, Properties.Resources.brick13b },
            { 13 + 64 + 64 + 64, Properties.Resources.brick13p },
            { 14, Properties.Resources.brick14 },
            { 14 + 64, Properties.Resources.brick14a },
            { 14 + 64 + 64, Properties.Resources.brick14b },
            { 14 + 64 + 64 + 64, Properties.Resources.brick14p },
            { 15, Properties.Resources.brick15 },
            { 15 + 64, Properties.Resources.brick15a },
            { 15 + 64 + 64, Properties.Resources.brick15b },
            { 15 + 64 + 64 + 64, Properties.Resources.brick15p },
            { 16, Properties.Resources.brick16 },
            { 16 + 64, Properties.Resources.brick16a },
            { 16 + 64 + 64, Properties.Resources.brick16b },
            { 16 + 64 + 64 + 64, Properties.Resources.brick16p },
            { 17, Properties.Resources.brick17 },
            { 17 + 64, Properties.Resources.brick17a },
            { 17 + 64 + 64, Properties.Resources.brick17b },
            { 17 + 64 + 64 + 64, Properties.Resources.brick17p },
            { 18, Properties.Resources.brick18 },
            { 18 + 64, Properties.Resources.brick18a },
            { 18 + 64 + 64, Properties.Resources.brick18b },
            { 18 + 64 + 64 + 64, Properties.Resources.brick18p },
            { 131, Properties.Resources.obstacle00 },
            { 132, Properties.Resources.obstacle01 },
            { 1, Properties.Resources.ludek1 },
            { 2, Properties.Resources.amygdala7 },
            { 0, Properties.Resources.brick_blank },
        };

        private byte[] rawMapData;
        private Button[] toolboxBrickButtons = new Button[TOTAL_BRICKS];
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

        private void button_SetBrownBrickSet_Click(object sender, EventArgs e) {
            currentBrickSet = brownBricks;
            RepaintBrickToolset();
            ShowInfo("Brown brick set selected");
        }

        private void button_SetPinkBrickSet_Click(object sender, EventArgs e) {
            currentBrickSet = pinkBricks;
            RepaintBrickToolset();
            ShowInfo("Pink brick set selected");
        }

        private void button_SetBlueBrickSet_Click(object sender, EventArgs e) {
            currentBrickSet = blueBricks;
            RepaintBrickToolset();
            ShowInfo("Blue brick set selected");
        }

        private void button_SetAmygdalaBrickSet_Click(object sender, EventArgs e) {
            currentBrickSet = amygdalaBricks;
            RepaintBrickToolset();
            ShowInfo("Amygdala-colored brick set selected");
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
            if (len != EXPECTED_FILE_SIZE) {
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
            for (int i = 0; i < TOTAL_MAP_COUNT; ++i) {
                caves[i] = new Cave(String.Format("Map {0} title", i + 1));
                caves[i].mapData = new byte[MAP_DATA_BYTE_COUNT];
                Array.Copy(rawMapData, i * MAP_DATA_BYTE_COUNT, caves[i].mapData, 0, MAP_DATA_BYTE_COUNT);
            }
        }

        private void PopulateMapList() {
            for (int i = 0; i < TOTAL_MAP_COUNT; ++i) {
                var item = listCaves.Items.Add(String.Format("{0}", i + 1));
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
                    but.Tag = i * MAP_DIMENSION + j;
                    mapTiles[(int)but.Tag] = but;
                    this.Controls.Add(but);
                }
            }
        }

        private Button AddToolboxButton(int x, int y, Bitmap pic, float scale = 1.0f) {
            System.Windows.Forms.Button but = new System.Windows.Forms.Button();
            but.Top = y;
            but.Left = x;
            but.Height = TOOLBOX_TILE_SIZE;
            but.Width = Convert.ToInt32(TOOLBOX_TILE_SIZE * scale);
            but.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            but.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            but.BackgroundImage = pic;
            but.MouseEnter += new System.EventHandler(this.button_MapTileMouseEnter);
            but.MouseLeave += new System.EventHandler(this.button_MapTileMouseLeave);
            //                but.Visible = false;
            //                but.Tag = i * MAP_DIMENSION + j;
            //                mapTiles[(int)but.Tag] = but;
            this.Controls.Add(but);
            but.BringToFront();
            return but;
        }

        private void CreateToolbox() {
            var toolboxYPosition = Convert.ToInt32(458 + 2.5 * (TOOLBOX_TILE_SIZE + 4));
            AddToolboxButton(660 + 0 * (TOOLBOX_TILE_SIZE + 4), toolboxYPosition, Properties.Resources.ludek1);
            AddToolboxButton(660 + 1 * (TOOLBOX_TILE_SIZE + 4), toolboxYPosition, Properties.Resources.obstacle00);
            AddToolboxButton(660 + 2 * (TOOLBOX_TILE_SIZE + 4), toolboxYPosition, Properties.Resources.obstacle01);
            AddToolboxButton(660 + 3 * (TOOLBOX_TILE_SIZE + 4), toolboxYPosition, Properties.Resources.amygdala7);
            
            AddToolboxButton(660 + 4 * (TOOLBOX_TILE_SIZE + 4), toolboxYPosition, Properties.Resources.brick_brown, 0.66f)
                .Click += new System.EventHandler(this.button_SetBrownBrickSet_Click);
            AddToolboxButton(Convert.ToInt32(660 + (4 + 0.75f) * (TOOLBOX_TILE_SIZE + 4)), toolboxYPosition, Properties.Resources.brick_pink, 0.66f)
                .Click += new System.EventHandler(this.button_SetPinkBrickSet_Click);
            AddToolboxButton(Convert.ToInt32(660 + (4 + 0.75f * 2) * (TOOLBOX_TILE_SIZE + 4)), toolboxYPosition, Properties.Resources.brick_blue, 0.66f)
                .Click += new System.EventHandler(this.button_SetBlueBrickSet_Click);
            AddToolboxButton(Convert.ToInt32(660 + (4 + 0.75f * 3) * (TOOLBOX_TILE_SIZE + 4)), toolboxYPosition, Properties.Resources.brick_amygdala, 0.66f)
                .Click += new System.EventHandler(this.button_SetAmygdalaBrickSet_Click);

            AddToolboxBrickButtons();
        }

        private void RepaintBrickToolset() {
            for (int j = 0; j < TOTAL_BRICK_ROWS; ++j) {
                for (int i = 0; i < TOTAL_BRICKS / TOTAL_BRICK_ROWS; ++i) {
                    var index = i + j * (TOTAL_BRICKS / TOTAL_BRICK_ROWS);
                    toolboxBrickButtons[index].BackgroundImage = currentBrickSet[index];
                }
            }
        }

        private void AddToolboxBrickButtons() {
            for (int j = 0; j < TOTAL_BRICK_ROWS; ++j) {
                for (int i = 0; i < TOTAL_BRICKS / TOTAL_BRICK_ROWS; ++i) {
                    var index = i + j * (TOTAL_BRICKS / TOTAL_BRICK_ROWS);
                    toolboxBrickButtons[index] =
                        AddToolboxButton(660 + i * (TOOLBOX_TILE_SIZE + 4), 458 + j * (TOOLBOX_TILE_SIZE + 4), currentBrickSet[index]);
                }
            }
        }

        private void ShowMapLayout(int index) {
            for (int i = 0; i < MAP_DIMENSION; ++i) {
                for (int j = 0; j < MAP_DIMENSION; ++j) {
                    var c = i * MAP_DIMENSION + j;
                    var myByte = caves[index].mapData[c];
                    mapTiles[c].BackgroundImage = caveByteMap[caves[index].mapData[c]];
                    mapTiles[c].Visible = true;
                }
            }
        }

        private void listCaves_SelectedIndexChanged(object sender, EventArgs e) {
            if (listCaves.SelectedIndices.Count == 0) {
                return;
            }
            var index = listCaves.SelectedIndices[0];
            ShowMapLayout(index);
        }
    }
}
