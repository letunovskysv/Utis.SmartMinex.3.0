using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utis.Minex.Common.Common
{
    public class JournalChangeDescription
    {
        public JournalChangeDescription(string fieldName, object oldValue, object newValue)
        {
            FieldName = fieldName;
            OldValue = oldValue;
            NewValue = newValue;
        }
        public string FieldName { get; set; }
        public object OldValue { get; set; }
        public object NewValue { get; set; }
    }
}
