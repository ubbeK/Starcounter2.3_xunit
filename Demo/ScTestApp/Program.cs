﻿using System;
using System.Linq;
using System.Reflection;
using Starcounter.Xunit.Runner;

namespace ScTestApp
{
    public class Program
    {
        static void Main()
        {
            StarcounterXunitRunner runner = new StarcounterXunitRunner();

            // Executing tests using TestCaseFilter i.e. excluding any test set which is called "TestSetAlwaysFailing"
            Func<Xunit.Abstractions.ITestCase, bool> testCaseFilter = (testCase) =>
            {
                if (testCase.DisplayName.Contains(nameof(TestSetAlwaysFailing)))
                {
                    return false;
                }
            
                return true;
            };
            runner.TestCaseFilter = testCaseFilter;
            runner.Start(testReportName: @"C:\XunitTestReport\TestReportUsingTestCaseFilter");

            // Executing tests using typeName, i.e. only runnign test set which is called "TestSetAlwaysFailing"
            runner.TestCaseFilter = null;
            string typeName = typeof(TestSetAlwaysFailing).GetTypeInfo().FullName;
            runner.Start(typeName: typeName, testReportName: "TestReportUsingTypeName");
        }
    }
}