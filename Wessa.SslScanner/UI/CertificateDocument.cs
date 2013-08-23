using System;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Wessa.SslScanner.Core;

namespace Wessa.SslScanner.UI
{
    public partial class CertificateDocument : BaseDocumentWindow
    {
        CancellationTokenSource tokenSource2 = new CancellationTokenSource();

        public CertificateDocument()
        {
            InitializeComponent();
        }


        internal void Scan()
        {
            /*var list = new List<ServerEntry>();

            foreach (ListViewItem item in listView1.Items)
                list.Add(item.Tag as ServerEntry);
            */

            tokenSource2.Cancel();

            if (tokenSource2.IsCancellationRequested)
                tokenSource2 = new CancellationTokenSource();

            foreach (ListViewItem item in listView1.Items)
            {
                //var task = Task.Run(ScanEntry);
                Task.Factory.StartNew(o =>
                    {
                        ScanEntry(o as ListViewItem);
                    }, item, tokenSource2.Token);

                //task.Start();
            }
        }


        private void ScanEntry(ListViewItem item)
        {
            var server = item.Tag as ServerEntry;

            if (server != null)
            {
                var ssl = new SslGrabber();
                server.Certificate = ssl.DownloadCertificate(server.Server, Convert.ToInt32(server.Port));
                try
                {
                    server.Certificate2 = ssl.ConvertToX509Certificate2(server.Certificate);
                }
                catch
                {
                }
                if (server.Certificate != null)
                {
                    SetListView(item);
                }
            }
        }


        void SetListView(ListViewItem item)
        {
            if (InvokeRequired)
            {
                var d = new Action<ListViewItem>(SetListView);
                this.Invoke(d, new object[] { item });
            }
            else
            {
                var server = item.Tag as ServerEntry;
                item.SubItems[2].Text = server.Issuer;
                item.SubItems[3].Text = server.Subject;
                item.SubItems[4].Text = server.San;
                item.SubItems[5].Text = server.ValidFrom;
                item.SubItems[6].Text = server.ValidTo;
                item.SubItems[7].Text = server.DayLeft;


            }

        }

        internal void AddNewEntry()
        {
            using (var addForm = new AddServerForm())
            {
                if (addForm.ShowDialog(this) == DialogResult.OK)
                {
                    foreach (var entry in addForm.ServerEntires)
                    {
                        var item = listView1.Items.Add(new ListViewItem(new[]
                            {
                                entry.Server,entry.Port, string.Empty,string.Empty,string.Empty,string.Empty,string.Empty,string.Empty
                            }));

                        item.Tag = entry;
                    }
                }
            }
        }
    }
}
