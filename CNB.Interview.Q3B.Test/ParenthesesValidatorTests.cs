using NUnit.Framework;
using CNB.Interview.Q3A.Utility;

namespace CNB.Interview.Q3B.Test
{
    public class ParenthesesValidatorTests
    {
        private IParenthesesValidator parenthesesValidator;
        [SetUp]
        public void Setup()
        {
            parenthesesValidator = new ParenthesesValidator();
        }

        [TestCase("()")]
        [TestCase("()[]{}")]
        [TestCase("{[]}")]      
        [Test]
        public void ValidateShouldReturnTrue(string toValidate)
        {
            //Act
            var result = parenthesesValidator.Validate(toValidate);

            //Assert
            Assert.IsTrue(result);
        }

        [TestCase("(]")]
        [TestCase("([)]")]
        [TestCase("()(")]
        [TestCase(")(")]
        [TestCase("")]
        [Test]
        public void ValidateShouldReturnFalse(string toValidate)
        {
            //Act
            var result = parenthesesValidator.Validate(toValidate);

            //Assert
            Assert.IsFalse(result);
        }
    }
}