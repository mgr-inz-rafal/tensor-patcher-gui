using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
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

        }

        private void button_LocateTensorAutomaticaly_Click(object sender, EventArgs e) {
            MessageBox.Show(this, "Not implemented... yet!", "Can't do it...", MessageBoxButtons.OK, MessageBoxIcon.Hand);
        }
    }
}
