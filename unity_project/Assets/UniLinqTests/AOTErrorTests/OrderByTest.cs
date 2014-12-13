using System;
using System.Collections.Generic;
using UniLinq;
using NUnit.Framework;
using SL = System.Linq;

namespace UniLinqTest
{
	[TestFixture]
	[Category("UniLinqTests")]
	class OrderByTest
	{
		#region empty_sequence
		[Test]
		public void TestEmptySequence ()
		{
			Assert.That (SL.Enumerable.SequenceEqual (
				new int[0].OrderBy (x => x),
				new int[0]));
			Assert.That (SL.Enumerable.SequenceEqual (
				new int[0].OrderBy (x => x.ToString ()),
				new int[0]));
			Assert.That (SL.Enumerable.SequenceEqual (
				new string[0].OrderBy (x => x),
				new string[0]));
			Assert.That (SL.Enumerable.SequenceEqual (
				new string[0].OrderBy (x => x.Length),
				new string[0]));
		}
		#endregion

		#region single_sequence
		[Test]
		public void TestSingleSequence ()
		{
			Assert.That (SL.Enumerable.SequenceEqual (
				new int[]{1}.OrderBy (x => x),
				new int[]{1}));
			Assert.That (SL.Enumerable.SequenceEqual (
				new int[]{1}.OrderBy (x => x.ToString ()),
				new int[]{1}));
			Assert.That (SL.Enumerable.SequenceEqual (
				new string[]{"Cube"}.OrderBy (x => x),
				new string[]{"Cube"}));
			Assert.That (SL.Enumerable.SequenceEqual (
				new string[]{"Cube"}.OrderBy (x => x.Length),
				new string[]{"Cube"}));
		}
		#endregion

		#region contain_null
		[Test]
		public void TestNullContainOrderBy ()
		{
			Assert.That (SL.Enumerable.SequenceEqual (
				new string[]{null}.OrderBy (x => x),
				new string[]{null}));
			Assert.That (SL.Enumerable.SequenceEqual (
				new string[]{null, null}.OrderBy (x => x),
				new string[]{null, null}));
			Assert.That (SL.Enumerable.SequenceEqual (
				new string[]{null, null, null}.OrderBy (x => x),
				new string[]{null, null, null}));

			Assert.That (SL.Enumerable.SequenceEqual (
				new string[]{null, "Cube"}.OrderBy (x => x),
				new string[]{null, "Cube"}));
			Assert.That (SL.Enumerable.SequenceEqual (
				new string[]{"Cube", null}.OrderBy (x => x),
				new string[]{null, "Cube"}));

			Assert.That (SL.Enumerable.SequenceEqual (
				new string[]{null, "Cube", "Sphere"}.OrderBy (x => x),
				new string[]{null, "Cube", "Sphere"}));
			Assert.That (SL.Enumerable.SequenceEqual (
				new string[]{null, "Sphere", "Cube"}.OrderBy (x => x),
				new string[]{null, "Cube", "Sphere"}));
			Assert.That (SL.Enumerable.SequenceEqual (
				new string[]{"Cube", null, "Sphere"}.OrderBy (x => x),
				new string[]{null, "Cube", "Sphere"}));
			Assert.That (SL.Enumerable.SequenceEqual (
				new string[]{"Sphere", null, "Cube"}.OrderBy (x => x),
				new string[]{null, "Cube", "Sphere"}));
			Assert.That (SL.Enumerable.SequenceEqual (
				new string[]{"Cube", "Sphere", null}.OrderBy (x => x),
				new string[]{null, "Cube", "Sphere"}));
			Assert.That (SL.Enumerable.SequenceEqual (
				new string[]{"Sphere", "Cube", null}.OrderBy (x => x),
				new string[]{null, "Cube", "Sphere"}));
		}
		#endregion

		#region two_seqence
		[Test]
		public void TestValueTypeValueKeyTwoSequence ()
		{
			Assert.That (SL.Enumerable.SequenceEqual (
				new int[]{1, 2}.OrderBy (x => x),
				new int[]{1, 2}));
			Assert.That (SL.Enumerable.SequenceEqual (
				new int[]{2, 1}.OrderBy (x => x),
				new int[]{1, 2}));

			Assert.That (SL.Enumerable.SequenceEqual (
				new int[]{1, 1}.OrderBy (x => x),
				new int[]{1, 1}));
		}

		[Test]
		public void TestValueTypeReferenceKeyTwoSequence ()
		{
			Assert.That (SL.Enumerable.SequenceEqual (
				new int[]{1, 2}.OrderBy (x => x.ToString ()),
				new int[]{1, 2}));
			Assert.That (SL.Enumerable.SequenceEqual (
				new int[]{2, 1}.OrderBy (x => x.ToString ()),
				new int[]{1, 2}));

			Assert.That (SL.Enumerable.SequenceEqual (
				new int[]{1, 1}.OrderBy (x => x.ToString ()),
				new int[]{1, 1}));
		}

		[Test]
		public void TestReferenceTypeReferenceKeyTwoSequence ()
		{
			Assert.That (SL.Enumerable.SequenceEqual (
				new string[]{"Cube", "Sphere"}.OrderBy (x => x),
				new string[]{"Cube", "Sphere"}));
			Assert.That (SL.Enumerable.SequenceEqual (
				new string[]{"Sphere", "Cube"}.OrderBy (x => x),
				new string[]{"Cube", "Sphere"}));

			Assert.That (SL.Enumerable.SequenceEqual (
				new string[]{"Cube", "Cube"}.OrderBy (x => x),
				new string[]{"Cube", "Cube"}));
		}

		[Test]
		public void TestReferenceTypeValueKeyTwoSequence ()
		{
			Assert.That (SL.Enumerable.SequenceEqual (
				new string[]{"Cube", "Sphere"}.OrderBy (x => x.Length),
				new string[]{"Cube", "Sphere"}));
			Assert.That (SL.Enumerable.SequenceEqual (
				new string[]{"Sphere", "Cube"}.OrderBy (x => x.Length),
				new string[]{"Cube", "Sphere"}));

			Assert.That (SL.Enumerable.SequenceEqual (
				new string[]{"Cube", "Cube"}.OrderBy (x => x.Length),
				new string[]{"Cube", "Cube"}));
		}
		#endregion

		#region three_seqence
		[Test]
		public void TestValueTypeValueKeyThreeSequence ()
		{
			Assert.That (SL.Enumerable.SequenceEqual (
				new int[]{1, 2, 3}.OrderBy (x => x),
				new int[]{1, 2, 3}));
			Assert.That (SL.Enumerable.SequenceEqual (
				new int[]{1, 3, 2}.OrderBy (x => x),
				new int[]{1, 2, 3}));
			Assert.That (SL.Enumerable.SequenceEqual (
				new int[]{2, 1, 3}.OrderBy (x => x),
				new int[]{1, 2, 3}));
			Assert.That (SL.Enumerable.SequenceEqual (
				new int[]{3, 1, 2}.OrderBy (x => x),
				new int[]{1, 2, 3}));
			Assert.That (SL.Enumerable.SequenceEqual (
				new int[]{3, 2, 1}.OrderBy (x => x),
				new int[]{1, 2, 3}));
			Assert.That (SL.Enumerable.SequenceEqual (
				new int[]{2, 3, 1}.OrderBy (x => x),
				new int[]{1, 2, 3}));

			Assert.That (SL.Enumerable.SequenceEqual (
				new int[]{1, 1, 2}.OrderBy (x => x),
				new int[]{1, 1, 2}));
			Assert.That (SL.Enumerable.SequenceEqual (
				new int[]{1, 2, 1}.OrderBy (x => x),
				new int[]{1, 1, 2}));
			Assert.That (SL.Enumerable.SequenceEqual (
				new int[]{2, 1, 1}.OrderBy (x => x),
				new int[]{1, 1, 2}));

			Assert.That (SL.Enumerable.SequenceEqual (
				new int[]{1, 1, 1}.OrderBy (x => x),
				new int[]{1, 1, 1}));
		}

		[Test]
		public void TestValueTypeReferenceKeyThereSequence ()
		{
			Assert.That (SL.Enumerable.SequenceEqual (
				new int[]{1, 2, 3}.OrderBy (x => x.ToString ()),
				new int[]{1, 2, 3}));
			Assert.That (SL.Enumerable.SequenceEqual (
				new int[]{1, 3, 2}.OrderBy (x => x.ToString ()),
				new int[]{1, 2, 3}));
			Assert.That (SL.Enumerable.SequenceEqual (
				new int[]{2, 1, 3}.OrderBy (x => x.ToString ()),
				new int[]{1, 2, 3}));
			Assert.That (SL.Enumerable.SequenceEqual (
				new int[]{3, 1, 2}.OrderBy (x => x.ToString ()),
				new int[]{1, 2, 3}));
			Assert.That (SL.Enumerable.SequenceEqual (
				new int[]{3, 2, 1}.OrderBy (x => x.ToString ()),
				new int[]{1, 2, 3}));
			Assert.That (SL.Enumerable.SequenceEqual (
				new int[]{2, 3, 1}.OrderBy (x => x.ToString ()),
				new int[]{1, 2, 3}));

			Assert.That (SL.Enumerable.SequenceEqual (
				new int[]{1, 1, 2}.OrderBy (x => x.ToString ()),
				new int[]{1, 1, 2}));
			Assert.That (SL.Enumerable.SequenceEqual (
				new int[]{1, 2, 1}.OrderBy (x => x.ToString ()),
				new int[]{1, 1, 2}));
			Assert.That (SL.Enumerable.SequenceEqual (
				new int[]{2, 1, 1}.OrderBy (x => x.ToString ()),
				new int[]{1, 1, 2}));

			Assert.That (SL.Enumerable.SequenceEqual (
				new int[]{1, 1, 1}.OrderBy (x => x.ToString ()),
				new int[]{1, 1, 1}));
		}

		[Test]
		public void TestReferenceTypeReferenceKeyThereSequence ()
		{
			Assert.That (SL.Enumerable.SequenceEqual (
				new string[]{"Capsule", "Cube", "Sphere"}.OrderBy (x => x),
				new string[]{"Capsule", "Cube", "Sphere"}));
			Assert.That (SL.Enumerable.SequenceEqual (
				new string[]{"Capsule", "Sphere", "Cube"}.OrderBy (x => x),
				new string[]{"Capsule", "Cube", "Sphere"}));
			Assert.That (SL.Enumerable.SequenceEqual (
				new string[]{"Cube", "Capsule", "Sphere"}.OrderBy (x => x),
				new string[]{"Capsule", "Cube", "Sphere"}));
			Assert.That (SL.Enumerable.SequenceEqual (
				new string[]{"Sphere", "Capsule", "Cube"}.OrderBy (x => x),
				new string[]{"Capsule", "Cube", "Sphere"}));
			Assert.That (SL.Enumerable.SequenceEqual (
				new string[]{"Cube", "Sphere", "Capsule"}.OrderBy (x => x),
				new string[]{"Capsule", "Cube", "Sphere"}));
			Assert.That (SL.Enumerable.SequenceEqual (
				new string[]{"Sphere", "Cube", "Capsule"}.OrderBy (x => x),
				new string[]{"Capsule", "Cube", "Sphere"}));

			Assert.That (SL.Enumerable.SequenceEqual (
				new string[]{"Cube", "Cube", "Capsule"}.OrderBy (x => x),
				new string[]{"Capsule", "Cube", "Cube"}));
			Assert.That (SL.Enumerable.SequenceEqual (
				new string[]{"Cube", "Capsule", "Cube"}.OrderBy (x => x),
				new string[]{"Capsule", "Cube", "Cube"}));
			Assert.That (SL.Enumerable.SequenceEqual (
				new string[]{"Capsule", "Cube", "Cube"}.OrderBy (x => x),
				new string[]{"Capsule", "Cube", "Cube"}));

			Assert.That (SL.Enumerable.SequenceEqual (
				new string[]{"Cube", "Cube", "Cube"}.OrderBy (x => x),
				new string[]{"Cube", "Cube", "Cube"}));
		}

		[Test]
		public void TestReferenceTypeValueKeyThereSequence ()
		{
			Assert.That (SL.Enumerable.SequenceEqual (
				new string[]{"Capsule", "Cube", "Sphere"}.OrderBy (x => x.Length),
				new string[]{"Cube", "Sphere", "Capsule"}));
			Assert.That (SL.Enumerable.SequenceEqual (
				new string[]{"Capsule", "Sphere", "Cube"}.OrderBy (x => x.Length),
				new string[]{"Cube", "Sphere", "Capsule"}));
			Assert.That (SL.Enumerable.SequenceEqual (
				new string[]{"Cube", "Capsule", "Sphere"}.OrderBy (x => x.Length),
				new string[]{"Cube", "Sphere", "Capsule"}));
			Assert.That (SL.Enumerable.SequenceEqual (
				new string[]{"Sphere", "Capsule", "Cube"}.OrderBy (x => x.Length),
				new string[]{"Cube", "Sphere", "Capsule"}));
			Assert.That (SL.Enumerable.SequenceEqual (
				new string[]{"Cube", "Sphere", "Capsule"}.OrderBy (x => x.Length),
				new string[]{"Cube", "Sphere", "Capsule"}));
			Assert.That (SL.Enumerable.SequenceEqual (
				new string[]{"Sphere", "Cube", "Capsule"}.OrderBy (x => x.Length),
				new string[]{"Cube", "Sphere", "Capsule"}));

			Assert.That (SL.Enumerable.SequenceEqual (
				new string[]{"Cube", "Cube", "Capsule"}.OrderBy (x => x.Length),
				new string[]{"Cube", "Cube", "Capsule"}));
			Assert.That (SL.Enumerable.SequenceEqual (
				new string[]{"Cube", "Capsule", "Cube"}.OrderBy (x => x.Length),
				new string[]{"Cube", "Cube", "Capsule"}));
			Assert.That (SL.Enumerable.SequenceEqual (
				new string[]{"Capsule", "Cube", "Cube"}.OrderBy (x => x.Length),
				new string[]{"Cube", "Cube", "Capsule"}));

			Assert.That (SL.Enumerable.SequenceEqual (
				new string[]{"Cube", "Cube", "Cube"}.OrderBy (x => x.Length),
				new string[]{"Cube", "Cube", "Cube"}));
		}
		#endregion

	}
}
