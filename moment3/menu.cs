using System;
using System.IO;

namespace moment3
{
    class menu
    {

       public static void MainMenu()
        {

            //Clear the console and write out the options
            Console.Clear();
            Console.WriteLine("Choose");
            Console.WriteLine("");
            Console.WriteLine("Option 1. Write");
            Console.WriteLine("Option 2. Delete");
            Console.WriteLine("Option 3. Quit");
            //Read the file
            var a = File.ReadAllText(@"C:\Users\Måns\source\repos\moment3\guests.txt");

            
            //Put the file in an array and get its length
            string[] fooArray = a.Split(',', StringSplitOptions.RemoveEmptyEntries);  // now you have an array of 3 strings

            int length = fooArray.Length;

      

            //Write out the posts
            foreach (string i in fooArray)
            {
                int j = 0;
                Console.WriteLine(i);
            }


            String[] arr = new String[] { a };


            //Let the user tpye in a number and start the correlating fucntion
            string myoptions;
            myoptions = Console.ReadLine();

            switch (myoptions)
            {
                case "1":

                    input.Write(a, length);
                    MainMenu();

                    break;

                case "2":

                    input.Delete(fooArray);
                    MainMenu();

                    break;

                case "3":

                    Exit();
                    MainMenu();

                    break;

            }

            
            //Exit the app

            static void Exit()
            {
                Environment.Exit(1);
            }

        }

    }
}
