using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace ClassRegisterProject
{
    class Program
    {




            // IsAlpha regex method to check that user input is alphabets
            public static bool IsAlpha(string strToCheck)
            {
                Regex alphaPattern = new Regex("[^a-zA-Z]");
                return !alphaPattern.IsMatch(strToCheck);

            }
            //Validate phone number
            public static bool ValidatePhone(string phoneNo)
            {
            Regex phonePattern = new Regex(@"^([\+]?234[-]|[0])[0-9]{10}$"); //simplified regex
            return !phonePattern.IsMatch(phoneNo);
            }

            public static string CollectFirstName()
            {
                Console.Write("Enter Firstname: ");
                string firstName = Console.ReadLine();
                return firstName;
            }

            public static string CollectLastName()
            {
                Console.Write("Enter Lastname: ");
                string lastName = Console.ReadLine();
                return lastName;
            }

            public static string CollectPhone()
            {
                Console.Write("Enter Phone Number (e.g +23409076543278): ");
                string phone = Console.ReadLine();
                return phone;
            }

            public static string[] CollectGadgets()
            {   
                string[] gadgets = new string[3];
                //This restricts a users gadget to 3. Not excatly practical
                int i;

                for (i = 0; i < gadgets.Length; i++)
                {
                    Console.Write("Enter Gadgets (Maximum of 3): "); //This should be outside your loop
                    gadgets[i] = Console.ReadLine();
                }
                    /*
                    foreach (var item in gadgets)
                    {
                       Console.WriteLine(item);
                    }*/
                       
                    return gadgets;
            }


            public static Gender CollectGender()
            {


                Console.Write("Enter Gender 'male' 'female' 'others': ");
                string gender = Console.ReadLine().ToLower();

                //Validation for gender
                switch (gender)
                {
                    case "male":
                        return ClassRegisterProject.Gender.Male;


                    case "female":
                        return ClassRegisterProject.Gender.Female;


                    case "other":
                    return ClassRegisterProject.Gender.Other;


                    default:
                        Console.WriteLine("No match found! Enter 'male', 'female' or 'other'");
                        return Gender.Other;

                }
            }


        //main method


        public static void Main(string[] args)
        {

            string sanitizedFirstName = "";
            string sanitizedLastName = "";
            string sanitizedPhoneNumber = "";
            string error = "";

            do
            {
                var firstname = CollectFirstName();
                if (IsAlpha(firstname)) 
                { 
                    sanitizedFirstName = firstname;
                    break;
                } //You were calling your collectFirstName method twice, do this instead
                else
                {
                    error = "Firstname must be valid letters[a-zA-Z]";
                    Console.WriteLine(error);

                    //introduced a loop to keep the user in the collect firstname method till they provide a valid firstname
                }
            } while (true);

            //repeat similar action in following code

            if (IsAlpha(CollectLastName())) { sanitizedLastName = CollectLastName(); }
            else
            {
                error = "Lastname must be valid letters[a-zA-Z]";
                Console.WriteLine(error);
            }

            if (!ValidatePhone(CollectPhone())) { sanitizedPhoneNumber = CollectPhone(); }
            else
            {
                error = "Phone number pattern must begin with +234 followed by any other 8 digits";
                Console.WriteLine(error);
            }

            Student student1 = new Student()
            {
                Firstname = sanitizedFirstName,
                Lastname = sanitizedLastName,
                TelephoneNumber = sanitizedPhoneNumber,
                Gadgets = CollectGadgets(),
                Gender = CollectGender()
            };

            Console.WriteLine("");

            //You are using the same data for multiple students name and phone number
            Student student2 = new Student
            {
                Firstname = sanitizedFirstName,
                Lastname = sanitizedLastName,
                TelephoneNumber = sanitizedPhoneNumber,
                Gadgets = CollectGadgets(),
                Gender = CollectGender()
            };

            Console.WriteLine("");


            Student[] students = new Student[]
            {
                             student1,
                             student2,
                             new Student()
                             {Firstname = sanitizedFirstName,
                                Lastname = sanitizedLastName,
                                TelephoneNumber = sanitizedPhoneNumber,
                                Gadgets = CollectGadgets(),
                                Gender = CollectGender()
                             }
            };

            foreach (Student dev in students) //Your printClassDetails method below does this better. No need for duplication
            {
                Console.WriteLine(dev);
            }

            DotNetClass netClass = new DotNetClass(students);
            netClass.PrintClassDetails(); 

        }



    }
}

