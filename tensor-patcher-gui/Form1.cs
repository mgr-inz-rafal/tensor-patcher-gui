using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Media;
using System.Windows.Forms;

namespace tensor_patcher_gui {
    public partial class MainForm : Form {
        private static Dictionary<int, Bitmap> currentBrickSet = Constants.brownBricks;

        private byte[] rawMapData;
        private Button[] toolboxBrickButtons = new Button[Constants.TOTAL_BRICKS];
        private Cave[] caves = new Cave[Constants.TOTAL_MAP_COUNT];
        private Button[] mapTiles = new Button[Constants.MAP_DATA_BYTE_COUNT];
        private byte? selectedCaveByte;

        public MainForm() {
            InitializeComponent();
            SetupForm();
            picSelection.BringToFront();
        }

        private void MainForm_Load(object sender, EventArgs e) {
            ShowInfo("Ready for action!");
        }

        private void button_LocateTensorAutomaticaly_Click(object sender, EventArgs e) {
            ShowError("Not implemented... yet!");
        }

        private void SetToolboxSelectionMarker(object sender) {
            Button b = (Button)sender;
            ButtonTag tag = (ButtonTag)b.Tag;
            picSelection.Left = tag.X + 4;
            picSelection.Top = tag.Y + 4;
        }

        private void button_SetBrownBrickSet_Click(object sender, EventArgs e) {
            currentBrickSet = Constants.brownBricks;
            RepaintBrickToolset();
            ShowInfo("Brown brick set selected");
        }

        private void button_SetPinkBrickSet_Click(object sender, EventArgs e) {
            currentBrickSet = Constants.pinkBricks;
            RepaintBrickToolset();
            ShowInfo("Pink brick set selected");
        }

        private void button_SetBlueBrickSet_Click(object sender, EventArgs e) {
            currentBrickSet = Constants.blueBricks;
            RepaintBrickToolset();
            ShowInfo("Blue brick set selected");
        }

        private void button_SetAmygdalaBrickSet_Click(object sender, EventArgs e) {
            currentBrickSet = Constants.amygdalaBricks;
            RepaintBrickToolset();
            ShowInfo("Amygdala-colored brick set selected");
        }

        private void button_ToolboxButton_Click(object sender, EventArgs e) {
            Button b = (Button)sender;
            ButtonTag t = (ButtonTag)b.Tag;
            selectedCaveByte = t.CaveByte;
            String name = Constants.CaveByteToName(selectedCaveByte);
            ShowInfo($"Element selected ({name})");
            SetToolboxSelectionMarker(sender);
        }

        private bool IsBrick(byte? caveByte) {
            if(caveByte == null) {
                return false;
            }
            return caveByte != 1 && caveByte != 2 && caveByte != 131 && caveByte != 132 && caveByte != 0;
        }

        private void button_MapTileButton_Click(object sender, EventArgs e) {
            Button b = (Button)sender;
            ButtonTag t = (ButtonTag)b.Tag;
            if (selectedCaveByte != null) {
                byte caveByteModifier = 0;
                if(IsBrick(selectedCaveByte)) {
                    if (currentBrickSet == Constants.pinkBricks) {
                        caveByteModifier = 64 + 64 + 64;
                    }
                    else if (currentBrickSet == Constants.blueBricks) {
                        caveByteModifier = 64 + 64;
                    }
                    else if (currentBrickSet == Constants.amygdalaBricks) {
                        caveByteModifier = 64;
                    }
                }
                t.CaveByte = Convert.ToByte(selectedCaveByte + caveByteModifier);
                b.BackgroundImage = Constants.caveByteMap[t.CaveByte.Value];
            }
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
            this.sbar.Items[0].Image = Properties.Resources.icon_error;
            SystemSounds.Hand.Play();
        }

        private void ShowInfo(String msg) {
            this.sbar.Items[0].Text = msg;
            this.sbar.Items[0].Image = Properties.Resources.icon_ok;
        }

        private void LoadTensor(String fileName) {
            const int MAP_DATA_OFFSET = 0xA022;
            var reader = new System.IO.BinaryReader(File.Open(fileName, FileMode.Open));
            reader.BaseStream.Seek(MAP_DATA_OFFSET, SeekOrigin.Begin);
            rawMapData = reader.ReadBytes(Constants.TOTAL_MAP_DATA_SIZE);
        }

        private void ParseMapData() {
            for (int i = 0; i < Constants.TOTAL_MAP_COUNT; ++i) {
                caves[i] = new Cave(String.Format("Map {0} title", i + 1));
                caves[i].mapData = new byte[Constants.MAP_DATA_BYTE_COUNT];
                Array.Copy(rawMapData, i * Constants.MAP_DATA_BYTE_COUNT, caves[i].mapData, 0, Constants.MAP_DATA_BYTE_COUNT);
            }
        }

        private void PopulateMapList() {
            for (int i = 0; i < Constants.TOTAL_MAP_COUNT; ++i) {
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
            for (int i = 0; i < Constants.MAP_DIMENSION; ++i) {
                for (int j = 0; j < Constants.MAP_DIMENSION; ++j) {
                    System.Windows.Forms.Button but = new System.Windows.Forms.Button();
                    but.Top = 32 + i * Constants.TILE_SIZE;
                    but.Left = 32 + j * Constants.TILE_SIZE;
                    but.Height = Constants.TILE_SIZE;
                    but.Width = Constants.TILE_SIZE;
                    but.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
                    but.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
                    but.Visible = false;
                    but.MouseEnter += new System.EventHandler(this.button_MapTileMouseEnter);
                    but.MouseLeave += new System.EventHandler(this.button_MapTileMouseLeave);
                    but.Tag = new ButtonTag(but.Left, but.Top, i * Constants.MAP_DIMENSION + j);
                    but.Click += new System.EventHandler(this.button_MapTileButton_Click);

                    mapTiles[((ButtonTag)but.Tag).Index] = but;

                    this.Controls.Add(but);
                }
            }
        }

        private Button AddToolboxButton(int x, int y, Bitmap pic, byte? caveByte = null, float scale = 1.0f) {
            System.Windows.Forms.Button but = new System.Windows.Forms.Button {
                Top = y,
                Left = x,
                Height = Constants.TOOLBOX_TILE_SIZE,
                Width = Convert.ToInt32(Constants.TOOLBOX_TILE_SIZE * scale),
                BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch,
                FlatStyle = System.Windows.Forms.FlatStyle.Flat,
                BackgroundImage = pic,
                Tag = new ButtonTag(x, y, -1, caveByte)
            };
            but.MouseEnter += new System.EventHandler(this.button_MapTileMouseEnter);
            but.MouseLeave += new System.EventHandler(this.button_MapTileMouseLeave);
            this.Controls.Add(but);
            but.BringToFront();
            return but;
        }

        private void CreateToolbox() {
            var toolboxYPosition = Convert.ToInt32(458 + 2.5 * (Constants.TOOLBOX_TILE_SIZE + 4));
            AddToolboxButton(660 + 0 * (Constants.TOOLBOX_TILE_SIZE + 4), toolboxYPosition, Properties.Resources.ludek1, 1)
                .Click += new System.EventHandler(this.button_ToolboxButton_Click);
            AddToolboxButton(660 + 1 * (Constants.TOOLBOX_TILE_SIZE + 4), toolboxYPosition, Properties.Resources.obstacle00, 131)
                .Click += new System.EventHandler(this.button_ToolboxButton_Click);
            AddToolboxButton(660 + 2 * (Constants.TOOLBOX_TILE_SIZE + 4), toolboxYPosition, Properties.Resources.obstacle01, 132)
                .Click += new System.EventHandler(this.button_ToolboxButton_Click);
            AddToolboxButton(660 + 3 * (Constants.TOOLBOX_TILE_SIZE + 4), toolboxYPosition, Properties.Resources.amygdala7, 2)
                .Click += new System.EventHandler(this.button_ToolboxButton_Click);

            AddToolboxButton(660 + 4 * (Constants.TOOLBOX_TILE_SIZE + 4), toolboxYPosition, Properties.Resources.brick_brown, null, 0.66f)
                .Click += new System.EventHandler(this.button_SetBrownBrickSet_Click);
            AddToolboxButton(Convert.ToInt32(660 + (4 + 0.75f) * (Constants.TOOLBOX_TILE_SIZE + 4)), toolboxYPosition, Properties.Resources.brick_pink, null, 0.66f)
                .Click += new System.EventHandler(this.button_SetPinkBrickSet_Click);
            AddToolboxButton(Convert.ToInt32(660 + (4 + 0.75f * 2) * (Constants.TOOLBOX_TILE_SIZE + 4)), toolboxYPosition, Properties.Resources.brick_blue, null, 0.66f)
                .Click += new System.EventHandler(this.button_SetBlueBrickSet_Click);
            AddToolboxButton(Convert.ToInt32(660 + (4 + 0.75f * 3) * (Constants.TOOLBOX_TILE_SIZE + 4)), toolboxYPosition, Properties.Resources.brick_amygdala, null, 0.66f)
                .Click += new System.EventHandler(this.button_SetAmygdalaBrickSet_Click);

            AddToolboxBrickButtons();
        }

        private void RepaintBrickToolset() {
            for (int j = 0; j < Constants.TOTAL_BRICK_ROWS; ++j) {
                for (int i = 0; i < Constants.TOTAL_BRICKS / Constants.TOTAL_BRICK_ROWS; ++i) {
                    var index = i + j * (Constants.TOTAL_BRICKS / Constants.TOTAL_BRICK_ROWS);
                    toolboxBrickButtons[index].BackgroundImage = currentBrickSet[index];
                }
            }
        }

        private void AddToolboxBrickButtons() {
            for (int j = 0; j < Constants.TOTAL_BRICK_ROWS; ++j) {
                for (int i = 0; i < Constants.TOTAL_BRICKS / Constants.TOTAL_BRICK_ROWS; ++i) {
                    var index = i + j * (Constants.TOTAL_BRICKS / Constants.TOTAL_BRICK_ROWS);
                    Button b = AddToolboxButton(660 + i * (Constants.TOOLBOX_TILE_SIZE + 4), 458 + j * (Constants.TOOLBOX_TILE_SIZE + 4), currentBrickSet[index], Convert.ToByte(index + 5));
                    b.Click += new System.EventHandler(this.button_ToolboxButton_Click);
                    toolboxBrickButtons[index] = b;
                }
            }
        }

        private void ShowMapLayout(int index) {
            for (int i = 0; i < Constants.MAP_DIMENSION; ++i) {
                for (int j = 0; j < Constants.MAP_DIMENSION; ++j) {
                    var c = i * Constants.MAP_DIMENSION + j;
                    var myByte = caves[index].mapData[c];
                    ((ButtonTag)mapTiles[c].Tag).CaveByte = myByte;
                    mapTiles[c].BackgroundImage = Constants.caveByteMap[caves[index].mapData[c]];
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
