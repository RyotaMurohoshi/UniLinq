using System;
using UniLinq;
using System.Collections.Generic;
using System.Threading;
using NUnit.Framework;

namespace UniLinqTest
{
	[TestFixture]
	[Category("UniLinqTests")]
	class MinTest
	{
		[Test]
		public void TestNormalSequence ()
		{
			Assert.That (new int[]{3, 1, 4, 1, 5, 9, 2}.Min (), Is.EqualTo (1));
			Assert.That (new int?[]{3, 1, 4, 1, 5, 9, 2}.Min (), Is.EqualTo (1));
			Assert.That (new long[]{3, 1, 4, 1, 5, 9, 2}.Min (), Is.EqualTo (1L));
			Assert.That (new long?[]{3, 1, 4, 1, 5, 9, 2}.Min (), Is.EqualTo (1L));
			Assert.That (new float[]{3.0F, 1.0F, 4.0F, 1.0F, 5.0F, 9.0F, 2.0F}.Min (), Is.EqualTo (1.0F));
			Assert.That (new float?[]{3.0F, 1.0F, 4.0F, 1.0F, 5.0F, 9.0F, 2.0F}.Min (), Is.EqualTo (1.0F));
			Assert.That (new double[]{3.0, 1.0, 4.0, 1.0, 5.0, 9.0, 2.0}.Min (), Is.EqualTo (1.0));
			Assert.That (new double?[]{3.0, 1.0, 4.0, 1.0, 5.0, 9.0, 2.0}.Min (), Is.EqualTo (1.0));
			Assert.That (new decimal[]{3.0M, 1.0M, 4.0M, 1.0M, 5.0M, 9.0M, 2.0M}.Min (), Is.EqualTo (1.0M));
			Assert.That (new decimal?[]{3.0M, 1.0M, 4.0M, 1.0M, 5.0M, 9.0M, 2.0M}.Min (), Is.EqualTo (1.0M));

			IEnumerable<string> strings = new string[] {
				"Cube",
				"Sphere",
				"Capsule",
				"Cylinder",
				"Plane",
				"Quad"
			};
			Assert.That (strings.Min (), Is.EqualTo ("Capsule"));

			IEnumerable<DateTime> dateTimes = new DateTime[]{
				new DateTime (2014, 3, 21),
				new DateTime (2014, 6, 21),
				new DateTime (2014, 9, 23),
				new DateTime (2014, 12, 22),
			};
			Assert.That (dateTimes.Min (), Is.EqualTo (new DateTime (2014, 3, 21)));
		}

		[Test]
		public void TestEmptySequence ()
		{
			Assert.Throws<InvalidOperationException> (() => new int[0].Min ());
			Assert.Throws<InvalidOperationException> (() => new long[0].Min ());
			Assert.Throws<InvalidOperationException> (() => new float[0].Min ());
			Assert.Throws<InvalidOperationException> (() => new double[0].Min ());
			Assert.Throws<InvalidOperationException> (() => new decimal[0].Min ());
			Assert.Throws<InvalidOperationException> (() => new DateTime[0].Min ());

			Assert.That (new string[0].Min (), Is.Null);

			Assert.That (new int?[0].Min (), Is.Null);
			Assert.That (new long?[0].Min (), Is.Null);
			Assert.That (new float?[0].Min (), Is.Null);
			Assert.That (new double?[0].Min (), Is.Null);
			Assert.That (new decimal?[0].Min (), Is.Null);
			Assert.That (new DateTime?[0].Min (), Is.Null);
		}

		[Test]
		public void TestNullOnlySequence ()
		{
			Assert.That (new string[]{ null }.Min (), Is.Null);

			Assert.That (new int?[]{ null }.Min (), Is.Null);
			Assert.That (new long?[]{ null }.Min (), Is.Null);
			Assert.That (new float?[]{ null }.Min (), Is.Null);
			Assert.That (new double?[]{ null }.Min (), Is.Null);
			Assert.That (new decimal?[]{ null }.Min (), Is.Null);
			Assert.That (new DateTime?[]{ null }.Min (), Is.Null);
		}

		[Test]
		public void TestNullMixedSequence ()
		{
			Assert.That (new int?[]{3, 1, 4, null, 1, 5, 9, 2, null}.Min (), Is.EqualTo (1));
			Assert.That (new long?[]{3, 1, 4, null, 1, 5, 9, 2, null}.Min (), Is.EqualTo (1L));
			Assert.That (new float?[]{3.0F, 1.0F, 4.0F, null, 1.0F, 5.0F, 9.0F, 2.0F, null }.Min (), Is.EqualTo (1.0F));
			Assert.That (new double?[]{3.0, 1.0, 4.0, null, 1.0, 5.0, 9.0, 2.0, null}.Min (), Is.EqualTo (1.0));
			Assert.That (new decimal?[]{3.0M, 1.0M, 4.0M, null, 1.0M, 5.0M, 9.0M, 2.0M, null }.Min (), Is.EqualTo (1.0M));

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
			Assert.That (strings.Min (), Is.EqualTo ("Capsule"));

			IEnumerable<DateTime?> dateTimes = new DateTime?[]{
				new DateTime (2014, 3, 21),
				new DateTime (2014, 6, 21),
				null,
				new DateTime (2014, 9, 23),
				new DateTime (2014, 12, 22),
				null,
			};
			Assert.That (dateTimes.Min (), Is.EqualTo (new DateTime (2014, 3, 21)));
		}

		[Test]
		public void TestNull ()
		{
			#pragma warning disable 1720
			Assert.Throws<ArgumentNullException> (() => ((int[])null).Min ());
			Assert.Throws<ArgumentNullException> (() => ((int?[])null).Min ());
			Assert.Throws<ArgumentNullException> (() => ((long[])null).Min ());
			Assert.Throws<ArgumentNullException> (() => ((long?[])null).Min ());
			Assert.Throws<ArgumentNullException> (() => ((float[])null).Min ());
			Assert.Throws<ArgumentNullException> (() => ((float?[])null).Min ());
			Assert.Throws<ArgumentNullException> (() => ((double[])null).Min ());
			Assert.Throws<ArgumentNullException> (() => ((double?[])null).Min ());
			Assert.Throws<ArgumentNullException> (() => ((decimal[])null).Min ());
			Assert.Throws<ArgumentNullException> (() => ((decimal?[])null).Min ());

			Assert.Throws<ArgumentNullException> (() => ((string[])null).Min ());
			Assert.Throws<ArgumentNullException> (() => ((DateTime?[])null).Min ());
			#pragma warning restore 1720
		}

		[Test]
		public void TestNumsWithSelector ()
		{
			IEnumerable<int> ints = new int[]{3, 1, 4, 1, 5, 9, 2};

			Assert.That (ints.Min (it => (int)it), Is.EqualTo (1));
			Assert.That (ints.Min (it => (int?)it), Is.EqualTo (1));
			Assert.That (ints.Min (it => (long)it), Is.EqualTo (1L));
			Assert.That (ints.Min (it => (long?)it), Is.EqualTo (1L));
			Assert.That (ints.Min (it => (float)it), Is.EqualTo (1.0F));
			Assert.That (ints.Min (it => (float?)it), Is.EqualTo (1.0F));
			Assert.That (ints.Min (it => (double)it), Is.EqualTo (1.0D));
			Assert.That (ints.Min (it => (double?)it), Is.EqualTo (1.0D));
			Assert.That (ints.Min (it => (decimal)it), Is.EqualTo (1.0M));
			Assert.That (ints.Min (it => (decimal?)it), Is.EqualTo (1.0M));

			IEnumerable<string> strings = new string[] {
				"Cube",
				"Sphere",
				"Capsule",
				"Cylinder",
				"Plane",
				"Quad"
			};

			Assert.That (strings.Min (it => (int)it.Length), Is.EqualTo (4));
			Assert.That (strings.Min (it => (int?)it.Length), Is.EqualTo (4));
			Assert.That (strings.Min (it => (long)it.Length), Is.EqualTo (4L));
			Assert.That (strings.Min (it => (long?)it.Length), Is.EqualTo (4L));
			Assert.That (strings.Min (it => (float)it.Length), Is.EqualTo (4.0F));
			Assert.That (strings.Min (it => (float?)it.Length), Is.EqualTo (4.0F));
			Assert.That (strings.Min (it => (double)it.Length), Is.EqualTo (4.0D));
			Assert.That (strings.Min (it => (double?)it.Length), Is.EqualTo (4.0D));
			Assert.That (strings.Min (it => (decimal)it.Length), Is.EqualTo (4.0M));
			Assert.That (strings.Min (it => (decimal?)it.Length), Is.EqualTo (4.0M));
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
			Assert.That (dateTimes.Min (it => it.ToString ()), Is.EqualTo ("03/21/2014 00:00:00"));

			// NonNullable -> NonNullable
			IEnumerable<long> dateTimeTics = dateTimes.Select (it => it.Ticks);
			Assert.That (dateTimeTics.Min (it => new DateTime (it)), Is.EqualTo (new DateTime(2014, 3, 21)));

			IEnumerable<string> strings = new string[] {
				"Cube",
				"Sphere",
				"Capsule",
				"Cylinder",
				"Plane",
				"Quad"
			};
			// Nullable -> NonNullable
			Assert.That (strings.Min (it => it.Length), Is.EqualTo (4));
			// Nullable -> Nullable
			Assert.That (strings.Min (it => it.ToUpper ()), Is.EqualTo ("CAPSULE"));
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
			Assert.Throws<ArgumentNullException> (() => strings.Min ((Func<string, int>)null));
			Assert.Throws<ArgumentNullException> (() => strings.Min ((Func<string, int?>)null));
			Assert.Throws<ArgumentNullException> (() => strings.Min ((Func<string, long>)null));
			Assert.Throws<ArgumentNullException> (() => strings.Min ((Func<string, long?>)null));
			Assert.Throws<ArgumentNullException> (() => strings.Min ((Func<string, float>)null));
			Assert.Throws<ArgumentNullException> (() => strings.Min ((Func<string, float?>)null));
			Assert.Throws<ArgumentNullException> (() => strings.Min ((Func<string, double>)null));
			Assert.Throws<ArgumentNullException> (() => strings.Min ((Func<string, double?>)null));
			Assert.Throws<ArgumentNullException> (() => strings.Min ((Func<string, decimal>)null));
			Assert.Throws<ArgumentNullException> (() => strings.Min ((Func<string, decimal?>)null));
			Assert.Throws<ArgumentNullException> (() => strings.Min ((Func<string, string>)null));
			Assert.Throws<ArgumentNullException> (() => strings.Min ((Func<string, DateTime>)null));

			IEnumerable<DateTime> dateTimes = new DateTime[]{
				new DateTime (2014, 3, 21),
				new DateTime (2014, 6, 21),
				new DateTime (2014, 9, 23),
				new DateTime (2014, 12, 22),
			};
			Assert.Throws<ArgumentNullException> (() => dateTimes.Min ((Func<DateTime, int>)null));
			Assert.Throws<ArgumentNullException> (() => dateTimes.Min ((Func<DateTime, int?>)null));
			Assert.Throws<ArgumentNullException> (() => dateTimes.Min ((Func<DateTime, long>)null));
			Assert.Throws<ArgumentNullException> (() => dateTimes.Min ((Func<DateTime, long?>)null));
			Assert.Throws<ArgumentNullException> (() => dateTimes.Min ((Func<DateTime, float>)null));
			Assert.Throws<ArgumentNullException> (() => dateTimes.Min ((Func<DateTime, float?>)null));
			Assert.Throws<ArgumentNullException> (() => dateTimes.Min ((Func<DateTime, double>)null));
			Assert.Throws<ArgumentNullException> (() => dateTimes.Min ((Func<DateTime, double?>)null));
			Assert.Throws<ArgumentNullException> (() => dateTimes.Min ((Func<DateTime, decimal>)null));
			Assert.Throws<ArgumentNullException> (() => dateTimes.Min ((Func<DateTime, decimal?>)null));
			Assert.Throws<ArgumentNullException> (() => dateTimes.Min ((Func<DateTime, string>)null));
			Assert.Throws<ArgumentNullException> (() => dateTimes.Min ((Func<DateTime, DateTime>)null));
		}

		[Test]
		public void TestEmptySequenceWithSelector ()
		{
			IEnumerable<int> emptyInts = new int[0];
			Assert.Throws<InvalidOperationException> (() => emptyInts.Min (it => (int)it));
			Assert.Throws<InvalidOperationException> (() => emptyInts.Min (it => (long)it));
			Assert.Throws<InvalidOperationException> (() => emptyInts.Min (it => (float)it));
			Assert.Throws<InvalidOperationException> (() => emptyInts.Min (it => (double)it));
			Assert.Throws<InvalidOperationException> (() => emptyInts.Min (it => (decimal)it));
			Assert.Throws<InvalidOperationException> (() => emptyInts.Min (it => new DateTime (it)));

			Assert.That (emptyInts.Min (it => (int?)it), Is.Null);
			Assert.That (emptyInts.Min (it => (long?)it), Is.Null);
			Assert.That (emptyInts.Min (it => (float?)it), Is.Null);
			Assert.That (emptyInts.Min (it => (double?)it), Is.Null);
			Assert.That (emptyInts.Min (it => (decimal?)it), Is.Null);

			IEnumerable<string> emptyStrings = new string[0];
			Assert.Throws<InvalidOperationException> (() => emptyStrings.Min (it => (int)it.Length));
			Assert.Throws<InvalidOperationException> (() => emptyStrings.Min (it => (long)it.Length));
			Assert.Throws<InvalidOperationException> (() => emptyStrings.Min (it => (float)it.Length));
			Assert.Throws<InvalidOperationException> (() => emptyStrings.Min (it => (double)it.Length));
			Assert.Throws<InvalidOperationException> (() => emptyStrings.Min (it => (decimal)it.Length));
			Assert.That (emptyStrings.Min (it => (int?)it.Length), Is.Null);
			Assert.That (emptyStrings.Min (it => (long?)it.Length), Is.Null);
			Assert.That (emptyStrings.Min (it => (float?)it.Length), Is.Null);
			Assert.That (emptyStrings.Min (it => (double?)it.Length), Is.Null);
			Assert.That (emptyStrings.Min (it => (decimal?)it.Length), Is.Null);
			Assert.That (emptyStrings.Min (it => it), Is.Null);
		}
	}
}
