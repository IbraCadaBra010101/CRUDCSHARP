using System;
using System.Collections.Generic;


namespace contactBookProject
{
    public class ContactBook
    {
        private string FirstName { get; set; }
        private string LastName { get; set; }
        private string PhoneNumber { get; set; }
        private string Email { get; set; }
        public static int AmountOfContacts;

        public ContactBook(string aFirstName, string aLastName, string aPhoneNumber, string aEmail)
        {
            FirstName = aFirstName;
            LastName = aLastName;
            PhoneNumber = aPhoneNumber;
            Email = aEmail;
            AmountOfContacts++;
        }

        public string ContactFirstName
        {
            get => FirstName;
            set => FirstName = value;
        }
        public string ContactLastName
        {
            get => LastName;
            set => LastName = value;
        }
        public string ContactPhoneNumber
        {
            get => PhoneNumber;
            set => PhoneNumber = value;
        }
        public string ContactEmail
        {
            get => Email;
            set => Email = value;
        }
        public static void ControlMenu() 
        {
            Console.WriteLine("Press 1: Add more contacts Press 2: Show my contacts Press 3: Quit ");
            int userInputMenu = int.Parse(Console.ReadLine());
            while (userInputMenu != 3)
            {
                switch (userInputMenu)
                {
                    case 1:
                        Console.WriteLine("Press 1: Add more contacts Press 2: Show my contacts Press 3: Quit ");
                        AddContact();
                        Console.WriteLine("Press 1: Add more contacts Press 2: Show my contacts Press 3: Quit ");
                        break;
                    case 2:
                        Console.WriteLine("Press 1: Add more contacts Press 2: Show my contacts Press 3: Quit ");
                        ShowContacts();
                        Console.WriteLine("Press 1: Add more contacts Press 2: Show my contacts Press 3: Quit ");
                        break;
                    default:
                        ControlMenu();
                        break;

                }
                userInputMenu = int.Parse(Console.ReadLine());
            }
        }

        public static void AddContact()
        {
            const string skip = "skip";
            var continueAddingContacts = true;
            var contactList = new List<ContactBook>();
            do
            {
                var person = new ContactBook("Empty first name", "Empty last name", "Empty phone number", "Empty email");
                const string continueAdding = "yes";
                const string quitAdding = "no";
                ContactBookUtils.CreateFirstName(person, skip);
                ContactBookUtils.CreateLastName(person, skip);
                ContactBookUtils.CreatePhoneNumber(person, skip);
                ContactBookUtils.CreateEmail(person, skip);
                Console.WriteLine("Would you like to add another contact?\nyes/no! ");
                while (true)
                {
                    var quitOrContinue = Console.ReadLine();
                    if (quitOrContinue == quitAdding)
                    {
                        continueAddingContacts = false;
                        break;
                    }
                    if (quitOrContinue == continueAdding)
                    {
                        break;
                    }

                    if (quitOrContinue == quitAdding && quitOrContinue == quitAdding) continue;
                    Console.WriteLine("Please provide an answer. Write yes or no");
                    Console.WriteLine("Would you like to add another user?\nyes/no");
                }
                contactList.Add(person);

            } while (continueAddingContacts);
            ContactBookUtils.SaveDataToJson(contactList);
        }
        public static void ShowContacts()
        {
            var contacts = ContactBookUtils.RetrieveDataFromJson();

            Console.WriteLine($"You have currently have {ContactBook.AmountOfContacts / 2} saved contacts\n");

            for (int i = 0; i < contacts.Count; i++)
            {
                Console.WriteLine($"Contact number: {i + 1}");
                Console.WriteLine(".........................");

                Console.WriteLine($"First Name:{contacts[i].FirstName}");
                Console.WriteLine(".........................");

                Console.WriteLine($"Last Name:{contacts[i].LastName}");
                Console.WriteLine(".........................");

                Console.WriteLine($"Email Address:{contacts[i].Email} ");
                Console.WriteLine(".........................");

                Console.WriteLine($"Phone Number:{contacts[i].PhoneNumber}\n\n");
            }
            Console.WriteLine($":::::::::::::::::::::::::");
        }
    }
}





// always capitalize first letter of name
// prompt user to add another contacts - DONE
// ask user if user wants to skip a detail 
// ask user if wants to exit to menu, view contacts 
// Add string for firstname i.e ouput FirstName: Jim.