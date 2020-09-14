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
            const string menuOptions = "Menu options: Enter a number to proceed!\n1. Add contacts 2. Print contacts 3. Delete contacts 4. Edit contacts";
            Console.WriteLine(menuOptions);
            var userInputMenu = ContactBookUtils.MenuOptionInput();

            while (userInputMenu <= 4)
            {
                var contacts = ContactBookUtils.ReadDataJson();
                switch (userInputMenu)
                {

                    case 1:
                        AddContact();
                        Console.WriteLine(menuOptions);
                        break;
                    case 2:
                        if (contacts.Count > 0)
                        {
                            ShowContacts();
                            Console.WriteLine(menuOptions);
                        }
                        else
                        {
                            Console.WriteLine("No contacts to show. Press 1 to add a contact");
                            Console.WriteLine(menuOptions);

                        }
                        break;
                    case 3:
                        if (contacts.Count > 0)
                        {
                            DeleteContact();
                            Console.WriteLine(menuOptions);
                        }
                        else
                        {
                            Console.WriteLine("No contacts to delete. Press 1 to add a contact");
                            Console.WriteLine(menuOptions);
                        }

                        break;
                    case 4:
                        if (contacts.Count > 0)
                        {
                            EditContact();
                            Console.WriteLine(menuOptions);
                        }
                        else
                        {
                            Console.WriteLine("No contact to edit. Press 1 to add a contact");
                            Console.WriteLine(menuOptions);
                        }
                        break;
                }
                userInputMenu = ContactBookUtils.MenuOptionInput();

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
            bool continueRemovingContacts;
            const string delete = "delete";
            do
            {
                ShowContacts();
                Console.WriteLine("Enter the number for the contact you would like to delete!");
                var contacts = ContactBookUtils.ReadDataJson();
                var deleteContactAtIndexInput = ContactBookUtils.ValidateInputIsInRangeOfList(contacts);
                var personFirstNameDeleted = contacts[deleteContactAtIndexInput - 1].FirstName;
                var personLastNameDeleted = contacts[deleteContactAtIndexInput - 1].LastName;
                contacts.Remove(contacts[deleteContactAtIndexInput - 1]);
                ContactBookUtils.DeleteEditDataJson(contacts);
                ShowContacts();
                Console.WriteLine($"{personFirstNameDeleted} {personLastNameDeleted} has been deleted from your contacts!");
                continueRemovingContacts = ContactBookUtils.PromptUserToContinueDeletingEditingContacts(contacts, delete);

            } while (continueRemovingContacts);

        }

        public static void EditContact()
        {
            bool continueEditingContacts;
            const string edit = "edit";

            do
            {
                ShowContacts();
                Console.WriteLine("Enter the contact number for the contact you would like to edit!");
                var contacts = ContactBookUtils.ReadDataJson();
                var editContactAtIndexInput = ContactBookUtils.ValidateInputIsInRangeOfList(contacts);
                var editAnotherDetailOnCurrentContact = true;
                Console.WriteLine("You have chosen to edit:");
                Console.WriteLine($"{contacts[editContactAtIndexInput - 1].ContactFirstName}");
                Console.WriteLine($"{contacts[editContactAtIndexInput - 1].LastName}");
                Console.WriteLine($"{contacts[editContactAtIndexInput - 1].PhoneNumber}");
                Console.WriteLine($"{contacts[editContactAtIndexInput - 1].Email}");

                do
                {
                    Console.WriteLine("Which part would you like to edit?\nPress one of the numbers\n1. First name 2. Last name 3. Phone number 4. Email");
                    var editContactDetailNumber = ContactBookUtils.EnterCorrectNumberToEditDetail();
                    switch (editContactDetailNumber)
                    {
                        case 1:
                            ContactBookUtils.CreateFirstName(contacts[editContactAtIndexInput - 1], "skip");
                            break;
                        case 2:
                            ContactBookUtils.CreateLastName(contacts[editContactAtIndexInput - 1], "skip");
                            break;
                        case 3:
                            ContactBookUtils.CreatePhoneNumber(contacts[editContactAtIndexInput - 1], "skip");
                            break;
                        case 4:
                            ContactBookUtils.CreateEmail(contacts[editContactAtIndexInput - 1], "skip");
                            break;
                    }

                    Console.WriteLine("Would you like to edit another part on the current contact?\nAnswer with yes/no");
                    var editOneMoreDetailOnCurrentContactInput = Console.ReadLine();
                    var answerIsNotYesOrNo = editOneMoreDetailOnCurrentContactInput != "yes" && editOneMoreDetailOnCurrentContactInput != "no";
                    while (answerIsNotYesOrNo)
                    {
                        Console.WriteLine("Please answer with yes/no!");
                        editOneMoreDetailOnCurrentContactInput = Console.ReadLine();
                        answerIsNotYesOrNo = editOneMoreDetailOnCurrentContactInput != "yes" && editOneMoreDetailOnCurrentContactInput != "no";

                    }

                    if (editOneMoreDetailOnCurrentContactInput == "no")
                        editAnotherDetailOnCurrentContact = false;

                } while (editAnotherDetailOnCurrentContact);

                Console.WriteLine($"Edit was successful!");
                Console.WriteLine($"{contacts[editContactAtIndexInput - 1].ContactFirstName}");
                Console.WriteLine($"{contacts[editContactAtIndexInput - 1].LastName}");
                Console.WriteLine($"{contacts[editContactAtIndexInput - 1].PhoneNumber}");
                Console.WriteLine($"{contacts[editContactAtIndexInput - 1].Email}");

                ContactBookUtils.DeleteEditDataJson(contacts);
                continueEditingContacts = ContactBookUtils.PromptUserToContinueDeletingEditingContacts(contacts, edit);
            } while (continueEditingContacts);

        }
    }
}
