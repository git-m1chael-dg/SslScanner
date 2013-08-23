using WeifenLuo.WinFormsUI.Docking;

namespace Wessa.SslScanner.UI
{
    [System.Diagnostics.DebuggerNonUserCode]
    public class BaseToolWindow : DockContent
    {
        public BaseToolWindow()
        {
            DockAreas = DockAreas.DockBottom | DockAreas.DockLeft | DockAreas.DockRight;
        }
    }
}
