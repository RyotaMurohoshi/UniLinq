using System;
using System.Collections.Generic;
using UniLinq;
using NUnit.Framework;

namespace UniLinqTest
{
	[TestFixture]
	[Category("UniLinqTests")]
	class SingleOrDefaultTest
	{
		#region source
		[Test]
		public void TestEmptySequence ()
		{
			Assert.That (new int[0].SingleOrDefault (), Is.EqualTo (default(int)));
			Assert.That (new string[0].SingleOrDefault (), Is.EqualTo (default(string)));
		}

		[Test]
		public void TestSingleElementSequence ()
		{
			Assert.That (new int[]{ 1 }.SingleOrDefault (), Is.EqualTo (1));
			Assert.That (new string[]{ "Cube" }.SingleOrDefault (), Is.EqualTo ("Cube"));
		}

		[Test]
		public void TestMultiElementsSequence ()
		{
			Assert.Throws <InvalidOperationException> (() => new int[] {
				1,
				2,
				3,
				4,
				5,
				6,
				7,
				8
			}.SingleOrDefault ());
			Assert.Throws <InvalidOperationException> (() => new string[] {
				"Cube",
				"Sphere",
				"Capsule",
				"Cylinder",
				"Plane",
				"Quad"
			}.SingleOrDefault ());
		}

		[Test]
		public void TestNullSequence ()
		{
			#pragma warning disable 1720
			Assert.Throws <ArgumentNullException> (() => ((int[])null).SingleOrDefault ());
			Assert.Throws <ArgumentNullException> (() => ((string[])null).SingleOrDefault ());
			#pragma warning restore 1720
		}
		#endregion

		#region source_predicate
		[Test]
		public void TestEmptySequenceWithPredicate ()
		{
			Assert.That (new int[0].SingleOrDefault (_ => true), Is.EqualTo (default(int)));
			Assert.That (new int[0].SingleOrDefault (_ => false), Is.EqualTo (default(int)));
			Assert.That (new string[0].SingleOrDefault (_ => true), Is.EqualTo (default(string)));
			Assert.That (new string[0].SingleOrDefault (_ => false), Is.EqualTo (default(string)));
		}

		[Test]
		public void TestSingleElementSequenceWithTruePredicate ()
		{
			Assert.That (new int[]{ 1 }.SingleOrDefault (x => true), Is.EqualTo (1));
			Assert.That (new string[]{ "Cube" }.SingleOrDefault (x => true), Is.EqualTo ("Cube"));
		}

		[Test]
		public void TestSingleElementSequenceWithFalsePredicate ()
		{
			Assert.That (new int[]{ 1 }.SingleOrDefault (x => false), Is.EqualTo (default(int)));
			Assert.That (new string[]{ "Cube" }.SingleOrDefault (x => false), Is.EqualTo (default(string)));
		}

		[Test]
		public void TestMultiElementsSequenceWithTruePredicate ()
		{
			Assert.Throws <InvalidOperationException> (
				() => new int[]{ 1, 2, 3, 4, 5, 6, 7, 8 }.SingleOrDefault (_ => true));
			Assert.Throws <InvalidOperationException> (
				() => new string[] {
				"Cube",
				"Sphere",
				"Capsule",
				"Cylinder",
				"Plane",
				"Quad"
			}.SingleOrDefault (_ => true)
			);
		}

		[Test]
		public void TestMultiElementsSequenceWithFalsePredicate ()
		{
			Assert.That (
				new int[]{ 1, 2, 3, 4, 5, 6, 7, 8 }.SingleOrDefault (_ => false),
				Is.EqualTo (default(int)));
			Assert.That (
				new string[]{"Cube", "Sphere", "Capsule", "Cylinder", "Plane", "Quad"}.SingleOrDefault (_ => false),
				Is.EqualTo (default(string))
			);
		}

		[Test]
		public void TestWithPredicate ()
		{
			Assert.That (
				new string[]{"Cube", "Sphere", "Capsule", "Cylinder", "Plane", "Quad"}.SingleOrDefault (str => str.Length >= 8),
				Is.EqualTo ("Cylinder"));

			Assert.That (
				new int[]{ 1, 2, 3, 4, 5, 6, 7, 8 }.SingleOrDefault (x => x >= 8),
				Is.EqualTo (8));

			Assert.Throws <InvalidOperationException> (
				() => new int[]{ 1, 2, 3, 4, 5, 6, 7, 8 }.SingleOrDefault (x => x > 5)
			);
			Assert.Throws <InvalidOperationException> (
				() => new string[] {
				"Cube",
				"Sphere",
				"Capsule",
				"Cylinder",
				"Plane",
				"Quad"
			}.SingleOrDefault (str => str.Length > 5)
			);

			Assert.That (
				new int[]{ 1, 2, 3, 4, 5, 6, 7, 8 }.SingleOrDefault (x => x > 10),
				Is.EqualTo (default(int)));
			Assert.That (
				new string[]{"Cube", "Sphere", "Capsule", "Cylinder", "Plane", "Quad"}.SingleOrDefault (str => str.Length > 10),
				Is.EqualTo (default(string)));
		}

		[Test]
		public void TestWithNullPredicate ()
		{
			Assert.Throws <ArgumentNullException> (() => new int[0].SingleOrDefault (null));
			Assert.Throws <ArgumentNullException> (() => new string[0].SingleOrDefault (null));
			Assert.Throws <ArgumentNullException> (() => new int[]{ 1 }.SingleOrDefault (null));
			Assert.Throws <ArgumentNullException> (() => new string[]{ "Cube" }.SingleOrDefault (null));
			Assert.Throws <ArgumentNullException> (() => new int[] {
				1,
				2,
				3,
				4,
				5,
				6,
				7,
				8
			}.SingleOrDefault (null));
			Assert.Throws <ArgumentNullException> (() => new string[] {
				"Cube",
				"Sphere",
				"Capsule",
				"Cylinder",
				"Plane",
				"Quad"
			}.SingleOrDefault (null));
		}

		[Test]
		public void TestNullSourceWithPredicate ()
		{
			#pragma warning disable 1720
			Assert.Throws <ArgumentNullException> (() => ((int[])null).SingleOrDefault (null));
			Assert.Throws <ArgumentNullException> (() => ((string[])null).SingleOrDefault (null));
			#pragma warning restore 1720
		}
		#endregion
	}
}
