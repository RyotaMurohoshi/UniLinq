using System;
using System.Collections.Generic;
using UniLinq;
using NUnit.Framework;

namespace UniLinqTest
{
	[TestFixture]
	[Category("UniLinqTests")]
	class LastOrDefaultTest
	{
		#region source
		[Test]
		public void TestEmptySequence ()
		{
			Assert.That (new int[0].LastOrDefault (), Is.EqualTo (default(int)));
			Assert.That (new string[0].LastOrDefault (), Is.EqualTo (default(string)));
		}

		[Test]
		public void TestSingleElementSequence ()
		{
			Assert.That (new int[]{ 1 }.LastOrDefault (), Is.EqualTo (1));
			Assert.That (new string[]{ "Cube" }.LastOrDefault (), Is.EqualTo ("Cube"));
		}

		[Test]
		public void TestMultiElementsSequence ()
		{
			Assert.That (new int[]{ 1, 2, 3, 4, 5, 6, 7, 8 }.LastOrDefault (), Is.EqualTo (8));
			Assert.That (new string[] {
				"Cube",
				"Sphere",
				"Capsule",
				"Cylinder",
				"Plane",
				"Quad"
			}.LastOrDefault (), Is.EqualTo ("Quad"));
		}

		[Test]
		public void TestNullSequence ()
		{
			#pragma warning disable 1720
			Assert.Throws <ArgumentNullException> (() => ((int[])null).Last ());
			Assert.Throws <ArgumentNullException> (() => ((string[])null).Last ());
			#pragma warning restore 1720
		}
		#endregion

		#region source_predicate
		[Test]
		public void TestEmptySequenceWithPredicate ()
		{
			Assert.That (new int[0].LastOrDefault (_ => true), Is.EqualTo (default(int)));
			Assert.That (new int[0].LastOrDefault (_ => false), Is.EqualTo (default(int)));
			Assert.That (new string[0].LastOrDefault (_ => true), Is.EqualTo (default(string)));
			Assert.That (new string[0].LastOrDefault (_ => false), Is.EqualTo (default(string)));
		}

		[Test]
		public void TestSingleElementSequenceWithTruePredicate ()
		{
			Assert.That (new int[]{ 1 }.LastOrDefault (x => true), Is.EqualTo (1));
			Assert.That (new string[]{ "Cube" }.LastOrDefault (x => true), Is.EqualTo ("Cube"));
		}

		[Test]
		public void TestSingleElementSequenceWithFalsePredicate ()
		{
			Assert.That (new int[]{ 1 }.LastOrDefault (_ => false), Is.EqualTo (default(int)));
			Assert.That (new string[]{ "Cube" }.LastOrDefault (_ => false), Is.EqualTo (default(string)));
		}

		[Test]
		public void TestMultiElementsSequenceWithTruePredicate ()
		{
			Assert.That (new int[]{ 1, 2, 3, 4, 5, 6, 7, 8 }.LastOrDefault (_ => true), Is.EqualTo (8));
			Assert.That (new string[] {
				"Cube",
				"Sphere",
				"Capsule",
				"Cylinder",
				"Plane",
				"Quad"
			}.LastOrDefault (_ => true), Is.EqualTo ("Quad"));
		}

		[Test]
		public void TestMultiElementsSequenceWithFalsePredicate ()
		{
			Assert.That (new int[]{ 1, 2, 3, 4, 5, 6, 7, 8 }.LastOrDefault (_ => false), Is.EqualTo (default(int)));
			Assert.That (new string[] {
				"Cube",
				"Sphere",
				"Capsule",
				"Cylinder",
				"Plane",
				"Quad"
			}.LastOrDefault (_ => false), Is.EqualTo (default(string)));
		}

		[Test]
		public void TestWithPredicate ()
		{
			Assert.That (new int[]{ 1, 2, 3, 4, 5, 6, 7, 8 }.LastOrDefault (x => x > 5), Is.EqualTo (8));
			Assert.That (new string[] {
				"Cube",
				"Sphere",
				"Capsule",
				"Cylinder",
				"Plane",
				"Quad"
			}.LastOrDefault (str => str.Length > 5), Is.EqualTo ("Cylinder"));

			Assert.That (new int[]{ 1, 2, 3, 4, 5, 6, 7, 8 }.LastOrDefault (x => x > 10), Is.EqualTo (default(int)));
			Assert.That (
				new string[]{"Cube", "Sphere", "Capsule", "Cylinder", "Plane", "Quad"}.LastOrDefault (str => str.Length > 10),
			Is.EqualTo (default(string)));
		}

		[Test]
		public void TestWithNullPredicate ()
		{
			Assert.Throws <ArgumentNullException> (() => new int[0].LastOrDefault (null));
			Assert.Throws <ArgumentNullException> (() => new string[0].LastOrDefault (null));
			Assert.Throws <ArgumentNullException> (() => new int[]{ 1 }.LastOrDefault (null));
			Assert.Throws <ArgumentNullException> (() => new string[]{ "Cube" }.LastOrDefault (null));
			Assert.Throws <ArgumentNullException> (() => new int[] {
				1,
				2,
				3,
				4,
				5,
				6,
				7,
				8
			}.LastOrDefault (null));
			Assert.Throws <ArgumentNullException> (() => new string[] {
				"Cube",
				"Sphere",
				"Capsule",
				"Cylinder",
				"Plane",
				"Quad"
			}.LastOrDefault (null));
		}

		[Test]
		public void TestNullSourceWithPredicate ()
		{
			#pragma warning disable 1720
			Assert.Throws <ArgumentNullException> (() => ((int[])null).LastOrDefault (null));
			Assert.Throws <ArgumentNullException> (() => ((string[])null).LastOrDefault (null));
			#pragma warning restore 1720
		}
		#endregion
	}
}
