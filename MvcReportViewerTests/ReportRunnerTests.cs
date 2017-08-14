﻿using NUnit.Framework;

namespace MvcReportViewer.Tests
{
    [TestFixture]
    public class ReportRunnerTests
    {
        [Test]
        public void ReportNameOnlyConstructor()
        {
            var reportRunner = new ReportRunner(ReportFormat.Excel, TestData.ReportName);
            var parameters = reportRunner.ViewerParameters;
            Assert.AreEqual(TestData.ReportName, parameters.ReportPath);
            Assert.AreEqual(TestData.DefaultServer, parameters.ReportServerUrl);
            Assert.AreEqual(TestData.DefaultUsername, parameters.Username);
            Assert.AreEqual(TestData.DefaultPassword, parameters.Password);
            Assert.AreEqual(ReportFormat.Excel, reportRunner.ReportFormat);
            Assert.AreEqual(0, parameters.ReportParameters.Count);
        }

        [Test]
        public void ReportNameAndParametersConstructor()
        {
            var reportRunner = new ReportRunner(
                ReportFormat.Excel, 
                TestData.ReportName,
                TestData.ActualParameters);

            var parameters = reportRunner.ViewerParameters;
            Assert.AreEqual(TestData.ReportName, parameters.ReportPath);
            Assert.AreEqual(TestData.DefaultServer, parameters.ReportServerUrl);
            Assert.AreEqual(TestData.DefaultUsername, parameters.Username);
            Assert.AreEqual(TestData.DefaultPassword, parameters.Password);
            Assert.AreEqual(ReportFormat.Excel, reportRunner.ReportFormat);
            var errors = TestHelpers.ValidateReportParameters(parameters);
            if (!string.IsNullOrEmpty(errors))
            {
                Assert.Fail(errors);
            }
        }

        [Test]
        public void AllParamtersSetInConstructor()
        {
            var reportRunner = new ReportRunner(
                ReportFormat.Excel,
                TestData.ReportName,
                TestData.Server,
                TestData.Username,
                TestData.Password,
                TestData.ActualParameters);

            var parameters = reportRunner.ViewerParameters;
            Assert.AreEqual(TestData.ReportName, parameters.ReportPath);
            Assert.AreEqual(TestData.Server, parameters.ReportServerUrl);
            Assert.AreEqual(TestData.Username, parameters.Username);
            Assert.AreEqual(TestData.Password, parameters.Password);
            Assert.AreEqual(ReportFormat.Excel, reportRunner.ReportFormat);
            var errors = TestHelpers.ValidateReportParameters(parameters);
            if (!string.IsNullOrEmpty(errors))
            {
                Assert.Fail(errors);
            }
        }
    }
}
