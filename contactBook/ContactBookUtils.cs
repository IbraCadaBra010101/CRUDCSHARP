using System;
using System.Linq;

namespace contactBookProject
{
    public class ContactBookUtils
    {
        public static string FirstNamePromptMessage = "Please enter a first name!\nUse alphabetical characters only. Write skip to jump over this part";
        public static string LastNamePromptMessage = "Please enter a last name!\nUse alphabetical characters only. Write skip to jump over this part";
        public static string EnterCorrectFirstNameInput = "Error:\nPlease enter a valid first name using alphabetical characters!";
        public static string EnterCorrectLastNameInput = "Error:\nPlease enter a valid last name using alphabetical characters!";
 
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



