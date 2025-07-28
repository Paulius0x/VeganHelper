using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VeganHelper.Models;
using VeganHelper.Helpers;
using System.Diagnostics.Eventing.Reader;

namespace VeganHelperConsole
{
    class ServiceRunner
    {
        public static UserInputs _userInputs = new UserInputs();
        public static VeganChoice _veganChoice = new VeganChoice();
        public static void CollectUserInfo()
        {
            Console.WriteLine("Vegan Helper Starting.");
            Console.WriteLine();
            
            var input = _userInputs.GETMenuKeyItems();

            _userInputs.userInputs.Add(input);

            Console.WriteLine("Collected inputs:");
            foreach (var item in _userInputs.userInputs)
            {
                Console.WriteLine($"-> {item.Number} | {item.StartDate:yyyy-MM-dd} | {item.EndDate:yyyy-MM-dd}");
            }

            _veganChoice = InputHelper.ConvertToVeganChoice(input);
            Console.WriteLine($"You selected, want to consume: {_veganChoice.CaloriesTarget}");
            Console.WriteLine($"Your picked time duration: {_veganChoice.TimeDuration}");
            Console.WriteLine($"Your start Season: {_veganChoice.StartDate}");
            Console.WriteLine($"Your end Season: {_veganChoice.EndDate}");
           
            var products = ProductUtility.LoadProducts("products.json");
            var selected = ProductUtility.PickProductsForCalories(products, Convert.ToDouble(_veganChoice.CaloriesTarget));

            InputHelper.PrintProducts(selected);
            FileUtility.PrintAndSaveToDownloads(selected);

            Console.WriteLine("END.");

            Console.WriteLine();
            //Console.ReadKey();
        } 
    }
}
