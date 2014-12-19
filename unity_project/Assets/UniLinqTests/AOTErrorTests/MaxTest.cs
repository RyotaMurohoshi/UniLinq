using System;
using System.Collections.Generic;
using UniLinq;
using NUnit.Framework;

namespace UniLinqTest
{
	[TestFixture]
	[Category("UniLinqTests")]
	class MaxTest
	{
		[Test]
		public void TestNormalSequence ()
		{
			Assert.That (new int[]{3, 1, 4, 1, 5, 9, 2}.Max (), Is.EqualTo (9));
			Assert.That (new int?[]{3, 1, 4, 1, 5, 9, 2}.Max (), Is.EqualTo (9));
			Assert.That (new long[]{3, 1, 4, 1, 5, 9, 2}.Max (), Is.EqualTo (9L));
			Assert.That (new long?[]{3, 1, 4, 1, 5, 9, 2}.Max (), Is.EqualTo (9L));
			Assert.That (new float[]{3.0F, 1.0F, 4.0F, 1.0F, 5.0F, 9.0F, 2.0F}.Max (), Is.EqualTo (9.0F));
			Assert.That (new float?[]{3.0F, 1.0F, 4.0F, 1.0F, 5.0F, 9.0F, 2.0F}.Max (), Is.EqualTo (9.0F));
			Assert.That (new double[]{3.0, 1.0, 4.0, 1.0, 5.0, 9.0, 2.0}.Max (), Is.EqualTo (9.0));
			Assert.That (new double?[]{3.0, 1.0, 4.0, 1.0, 5.0, 9.0, 2.0}.Max (), Is.EqualTo (9.0));
			Assert.That (new decimal[]{3.0M, 1.0M, 4.0M, 1.0M, 5.0M, 9.0M, 2.0M}.Max (), Is.EqualTo (9.0M));
			Assert.That (new decimal?[]{3.0M, 1.0M, 4.0M, 1.0M, 5.0M, 9.0M, 2.0M}.Max (), Is.EqualTo (9.0M));

			IEnumerable<string> strings = new string[] {
				"Cube",
				"Sphere",
				"Capsule",
				"Cylinder",
				"Plane",
				"Quad"
			};
			Assert.That (strings.Max (), Is.EqualTo ("Sphere"));

			IEnumerable<DateTime> dateTimes = new DateTime[]{
				new DateTime (2014, 3, 21),
				new DateTime (2014, 6, 21),
				new DateTime (2014, 9, 23),
				new DateTime (2014, 12, 22),
			};
			Assert.That (dateTimes.Max (), Is.EqualTo (new DateTime (2014, 12, 22)));
		}

		[Test]
		public void TestEmptySequence ()
		{
			Assert.Throws<InvalidOperationException> (() => new int[0].Max ());
			Assert.Throws<InvalidOperationException> (() => new long[0].Max ());
			Assert.Throws<InvalidOperationException> (() => new float[0].Max ());
			Assert.Throws<InvalidOperationException> (() => new double[0].Max ());
			Assert.Throws<InvalidOperationException> (() => new decimal[0].Max ());
			Assert.Throws<InvalidOperationException> (() => new DateTime[0].Max ());

			Assert.That (new string[0].Max (), Is.Null);

			Assert.That (new int?[0].Max (), Is.Null);
			Assert.That (new long?[0].Max (), Is.Null);
			Assert.That (new float?[0].Max (), Is.Null);
			Assert.That (new double?[0].Max (), Is.Null);
			Assert.That (new decimal?[0].Max (), Is.Null);
			Assert.That (new DateTime?[0].Max (), Is.Null);
		}

		[Test]
		public void TestNullOnlySequence ()
		{
			Assert.That (new string[]{ null }.Max (), Is.Null);

			Assert.That (new int?[]{ null }.Max (), Is.Null);
			Assert.That (new long?[]{ null }.Max (), Is.Null);
			Assert.That (new float?[]{ null }.Max (), Is.Null);
			Assert.That (new double?[]{ null }.Max (), Is.Null);
			Assert.That (new decimal?[]{ null }.Max (), Is.Null);
			Assert.That (new DateTime?[]{ null }.Max (), Is.Null);
		}

		[Test]
		public void TestNullMixedSequence ()
		{
			Assert.That (new int?[]{3, 1, 4, null, 1, 5, 9, 2, null}.Max (), Is.EqualTo (9));
			Assert.That (new long?[]{3, 1, 4, null, 1, 5, 9, 2, null}.Max (), Is.EqualTo (9L));
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
			}.Max (), Is.EqualTo (9.0F));
			Assert.That (new double?[]{3.0, 1.0, 4.0, null, 1.0, 5.0, 9.0, 2.0, null}.Max (), Is.EqualTo (9.0));
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
			}.Max (), Is.EqualTo (9.0M));

			IEnumerable<string> strings = new string[] {
				"Cube",
				"Sphere",
				"Capsule",
				null,
				"Cylinder",
				"Plane",
				"Quad",
				null
			};
			Assert.That (strings.Max (), Is.EqualTo ("Sphere"));

			IEnumerable<DateTime?> dateTimes = new DateTime?[]{
				new DateTime (2014, 3, 21),
				new DateTime (2014, 6, 21),
				null,
				new DateTime (2014, 9, 23),
				new DateTime (2014, 12, 22),
				null,
			};
			Assert.That (dateTimes.Max (), Is.EqualTo (new DateTime (2014, 12, 22)));
		}

		[Test]
		public void TestNull ()
		{
			#pragma warning disable 1720
			Assert.Throws<ArgumentNullException> (() => ((int[])null).Max ());
			Assert.Throws<ArgumentNullException> (() => ((int?[])null).Max ());
			Assert.Throws<ArgumentNullException> (() => ((long[])null).Max ());
			Assert.Throws<ArgumentNullException> (() => ((long?[])null).Max ());
			Assert.Throws<ArgumentNullException> (() => ((float[])null).Max ());
			Assert.Throws<ArgumentNullException> (() => ((float?[])null).Max ());
			Assert.Throws<ArgumentNullException> (() => ((double[])null).Max ());
			Assert.Throws<ArgumentNullException> (() => ((double?[])null).Max ());
			Assert.Throws<ArgumentNullException> (() => ((decimal[])null).Max ());
			Assert.Throws<ArgumentNullException> (() => ((decimal?[])null).Max ());

			Assert.Throws<ArgumentNullException> (() => ((string[])null).Max ());
			Assert.Throws<ArgumentNullException> (() => ((DateTime?[])null).Max ());
			#pragma warning restore 1720
		}

		[Test]
		public void TestNumsWithSelector ()
		{
			IEnumerable<int> ints = new int[]{3, 1, 4, 1, 5, 9, 2};

			Assert.That (ints.Max (it => (int)it), Is.EqualTo (9));
			Assert.That (ints.Max (it => (int?)it), Is.EqualTo (9));
			Assert.That (ints.Max (it => (long)it), Is.EqualTo (9L));
			Assert.That (ints.Max (it => (long?)it), Is.EqualTo (9L));
			Assert.That (ints.Max (it => (float)it), Is.EqualTo (9.0F));
			Assert.That (ints.Max (it => (float?)it), Is.EqualTo (9.0F));
			Assert.That (ints.Max (it => (double)it), Is.EqualTo (9.0D));
			Assert.That (ints.Max (it => (double?)it), Is.EqualTo (9.0D));
			Assert.That (ints.Max (it => (decimal)it), Is.EqualTo (9.0M));
			Assert.That (ints.Max (it => (decimal?)it), Is.EqualTo (9.0M));

			IEnumerable<string> strings = new string[] {
				"Cube",
				"Sphere",
				"Capsule",
				"Cylinder",
				"Plane",
				"Quad"
			};

			Assert.That (strings.Max (it => (int)it.Length), Is.EqualTo (8));
			Assert.That (strings.Max (it => (int?)it.Length), Is.EqualTo (8));
			Assert.That (strings.Max (it => (long)it.Length), Is.EqualTo (8L));
			Assert.That (strings.Max (it => (long?)it.Length), Is.EqualTo (8L));
			Assert.That (strings.Max (it => (float)it.Length), Is.EqualTo (8.0F));
			Assert.That (strings.Max (it => (float?)it.Length), Is.EqualTo (8.0F));
			Assert.That (strings.Max (it => (double)it.Length), Is.EqualTo (8.0D));
			Assert.That (strings.Max (it => (double?)it.Length), Is.EqualTo (8.0D));
			Assert.That (strings.Max (it => (decimal)it.Length), Is.EqualTo (8.0M));
			Assert.That (strings.Max (it => (decimal?)it.Length), Is.EqualTo (8.0M));
		}

		[Test]
		public void TestTSourceWithSelector ()
		{
			// NonNullable -> Nullable
			IEnumerable<DateTime> dateTimes = new DateTime[]{
				new DateTime (2014, 3, 21),
				new DateTime (2014, 6, 21),
				new DateTime (2014, 9, 23),
				new DateTime (2014, 12, 22),
			};
			Assert.That (dateTimes.Max (it => it.ToString ()), Is.EqualTo ("12/22/2014 00:00:00"));

			// NonNullable -> NonNullable
			IEnumerable<long> dateTimeTics = dateTimes.Select (it => it.Ticks);
			Assert.That (dateTimeTics.Max (it => new DateTime (it)), Is.EqualTo (new DateTime (2014, 12, 22)));

			IEnumerable<string> strings = new string[] {
				"Cube",
				"Sphere",
				"Capsule",
				"Cylinder",
				"Plane",
				"Quad"
			};
			// Nullable -> NonNullable
			Assert.That (strings.Max (it => it.Length), Is.EqualTo (8));
			// Nullable -> Nullable
			Assert.That (strings.Max (it => it.ToUpper ()), Is.EqualTo ("SPHERE"));
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
			Assert.Throws<ArgumentNullException> (() => strings.Max ((Func<string, int>)null));
			Assert.Throws<ArgumentNullException> (() => strings.Max ((Func<string, int?>)null));
			Assert.Throws<ArgumentNullException> (() => strings.Max ((Func<string, long>)null));
			Assert.Throws<ArgumentNullException> (() => strings.Max ((Func<string, long?>)null));
			Assert.Throws<ArgumentNullException> (() => strings.Max ((Func<string, float>)null));
			Assert.Throws<ArgumentNullException> (() => strings.Max ((Func<string, float?>)null));
			Assert.Throws<ArgumentNullException> (() => strings.Max ((Func<string, double>)null));
			Assert.Throws<ArgumentNullException> (() => strings.Max ((Func<string, double?>)null));
			Assert.Throws<ArgumentNullException> (() => strings.Max ((Func<string, decimal>)null));
			Assert.Throws<ArgumentNullException> (() => strings.Max ((Func<string, decimal?>)null));
			Assert.Throws<ArgumentNullException> (() => strings.Max ((Func<string, string>)null));
			Assert.Throws<ArgumentNullException> (() => strings.Max ((Func<string, DateTime>)null));

			IEnumerable<DateTime> dateTimes = new DateTime[]{
				new DateTime (2014, 3, 21),
				new DateTime (2014, 6, 21),
				new DateTime (2014, 9, 23),
				new DateTime (2014, 12, 22),
			};
			Assert.Throws<ArgumentNullException> (() => dateTimes.Max ((Func<DateTime, int>)null));
			Assert.Throws<ArgumentNullException> (() => dateTimes.Max ((Func<DateTime, int?>)null));
			Assert.Throws<ArgumentNullException> (() => dateTimes.Max ((Func<DateTime, long>)null));
			Assert.Throws<ArgumentNullException> (() => dateTimes.Max ((Func<DateTime, long?>)null));
			Assert.Throws<ArgumentNullException> (() => dateTimes.Max ((Func<DateTime, float>)null));
			Assert.Throws<ArgumentNullException> (() => dateTimes.Max ((Func<DateTime, float?>)null));
			Assert.Throws<ArgumentNullException> (() => dateTimes.Max ((Func<DateTime, double>)null));
			Assert.Throws<ArgumentNullException> (() => dateTimes.Max ((Func<DateTime, double?>)null));
			Assert.Throws<ArgumentNullException> (() => dateTimes.Max ((Func<DateTime, decimal>)null));
			Assert.Throws<ArgumentNullException> (() => dateTimes.Max ((Func<DateTime, decimal?>)null));
			Assert.Throws<ArgumentNullException> (() => dateTimes.Max ((Func<DateTime, string>)null));
			Assert.Throws<ArgumentNullException> (() => dateTimes.Max ((Func<DateTime, DateTime>)null));
		}

		[Test]
		public void TestEmptySequenceWithSelector ()
		{
			IEnumerable<int> emptyInts = new int[0];
			Assert.Throws<InvalidOperationException> (() => emptyInts.Max (it => (int)it));
			Assert.Throws<InvalidOperationException> (() => emptyInts.Max (it => (long)it));
			Assert.Throws<InvalidOperationException> (() => emptyInts.Max (it => (float)it));
			Assert.Throws<InvalidOperationException> (() => emptyInts.Max (it => (double)it));
			Assert.Throws<InvalidOperationException> (() => emptyInts.Max (it => (decimal)it));
			Assert.Throws<InvalidOperationException> (() => emptyInts.Max (it => new DateTime (it)));

			Assert.That (emptyInts.Max (it => (int?)it), Is.Null);
			Assert.That (emptyInts.Max (it => (long?)it), Is.Null);
			Assert.That (emptyInts.Max (it => (float?)it), Is.Null);
			Assert.That (emptyInts.Max (it => (double?)it), Is.Null);
			Assert.That (emptyInts.Max (it => (decimal?)it), Is.Null);

			IEnumerable<string> emptyStrings = new string[0];
			Assert.Throws<InvalidOperationException> (() => emptyStrings.Max (it => (int)it.Length));
			Assert.Throws<InvalidOperationException> (() => emptyStrings.Max (it => (long)it.Length));
			Assert.Throws<InvalidOperationException> (() => emptyStrings.Max (it => (float)it.Length));
			Assert.Throws<InvalidOperationException> (() => emptyStrings.Max (it => (double)it.Length));
			Assert.Throws<InvalidOperationException> (() => emptyStrings.Max (it => (decimal)it.Length));
			Assert.That (emptyStrings.Max (it => (int?)it.Length), Is.Null);
			Assert.That (emptyStrings.Max (it => (long?)it.Length), Is.Null);
			Assert.That (emptyStrings.Max (it => (float?)it.Length), Is.Null);
			Assert.That (emptyStrings.Max (it => (double?)it.Length), Is.Null);
			Assert.That (emptyStrings.Max (it => (decimal?)it.Length), Is.Null);
			Assert.That (emptyStrings.Max (it => it), Is.Null);
		}
	}
}
