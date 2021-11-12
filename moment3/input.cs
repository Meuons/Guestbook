using System;
using System.IO;

using System.Xml.Serialization;
using System.Collections.Generic;

namespace moment3
{
    [Serializable]
    public partial class guest
    {
       public string name;
      public  string content;
       
        public static void Read()
        {

            int i = 0;
            var guests = getList();
            foreach (var guest in guests)
            {
                
                Console.WriteLine("[{0}] {1} - {2}",
                    i,
                    guest.name,
                    guest.content
                    );
                i++;
            }

        }

        public static List<guest> getList()
        {
            List<guest> guests = new List<guest>();

           
            guests = null;

            XmlSerializer serializer3 = new XmlSerializer(typeof(List<guest>), new XmlRootAttribute("ArrayOfGuest")) ;

            using (FileStream fs2 = File.OpenRead(@"C:\Users\Måns\source\repos\moment3\guests.xml"))
            {
                guests = (List<guest>)serializer3.Deserialize(fs2);

            }

            return guests;
        }
        public static void Write()
        {
            var guests = getList();

       

           

            guest inputObj = new guest();
            
            

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
         
            else {
                   guests.Add(inputObj);
        
      using (Stream fs = new FileStream(@"C:\Users\Måns\source\repos\moment3\guests.xml", FileMode.Create, FileAccess.Write))
            {
                XmlSerializer serializer2 = new XmlSerializer(typeof(List<guest>));
                serializer2.Serialize(fs, guests);

            }
            
                 }
          

            

     
        }



     
      
            public static void Delete()
        {
            var guests = getList();



            Console.WriteLine("Choose index");
            var input = Console.ReadLine();
            int index = int.Parse(input);

            guests.RemoveAt(index);


            using (Stream fs = new FileStream(@"C:\Users\Måns\source\repos\moment3\guests.xml", FileMode.Create, FileAccess.Write))
            {
                XmlSerializer serializer2 = new XmlSerializer(typeof(List<guest>));
                serializer2.Serialize(fs, guests);

            }

        }
    }
}
