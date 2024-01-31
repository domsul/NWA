using Microsoft.VisualStudio.TestTools.UnitTesting;
using NotesAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace NotesAPI.Tests
{
    public class AutotaggingTest
    {
        [Theory]
        [InlineData("123456789")]
        [InlineData("+48123456789")]
        [InlineData("My number is: 123456789")]
        [InlineData("My number with spaces 123 456 789")]
        [InlineData("My number with spaces 123 456 789 and some text")]
        [InlineData("Number with spaces and area code +48 123 456 789 and some text")]
        [InlineData("999-888-777 separator number")]
        public void phone_true(string input)
        {
            // to do
        }

        [Theory]
        [InlineData("12345678")]
        [InlineData("+4812345789")]
        [InlineData("My number is: 12456789")]
        [InlineData("My number with spaces 12 456 789")]
        [InlineData("My number with spaces 123 456 79 and some text")]
        [InlineData("Number with spaces and area code +48 12 4567 89 and some text")]
        [InlineData("999-888-7777 separator number")]
        public void phone_false(string input)
        {
            // to do
        }

        [Theory]
        [InlineData("123456789@test.xx")]
        [InlineData("text@test.xx")]
        [InlineData("text.with.comma@gmail.com")]
        [InlineData("My email is random@gmail.com.")]
        [InlineData("Some text random@test.com.pl some text")]
        public void email_true(string input)
        {
            // to do
        }

        [Theory]
        [InlineData("123456789@test")]
        [InlineData("text@test@xx.pl")]
        [InlineData("text with spaces @ gmail com")]
        [InlineData("Email not found")]
        [InlineData("antispam(at)test.xx")]
        public void email_false(string input)
        {
            // to do
        }
    }
}
