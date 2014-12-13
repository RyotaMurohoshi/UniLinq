using System;
using System.Collections.Generic;
using UniLinq;
using NUnit.Framework;

namespace UniLinqTest
{
	[TestFixture]
	[Category("UniLinqTests")]
	class SumTest
	{
		[Test]
		public void TestNormalSequence ()
		{
			Assert.That (new int[]{3, 1, 4, 1, 5, 9, 2}.Sum (), Is.EqualTo (25));
			Assert.That (new int?[]{3, 1, 4, 1, 5, 9, 2}.Sum (), Is.EqualTo (25));
			Assert.That (new long[]{3, 1, 4, 1, 5, 9, 2}.Sum (), Is.EqualTo (25L));
			Assert.That (new long?[]{3, 1, 4, 1, 5, 9, 2}.Sum (), Is.EqualTo (25L));
			Assert.That (new float[]{3.0F, 1.0F, 4.0F, 1.0F, 5.0F, 9.0F, 2.0F}.Sum (), Is.EqualTo (25.0F));
			Assert.That (new float?[]{3.0F, 1.0F, 4.0F, 1.0F, 5.0F, 9.0F, 2.0F}.Sum (), Is.EqualTo (25.0F));
			Assert.That (new double[]{3.0, 1.0, 4.0, 1.0, 5.0, 9.0, 2.0}.Sum (), Is.EqualTo (25.0));
			Assert.That (new double?[]{3.0, 1.0, 4.0, 1.0, 5.0, 9.0, 2.0}.Sum (), Is.EqualTo (25.0));
			Assert.That (new decimal[]{3.0M, 1.0M, 4.0M, 1.0M, 5.0M, 9.0M, 2.0M}.Sum (), Is.EqualTo (25.0M));
			Assert.That (new decimal?[]{3.0M, 1.0M, 4.0M, 1.0M, 5.0M, 9.0M, 2.0M}.Sum (), Is.EqualTo (25.0M));
		}

		[Test]
		public void TestEmptySequence ()
		{
			Assert.That (new int[0].Sum (), Is.EqualTo (0));
			Assert.That (new long[0].Sum (), Is.EqualTo (0L));
			Assert.That (new float[0].Sum (), Is.EqualTo (0.0F));
			Assert.That (new double[0].Sum (), Is.EqualTo (0.0));
			Assert.That (new decimal[0].Sum (), Is.EqualTo (0M));

			Assert.That (new int?[0].Sum (), Is.EqualTo (0));
			Assert.That (new long?[0].Sum (), Is.EqualTo (0L));
			Assert.That (new float?[0].Sum (), Is.EqualTo (0.0F));
			Assert.That (new double?[0].Sum (), Is.EqualTo (0.0));
			Assert.That (new decimal?[0].Sum (), Is.EqualTo (0M));
		}

		[Test]
		public void TestNullOnlySequence ()
		{
			Assert.That (new int?[]{ null }.Sum (), Is.EqualTo (0));
			Assert.That (new long?[]{ null }.Sum (), Is.EqualTo (0L));
			Assert.That (new float?[]{ null }.Sum (), Is.EqualTo (0.0F));
			Assert.That (new double?[]{ null }.Sum (), Is.EqualTo (0.0));
			Assert.That (new decimal?[]{ null }.Sum (), Is.EqualTo (0M));
		}

		[Test]
		public void TestNullMixedSequence ()
		{
			Assert.That (new int?[]{3, 1, 4, null, 1, 5, 9, 2, null}.Sum (), Is.EqualTo (25));
			Assert.That (new long?[]{3, 1, 4, null, 1, 5, 9, 2, null}.Sum (), Is.EqualTo (25L));
			Assert.That (new float?[] {
				3.0F,
				1.0F,
				4.0F,
				null,
				1.0F,
				5.0F,
				9.0F,
				2.0F,
				null
			}.Sum (), Is.EqualTo (25.0F));
			Assert.That (new double?[]{3.0, 1.0, 4.0, null, 1.0, 5.0, 9.0, 2.0, null}.Sum (), Is.EqualTo (25.0));
			Assert.That (new decimal?[] {
				3.0M,
				1.0M,
				4.0M,
				null,
				1.0M,
				5.0M,
				9.0M,
				2.0M,
				null
			}.Sum (), Is.EqualTo (25.0M));
		}

		[Test]
		public void TestNull ()
		{
			#pragma warning disable 1720
			Assert.Throws<ArgumentNullException> (() => ((int[])null).Sum ());
			Assert.Throws<ArgumentNullException> (() => ((int?[])null).Sum ());
			Assert.Throws<ArgumentNullException> (() => ((long[])null).Sum ());
			Assert.Throws<ArgumentNullException> (() => ((long?[])null).Sum ());
			Assert.Throws<ArgumentNullException> (() => ((float[])null).Sum ());
			Assert.Throws<ArgumentNullException> (() => ((float?[])null).Sum ());
			Assert.Throws<ArgumentNullException> (() => ((double[])null).Sum ());
			Assert.Throws<ArgumentNullException> (() => ((double?[])null).Sum ());
			Assert.Throws<ArgumentNullException> (() => ((decimal[])null).Sum ());
			Assert.Throws<ArgumentNullException> (() => ((decimal?[])null).Sum ());
			#pragma warning restore 1720
		}

		[Test]
		public void TestNumsWithSelector ()
		{
			IEnumerable<int> ints = new int[]{3, 1, 4, 1, 5, 9, 2};

			Assert.That (ints.Sum (it => (int)it), Is.EqualTo (25));
			Assert.That (ints.Sum (it => (int?)it), Is.EqualTo (25));
			Assert.That (ints.Sum (it => (long)it), Is.EqualTo (25L));
			Assert.That (ints.Sum (it => (long?)it), Is.EqualTo (25L));
			Assert.That (ints.Sum (it => (float)it), Is.EqualTo (25.0F));
			Assert.That (ints.Sum (it => (float?)it), Is.EqualTo (25.0F));
			Assert.That (ints.Sum (it => (double)it), Is.EqualTo (25.0D));
			Assert.That (ints.Sum (it => (double?)it), Is.EqualTo (25.0D));
			Assert.That (ints.Sum (it => (decimal)it), Is.EqualTo (25.0M));
			Assert.That (ints.Sum (it => (decimal?)it), Is.EqualTo (25.0M));

			IEnumerable<string> strings = new string[] {
				"Cube",
				"Sphere",
				"Capsule",
				"Cylinder",
				"Plane",
				"Quad"
			};

			Assert.That (strings.Sum (it => (int)it.Length), Is.EqualTo (34));
			Assert.That (strings.Sum (it => (int?)it.Length), Is.EqualTo (34));
			Assert.That (strings.Sum (it => (long)it.Length), Is.EqualTo (34L));
			Assert.That (strings.Sum (it => (long?)it.Length), Is.EqualTo (34L));
			Assert.That (strings.Sum (it => (float)it.Length), Is.EqualTo (34.0F));
			Assert.That (strings.Sum (it => (float?)it.Length), Is.EqualTo (34.0F));
			Assert.That (strings.Sum (it => (double)it.Length), Is.EqualTo (34.0D));
			Assert.That (strings.Sum (it => (double?)it.Length), Is.EqualTo (34.0D));
			Assert.That (strings.Sum (it => (decimal)it.Length), Is.EqualTo (34.0M));
			Assert.That (strings.Sum (it => (decimal?)it.Length), Is.EqualTo (34.0M));
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
			Assert.Throws<ArgumentNullException> (() => strings.Sum ((Func<string, int>)null));
			Assert.Throws<ArgumentNullException> (() => strings.Sum ((Func<string, int?>)null));
			Assert.Throws<ArgumentNullException> (() => strings.Sum ((Func<string, long>)null));
			Assert.Throws<ArgumentNullException> (() => strings.Sum ((Func<string, long?>)null));
			Assert.Throws<ArgumentNullException> (() => strings.Sum ((Func<string, float>)null));
			Assert.Throws<ArgumentNullException> (() => strings.Sum ((Func<string, float?>)null));
			Assert.Throws<ArgumentNullException> (() => strings.Sum ((Func<string, double>)null));
			Assert.Throws<ArgumentNullException> (() => strings.Sum ((Func<string, double?>)null));
			Assert.Throws<ArgumentNullException> (() => strings.Sum ((Func<string, decimal>)null));
			Assert.Throws<ArgumentNullException> (() => strings.Sum ((Func<string, decimal?>)null));

			IEnumerable<DateTime> dateTimes = new DateTime[]{
				new DateTime (2014, 3, 21),
				new DateTime (2014, 6, 21),
				new DateTime (2014, 9, 23),
				new DateTime (2014, 12, 22),
			};
			Assert.Throws<ArgumentNullException> (() => dateTimes.Sum ((Func<DateTime, int>)null));
			Assert.Throws<ArgumentNullException> (() => dateTimes.Sum ((Func<DateTime, int?>)null));
			Assert.Throws<ArgumentNullException> (() => dateTimes.Sum ((Func<DateTime, long>)null));
			Assert.Throws<ArgumentNullException> (() => dateTimes.Sum ((Func<DateTime, long?>)null));
			Assert.Throws<ArgumentNullException> (() => dateTimes.Sum ((Func<DateTime, float>)null));
			Assert.Throws<ArgumentNullException> (() => dateTimes.Sum ((Func<DateTime, float?>)null));
			Assert.Throws<ArgumentNullException> (() => dateTimes.Sum ((Func<DateTime, double>)null));
			Assert.Throws<ArgumentNullException> (() => dateTimes.Sum ((Func<DateTime, double?>)null));
			Assert.Throws<ArgumentNullException> (() => dateTimes.Sum ((Func<DateTime, decimal>)null));
			Assert.Throws<ArgumentNullException> (() => dateTimes.Sum ((Func<DateTime, decimal?>)null));
		}

		[Test]
		public void TestEmptySequenceWithSelector ()
		{
			IEnumerable<int> emptyInts = new int[0];
			Assert.That (emptyInts.Sum (it => (int)it), Is.EqualTo (0));
			Assert.That (emptyInts.Sum (it => (int?)it), Is.EqualTo (0));
			Assert.That (emptyInts.Sum (it => (long)it), Is.EqualTo (0L));
			Assert.That (emptyInts.Sum (it => (long?)it), Is.EqualTo (0L));
			Assert.That (emptyInts.Sum (it => (float)it), Is.EqualTo (0.0F));
			Assert.That (emptyInts.Sum (it => (float?)it), Is.EqualTo (0.0F));
			Assert.That (emptyInts.Sum (it => (double)it), Is.EqualTo (0.0));
			Assert.That (emptyInts.Sum (it => (double?)it), Is.EqualTo (0.0));
			Assert.That (emptyInts.Sum (it => (decimal)it), Is.EqualTo (0.0M));
			Assert.That (emptyInts.Sum (it => (decimal?)it), Is.EqualTo (0.0M));

			IEnumerable<string> emptyStrings = new string[0];
			Assert.That (emptyStrings.Sum (it => (int)it.Length), Is.EqualTo (0));
			Assert.That (emptyStrings.Sum (it => (int?)it.Length), Is.EqualTo (0));
			Assert.That (emptyStrings.Sum (it => (long)it.Length), Is.EqualTo (0L));
			Assert.That (emptyStrings.Sum (it => (long?)it.Length), Is.EqualTo (0L));
			Assert.That (emptyStrings.Sum (it => (float)it.Length), Is.EqualTo (0.0F));
			Assert.That (emptyStrings.Sum (it => (float?)it.Length), Is.EqualTo (0.0F));
			Assert.That (emptyStrings.Sum (it => (double)it.Length), Is.EqualTo (0.0));
			Assert.That (emptyStrings.Sum (it => (double?)it.Length), Is.EqualTo (0.0));
			Assert.That (emptyStrings.Sum (it => (decimal)it.Length), Is.EqualTo (0.0M));
			Assert.That (emptyStrings.Sum (it => (decimal?)it.Length), Is.EqualTo (0.0M));
		}
	}
}
