using System;
using System.Collections.Generic;
using UniLinq;
using NUnit.Framework;

namespace UniLinqTest
{
	[TestFixture]
	[Category("UniLinqTests")]
	class AverageTest
	{
		#region source
		[Test]
		public void TestNormalSequence ()
		{
			Assert.That (new int[]{3, 1, 4, 1, 5, 9, 2, 0}.Average (), Is.EqualTo (3.125));
			Assert.That (new int?[]{3, 1, 4, 1, 5, 9, 2, 0}.Average (), Is.EqualTo (3.125));
			Assert.That (new long[]{3, 1, 4, 1, 5, 9, 2, 0}.Average (), Is.EqualTo (3.125));
			Assert.That (new long?[]{3, 1, 4, 1, 5, 9, 2, 0}.Average (), Is.EqualTo (3.125));
			Assert.That (new float[]{3.0F, 1.0F, 4.0F, 1.0F, 5.0F, 9.0F, 2.0F, 0.0F}.Average (), Is.EqualTo (3.125F));
			Assert.That (new float?[]{3.0F, 1.0F, 4.0F, 1.0F, 5.0F, 9.0F, 2.0F, 0.0F}.Average (), Is.EqualTo (3.125F));
			Assert.That (new double[]{3.0, 1.0, 4.0, 1.0, 5.0, 9.0, 2.0, 0.0}.Average (), Is.EqualTo (3.125));
			Assert.That (new double?[]{3.0, 1.0, 4.0, 1.0, 5.0, 9.0, 2.0, 0.0}.Average (), Is.EqualTo (3.125));
			Assert.That (new decimal[]{3.0M, 1.0M, 4.0M, 1.0M, 5.0M, 9.0M, 2.0M, 0.0M}.Average (), Is.EqualTo (3.125M));
			Assert.That (new decimal?[]{3.0M, 1.0M, 4.0M, 1.0M, 5.0M, 9.0M, 2.0M, 0.0M}.Average (), Is.EqualTo (3.125M));
		}

		[Test]
		public void TestEmptySequence ()
		{
			Assert.Throws <InvalidOperationException> (() => new int[0].Average ());
			Assert.Throws <InvalidOperationException> (() => new long[0].Average ());
			Assert.Throws <InvalidOperationException> (() => new float[0].Average ());
			Assert.Throws <InvalidOperationException> (() => new double[0].Average ());
			Assert.Throws <InvalidOperationException> (() => new decimal[0].Average ());

			Assert.That (new int?[0].Average (), Is.Null);
			Assert.That (new long?[0].Average (), Is.Null);
			Assert.That (new float?[0].Average (), Is.Null);
			Assert.That (new double?[0].Average (), Is.Null);
			Assert.That (new decimal?[0].Average (), Is.Null);
		}

		[Test]
		public void TestNullOnlySequence ()
		{
			Assert.That (new int?[]{ null }.Average (), Is.Null);
			Assert.That (new long?[]{ null }.Average (), Is.Null);
			Assert.That (new float?[]{ null }.Average (), Is.Null);
			Assert.That (new double?[]{ null }.Average (), Is.Null);
			Assert.That (new decimal?[]{ null }.Average (), Is.Null);
		}

		[Test]
		public void TestNullMixedSequence ()
		{
			Assert.That (new int?[]{3, 1, 4, null, 1, 5, 9, 2, null, 0}.Average (), Is.EqualTo (3.125));
			Assert.That (new long?[]{3, 1, 4, null, 1, 5, 9, 2, null, 0}.Average (), Is.EqualTo (3.125));
			Assert.That (new float?[] {
				3.0F,
				1.0F,
				4.0F,
				null,
				1.0F,
				5.0F,
				9.0F,
				2.0F,
				null,
				0.0F
			}.Average (), Is.EqualTo (3.125F));
			Assert.That (new double?[] {
				3.0,
				1.0,
				4.0,
				null,
				1.0,
				5.0,
				9.0,
				2.0,
				null,
				0.0
			}.Average (), Is.EqualTo (3.125));
			Assert.That (new decimal?[] {
				3.0M,
				1.0M,
				4.0M,
				null,
				1.0M,
				5.0M,
				9.0M,
				2.0M,
				null,
				0.0M
			}.Average (), Is.EqualTo (3.125M));
		}

		[Test]
		public void TestNull ()
		{
			#pragma warning disable 1720
			Assert.Throws<ArgumentNullException> (() => ((int[])null).Average ());
			Assert.Throws<ArgumentNullException> (() => ((int?[])null).Average ());
			Assert.Throws<ArgumentNullException> (() => ((long[])null).Average ());
			Assert.Throws<ArgumentNullException> (() => ((long?[])null).Average ());
			Assert.Throws<ArgumentNullException> (() => ((float[])null).Average ());
			Assert.Throws<ArgumentNullException> (() => ((float?[])null).Average ());
			Assert.Throws<ArgumentNullException> (() => ((double[])null).Average ());
			Assert.Throws<ArgumentNullException> (() => ((double?[])null).Average ());
			Assert.Throws<ArgumentNullException> (() => ((decimal[])null).Average ());
			Assert.Throws<ArgumentNullException> (() => ((decimal?[])null).Average ());
			#pragma warning restore 1720
		}
		#endregion

		#region source_selector
		[Test]
		public void TestNumsWithSelector ()
		{
			IEnumerable<int> ints = new int[]{3, 1, 4, 1, 5, 9, 2, 0};

			Assert.That (ints.Average (it => (int)it), Is.EqualTo (3.125));
			Assert.That (ints.Average (it => (int?)it), Is.EqualTo (3.125));
			Assert.That (ints.Average (it => (long)it), Is.EqualTo (3.125));
			Assert.That (ints.Average (it => (long?)it), Is.EqualTo (3.125));
			Assert.That (ints.Average (it => (float)it), Is.EqualTo (3.125F));
			Assert.That (ints.Average (it => (float?)it), Is.EqualTo (3.125F));
			Assert.That (ints.Average (it => (double)it), Is.EqualTo (3.125));
			Assert.That (ints.Average (it => (double?)it), Is.EqualTo (3.125));
			Assert.That (ints.Average (it => (decimal)it), Is.EqualTo (3.125M));
			Assert.That (ints.Average (it => (decimal?)it), Is.EqualTo (3.125M));

			IEnumerable<string> strings = new string[] {
				"Cube",
				"Sphere",
				"Capsule",
				"Cylinder",
				"Plane",
			};

			Assert.That (strings.Average (it => (int)it.Length), Is.EqualTo (6.0));
			Assert.That (strings.Average (it => (int?)it.Length), Is.EqualTo (6.0));
			Assert.That (strings.Average (it => (long)it.Length), Is.EqualTo (6.0));
			Assert.That (strings.Average (it => (long?)it.Length), Is.EqualTo (6.0));
			Assert.That (strings.Average (it => (float)it.Length), Is.EqualTo (6.0F));
			Assert.That (strings.Average (it => (float?)it.Length), Is.EqualTo (6.0F));
			Assert.That (strings.Average (it => (double)it.Length), Is.EqualTo (6.0));
			Assert.That (strings.Average (it => (double?)it.Length), Is.EqualTo (6.0));
			Assert.That (strings.Average (it => (decimal)it.Length), Is.EqualTo (6.0M));
			Assert.That (strings.Average (it => (decimal?)it.Length), Is.EqualTo (6.0M));
		}

		[Test]
		public void TestNullSelector ()
		{
			IEnumerable<string> strings = new string[] {
				"Cube",
				"Sphere",
				"Capsule",
				"Cylinder",
				"Plane",
				"Quad"
			};
			Assert.Throws<ArgumentNullException> (() => strings.Average ((Func<string, int>)null));
			Assert.Throws<ArgumentNullException> (() => strings.Average ((Func<string, int?>)null));
			Assert.Throws<ArgumentNullException> (() => strings.Average ((Func<string, long>)null));
			Assert.Throws<ArgumentNullException> (() => strings.Average ((Func<string, long?>)null));
			Assert.Throws<ArgumentNullException> (() => strings.Average ((Func<string, float>)null));
			Assert.Throws<ArgumentNullException> (() => strings.Average ((Func<string, float?>)null));
			Assert.Throws<ArgumentNullException> (() => strings.Average ((Func<string, double>)null));
			Assert.Throws<ArgumentNullException> (() => strings.Average ((Func<string, double?>)null));
			Assert.Throws<ArgumentNullException> (() => strings.Average ((Func<string, decimal>)null));
			Assert.Throws<ArgumentNullException> (() => strings.Average ((Func<string, decimal?>)null));

			IEnumerable<DateTime> dateTimes = new DateTime[]{
				new DateTime (2014, 3, 21),
				new DateTime (2014, 6, 21),
				new DateTime (2014, 9, 23),
				new DateTime (2014, 12, 22),
			};
			Assert.Throws<ArgumentNullException> (() => dateTimes.Average ((Func<DateTime, int>)null));
			Assert.Throws<ArgumentNullException> (() => dateTimes.Average ((Func<DateTime, int?>)null));
			Assert.Throws<ArgumentNullException> (() => dateTimes.Average ((Func<DateTime, long>)null));
			Assert.Throws<ArgumentNullException> (() => dateTimes.Average ((Func<DateTime, long?>)null));
			Assert.Throws<ArgumentNullException> (() => dateTimes.Average ((Func<DateTime, float>)null));
			Assert.Throws<ArgumentNullException> (() => dateTimes.Average ((Func<DateTime, float?>)null));
			Assert.Throws<ArgumentNullException> (() => dateTimes.Average ((Func<DateTime, double>)null));
			Assert.Throws<ArgumentNullException> (() => dateTimes.Average ((Func<DateTime, double?>)null));
			Assert.Throws<ArgumentNullException> (() => dateTimes.Average ((Func<DateTime, decimal>)null));
			Assert.Throws<ArgumentNullException> (() => dateTimes.Average ((Func<DateTime, decimal?>)null));
		}

		[Test]
		public void TestEmptySequenceWithSelector ()
		{
			IEnumerable<int> emptyInts = new int[0];
			Assert.Throws <InvalidOperationException> (() => emptyInts.Average (it => (int)it));
			Assert.Throws <InvalidOperationException> (() => emptyInts.Average (it => (long)it));
			Assert.Throws <InvalidOperationException> (() => emptyInts.Average (it => (float)it));
			Assert.Throws <InvalidOperationException> (() => emptyInts.Average (it => (double)it));
			Assert.Throws <InvalidOperationException> (() => emptyInts.Average (it => (decimal)it));
			Assert.That (emptyInts.Average (it => (int?)it), Is.Null);
			Assert.That (emptyInts.Average (it => (long?)it), Is.Null);
			Assert.That (emptyInts.Average (it => (float?)it), Is.Null);
			Assert.That (emptyInts.Average (it => (double?)it), Is.Null);
			Assert.That (emptyInts.Average (it => (decimal?)it), Is.Null);

			IEnumerable<string> emptyStrings = new string[0];
			Assert.Throws <InvalidOperationException> (() => emptyStrings.Average (it => (int)it.Length));
			Assert.Throws <InvalidOperationException> (() => emptyStrings.Average (it => (long)it.Length));
			Assert.Throws <InvalidOperationException> (() => emptyStrings.Average (it => (float)it.Length));
			Assert.Throws <InvalidOperationException> (() => emptyStrings.Average (it => (double)it.Length));
			Assert.Throws <InvalidOperationException> (() => emptyStrings.Average (it => (decimal)it.Length));
			Assert.That (emptyStrings.Average (it => (int?)it.Length), Is.Null);
			Assert.That (emptyStrings.Average (it => (long?)it.Length), Is.Null);
			Assert.That (emptyStrings.Average (it => (float?)it.Length), Is.Null);
			Assert.That (emptyStrings.Average (it => (double?)it.Length), Is.Null);
			Assert.That (emptyStrings.Average (it => (decimal?)it.Length), Is.Null);
		}
		#endregion
	}
}
