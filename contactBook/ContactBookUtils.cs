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
        private const string contactsStorageFile = "ContactBookData/ContactBookData.json";
        public static string FirstNamePromptMessage = "Please enter a first name!\nUse alphabetical characters only. Write skip to jump over this part";
        public static string LastNamePromptMessage = "Please enter a last name!\nUse alphabetical characters only. Write skip to jump over this part";
        public static string PhoneNumberPromptMessage = "Please enter a swedish mobile phone number. Ex 0792345304";
        public static string EmailPromptMessage = "Please enter an email address. Don't forget the @ sign";



        public static string EnterCorrectFirstNameInput = "Error:\nPlease enter a valid first name using alphabetical characters!";
        public static string EnterCorrectLastNameInput = "Error:\nPlease enter a valid last name using alphabetical characters!";
        public static string EnterCorrectPhoneNumberFormat = "Error:\nPlease enter a valid swedish mobile phone number. Ex 0792345304";
        public static string EnterCorrectEmailInput = "Error:\nPlease enter a valid email address. Ex muemail123@gmail.com";
        public static string EnterCorrectInputToMen = "Error:\nPlease select an option using only the numbers 1 to 4!";
        public static string EnterExistingContactNumber = "Error:\nContact does not exist! Please enter a valid number";
        public static string EnterCorrectDetailToEditNumber = "Error:\nEnter a valid number!\nWhich part would you like to edit? 1. First name 2. Last name 3. Phone number 4. Email";

        public static void WriteDataJson(List<ContactBook> contacts)
        {
            if (JsonConvert.DeserializeObject<List<ContactBook>>(File.ReadAllText(
                contactsStorageFile)) == null)
            {
                var contactsJson = JsonConvert.SerializeObject(contacts, formatting: Formatting.Indented);
                File.WriteAllText(contactsStorageFile, contactsJson);
            }
            else
            {
                var savedContactsJson = JsonConvert.DeserializeObject<List<ContactBook>>(File.ReadAllText(contactsStorageFile));
                contacts.AddRange(savedContactsJson);
                var contactsJson = JsonConvert.SerializeObject(contacts, formatting: Formatting.Indented);
                File.WriteAllText(contactsStorageFile, contactsJson);
            }
        }

        public static List<ContactBook> ReadDataJson()
        {
            List<ContactBook> contacts = new List<ContactBook>();
            if (JsonConvert.DeserializeObject<List<ContactBook>>(File.ReadAllText(
                contactsStorageFile)) == null)
            {
                return contacts;
            }
            var currentContacts = JsonConvert.DeserializeObject<List<ContactBook>>(File.ReadAllText(contactsStorageFile));
            contacts.AddRange(currentContacts);
            return contacts;
        }

        public static void DeleteEditDataJson(List<ContactBook> contacts)
        {
            var contactsJson = JsonConvert.SerializeObject(contacts, formatting: Formatting.Indented);
            File.WriteAllText(contactsStorageFile, contactsJson);
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
        public static int MenuOptionInput()
        {
            var inputIsInvalid = true;
            int correctInput;
            do
            {
                if (int.TryParse(Console.ReadLine(), out correctInput) && correctInput > 0 && correctInput < 5) inputIsInvalid = false;
                else Console.WriteLine(EnterCorrectInputToMen);

            } while (inputIsInvalid);
            return correctInput;
        }

        public static int ValidateInputIsInRangeOfList(List<ContactBook> contacts)
        {
            var inputIsValidAndWithinRangeInList = true;
            int deleteContactAtIndexInput;
            do
            {
                if (int.TryParse(Console.ReadLine(), out deleteContactAtIndexInput) && deleteContactAtIndexInput <= contacts.Count && deleteContactAtIndexInput > 0)
                    inputIsValidAndWithinRangeInList = false;
                else Console.WriteLine(EnterExistingContactNumber);

            } while (inputIsValidAndWithinRangeInList);

            return deleteContactAtIndexInput;
        }

        public static bool PromptUserToContinueDeletingEditingContacts(List<ContactBook> contacts, string editOrDelete)
        {
            var continueRemovingContacts = true;
            if (contacts.Count > 0)
            {
                switch (editOrDelete)
                {
                    case "edit":
                        Console.WriteLine("Would you like to edit another contact? Answer with yes/no?");
                        break;
                    case "delete":
                        Console.WriteLine("Would you like to delete another contact? Answer with yes/no?");
                        break;
                }

                var isUserWantToDeleteMoreInput = Console.ReadLine();
                Console.Clear();
                var answerIsNotYesOrNo =
                    isUserWantToDeleteMoreInput != "yes" && isUserWantToDeleteMoreInput != "no";
                while (answerIsNotYesOrNo)
                {
                    switch (editOrDelete)
                    {
                        case "edit":
                            Console.WriteLine("Please provide a valid answer!\nWould you like to edit another contact? Answer with yes/no?");
                            break;
                        case "delete":
                            Console.WriteLine("Please provide a valid answer!\nWould you like to delete another contact? Answer with yes/no?");
                            break;
                    }
                    isUserWantToDeleteMoreInput = Console.ReadLine();
                    answerIsNotYesOrNo =
                        isUserWantToDeleteMoreInput != "yes" && isUserWantToDeleteMoreInput != "no";
                }

                if (isUserWantToDeleteMoreInput == "no")
                {
                    continueRemovingContacts = false;
                }
            }
            else
            {
                continueRemovingContacts = false;
            }
            return continueRemovingContacts;
        }

        public static int EnterCorrectNumberToEditDetail()
        {
            var continueUntilCorrectNumber = true;
            int correctNumber;
            do
            {
                if (int.TryParse(Console.ReadLine(), out correctNumber) && correctNumber > 0 && correctNumber < 5)
                    continueUntilCorrectNumber = false;
                else Console.WriteLine(EnterCorrectDetailToEditNumber);

            } while (continueUntilCorrectNumber);

            return correctNumber;
        }

    }

}