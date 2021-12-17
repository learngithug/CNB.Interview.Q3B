namespace CNB.Interview.Q3A.Utility
{
    /// <summary>
    /// Interface for ParenthesesValidator
    /// </summary>
    public interface IParenthesesValidator
    {
        /// <summary>
        /// This method validate string for valid ordering of parenthese and return true or false
        /// </summary>
        /// <param name="toValidate">string to validate</param>
        /// <returns></returns>
        bool Validate(string toValidate);
    }
}