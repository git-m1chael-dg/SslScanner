using System;
using System.Net.Security;
using System.Net.Sockets;
using System.Security.Authentication;
using System.Security.Cryptography.X509Certificates;

namespace Wessa.SslScanner.Core
{
    class SslGrabber
    {
        internal X509Certificate DownloadCertificate(string serverName, int port)
        {
            using (var tcpClient = new TcpClient())
            {
                tcpClient.Connect(serverName, port);

                using (var sslStream = new SslStream(tcpClient.GetStream(), false, ValidateServerCertificate, null))
                {
                    var certs = new X509CertificateCollection();
                    foreach (var sslProtocol in new[] { SslProtocols.Default, SslProtocols.Tls, SslProtocols.Ssl2, SslProtocols.Ssl3 })
                    {
                        try
                        {
                            sslStream.AuthenticateAsClient(serverName, certs, sslProtocol, false);
                            return sslStream.RemoteCertificate;
                        }
                        catch
                        {
                        }
                    }
                }

                return null;
            }
        }


        public X509Certificate2 DownloadCertificate2(string ipAddress, int port)
        {
            var downloadCertificate = DownloadCertificate(ipAddress, port);
            return downloadCertificate as X509Certificate2 ?? new X509Certificate2(Convert.ToBase64String(downloadCertificate.GetRawCertData()));
        }


        private bool ValidateServerCertificate(object sender, X509Certificate certificate, X509Chain chain, SslPolicyErrors sslpolicyerrors)
        {
            const SslPolicyErrors sslPolicyError = new SslPolicyErrors();
            return sslPolicyError.Equals(SslPolicyErrors.None);
        }

        internal X509Certificate2 ConvertToX509Certificate2(X509Certificate x509Certificate)
        {
            return x509Certificate as X509Certificate2 ?? new X509Certificate2(Convert.ToBase64String(x509Certificate.GetRawCertData()));
        }
    }
}
