using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoogleMapSDK.Contract.Components.AutoComplete.Models
{
    public class ActionModel<T>
    {
        public Task<Dictionary<string, T>> ValuesTask { get; set; }
        public Dictionary<string, T> Values { get; set; }
        public List<string> Matched { get; set; }
        public int SelectedIndex { get; set; } = -1;
        public string Text { get; set; }
        public string FormerText { get; set; } = string.Empty;
    }
}
