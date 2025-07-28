using System;
using System.Collections.Generic;
using System.Runtime.InteropServices.ComTypes;
using VeganHelper.Helpers;
using VeganHelper.Models;

namespace VeganHelperConsole
{
    public class UserInputs
    {
        public List<UserInputModel> userInputs = new List<UserInputModel>();
        public DateTime startDate;
        public DateTime endDate;

        public UserInputs()
        {
            userInputs = new List<UserInputModel>();
        }
        public UserInputModel GETMenuKeyItems()
        {
            Console.WriteLine("Write calories goal per Day:");
            var number = InputHelper.GetInt(Console.ReadLine());

            while (true)
            {
                Console.WriteLine("Insert startDate date (yyyy-MM-dd):");
                startDate = InputHelper.GetDate(Console.ReadLine());

                if (DateUtility.IsStartLessThenToday(startDate))
                    break;

                Console.WriteLine("Start date must be from today. Please try again.");
            }


            while (true)
            {
                Console.WriteLine($"Insert endDate date (yyyy-MM-dd):");
                endDate = InputHelper.GetDate(Console.ReadLine());

                if (DateUtility.IsValidDateRange(startDate, endDate))
                    break;

                Console.WriteLine("End date must be after startDate date. Please try again.");
            }

            var userInserted = InputHelper.UserInputReturn(number, startDate, endDate);
            return userInserted;
        }


    }
}
