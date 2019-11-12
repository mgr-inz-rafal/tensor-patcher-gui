using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace tensor_patcher_gui {
    public partial class MainForm : Form {
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

        private void button_LocateTensorManually_Click(object sender, EventArgs e) {
            if (openFileDialog.ShowDialog() != DialogResult.OK) {
                return;
            }

            var valid = ValidateTensorBinary(openFileDialog.FileName);
            if (!valid.Item1) {
                ShowError(valid.Item2);
                return;
            }

            ShowInfo("Tensor.xex loaded successfully");
        }
    }
}
