using System;
using WeifenLuo.WinFormsUI.Docking;

namespace Wessa.SslScanner.UI
{
    public partial class LogWindow : BaseToolWindow
    {
        public LogWindow()
        {
            DockAreas = DockAreas.DockBottom;


            InitializeComponent();

            
        }

        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);

            Log.Width = listView1.Width - Date.Width - 5;
        }
    }
}
