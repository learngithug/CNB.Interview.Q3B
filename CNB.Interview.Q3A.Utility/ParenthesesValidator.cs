using System.Collections.Generic;

namespace CNB.Interview.Q3A.Utility
{
    /// <summary>
    /// This class validates a string containing just the characters '(', ')', '{', '}', '[' and ']', determine if the input string is valid.
    /// </summary>
    public class ParenthesesValidator : IParenthesesValidator
    {
        private const char OpeningBracket = '[';
        private const char ClosingBracket = ']';
        private const char OpeningParentheses = '(';
        private const char ClosingParentheses = ')';
        private const char OpeningCurlyBrace = '{';
        private const char ClosingCurlyBrace = '}';

        /// <summary>
        /// This method validate string for valid ordering of parenthese and return true or false
        /// </summary>
        /// <param name="toValidate">string to validate</param>
        /// <returns></returns>
        public bool Validate(string toValidate)
        {
            if (string.IsNullOrEmpty(toValidate))
                return false;
            //maximum length of string would be 10^4
            //specify capacity to have operation in constant time
            var validatorStack = new Stack<char>(10000);

            var characters = toValidate.ToCharArray();
            foreach (var character in characters)
            {
                switch (character)
                {
                    case OpeningBracket: // "["
                    case OpeningParentheses: // "(" 
                    case OpeningCurlyBrace: // "{"
                        //push into stack to find matching character
                        validatorStack.Push(character);
                        break;
                    default:
                        if (validatorStack.Count == 0)
                        {
                            //invalid data
                            return false;
                        }
                        else
                        {
                            char topCharacter = validatorStack.Peek();
                            switch (topCharacter)
                            {
                                // "[]" - valid case
                                case OpeningBracket when character is ClosingBracket:
                                // "()" - valid case
                                case OpeningParentheses when character is ClosingParentheses:
                                // "{}" - valid case
                                case OpeningCurlyBrace when character is ClosingCurlyBrace:
                                    //matching found and remove opening character from stack
                                    validatorStack.Pop();
                                    break;
                                default:
                                    //invalid data
                                    return false;
                            }
                        }
                        break;
                }
            }
            if (validatorStack.Count == 0)
            {
                //valid data
                return true;
            }
            else
            {
                //invalid data
                return false;
            }
        }
    }
}
