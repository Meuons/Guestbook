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
          public static List<guest> getList()
        {

            //Get the xml file, dezerilaize it and turn it into a list
            List<guest> guests = new List<guest>();

           
            guests = null;

            XmlSerializer serializer3 = new XmlSerializer(typeof(List<guest>), new XmlRootAttribute("ArrayOfGuest")) ;

            using (FileStream fs2 = File.OpenRead(@"C:\Users\Måns\source\repos\moment3\guests.xml"))
            {
                guests = (List<guest>)serializer3.Deserialize(fs2);

            }

            return guests;
        }
        public static void Read()
        {

            //Loop through the list

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

     
        public static void Write()
        {

            //Get the users input and add it to the object
            var guests = getList();

            guest inputObj = new guest();
            

            Console.WriteLine("Write your name: ");
            
           
            inputObj.name = Console.ReadLine();

            Console.WriteLine("Write down a quote: "); 
            inputObj.content = Console.ReadLine();
  
            //Check so that neither property is empty
            if (string.IsNullOrEmpty(inputObj.content) || string.IsNullOrEmpty(inputObj.name))
            {
                Console.WriteLine("Error: mssing data");
                Console.WriteLine("Press any key to try again");
                Console.ReadKey();
                menu.MainMenu();
            }
         
            else {

                //Add the object to the list, serialize it and write it to the file
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

            //Remove the element with the index selected by the user. Serialize the updated list and add it to the file

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
