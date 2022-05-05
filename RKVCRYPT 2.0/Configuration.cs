using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RKVCRYPT_2._0
{
    internal class Configuration
    {
        private string path;
        public Configuration()
        {
            this.path = "";
        }
        public string Path
        {
            get { return this.path; }
            set { this.path = value; }
        }
    }
}
