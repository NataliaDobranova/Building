using System;

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

        public void ChangeState(string key)
        {
            if (int.TryParse(key, out int keyValue))
            {
                switch (keyValue)
                {
                    case ExitCode:
                        {
                            if (Current == Root)
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
