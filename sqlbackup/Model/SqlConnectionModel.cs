using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sqlbackup.Model
{
  public  class SqlConnectionModel
    {
        public List<string> Databases { get; set; }

        public string Errors { get; set; }

        public SqlConnectionModel()
        {
            Databases = new List<string>();
            Errors = string.Empty;
        }

    }
}
