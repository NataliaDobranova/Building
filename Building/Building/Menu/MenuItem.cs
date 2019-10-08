using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace Building.Menu
{
    [Serializable]
    public class MenuItem
    {
        public string Text { get; set; }
        public int Index { get; set; }
        public List<MenuItem> Items { get; set; }

        [NonSerialized]
        [XmlIgnore]
        public MenuItem Parent;

        public MenuItem()
        { }

        public MenuItem(string text)
        {
            Text = text;
            Items = new List<MenuItem>();
        }

        public void Add(params MenuItem[] items)
        {
            foreach (var item in items)
            {
                item.Index = Items.Count + 1;
                item.Parent = this;
                Items.Add(item);
            }
        }

        public MenuItem GoForward(int index)
        {
            return Items[index - 1];
        }

        public MenuItem GoBack()
        {
            return Parent;
        }

        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.AppendLine(Text + ":");

            foreach (var item in Items)
            {
                sb.AppendLine(item.Index + ". " + item.Text);
            }

            sb.AppendLine(Parent == null ?
                "0.Exit" : "0.Back");
            return sb.ToString();
        }
    }
}
