using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EncryptAllProcs.Models
{
    public class ExcludeList
    {
        public List<StoredProcedure> StoredProcedures { get; set; } = new List<StoredProcedure>();

        public List<View> Views { get; set; } = new List<View>();

        public List<string> ExcludedSchemas { get; set; } = new List<string>();
    }
}
