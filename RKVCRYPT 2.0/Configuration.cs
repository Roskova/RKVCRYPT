using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core
{
    internal class Configuration
    {
        private string path;
        private string fileName;
        private string fileExtension;

        public Configuration(string path, string fileName, string fileExtension)
        {
            this.path = path;
            this.fileName = fileName;
            this.fileExtension = fileExtension;
        }
        public string Path
        {
            get { return this.path; }
            set { this.path = value; }
        }
    }
}
