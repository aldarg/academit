using System;
using RestaurantProject;

namespace AssemblySignTask
{
    public class MyRestaurant
    {
        public static void Main(string[] args)
        {
            var myRestaurant = new Restaurant("Karas");
            myRestaurant.AddMenuItem("porridge", 5, "Just cook some rice.");
            myRestaurant.AddMenuItem("borsch", 15, "Beef, water, potato, svekla i kapusta. Cook altogether for an hour.");

            #region MenuPrint

            foreach (var food in myRestaurant.Menu)
            {
#if DEBUG
                Console.WriteLine(food.Name);
                Console.WriteLine(food.Price);
                Console.WriteLine(food.Recipe);
#else
                Console.WriteLine("Release");
#endif                
            }

            #endregion
        }
    }
}
