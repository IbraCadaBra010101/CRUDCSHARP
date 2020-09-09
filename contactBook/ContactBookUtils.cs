using System;
using System.Linq;

namespace contactBookProject
{
    public class ContactBookUtils
    {
        public static string FirstNamePromptMessage = "Please enter a first name for your contact in order to proceed!\nRemember to use valid characters i.e no number etc ..";
        public static string LastNamePromptMessage = "Please enter a last name for your contact in order to proceed!\nRemember to use valid characters i.e no number etc ..";
        public static string EnterCorrectFirstNameInput = "Please enter a valid first name using alphabetical characters only!";
        public static string EnterCorrectLastNameInput = "Please enter a valid last name using alphabetical characters only!";
        public static string FirstName = "First Name: ";
        public static string LastName = "Last Name: ";
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

        public static void FirstNamePrompt()
        {
            Console.WriteLine(ContactBookUtils.FirstNamePromptMessage);
        }
        public static void LastNamePrompt()
        {
            Console.WriteLine(ContactBookUtils.LastNamePromptMessage);
        }
    }
}



