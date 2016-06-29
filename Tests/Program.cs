using System.Collections.Generic;
using NUnit.Framework.Api;
using System.Reflection;
using NUnit.Framework.Interfaces;
using System;

namespace DvdShop.Tests
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = new DefaultTestAssemblyBuilder();
            var runner = new NUnitTestAssemblyRunner(builder);
            runner.Load(Assembly.GetEntryAssembly(), new Dictionary<string, object>());
            runner.Run(new TestListener(), new TestFilter());
            Console.ReadKey();
        }
    }

    public class TestFilter : ITestFilter
    {
        public TNode AddToXml(TNode parentNode, bool recursive)
        {
            return parentNode;
        }

        public bool IsExplicitMatch(ITest test)
        {
            return false;
        }

        public bool Pass(ITest test)
        {
            return false;
        }

        public TNode ToXml(bool recursive)
        {
            throw new NotImplementedException();
        }
    }
    public class TestListener : ITestListener
    {
        public void TestFinished(ITestResult result)
        {
            Console.WriteLine(result.Output);
        }

        public void TestOutput(TestOutput output)
        {
            Console.WriteLine(output.Text);
        }

        public void TestStarted(ITest test)
        {
            Console.WriteLine($"+++{test.ClassName}: test.MethodName");
        }
    }
}