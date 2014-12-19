using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.IO;

using NUnitLite;
using NUnit.Framework.Api;
using NUnit.Framework.Internal;

using NUnitLite.Runner;

using UnityEngine;

namespace NUnitLiteForUnity
{
	public static class NUnitLiteForUnityTestRunner
	{
		public static void RunTests ()
		{
			ITestAssemblyRunner testRunner = new NUnitLiteTestAssemblyRunner (new NUnitLiteTestAssemblyBuilder ());

			Assembly assembly = Assembly.GetCallingAssembly ();

			bool hasTestLoaded = testRunner.Load (assembly: assembly, settings: new Hashtable ());
			if (!hasTestLoaded) {
				Debug.Log (string.Format ("No tests found in assembly {0}", assembly.GetName ().Name));
				return;
			}

			ITestResult rootTestResult = testRunner.Run (TestListener.NULL, TestFilter.Empty);

			ResultSummary summary = new ResultSummary (rootTestResult);
			Debug.Log (ToSummryString (summary));

			List<ITestResult> testResultList = EnumerateTestResult (rootTestResult).Where (it => !it.HasChildren).ToList ();

			if (summary.FailureCount > 0 || summary.ErrorCount > 0) {
				DebugLogErrorResults (testResultList);
			}

			if (summary.NotRunCount > 0) {
				DebugLogNotRunResults (testResultList);
			}
		}

		static string ToSummryString (ResultSummary resultSummry)
		{
			using (StringWriter stringWriter = new StringWriter ()) {
				stringWriter.Write ("{0} Tests :", resultSummry.TestCount);
				stringWriter.Write (" {0} Pass", resultSummry.PassCount);

				if (resultSummry.FailureCount > 0) {
					stringWriter.Write (", {0} Failure", resultSummry.FailureCount);
				}

				if (resultSummry.ErrorCount > 0) {
					stringWriter.Write (", {0} Error", resultSummry.ErrorCount);
				}

				if (resultSummry.NotRunCount > 0) {
					stringWriter.Write (", {0} NotRun", resultSummry.NotRunCount);
				}

				if (resultSummry.InconclusiveCount > 0) {
					stringWriter.Write (", {0} Inconclusive", resultSummry.InconclusiveCount);
				}

				return stringWriter.GetStringBuilder ().ToString ();
			}
		}

		static IEnumerable<ITestResult> EnumerateTestResult (ITestResult result)
		{
			if (result.HasChildren) {
				foreach (ITestResult child in result.Children) {
					foreach (ITestResult c in EnumerateTestResult (child)) {
						yield return c;
					}
				}
			}
			yield return result;
		}

		static void DebugLogErrorResults (IEnumerable<ITestResult> testResults)
		{
			foreach (ITestResult testResult in testResults) {
				if (testResult.ResultState == ResultState.Error || testResult.ResultState == ResultState.Failure) {
					string foramt = "{0}\n{1} ({2})\n{3}\n{4}";
					string log = string.Format (foramt, testResult.ResultState, testResult.Name, testResult.FullName, testResult.Message, testResult.StackTrace);
					Debug.Log (log);
				}
			}
		}

		static void DebugLogNotRunResults (IEnumerable<ITestResult> testResults)
		{
			foreach (ITestResult testResult in testResults) {
				if (testResult.ResultState == ResultState.Ignored || testResult.ResultState == ResultState.NotRunnable || testResult.ResultState == ResultState.Skipped) {
					string foramt = "{0}\n{1} ({2})\n{3}";
					string log = string.Format (foramt, testResult.ResultState, testResult.Name, testResult.FullName, testResult.Message);
					Debug.Log (log);
				}
			}
		}
	}
}
