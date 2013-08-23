using System;
using System.Linq;
using System.Windows.Forms;

namespace Wessa.SslScanner.UI
{
    public partial class KnowPortForm : Form
    {
        public KnowPortForm()
        {
            InitializeComponent();

            Source.BeginUpdate();

            foreach (var item in KnownPort.KnownPorts())
                Source.Items.Add(item);

            Source.EndUpdate();
        }

        private void Add_Click(object sender, EventArgs e)
        {
            Destination.BeginUpdate();
            foreach (var item in Source.SelectedItems)
                Destination.Items.Add(item);
            Destination.EndUpdate();

            Source.BeginUpdate();
            for (int i = Source.SelectedItems.Count - 1; i >= 0; i--)
                Source.Items.Remove(Source.SelectedItems[i]);

            Source.EndUpdate();
        }

        private void Delete_Click(object sender, EventArgs e)
        {
            Source.BeginUpdate();
            foreach (var item in Destination.SelectedItems)
                Source.Items.Add(item);
            Source.EndUpdate();

            Destination.BeginUpdate();
            for (int i = Destination.SelectedItems.Count - 1; i >= 0; i--)
                Destination.Items.Remove(Destination.SelectedItems[i]);

            Destination.EndUpdate();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
        }

        internal KnownPort[] Selected()
        {
            return Destination.SelectedItems.Cast<KnownPort>().ToArray();
        }
    }



    public class KnownPort
    {
        public KnownPort(string name, int port)
        {
            Name = name;
            Port = port;
        }

        public string Name { get; set; }
        public int Port { get; set; }

        public override string ToString()
        {
            return string.Format("{0} - {1}", Name, Port);
        }


        public static KnownPort[] KnownPorts()
        {
            return new[]
                {
                    new KnownPort("Web server", 443), 
                    new KnownPort("Vmware Update Manager", 8084), 
                    new KnownPort("Vmware Single Sign On", 7444)
                };
        }
    }
}
