using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace EfDemo
{
    [TestClass]
    public class LambdaTests
    {
        [TestMethod]
        public void test_action()
        {
            Action<string> act = (s) =>
            {
                Console.WriteLine(s);
            };

            act("test action");
        }

        [TestMethod]
        public void test_func()
        {
            Func<string, string> func = s => $"{s} {s}";

            //Func<string, string> func = s =>
            //{
            //    return $"{s} {s}";
            //};

            Console.WriteLine(func("test"));
        }
    }
}