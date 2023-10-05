using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataDesignInClass4
{
    public interface IFileFormat
    {
        public string path { get; set; }

        public string EXT { get; set; }

        public string Delimeter { get; set; }

        public void SetFile(string _path, string _EXT, string _Delimeter)
        {
            this.path = _path;
            this.EXT = _EXT;
            this.Delimeter = _Delimeter; 

        }
    }


}
