using System;



namespace moment3
{

    [Serializable]
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

            guest.Read();

            
            //Put the file in an array and get its length
         
            //Let the user tpye in a number and start the correlating fucntion
            string myoptions;
            myoptions = Console.ReadLine();

            switch (myoptions)
            {
                case "1":

                    guest.Write();
                    MainMenu();

                    break;

                case "2":

                    guest.Delete();
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
