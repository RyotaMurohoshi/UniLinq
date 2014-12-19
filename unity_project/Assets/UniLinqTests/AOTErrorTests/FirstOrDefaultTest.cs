using System;
using System.Collections.Generic;
using UniLinq;
using NUnit.Framework;

namespace UniLinqTest
{
	[TestFixture]
	[Category("UniLinqTests")]
	class FirstOrDefaultTest
	{
		#region source
		[Test]
		public void TestEmptySequence ()
		{
			Assert.That (new int[0].FirstOrDefault (), Is.EqualTo (default(int)));
			Assert.That (new string[0].FirstOrDefault (), Is.EqualTo (default(string)));
		}

		[Test]
		public void TestSingleElementSequence ()
		{
			Assert.That (new int[]{ 1 }.FirstOrDefault (), Is.EqualTo (1));
			Assert.That (new string[]{ "Cube" }.FirstOrDefault (), Is.EqualTo ("Cube"));
		}

		[Test]
		public void TestMultiElementsSequence ()
		{
			Assert.That (new int[]{ 1, 2, 3, 4, 5, 6, 7, 8 }.FirstOrDefault (), Is.EqualTo (1));
			Assert.That (new string[] {
				"Cube",
				"Sphere",
				"Capsule",
				"Cylinder",
				"Plane",
				"Quad"
			}.FirstOrDefault (), Is.EqualTo ("Cube"));
		}

		[Test]
		public void TestNullSequence ()
		{
			#pragma warning disable 1720
			Assert.Throws <ArgumentNullException> (() => ((int[])null).FirstOrDefault ());
			Assert.Throws <ArgumentNullException> (() => ((string[])null).FirstOrDefault ());
			#pragma warning restore 1720
		}
		#endregion

		#region source_predicate
		[Test]
		public void TestEmptySequenceWithPredicate ()
		{
			Assert.That (new int[0].FirstOrDefault (_ => true), Is.EqualTo (default(int)));
			Assert.That (new int[0].FirstOrDefault (_ => false), Is.EqualTo (default(int)));
			Assert.That (new string[0].FirstOrDefault (_ => true), Is.EqualTo (default(string)));
			Assert.That (new string[0].FirstOrDefault (_ => false), Is.EqualTo (default(string)));
		}

		[Test]
		public void TestSingleElementSequenceWithTruePredicate ()
		{
			Assert.That (new int[]{ 1 }.FirstOrDefault (x => true), Is.EqualTo (1));
			Assert.That (new string[]{ "Cube" }.FirstOrDefault (x => true), Is.EqualTo ("Cube"));
		}

		[Test]
		public void TestSingleElementSequenceWithFalsePredicate ()
		{
			Assert.That (new int[]{ 1 }.FirstOrDefault (_ => false), Is.EqualTo (default(int)));
			Assert.That (new string[]{ "Cube" }.FirstOrDefault (_ => false), Is.EqualTo (default(string)));
		}

		[Test]
		public void TestMultiElementsSequenceWithTruePredicate ()
		{
			Assert.That (new int[]{ 1, 2, 3, 4, 5, 6, 7, 8 }.FirstOrDefault (_ => true), Is.EqualTo (1));
			Assert.That (new string[] {
				"Cube",
				"Sphere",
				"Capsule",
				"Cylinder",
				"Plane",
				"Quad"
			}.FirstOrDefault (_ => true), Is.EqualTo ("Cube"));
		}

		[Test]
		public void TestMultiElementsSequenceWithFalsePredicate ()
		{
			Assert.That (new int[]{ 1, 2, 3, 4, 5, 6, 7, 8 }.FirstOrDefault (_ => false), Is.EqualTo (default(int)));
			Assert.That (new string[] {
				"Cube",
				"Sphere",
				"Capsule",
				"Cylinder",
				"Plane",
				"Quad"
			}.FirstOrDefault (_ => false), Is.EqualTo (default(string)));
		}

		[Test]
		public void TestWithPredicate ()
		{
			Assert.That (new int[]{ 1, 2, 3, 4, 5, 6, 7, 8 }.FirstOrDefault (x => x > 5), Is.EqualTo (6));
			Assert.That (new string[] {
				"Cube",
				"Sphere",
				"Capsule",
				"Cylinder",
				"Plane",
				"Quad"
			}.FirstOrDefault (str => str.Length > 5), Is.EqualTo ("Sphere"));

			Assert.That (new int[]{ 1, 2, 3, 4, 5, 6, 7, 8 }.FirstOrDefault (x => x > 10), Is.EqualTo (default(int)));
			Assert.That (
				new string[]{"Cube", "Sphere", "Capsule", "Cylinder", "Plane", "Quad"}.FirstOrDefault (str => str.Length > 10),
				Is.EqualTo (default(string)));
		}

		[Test]
		public void TestWithNullPredicate ()
		{
			Assert.Throws <ArgumentNullException> (() => new int[0].FirstOrDefault (null));
			Assert.Throws <ArgumentNullException> (() => new string[0].FirstOrDefault (null));
			Assert.Throws <ArgumentNullException> (() => new int[]{ 1 }.FirstOrDefault (null));
			Assert.Throws <ArgumentNullException> (() => new string[]{ "Cube" }.FirstOrDefault (null));
			Assert.Throws <ArgumentNullException> (() => new int[] {
				1,
				2,
				3,
				4,
				5,
				6,
				7,
				8
			}.FirstOrDefault (null));
			Assert.Throws <ArgumentNullException> (() => new string[] {
				"Cube",
				"Sphere",
				"Capsule",
				"Cylinder",
				"Plane",
				"Quad"
			}.FirstOrDefault (null));
		}

		[Test]
		public void TestNullSourceWithPredicate ()
		{
			#pragma warning disable 1720
			Assert.Throws <ArgumentNullException> (() => ((int[])null).FirstOrDefault (null));
			Assert.Throws <ArgumentNullException> (() => ((string[])null).FirstOrDefault (null));
			#pragma warning restore 1720
		}
		#endregion
	}
}
