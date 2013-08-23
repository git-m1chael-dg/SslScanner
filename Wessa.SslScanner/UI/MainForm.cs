using System;
using System.Windows.Forms;

namespace Wessa.SslScanner.UI
{
    public partial class MainForm : Form
    {
        private readonly CertificateDocument _certificateDocument;
        private readonly LogWindow _logWindow;

        public MainForm()
        {
            InitializeComponent();

            _certificateDocument = new CertificateDocument();
            _logWindow = new LogWindow();

            _certificateDocument.Show(dockPanel);
            _logWindow.Show(dockPanel);
        }

        #region Events
        private void scanToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (var f = new AboutForm())
                f.ShowDialog(this);
        }

        private void toolStripLabel5_Click(object sender, EventArgs e)
        {
            _certificateDocument.Scan();
        }

        private void toolStripLabel2_Click(object sender, EventArgs e)
        {
            _certificateDocument.AddNewEntry();
        }
        #endregion

        
    }
}
