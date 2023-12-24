using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace inoa_test
{
    class Configuration
    {
        public List<string> destinyEmails { get; set; }
        public string smtpHost { get; set; }
        public int port { get; set; }
        public string userName { get; set; }
        public string password { get; set; }

        public bool oneTimeWarning { get; set; }
    }
}
