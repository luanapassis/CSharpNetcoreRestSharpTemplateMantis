using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using NUnit.Framework;
using RestSharpNetCoreTemplate.Helpers;

namespace RestSharpNetCoreTemplate.DataDriven
{
	class GetAllIssueDataDriven
	{
        public static List<TestCaseData> GetAllIssueTestCases
        {
            get
            {
                var testCases = new List<TestCaseData>();

                using (var fs = File.OpenRead(GeneralHelpers.ReturnProjectPath() + @"DataDriven\IssueData.csv"))
                using (var sr = new StreamReader(fs))
                {
                    string line = string.Empty;
                    while (line != null)
                    {
                        line = sr.ReadLine();
                        if (line != null)
                        {
                            string[] split = line.Split(new char[] { ',' },
                                StringSplitOptions.None);

                            string colum1 = split[0];
                            string colum2 = split[1];

                            var testCase = new TestCaseData(colum1, colum2);
                            testCases.Add(testCase);
                        }
                    }
                }

                return testCases;
            }
        }
    }
}
