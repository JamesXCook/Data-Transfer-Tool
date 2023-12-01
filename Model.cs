using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DataTransferTool
{
    public class DTSRelationDistionary  
    {
        public string SourceTableName;
        public string TargetTableName;
        public List<KeyValuePair<String, String>> ColumnMappingDictionary;

    }
}
