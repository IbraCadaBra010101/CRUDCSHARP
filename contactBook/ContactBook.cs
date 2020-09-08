using System;
using System.Collections.Generic;


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

        public string ContacFirstName
        {
            get => FirstName;
            set => FirstName = value;
        }
        public string ContactLastName
        {
            get => LastName;
            set => LastName = value;
        }


        public static List<ContactBook> AddContacts()
        {
            List<ContactBook> contactsList = new List<ContactBook>();
            for (int i = 0; i < 3; i++)
            {
                PromptUser(i);
            }
            var userInputName = Console.ReadLine();
            var userInputLastName = Console.ReadLine();

            while (contactsList.Count < 3)
            {
                ContactBook person = new ContactBook(userInputName, userInputLastName);
                contactsList.Add(person);
            };

            Console.WriteLine(contactsList.Count);
            //a.FirstName = "Mombasa";
            //Console.WriteLine(a.FirstName);
            //a.PrintContacts();
            //string userInputName = "test";
            //if (!string.IsNullOrEmpty(userInputName))
            //{
            //    ContactBook newContactBook = new ContactBook(userInputName);
            //    contacts.Add(newContactBook);
            //}
            return contactsList;
        }
        public static void PromptUser(int messageNumber)
        {
            List<string> promptMessagesToUser = new List<string>()
           {
               "Enter the first name of you contact\n",
               "Enter the last name of you contact\n",
               "*************THE CONTACTBOOK APPLICATION 3000*************"
           }; 
        }
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