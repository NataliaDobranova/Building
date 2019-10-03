using System;

namespace Building
{
    class Program
    {
        static void Main(string[] args)
        {
            //init menu
            // var menu = new Menu(root item);
            // menu.Add(new MenuItem(text, action?), where to add);

            //то к чему идем
            while (true)
            {
                Console.Write(menu);
                menu.DoSmth(Console.ReadKey());
            }
        }
    }
}
