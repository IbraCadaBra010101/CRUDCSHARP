using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace contactBookProject
{
    public class ContactBook
    {
        private string FirstName { get; set; }
        private string LastName { get; set; }
        //public string LastName;
        //public int PhoneNumber;
        //public string Email;
        //public string Address { get; set; }
        //public int ZipCode;
        //public string Country;

        //public static int AmountOfContacts;
        public override string ToString()
        {
            return $" Contact book information: FirstName {FirstName}, LastName: {LastName}";
        }

        public ContactBook(
            string aFirstName,
            string aLastName
        //string aLastName, int aPhoneNumber,
        //string aEmail, string aAddress, int aZipCode, string aCountry
        )
        {
            FirstName = aFirstName;
            LastName = aLastName;
            //LastName = aLastName;
            //PhoneNumber = aPhoneNumber;
            //Email = aEmail;
            //Address = aAddress;
            //ZipCode = aZipCode;
            //Country = aCountry;
            // AmountOfContacts++;
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


        public static void AddContact()
        {
            const string skip = "skip";
            var continueAddingContacts = true;
            var contactList = new List<ContactBook>();

            do
            {
                var person = new ContactBook("Empty first name", "Empty first name");

                const string yesContinueAdding = "yes";
                const string noQuitAdding = "no";

                while (true)
                {
                    ContactBookUtils.FirstNamePrompt();
                    var firstName = ContactBookUtils.FirstNameInput();
                    if (firstName == skip)
                    {
                        person.ContactFirstName = "empty";
                        break;
                    }
                    person.FirstName = firstName;
                    break;
                }

                while (true)
                {
                    ContactBookUtils.LastNamePrompt();
                    var lastName = ContactBookUtils.LastNameInput();
                    if (lastName == skip)
                    {
                        person.ContactLastName = "empty";
                        break;
                    }
                    person.LastName = lastName;
                    break;
                }
                Console.WriteLine("Would you like to add another user?\nWrite no if you're not interested or write yes key to continue adding more contacts! ");
                while (true)
                {
                    var quitOrContinue = Console.ReadLine();
                    if (quitOrContinue == noQuitAdding)
                    {
                        continueAddingContacts = false;
                        break;
                    }
                    if (quitOrContinue == yesContinueAdding)
                    {
                        break;
                    }

                    if (quitOrContinue == noQuitAdding && quitOrContinue == noQuitAdding) continue;
                    Console.WriteLine("Please provide a valid answer with a yes or no");
                    Console.WriteLine("Would you like to add another user?\nWrite no if you're not interested or write yes key to continue adding more contacts! ");
                }
                contactList.Add(person);
            } while (continueAddingContacts);

            if (JsonConvert.DeserializeObject<List<ContactBook>>(File.ReadAllText(
                @"C:\oop_csharp\assignments\contactBook\contactBook\ContactBookData\ContactBookData.json")) == null)
            {
                var contactsJson = JsonConvert.SerializeObject(contactList, formatting: Formatting.Indented);
                File.WriteAllText(@"C:\oop_csharp\assignments\contactBook\contactBook\ContactBookData\ContactBookData.json", contactsJson);
            }
            else
            {
                var savedContactsJson = JsonConvert.DeserializeObject<List<ContactBook>>(File.ReadAllText(@"C:\oop_csharp\assignments\contactBook\contactBook\ContactBookData\ContactBookData.json"));
                contactList.AddRange(savedContactsJson);
                var contactsJson = JsonConvert.SerializeObject(contactList, formatting: Formatting.Indented);
                File.WriteAllText(@"C:\oop_csharp\assignments\contactBook\contactBook\ContactBookData\ContactBookData.json", contactsJson);
            }

          
        }

    }
}

// always capitalize first letter of name
// prompt user to add another contacts - DONE
// ask user if user wants to skip a detail 
// ask user if wants to exit to menu, view contacts 
// Add string for firstname i.e ouput FirstName: Jim.