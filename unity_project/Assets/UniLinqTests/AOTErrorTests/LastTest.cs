using System;
using System.Collections.Generic;
using UniLinq;
using NUnit.Framework;

namespace UniLinqTest
{
	[TestFixture]
	[Category("UniLinqTests")]
	class LastTest
	{
		#region source
		[Test]
		public void TestEmptySequence ()
		{
			Assert.Throws <InvalidOperationException> (() => new int[0].Last ());
			Assert.Throws <InvalidOperationException> (() => new string[0].Last ());
		}

		[Test]
		public void TestSingleElementSequence ()
		{
			Assert.That (new int[]{ 1 }.Last (), Is.EqualTo (1));
			Assert.That (new string[]{ "Cube" }.Last (), Is.EqualTo ("Cube"));
		}

		[Test]
		public void TestMultiElementsSequence ()
		{
			Assert.That (new int[]{ 1, 2, 3, 4, 5, 6, 7, 8 }.Last (), Is.EqualTo (8));
			Assert.That (new string[] {
				"Cube",
				"Sphere",
				"Capsule",
				"Cylinder",
				"Plane",
				"Quad"
			}.Last (), Is.EqualTo ("Quad"));
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
			Assert.Throws <InvalidOperationException> (() => new int[0].Last (_ => true));
			Assert.Throws <InvalidOperationException> (() => new int[0].Last (_ => false));
			Assert.Throws <InvalidOperationException> (() => new string[0].Last (_ => true));
			Assert.Throws <InvalidOperationException> (() => new string[0].Last (_ => false));
		}

		[Test]
		public void TestSingleElementSequenceWithTruePredicate ()
		{
			Assert.That (new int[]{ 1 }.Last (x => true), Is.EqualTo (1));
			Assert.That (new string[]{ "Cube" }.Last (x => true), Is.EqualTo ("Cube"));
		}

		[Test]
		public void TestSingleElementSequenceWithFalsePredicate ()
		{
			Assert.Throws <InvalidOperationException> (() => new int[]{ 1 }.Last (_ => false));
			Assert.Throws <InvalidOperationException> (() => new string[]{ "Cube" }.Last (_ => false));
		}

		[Test]
		public void TestMultiElementsSequenceWithTruePredicate ()
		{
			Assert.That (new int[]{ 1, 2, 3, 4, 5, 6, 7, 8 }.Last (_ => true), Is.EqualTo (8));
			Assert.That (new string[] {
				"Cube",
				"Sphere",
				"Capsule",
				"Cylinder",
				"Plane",
				"Quad"
			}.Last (_ => true), Is.EqualTo ("Quad"));
		}

		[Test]
		public void TestMultiElementsSequenceWithFalsePredicate ()
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
			}.Last (_ => false));
			Assert.Throws <InvalidOperationException> (() => new string[] {
				"Cube",
				"Sphere",
				"Capsule",
				"Cylinder",
				"Plane",
				"Quad"
			}.Last (_ => false));
		}

		[Test]
		public void TestWithPredicate ()
		{
			Assert.That (new int[]{ 1, 2, 3, 4, 5, 6, 7, 8 }.Last (x => x > 5), Is.EqualTo (8));
			Assert.That (new string[] {
				"Cube",
				"Sphere",
				"Capsule",
				"Cylinder",
				"Plane",
				"Quad"
			}.Last (str => str.Length > 5), Is.EqualTo ("Cylinder"));

			Assert.Throws <InvalidOperationException> (() => new int[] {
				1,
				2,
				3,
				4,
				5,
				6,
				7,
				8
			}.Last (x => x > 10));
			Assert.Throws <InvalidOperationException> (() => new string[] {
				"Cube",
				"Sphere",
				"Capsule",
				"Cylinder",
				"Plane",
				"Quad"
			}.Last (str => str.Length > 10));
		}

		[Test]
		public void TestWithNullPredicate ()
		{
			Assert.Throws <ArgumentNullException> (() => new int[0].Last (null));
			Assert.Throws <ArgumentNullException> (() => new string[0].Last (null));
			Assert.Throws <ArgumentNullException> (() => new int[]{ 1 }.Last (null));
			Assert.Throws <ArgumentNullException> (() => new string[]{ "Cube" }.Last (null));
			Assert.Throws <ArgumentNullException> (() => new int[] {
				1,
				2,
				3,
				4,
				5,
				6,
				7,
				8
			}.Last (null));
			Assert.Throws <ArgumentNullException> (() => new string[] {
				"Cube",
				"Sphere",
				"Capsule",
				"Cylinder",
				"Plane",
				"Quad"
			}.Last (null));
		}

		[Test]
		public void TestNullSourceWithPredicate ()
		{
			#pragma warning disable 1720
			Assert.Throws <ArgumentNullException> (() => ((int[])null).Last (null));
			Assert.Throws <ArgumentNullException> (() => ((string[])null).Last (null));
			#pragma warning restore 1720
		}
		#endregion
	}
}
