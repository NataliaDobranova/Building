using System;
using System.Collections.Generic;
using System.Text;

namespace Building.Menu
{
    public class MenuItem
    {
        public string Text { get; set; }
        public int Index { get; set; }
        public Action Action { get; set; }
        public List<MenuItem> Items { get; set; }

        public override string ToString()
        {
            var sb = new StringBuilder();
            foreach (var item in Items)
            {
                sb.AppendLine(item.Index + '.' + item.Text);
            }
            sb.AppendLine("")
            return sb.ToString();
        }
    }
}
