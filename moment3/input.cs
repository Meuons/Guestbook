using System;
using System.Text;
using System.Linq;
using System.IO;

namespace moment3
{
    
    public class input
    {
       public string name;
      public  string content;
       public string list;
        public int length;

        public static void Write(string list, int length)
        {
            
            input inputObj = new input();
             inputObj.list = list;
            inputObj.length = length;
            Console.WriteLine("Write your name: ");
            
           
            inputObj.name = Console.ReadLine();

            Console.WriteLine("Write down a quote: "); 
            inputObj.content = Console.ReadLine();



            if (string.IsNullOrEmpty(inputObj.content) || string.IsNullOrEmpty(inputObj.name))
            {
                Console.WriteLine("Error: mssing data");
                Console.WriteLine("Press any key to try again");
                Console.ReadKey();
                menu.MainMenu();
            }
            else if(inputObj.content.Contains(",") || inputObj.name.Contains(","))
            {

                
                inputObj.content = inputObj.content.Replace(",", "");
                inputObj.name = inputObj.name.Replace(",", "");
                Console.WriteLine(inputObj.content);
                goto done;
            }
            else {
                goto done;
            
                 }
            done:  string newString = $"{list}[{length}]{inputObj.name} - {inputObj.content},";
            
            File.WriteAllText(@"C:\Users\Måns\source\repos\moment3\guests.txt", newString);
            Console.WriteLine("Quote added");
        }



     
      
            public static void Delete(string[] arr)
        {

            string newString = "";

            Console.WriteLine("Choose index");
            var input = Console.ReadLine();
            int numIndex = int.Parse(input);
           

            arr = arr.Where((val, idx) => idx != numIndex).ToArray();
            int j = 0;
            foreach (string i in arr)
            {

                int startIndex = i.Length - 3;

               string content = i.Substring(3, startIndex);

                newString += "[" + j + "]" + content + ",";

                j++;

            }


            
            File.WriteAllText(@"C:\Users\Måns\source\repos\moment3\guests.txt", newString);

           
            Console.WriteLine("Quote deleted");

        }
    }
}
