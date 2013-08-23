using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Wessa.SslScanner
{
    public class ServerEntry
    {
        public string Server { get; set; }
        public string Port { get; set; }

        public X509Certificate Certificate { get; set; }
        public X509Certificate2 Certificate2 { get; set; }

        public string Subject
        {
            get { return Certificate != null ? Certificate.Subject : string.Empty; }
        }

        public string ValidFrom
        {
            get { return Certificate != null ? Certificate.GetEffectiveDateString() : string.Empty; }
        }

        public string ValidTo
        {
            get { return Certificate != null ? Certificate.GetExpirationDateString() : string.Empty; }
        }

        public string Issuer
        {
            get { return Certificate2 != null ? Certificate2.Issuer : string.Empty; }
        }

        public string San
        {
            get { return null; }
        }

        public string DayLeft
        {
            get { return Certificate != null ? GetDaysLeft() : string.Empty; }
        }

        private string GetDaysLeft()
        {
            int days = Convert.ToDateTime(ValidTo).Subtract(DateTime.Now).Days;
            return days > 0 ? Convert.ToString(days) : "Expired";
        }

    }
}
