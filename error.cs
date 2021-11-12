using System;


namespace moment3
{
    public class Error
    {

        public static void Empty(guest obj)
        {
            //Dispaly an error message and restart the write function
            Console.WriteLine("Error: mssing data");
            Console.WriteLine("Press any key to try again ");
            Console.ReadKey();
            guest.Write(); 
        }
    }
}
