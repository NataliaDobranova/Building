using System;
using System.Collections.Generic;

namespace Building.Menu
{
    /// <summary>
    /// Menu orchestrator class that handles menu item actions: navigation, actions, exit etc.
    /// </summary>
    [Serializable]
    public class Menu
    {
        /// <summary>
        /// Exit event
        /// </summary>
        public event EventHandler OnExit;

        /// <summary>
        /// Exit/back code
        /// </summary>
        private const int ExitCode = 0;
        
        /// <summary>
        /// Menu Root element (main menu)
        /// </summary>
        public MenuItem Root { get; set; }

        /// <summary>
        /// Currently selected menu item
        /// </summary>
        public MenuItem Current { get; set; }

        /// <summary>
        /// Ctor needed for xml deserialization
        /// </summary>
        public Menu()
        {

        }

        /// <summary>
        /// Ctor for manual creation 
        /// </summary>
        /// <param name="root">Requires a root element to start with</param>
        public Menu(MenuItem root)
        {
            Root = root;
            Current = root;
        }

        /// <summary>
        /// Initializes all required Parent elements for Root and Current trees
        /// </summary>
        public void Init()
        {
            Init(Root.Items, Root);
            Init(Current.Items, Current);
        }

        /// <summary>
        /// Recursively initializes all required Parent elements for MenuItem tree
        /// </summary>
        /// <param name="items">Child items that possibly requre Parent item to initialize</param>
        /// <param name="parent">Parent item </param>
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

        /// <summary>
        /// Handles menu navigation
        /// </summary>
        /// <param name="key">Navigation key</param>
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

        /// <summary>
        /// Generates an exit message
        /// </summary>
        private void Exit()
        {
            OnExit?.Invoke(this, new EventArgs());
        }

        /// <summary>
        /// View currently selected menu item
        /// </summary>
        /// <returns>Current menu item presented as string</returns>
        public override string ToString()
        {
            return Current.ToString();
        }

    }
}
