using System;

using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FluentAssertions.Specs
{
    [TestClass]
    public class NullableNumericAssertionSpecs
    {
        [TestMethod]
        public void Should_succeed_when_asserting_nullable_numeric_value_with_value_to_have_a_value()
        {
            int? nullableInteger = 1;
            nullableInteger.Should().HaveValue();
        }

        [TestMethod]
        [ExpectedException(typeof (AssertFailedException))]
        public void Should_fail_when_asserting_nullable_numeric_value_without_a_value_to_have_a_value()
        {
            int? nullableInteger = null;
            nullableInteger.Should().HaveValue();
        }

        [TestMethod]
        public void Should_fail_with_descriptive_message_when_asserting_nullable_numeric_value_without_a_value_to_have_a_value()
        {
            int? nullableInteger = null;
            var assertions = nullableInteger.Should();
            assertions.Invoking(x => x.HaveValue("because we want to test the failure {0}", "message"))
                .ShouldThrow<AssertFailedException>()
                .WithMessage("Expected a value because we want to test the failure message.");
        }

        [TestMethod]
        public void Should_succeed_when_asserting_nullable_numeric_value_without_a_value_to_be_null()
        {
            int? nullableInteger = null;
            nullableInteger.Should().NotHaveValue();
        }

        [TestMethod]
        [ExpectedException(typeof (AssertFailedException))]
        public void Should_fail_when_asserting_nullable_numeric_value_with_a_value_to_be_null()
        {
            int? nullableInteger = 1;
            nullableInteger.Should().NotHaveValue();
        }

        [TestMethod]
        public void When_nullable_value_with_unexpected_value_is_found_it_should_throw_with_message()
        {
            //-----------------------------------------------------------------------------------------------------------
            // Arrange
            //-----------------------------------------------------------------------------------------------------------
            int? nullableInteger = 1;

            //-----------------------------------------------------------------------------------------------------------
            // Act
            //-----------------------------------------------------------------------------------------------------------
            Action action = () => nullableInteger.Should().NotHaveValue("it was {0} expected", "not");

            //-----------------------------------------------------------------------------------------------------------
            // Assert
            //-----------------------------------------------------------------------------------------------------------
            action
                .ShouldThrow<AssertFailedException>()
                .WithMessage("Did not expect a value because it was not expected, but found <1>.");
        }

        [TestMethod]
        public void Should_succeed_when_asserting_nullable_numeric_value_equals_an_equal_value()
        {
            int? nullableIntegerA = 1;
            int? nullableIntegerB = 1;
            nullableIntegerA.Should().Be(nullableIntegerB);
        }

        [TestMethod]
        public void Should_succeed_when_asserting_nullable_numeric_null_value_equals_null()
        {
            int? nullableIntegerA = null;
            int? nullableIntegerB = null;
            nullableIntegerA.Should().Be(nullableIntegerB);
        }

        [TestMethod]
        [ExpectedException(typeof (AssertFailedException))]
        public void Should_fail_when_asserting_nullable_numeric_value_equals_a_different_value()
        {
            int? nullableIntegerA = 1;
            int? nullableIntegerB = 2;
            nullableIntegerA.Should().Be(nullableIntegerB);
        }

        [TestMethod]
        public void Should_fail_with_descriptive_message_when_asserting_nullable_numeric_value_equals_a_different_value()
        {
            int? nullableIntegerA = 1;
            int? nullableIntegerB = 2;
            var assertions = nullableIntegerA.Should();
            assertions.Invoking(x => x.Be(nullableIntegerB, "because we want to test the failure {0}", "message"))
                .ShouldThrow<AssertFailedException>()
                .WithMessage("Expected <2> because we want to test the failure message, but found <1>.");
        }

        [TestMethod]
        public void Should_support_chaining_constraints_with_and()
        {
            int? nullableInteger = 1;
            nullableInteger.Should()
                .HaveValue()
                .And
                .BePositive();
        }
    }
}