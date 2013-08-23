using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Wessa.SslScanner.UI
{
    public partial class AddServerForm : BaseDialogForm
    {
        public AddServerForm()
        {
            InitializeComponent();
        }


        private void btnAdd_Click(object sender, EventArgs e)
        {
            var list = new List<ServerEntry>();

            if(txtServerName.Text.Length > 0 && txtServerPort.Text.Length > 0)
            {
                list.AddRange(
                    from c in txtServerPort.Text.Split(',')
                    select new ServerEntry
                        {
                            Server = txtServerName.Text,
                            Port = c
                        }
                    );
            }


            if (txtIpRangeFrom.Text.Length > 0 && txtIpRangeTo.Text.Length > 0 && txtIpRagePort.Text.Length > 0)
            {
                var splited = txtIpRangeFrom.Text.Split('.');
                int start = Convert.ToInt32(splited[3]);
                int end = Convert.ToInt32(txtIpRangeTo.Text);

                string ipAdd = string.Format("{0}.{1}.{2}" ,splited[0] , splited[1] , splited[2]);
                
                var ports = txtServerPort.Text.Split(',');

                for (; start <= end && start < 255; start++)
                {
                    list.AddRange(
                        from c in ports
                        select new ServerEntry
                            {
                                Server = string.Format("{0}.{1}", ipAdd, start),
                                Port = c
                            }
                        );
                }

            }

            ServerEntires = list;

            DialogResult = DialogResult.OK;
            Close();

        }


        internal IEnumerable<ServerEntry> ServerEntires { get; set; }

        private void listPort1_Click(object sender, EventArgs e)
        {
            ListPorts(txtServerPort);
        }

        private void ListPorts(TextBox assignedTo)
        {
            using (var f = new KnowPortForm())
            {
                if (f.ShowDialog(this) == DialogResult.OK)
                {
                    var stb = new StringBuilder();

                    foreach (var port in f.Selected())
                    {
                        stb.Append(port.Port).Append(',');
                    }

                    assignedTo.Text = stb.ToString();

                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ListPorts(txtIpRagePort);
        }
    }


}
