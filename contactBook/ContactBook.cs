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

        public ContactBook(string aFirstName, string aLastName, string aPhoneNumber, string aEmail)
        {
            FirstName = aFirstName;
            LastName = aLastName;
            PhoneNumber = aPhoneNumber;
            Email = aEmail;
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
            var menuOptions = "Menu options: Enter a number to proceed!\n1.Add contacts 2.Print contacts 3.Delete contacts 4. Edit contacts 5. Erase all contacts";
            Console.WriteLine(menuOptions);
            int userInputMenu = int.Parse(Console.ReadLine());
            while (userInputMenu != 4)
            { 
                switch (userInputMenu)
                {
                    case 1:
                        AddContact();
                        Console.WriteLine(menuOptions);
                        break;
                    case 2:
                        ShowContacts();
                        Console.WriteLine(menuOptions);
                        break;
                    case 3:
                        DeleteContact();
                        Console.WriteLine(menuOptions);
                        break;
                    default:
                        ControlMenu();
                        break;

                }
                userInputMenu = int.Parse(Console.ReadLine());
                Console.Clear();
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
                    Console.Clear();
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
            ContactBookUtils.WriteDataJson(contactList);
            

        }
        public static void ShowContacts()
        {
            var contacts = ContactBookUtils.ReadDataJson();

            if (contacts.Count < 1) Console.WriteLine("You do not have any contacts stored.");
            else
                for (var i = 0; i < contacts.Count; i++)
                {
                    Console.WriteLine($"Contact number: {i + 1}");
                    Console.WriteLine($"First Name:{contacts[i].FirstName} Last Name:{contacts[i].LastName}");
                    Console.WriteLine($"Email Address:{contacts[i].Email} ");
                    Console.WriteLine($"Phone Number:{contacts[i].PhoneNumber}\n");
                }
        }

        public static void DeleteContact()
        {
            var continueRemovingContacts = true;
            do
            {
                ShowContacts();
                Console.WriteLine("Enter the contact number of the contact you would like to delete!");
                var contacts = ContactBookUtils.ReadDataJson();
                var deleteContactAtIndexInput = int.Parse(Console.ReadLine());
                var indexIsNotOutOfBound =
                    deleteContactAtIndexInput > contacts.Count || deleteContactAtIndexInput < 1;
                while (indexIsNotOutOfBound)
                {
                    Console.WriteLine($"No user was found with the contact number {deleteContactAtIndexInput}");
                    deleteContactAtIndexInput = int.Parse(Console.ReadLine());
                    indexIsNotOutOfBound =
                        deleteContactAtIndexInput > contacts.Count || deleteContactAtIndexInput < contacts.Count;
                }
                var personFirstNameDeleted = contacts[deleteContactAtIndexInput - 1].FirstName;
                var personLastNameDeleted = contacts[deleteContactAtIndexInput - 1].FirstName;
                contacts.Remove(contacts[deleteContactAtIndexInput - 1]);
                ContactBookUtils.DeleteDataJson(contacts);
                ShowContacts();
                Console.WriteLine($"{personFirstNameDeleted} {personLastNameDeleted} has been deleted from your contacts!");
                if (contacts.Count > 0)
                {
                    Console.WriteLine("Would you like to delete another contact Answer with yes/no?");
                    var isUserWantToDeleteMoreInput = Console.ReadLine();
                    Console.Clear();
                    var answerIsNotYesOrNo =
                        isUserWantToDeleteMoreInput != "yes" && isUserWantToDeleteMoreInput != "no";
                    while (answerIsNotYesOrNo)
                    {
                        Console.WriteLine("Provide a valid answer with yes/no. Delete more contacts yes or no?");
                        isUserWantToDeleteMoreInput = Console.ReadLine();
                        answerIsNotYesOrNo =
                            isUserWantToDeleteMoreInput != "yes" && isUserWantToDeleteMoreInput != "no";
                    }

                    if (isUserWantToDeleteMoreInput == "no" )
                    {
                        continueRemovingContacts = false;
                    }
                }
                else
                {
                    continueRemovingContacts = false;
                }
            } while (continueRemovingContacts);


        }
    }
}





// always capitalize first letter of name
// prompt user to add another contacts - DONE
// ask user if user wants to skip a detail 
// ask user if wants to exit to menu, view contacts 
// Add string for firstname i.e ouput FirstName: Jim.