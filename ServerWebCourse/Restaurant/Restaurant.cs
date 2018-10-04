using System.Collections.Generic;

namespace RestaurantProject
{
    public class Restaurant
    {
        public List<MenuItem> Menu { get; }
        public string Name;

        public Restaurant(string name)
        {
            Menu = new List<MenuItem>();
            Name = name;
        }

        public void AddMenuItem(string name, int price, string recipe)
        {
            var newMenuItem = new MenuItem(name, price, recipe);
            Menu.Add(newMenuItem);
        }
    }
}
