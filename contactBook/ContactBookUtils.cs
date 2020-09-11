using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;
using System.IO;
using System.Text.RegularExpressions;
using System.ComponentModel.DataAnnotations;

namespace contactBookProject
{
    public class ContactBookUtils
    {
        public static string FirstNamePromptMessage = "Please enter a first name!\nUse alphabetical characters only. Write skip to jump over this part";
        public static string LastNamePromptMessage = "Please enter a last name!\nUse alphabetical characters only. Write skip to jump over this part";
        public static string PhoneNumberPromptMessage = "Please enter a swedish mobile phone number. Ex 0792345304";
        public static string EmailPromptMessage = "Please enter an email address. Don't forget the @ sign";



        public static string EnterCorrectFirstNameInput = "Error:\nPlease enter a valid first name using alphabetical characters!";
        public static string EnterCorrectLastNameInput = "Error:\nPlease enter a valid last name using alphabetical characters!";
        public static string EnterCorrectPhoneNumberFormat = "Error:\nPlease enter a valid swedish mobile phone number. Ex 0792345304";
        public static string EnterCorrectEmailInput = "Error:\nPlease enter a valid email address. Ex muemail123@gmail.com";


        public static void SaveDataToJson(List<ContactBook> contacts)
        {
            if (JsonConvert.DeserializeObject<List<ContactBook>>(File.ReadAllText(
                @"C:\oop_csharp\assignments\contactBook\contactBook\ContactBookData\ContactBookData.json")) == null)
            {
                var contactsJson = JsonConvert.SerializeObject(contacts, formatting: Formatting.Indented);
                File.WriteAllText(@"C:\oop_csharp\assignments\contactBook\contactBook\ContactBookData\ContactBookData.json", contactsJson);
            }
            else
            {
                var savedContactsJson = JsonConvert.DeserializeObject<List<ContactBook>>(File.ReadAllText(@"C:\oop_csharp\assignments\contactBook\contactBook\ContactBookData\ContactBookData.json"));
                contacts.AddRange(savedContactsJson);
                var contactsJson = JsonConvert.SerializeObject(contacts, formatting: Formatting.Indented);
                File.WriteAllText(@"C:\oop_csharp\assignments\contactBook\contactBook\ContactBookData\ContactBookData.json", contactsJson);
            }
        }








        public static void FirstNamePrompt()
        {
            Console.WriteLine(ContactBookUtils.FirstNamePromptMessage);
        }
        public static void LastNamePrompt()
        {
            Console.WriteLine(ContactBookUtils.LastNamePromptMessage);
        }
        public static void PhoneNumberPrompt()
        {
            Console.WriteLine(ContactBookUtils.PhoneNumberPromptMessage);
        }
        private static void EmailPrompt()
        {
            Console.WriteLine(ContactBookUtils.EmailPromptMessage);
        }








        public static string FirstNameInput()
        {
            var firstNameInput = Console.ReadLine();
            var isInputCharactersOnly = (firstNameInput ?? throw new InvalidOperationException()).All(char.IsLetter);

            while (string.IsNullOrEmpty(firstNameInput) || !isInputCharactersOnly)
            {
                Console.WriteLine(ContactBookUtils.EnterCorrectFirstNameInput);
                firstNameInput = Console.ReadLine();
                isInputCharactersOnly = (firstNameInput ?? throw new InvalidOperationException()).All(char.IsLetter);
            }
            return firstNameInput;
        }
        public static string LastNameInput()
        {
            var lastNameInput = Console.ReadLine();
            var isInputCharactersOnly = (lastNameInput ?? throw new InvalidOperationException()).All(char.IsLetter);
            while (string.IsNullOrEmpty(lastNameInput) || !isInputCharactersOnly)
            {
                Console.WriteLine(ContactBookUtils.EnterCorrectLastNameInput);
                lastNameInput = Console.ReadLine();
                isInputCharactersOnly = (lastNameInput ?? throw new InvalidOperationException()).All(char.IsLetter);
            }
            return lastNameInput;
        }
        public static string PhoneNumberInput(string skip)
        {
            var phoneNumberInput = Console.ReadLine();
            Regex swedishPhoneNumberRegex = new Regex(@"^(((|(\+){1})46)|0)7[\d]{8}");
            while (string.IsNullOrEmpty(phoneNumberInput) || !swedishPhoneNumberRegex.IsMatch(phoneNumberInput))
            {
                Console.WriteLine(ContactBookUtils.EnterCorrectPhoneNumberFormat);
                phoneNumberInput = Console.ReadLine();
                if (phoneNumberInput == skip) break;
            }
            return phoneNumberInput;
        }
        private static string EmailInput()
        {
            var emailInput = Console.ReadLine();
            var emailAddressAttribute = new EmailAddressAttribute();
            var isEmailAddressValid = emailAddressAttribute.IsValid(emailInput);
            while (!isEmailAddressValid)
            {
                Console.WriteLine(ContactBookUtils.EnterCorrectEmailInput);
                emailInput = Console.ReadLine();
                isEmailAddressValid = emailAddressAttribute.IsValid(emailInput);

            }
            return emailInput;
        }





        public static void CreateFirstName(ContactBook person, string skip)
        {

            while (true)
            {
                ContactBookUtils.FirstNamePrompt();
                var firstName = ContactBookUtils.FirstNameInput();
                if (firstName == skip)
                {
                    person.ContactFirstName = "empty";
                    break;
                }
                person.ContactFirstName = firstName;
                break;
            }
        }
        public static void CreateLastName(ContactBook person, string skip)
        {

            while (true)
            {
                ContactBookUtils.LastNamePrompt();
                var lastName = ContactBookUtils.LastNameInput();
                if (lastName == skip)
                {
                    person.ContactLastName = "empty";
                    break;
                }
                person.ContactLastName = lastName;
                break;
            }
        }

        public static void CreatePhoneNumber(ContactBook person, string skip)
        {

            while (true)
            {
                ContactBookUtils.PhoneNumberPrompt();
                var phoneNumber = ContactBookUtils.PhoneNumberInput(skip);
                if (phoneNumber == skip)
                {
                    person.ContactPhoneNumber = "empty";
                    break;
                }
                person.ContactPhoneNumber = phoneNumber;
                break;
            }
        }

        public static void CreateEmail(ContactBook person, string skip)
        {
            while (true)
            {

                ContactBookUtils.EmailPrompt();
                var email = ContactBookUtils.EmailInput();
                if (email == skip)
                {
                    person.ContactEmail = "empty";
                    break;
                }
                person.ContactEmail = email;
                break;
            }
        }
    }

}



