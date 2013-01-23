using System;
using NUnit.Framework;

namespace MBC.Tests.UnitTests.UInteger
{
    abstract public class BaseTests
    {
        public void test<T>(string a, string b, string expected, Func<T, T, T> fun) where T : class
        {
            var first = (T)Activator.CreateInstance(typeof(T), a);
            var second = (T)Activator.CreateInstance(typeof(T), b);

            var actual = fun(first, second).ToString();

            Assert.That(actual, Is.EqualTo(expected));
        }

        public void testIsInstanceOf<T>(string a, string b, Func<T, T, T> fun) where T : class
        {
            var first = (T)Activator.CreateInstance(typeof(T), a);
            var second = (T)Activator.CreateInstance(typeof(T), b);

            var actual = fun(first, second);

            Assert.IsInstanceOf<T>(actual);
        }
    }
}