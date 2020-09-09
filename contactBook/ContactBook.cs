using System;
using System.Collections.Generic;
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


        public static ContactBook AddContact()
        {
            const string skip = "skip";
            var person = new ContactBook("Empty first name", "");

            while (true) 
            {
                ContactBookUtils.FirstNamePrompt();
                var firstName = ContactBookUtils.FirstNameInput();
                if (firstName == skip)
                {
                    person.ContactFirstName = $"{ContactBookUtils.FirstName} was left empty";
                    break;
                }
                person.FirstName = ContactBookUtils.FirstName + firstName;
                break;
            }

            while (true)
            {
                ContactBookUtils.LastNamePrompt();
                var lastName = ContactBookUtils.LastNameInput();
                if (lastName == skip)
                {
                    person.ContactLastName = $"{ContactBookUtils.LastName} was left empty";
                    break;
                }
                person.LastName = ContactBookUtils.LastName + lastName;

                break;
            }
            return person;
        }





        //a.FirstName = "Mombasa";
        //Console.WriteLine(a.FirstName);
        //a.PrintContacts();
        //string userInputName = "test";
        //if (!string.IsNullOrEmpty(userInputName))
        //{
        //    ContactBook newContactBook = new ContactBook(userInputName);
        //    contacts.Add(newContactBook);
        //}



        //public void PrintContacts()
        //{
        //    Console.WriteLine(this.FirstN);
        //}
        //public void EditContacts()
        //{
        //    Console.WriteLine(this.FirstN);
        //}
        //public void DeleteContact()
        //{
        //    Console.WriteLine(this.FirstN);
        //}

        //public void ContactBookMenu()
        //{

    }


}

// always capitalize first letter of name
// prompt user to add another contacts 
// ask user if user wants to skip a detail
// ask user if wants to exit to menu, view contacts 
// Add string for firstname i.e ouput FirstName: Jim.