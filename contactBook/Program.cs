using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using static contactBookProject.ContactBook;

namespace contactBookProject
{
    class Program
    {
        static void Main(string[] args)
        {
            
            var continueAddingContacts = true;
            List<ContactBook> contactsList = new List<ContactBook>();
             
            while (continueAddingContacts)
            {
               contactsList.Add(AddContact());
               Console.WriteLine("Would you like to add another contact?");
                var userInput = Console.ReadLine();
                if (userInput != null && userInput.ToLower() == "no")
                {
                    continueAddingContacts = false;
                }

                foreach (var p in contactsList)
                {
                    Console.WriteLine($"{p.ContacFirstName} {p.ContactLastName}");
                }
            }

            //for (int i = 0; i < currentListOfContacts.Count; i++)
            //{
            //    Console.WriteLine("Contact number {0} ", i + 1);
            //    Console.WriteLine(currentListOfContacts[i].ContacFirstName);
            //    Console.WriteLine(currentListOfContacts[i].ContactLastName);
            //}
            //foreach (var contact in  currentListOfContacts)
            //{
            //    Console.WriteLine(contact.ContacFirstName);
            //    Console.WriteLine(contact.ContactLastName);
            //}




            //ContactBook a = new ContactBook("Jim");
            //List<ContactBook> contacts = new List<ContactBook>();
            //a.FirstName = "Mombasa";
            //Console.WriteLine(a.FirstName);
            //a.PrintContacts();
            //string userInputName = "test";
            //if (!string.IsNullOrEmpty(userInputName))
            //{
            //    ContactBook newContactBook = new ContactBook(userInputName);
            //    contacts.Add(newContactBook);
            //}
        }
    }
}
