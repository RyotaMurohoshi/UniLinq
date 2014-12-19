using System;
using System.Collections.Generic;
using UniLinq;
using NUnit.Framework;

namespace UniLinqTest
{
	[TestFixture]
	[Category("UniLinqTests")]
	class FirstTest
	{
		#region source
		[Test]
		public void TestEmptySequence ()
		{
			Assert.Throws <InvalidOperationException> (() => new int[0].First ());
			Assert.Throws <InvalidOperationException> (() => new string[0].First ());
		}

		[Test]
		public void TestSingleElementSequence ()
		{
			Assert.That (new int[]{ 1 }.First (), Is.EqualTo (1));
			Assert.That (new string[]{ "Cube" }.First (), Is.EqualTo ("Cube"));
		}

		[Test]
		public void TestMultiElementsSequence ()
		{
			Assert.That (new int[]{ 1, 2, 3, 4, 5, 6, 7, 8 }.First (), Is.EqualTo (1));
			Assert.That (new string[] {
				"Cube",
				"Sphere",
				"Capsule",
				"Cylinder",
				"Plane",
				"Quad"
			}.First (), Is.EqualTo ("Cube"));
		}

		[Test]
		public void TestNullSequence ()
		{
			#pragma warning disable 1720
			Assert.Throws <ArgumentNullException> (() => ((int[])null).First ());
			Assert.Throws <ArgumentNullException> (() => ((string[])null).First ());
			#pragma warning restore 1720
		}
		#endregion

		#region source_predicate
		[Test]
		public void TestEmptySequenceWithPredicate ()
		{
			Assert.Throws <InvalidOperationException> (() => new int[0].First (_ => true));
			Assert.Throws <InvalidOperationException> (() => new int[0].First (_ => false));
			Assert.Throws <InvalidOperationException> (() => new string[0].First (_ => true));
			Assert.Throws <InvalidOperationException> (() => new string[0].First (_ => false));
		}

		[Test]
		public void TestSingleElementSequenceWithTruePredicate ()
		{
			Assert.That (new int[]{ 1 }.First (x => true), Is.EqualTo (1));
			Assert.That (new string[]{ "Cube" }.First (x => true), Is.EqualTo ("Cube"));
		}

		[Test]
		public void TestSingleElementSequenceWithFalsePredicate ()
		{
			Assert.Throws <InvalidOperationException> (() => new int[]{ 1 }.First (_ => false));
			Assert.Throws <InvalidOperationException> (() => new string[]{ "Cube" }.First (_ => false));
		}

		[Test]
		public void TestMultiElementsSequenceWithTruePredicate ()
		{
			Assert.That (new int[]{ 1, 2, 3, 4, 5, 6, 7, 8 }.First (_ => true), Is.EqualTo (1));
			Assert.That (new string[] {
				"Cube",
				"Sphere",
				"Capsule",
				"Cylinder",
				"Plane",
				"Quad"
			}.First (_ => true), Is.EqualTo ("Cube"));
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
			}.First (_ => false));
			Assert.Throws <InvalidOperationException> (() => new string[] {
				"Cube",
				"Sphere",
				"Capsule",
				"Cylinder",
				"Plane",
				"Quad"
			}.First (_ => false));
		}

		[Test]
		public void TestWithPredicate ()
		{
			Assert.That (new int[]{ 1, 2, 3, 4, 5, 6, 7, 8 }.First (x => x > 5), Is.EqualTo (6));
			Assert.That (new string[] {
				"Cube",
				"Sphere",
				"Capsule",
				"Cylinder",
				"Plane",
				"Quad"
			}.First (str => str.Length > 5), Is.EqualTo ("Sphere"));

			Assert.Throws <InvalidOperationException> (() => new int[] {
				1,
				2,
				3,
				4,
				5,
				6,
				7,
				8
			}.First (x => x > 10));
			Assert.Throws <InvalidOperationException> (() => new string[] {
				"Cube",
				"Sphere",
				"Capsule",
				"Cylinder",
				"Plane",
				"Quad"
			}.First (str => str.Length > 10));
		}

		[Test]
		public void TestWithNullPredicate ()
		{
			Assert.Throws <ArgumentNullException> (() => new int[0].First (null));
			Assert.Throws <ArgumentNullException> (() => new string[0].First (null));
			Assert.Throws <ArgumentNullException> (() => new int[]{ 1 }.First (null));
			Assert.Throws <ArgumentNullException> (() => new string[]{ "Cube" }.First (null));
			Assert.Throws <ArgumentNullException> (() => new int[] {
				1,
				2,
				3,
				4,
				5,
				6,
				7,
				8
			}.First (null));
			Assert.Throws <ArgumentNullException> (() => new string[] {
				"Cube",
				"Sphere",
				"Capsule",
				"Cylinder",
				"Plane",
				"Quad"
			}.First (null));
		}

		[Test]
		public void TestNullSourceWithPredicate ()
		{
			#pragma warning disable 1720
			Assert.Throws <ArgumentNullException> (() => ((int[])null).First (null));
			Assert.Throws <ArgumentNullException> (() => ((string[])null).First (null));
			#pragma warning restore 1720
		}
		#endregion
	}
}
