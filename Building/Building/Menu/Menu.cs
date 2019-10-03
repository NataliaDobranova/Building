
namespace Building.Menu
{
    public class Menu
    {
        public MenuItem Root { get; set; }
        public MenuItem Current { get; set; }

        public override string ToString()
        {
            return Current.ToString();
        }
    }
}
