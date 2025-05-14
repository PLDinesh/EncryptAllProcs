using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EncryptAllProcs.Models
{
    public class StoredProcedure
    {
        public string Name { get; set; }
        public string Schema { get; set; }
        public bool IsExcluded { get; set; } = true;
        public string DBName { get; set; }

    }
}
