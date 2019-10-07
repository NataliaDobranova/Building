using System;
using System.Collections.Generic;
using System.Text;

namespace Building.Menu
{
    public class MenuItem
    {
        public string Text { get; set; }
        public int Index { get; set; }
        public List<MenuItem> Items { get; set; }

        public MenuItem Parent { get; set; }

        public MenuItem(string text)
        {
            Items = new List<MenuItem>();
            Text = text;
        }

        public void Add(params MenuItem[] items)
        {
            foreach (var item in items)
            {
                item.Parent = this;
                item.Index = Items.Count + 1;
                Items.Add(item);
            }
        }

        public MenuItem GoForward(int index)
        {
            return Items?[index - 1] ?? throw new ArgumentOutOfRangeException("Menu item is not exist");
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

            sb.AppendLine(Parent == null ? "0.Exit" : "0.Back");
            return sb.ToString();
        }
    }
}
