using System;
using System.Collections.Generic;

namespace Building.Menu
{
    [Serializable]
    public class Menu
    {
        public event EventHandler OnExit;

        private const int ExitCode = 0;
        public MenuItem Root { get; set; }

        public MenuItem Current { get; set; }

        public Menu()
        {

        }

        public Menu(MenuItem root)
        {
            Root = root;
            Current = root;
        }

        public void Init()
        {
            Init(Root.Items, Root);
            Init(Current.Items, Current);
        }

        private void Init
            (List<MenuItem> items, MenuItem parent)
        {
            foreach (var item in items)
            {
                item.Parent = parent;

                if (item.Items.Count != 0)
                    Init(item.Items, item);
            }
        }

        public void ChangeState(string key)
        {
            if (int.TryParse(key, out int keyValue))
            {
                switch (keyValue)
                {
                    case ExitCode:
                        {
                            if (Current.Id == Root.Id)
                            {
                                Exit();
                            }
                            else
                            {
                                Current = Current.GoBack();
                            }

                            break;
                        }
                    default:
                        {
                            Current = Current.GoForward(keyValue);
                            break;
                        }
                }
            }
        }

        private void Exit()
        {
            OnExit?.Invoke(this, new EventArgs());
        }

        public override string ToString()
        {
            return Current.ToString();
        }

    }
}
