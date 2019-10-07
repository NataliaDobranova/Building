using System;

namespace Building.Menu
{
    public class Menu
    {
        public event EventHandler OnExit;

        private const int ExitCode = 0;
        public MenuItem Root { get; set; }
        public MenuItem Current { get; set; }

        public Menu(MenuItem root)
        {
            Root = root;
            Current = root;
        }

        public override string ToString()
        {
            return Current.ToString();
        }

        public void ChangeState(object sender, EventArgs e)
        {
            var key = (char)sender;

            if (int.TryParse(key.ToString(), out int keyCode))
            {
                switch (keyCode)
                {
                    case ExitCode:
                        {
                            if (Current == Root)
                            {
                                Exit();
                                break;
                            }
                            else
                            {
                                Current = Current.GoBack();
                                break;
                            }
                        }
                    default:
                        {
                            Current = Current.GoForward(keyCode);
                            break;
                        }
                }
            }
        }

        private void Exit()
        {
            OnExit?.Invoke(this, new EventArgs());
        }
    }
}
