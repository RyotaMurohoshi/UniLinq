using System;
using System.Collections.Generic;
using UniLinq;
using NUnit.Framework;

namespace UniLinqTest
{
	[TestFixture]
	[Category("UniLinqTests")]
	class SingleTest
	{
		#region source
		[Test]
		public void TestEmptySequence ()
		{
			Assert.Throws <InvalidOperationException> (() => new int[0].Single ());
			Assert.Throws <InvalidOperationException> (() => new string[0].Single ());
		}

		[Test]
		public void TestSingleElementSequence ()
		{
			Assert.That (new int[]{ 1 }.Single (), Is.EqualTo (1));
			Assert.That (new string[]{ "Cube" }.Single (), Is.EqualTo ("Cube"));
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
			}.Single ());
			Assert.Throws <InvalidOperationException> (() => new string[] {
				"Cube",
				"Sphere",
				"Capsule",
				"Cylinder",
				"Plane",
				"Quad"
			}.Single ());
		}

		[Test]
		public void TestNullSequence ()
		{
			#pragma warning disable 1720
			Assert.Throws <ArgumentNullException> (() => ((int[])null).Single ());
			Assert.Throws <ArgumentNullException> (() => ((string[])null).Single ());
			#pragma warning restore 1720
		}
		#endregion

		#region source_predicate
		[Test]
		public void TestEmptySequenceWithPredicate ()
		{
			Assert.Throws <InvalidOperationException> (() => new int[0].Single (_ => true));
			Assert.Throws <InvalidOperationException> (() => new int[0].Single (_ => false));
			Assert.Throws <InvalidOperationException> (() => new string[0].Single (_ => true));
			Assert.Throws <InvalidOperationException> (() => new string[0].Single (_ => false));
		}

		[Test]
		public void TestSingleElementSequenceWithTruePredicate ()
		{
			Assert.That (new int[]{ 1 }.Single (x => true), Is.EqualTo (1));
			Assert.That (new string[]{ "Cube" }.Single (x => true), Is.EqualTo ("Cube"));
		}

		[Test]
		public void TestSingleElementSequenceWithFalsePredicate ()
		{
			Assert.Throws <InvalidOperationException> (() => new int[]{ 1 }.Single (_ => false));
			Assert.Throws <InvalidOperationException> (() => new string[]{ "Cube" }.Single (_ => false));
		}

		[Test]
		public void TestMultiElementsSequenceWithTruePredicate ()
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
			}.Single (_ => true));
			Assert.Throws <InvalidOperationException> (
				() => new string[] {
				"Cube",
				"Sphere",
				"Capsule",
				"Cylinder",
				"Plane",
				"Quad"
			}.Single (_ => true)
			);
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
			}.Single (_ => false));
			Assert.Throws <InvalidOperationException> (() => new string[] {
				"Cube",
				"Sphere",
				"Capsule",
				"Cylinder",
				"Plane",
				"Quad"
			}.Single (_ => false));
		}

		[Test]
		public void TestWithPredicate ()
		{
			Assert.That (new string[] {
				"Cube",
				"Sphere",
				"Capsule",
				"Cylinder",
				"Plane",
				"Quad"
			}.Single (str => str.Length >= 8),
						Is.EqualTo ("Cylinder"));

			Assert.That (new int[]{ 1, 2, 3, 4, 5, 6, 7, 8 }.Single (x => x >= 8), Is.EqualTo (8));


			Assert.Throws <InvalidOperationException> (() => new int[] {
				1,
				2,
				3,
				4,
				5,
				6,
				7,
				8
			}.Single (x => x > 5));
			Assert.Throws <InvalidOperationException> (
				() => new string[] {
				"Cube",
				"Sphere",
				"Capsule",
				"Cylinder",
				"Plane",
				"Quad"
			}.Single (str => str.Length > 5)
			);

			Assert.Throws <InvalidOperationException> (() => new int[] {
				1,
				2,
				3,
				4,
				5,
				6,
				7,
				8
			}.Single (x => x > 10));
			Assert.Throws <InvalidOperationException> (() => new string[] {
				"Cube",
				"Sphere",
				"Capsule",
				"Cylinder",
				"Plane",
				"Quad"
			}.Single (str => str.Length > 10));
		}

		[Test]
		public void TestWithNullPredicate ()
		{
			Assert.Throws <ArgumentNullException> (() => new int[0].Single (null));
			Assert.Throws <ArgumentNullException> (() => new string[0].Single (null));
			Assert.Throws <ArgumentNullException> (() => new int[]{ 1 }.Single (null));
			Assert.Throws <ArgumentNullException> (() => new string[]{ "Cube" }.Single (null));
			Assert.Throws <ArgumentNullException> (() => new int[] {
				1,
				2,
				3,
				4,
				5,
				6,
				7,
				8
			}.Single (null));
			Assert.Throws <ArgumentNullException> (() => new string[] {
				"Cube",
				"Sphere",
				"Capsule",
				"Cylinder",
				"Plane",
				"Quad"
			}.Single (null));
		}

		[Test]
		public void TestNullSourceWithPredicate ()
		{
			#pragma warning disable 1720
			Assert.Throws <ArgumentNullException> (() => ((int[])null).Single (null));
			Assert.Throws <ArgumentNullException> (() => ((string[])null).Single (null));
			#pragma warning restore 1720
		}
		#endregion
	}
}
