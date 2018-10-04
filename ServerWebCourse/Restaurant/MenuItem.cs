namespace RestaurantProject
{
    public class MenuItem
    {
        public string Name;
        public int Price;
        public string Recipe;

        public MenuItem(string name, int price, string recipe)
        {
            Name = name;
            Price = price;
            Recipe = recipe;
        }
    }
}
