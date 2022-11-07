using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Note.Services
{
    internal class GlobalConfig
    {
        public static string ConnectionString()
        {
            return @"Server=DESKTOP-N93AKIG\SQLEXPRESS;Database=SqlNote;Trusted_Connection=True;TrustedServerCertificate=True";
        }
    }
}
