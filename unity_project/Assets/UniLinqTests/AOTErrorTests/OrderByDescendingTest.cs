using System;
using System.Collections.Generic;
using UniLinq;
using NUnit.Framework;
using SL = System.Linq;

namespace UniLinqTest
{
	[TestFixture]
	[Category("UniLinqTests")]
	class OrderByDescendingTest
	{
		#region empty_sequence
		[Test]
		public void TestEmptySequence ()
		{
			Assert.That (SL.Enumerable.SequenceEqual (
				new int[0].OrderByDescending (x => x),
				new int[0]));
			Assert.That (SL.Enumerable.SequenceEqual (
				new int[0].OrderByDescending (x => x.ToString ()),
				new int[0]));
			Assert.That (SL.Enumerable.SequenceEqual (
				new string[0].OrderByDescending (x => x),
				new string[0]));
			Assert.That (SL.Enumerable.SequenceEqual (
				new string[0].OrderByDescending (x => x.Length),
				new string[0]));
		}
		#endregion

		#region single_sequence
		[Test]
		public void TestSingleSequence ()
		{
			Assert.That (SL.Enumerable.SequenceEqual (
				new int[]{1}.OrderByDescending (x => x),
				new int[]{1}));
			Assert.That (SL.Enumerable.SequenceEqual (
				new int[]{1}.OrderByDescending (x => x.ToString ()),
				new int[]{1}));
			Assert.That (SL.Enumerable.SequenceEqual (
				new string[]{"Cube"}.OrderByDescending (x => x),
				new string[]{"Cube"}));
			Assert.That (SL.Enumerable.SequenceEqual (
				new string[]{"Cube"}.OrderByDescending (x => x.Length),
				new string[]{"Cube"}));
		}
		#endregion

		#region contain_null
		[Test]
		public void TestNullContainOrderBy ()
		{
			Assert.That (SL.Enumerable.SequenceEqual (
				new string[]{null}.OrderByDescending (x => x),
				new string[]{null}));
			Assert.That (SL.Enumerable.SequenceEqual (
				new string[]{null, null}.OrderByDescending (x => x),
				new string[]{null, null}));
			Assert.That (SL.Enumerable.SequenceEqual (
				new string[]{null, null, null}.OrderByDescending (x => x),
				new string[]{null, null, null}));

			Assert.That (SL.Enumerable.SequenceEqual (
				new string[]{null, "Cube"}.OrderByDescending (x => x),
				new string[]{"Cube", null}));
			Assert.That (SL.Enumerable.SequenceEqual (
				new string[]{"Cube", null}.OrderByDescending (x => x),
				new string[]{"Cube", null}));

			Assert.That (SL.Enumerable.SequenceEqual (
				new string[]{null, "Cube", "Sphere"}.OrderByDescending (x => x),
				new string[]{"Sphere", "Cube", null}));
			Assert.That (SL.Enumerable.SequenceEqual (
				new string[]{null, "Sphere", "Cube"}.OrderByDescending (x => x),
				new string[]{"Sphere", "Cube", null}));
			Assert.That (SL.Enumerable.SequenceEqual (
				new string[]{"Cube", null, "Sphere"}.OrderByDescending (x => x),
				new string[]{"Sphere", "Cube", null}));
			Assert.That (SL.Enumerable.SequenceEqual (
				new string[]{"Sphere", null, "Cube"}.OrderByDescending (x => x),
				new string[]{"Sphere", "Cube", null}));
			Assert.That (SL.Enumerable.SequenceEqual (
				new string[]{"Cube", "Sphere", null}.OrderByDescending (x => x),
				new string[]{"Sphere", "Cube", null}));
			Assert.That (SL.Enumerable.SequenceEqual (
				new string[]{"Sphere", "Cube", null}.OrderByDescending (x => x),
				new string[]{"Sphere", "Cube", null}));
		}
		#endregion

		#region two_seqence
		[Test]
		public void TestValueTypeValueKeyTwoSequence ()
		{
			Assert.That (SL.Enumerable.SequenceEqual (
				new int[]{1, 2}.OrderByDescending (x => x),
				new int[]{2, 1}));
			Assert.That (SL.Enumerable.SequenceEqual (
				new int[]{2, 1}.OrderByDescending (x => x),
				new int[]{2, 1}));

			Assert.That (SL.Enumerable.SequenceEqual (
				new int[]{1, 1}.OrderByDescending (x => x),
				new int[]{1, 1}));
		}

		[Test]
		public void TestValueTypeReferenceKeyTwoSequence ()
		{
			Assert.That (SL.Enumerable.SequenceEqual (
				new int[]{1, 2}.OrderByDescending (x => x.ToString ()),
				new int[]{2, 1}));
			Assert.That (SL.Enumerable.SequenceEqual (
				new int[]{2, 1}.OrderByDescending (x => x.ToString ()),
				new int[]{2, 1}));

			Assert.That (SL.Enumerable.SequenceEqual (
				new int[]{1, 1}.OrderByDescending (x => x.ToString ()),
				new int[]{1, 1}));
		}

		[Test]
		public void TestReferenceTypeReferenceKeyTwoSequence ()
		{
			Assert.That (SL.Enumerable.SequenceEqual (
				new string[]{"Cube", "Sphere"}.OrderByDescending (x => x),
				new string[]{"Sphere", "Cube"}));
			Assert.That (SL.Enumerable.SequenceEqual (
				new string[]{"Sphere", "Cube"}.OrderByDescending (x => x),
				new string[]{"Sphere", "Cube"}));

			Assert.That (SL.Enumerable.SequenceEqual (
				new string[]{"Cube", "Cube"}.OrderByDescending (x => x),
				new string[]{"Cube", "Cube"}));
		}

		[Test]
		public void TestReferenceTypeValueKeyTwoSequence ()
		{
			Assert.That (SL.Enumerable.SequenceEqual (
				new string[]{"Cube", "Sphere"}.OrderByDescending (x => x.Length),
				new string[]{"Sphere", "Cube"}));
			Assert.That (SL.Enumerable.SequenceEqual (
				new string[]{"Sphere", "Cube"}.OrderByDescending (x => x.Length),
				new string[]{"Sphere", "Cube"}));

			Assert.That (SL.Enumerable.SequenceEqual (
				new string[]{"Cube", "Cube"}.OrderByDescending (x => x.Length),
				new string[]{"Cube", "Cube"}));
		}
		#endregion

		#region three_seqence
		[Test]
		public void TestValueTypeValueKeyThreeSequence ()
		{
			Assert.That (SL.Enumerable.SequenceEqual (
				new int[]{1, 2, 3}.OrderByDescending (x => x),
				new int[]{3, 2, 1}));
			Assert.That (SL.Enumerable.SequenceEqual (
				new int[]{1, 3, 2}.OrderByDescending (x => x),
				new int[]{3, 2, 1}));
			Assert.That (SL.Enumerable.SequenceEqual (
				new int[]{2, 1, 3}.OrderByDescending (x => x),
				new int[]{3, 2, 1}));
			Assert.That (SL.Enumerable.SequenceEqual (
				new int[]{3, 1, 2}.OrderByDescending (x => x),
				new int[]{3, 2, 1}));
			Assert.That (SL.Enumerable.SequenceEqual (
				new int[]{3, 2, 1}.OrderByDescending (x => x),
				new int[]{3, 2, 1}));
			Assert.That (SL.Enumerable.SequenceEqual (
				new int[]{2, 3, 1}.OrderByDescending (x => x),
				new int[]{3, 2, 1}));

			Assert.That (SL.Enumerable.SequenceEqual (
				new int[]{1, 1, 2}.OrderByDescending (x => x),
				new int[]{2, 1, 1}));
			Assert.That (SL.Enumerable.SequenceEqual (
				new int[]{1, 2, 1}.OrderByDescending (x => x),
				new int[]{2, 1, 1}));
			Assert.That (SL.Enumerable.SequenceEqual (
				new int[]{2, 1, 1}.OrderByDescending (x => x),
				new int[]{2, 1, 1}));

			Assert.That (SL.Enumerable.SequenceEqual (
				new int[]{1, 1, 1}.OrderByDescending (x => x),
				new int[]{1, 1, 1}));
		}

		[Test]
		public void TestValueTypeReferenceKeyThereSequence ()
		{
			Assert.That (SL.Enumerable.SequenceEqual (
				new int[]{1, 2, 3}.OrderByDescending (x => x.ToString ()),
				new int[]{3, 2, 1}));
			Assert.That (SL.Enumerable.SequenceEqual (
				new int[]{1, 3, 2}.OrderByDescending (x => x.ToString ()),
				new int[]{3, 2, 1}));
			Assert.That (SL.Enumerable.SequenceEqual (
				new int[]{2, 1, 3}.OrderByDescending (x => x.ToString ()),
				new int[]{3, 2, 1}));
			Assert.That (SL.Enumerable.SequenceEqual (
				new int[]{3, 1, 2}.OrderByDescending (x => x.ToString ()),
				new int[]{3, 2, 1}));
			Assert.That (SL.Enumerable.SequenceEqual (
				new int[]{3, 2, 1}.OrderByDescending (x => x.ToString ()),
				new int[]{3, 2, 1}));
			Assert.That (SL.Enumerable.SequenceEqual (
				new int[]{2, 3, 1}.OrderByDescending (x => x.ToString ()),
				new int[]{3, 2, 1}));

			Assert.That (SL.Enumerable.SequenceEqual (
				new int[]{1, 1, 2}.OrderByDescending (x => x.ToString ()),
				new int[]{2, 1, 1}));
			Assert.That (SL.Enumerable.SequenceEqual (
				new int[]{1, 2, 1}.OrderByDescending (x => x.ToString ()),
				new int[]{2, 1, 1}));
			Assert.That (SL.Enumerable.SequenceEqual (
				new int[]{2, 1, 1}.OrderByDescending (x => x.ToString ()),
				new int[]{2, 1, 1}));

			Assert.That (SL.Enumerable.SequenceEqual (
				new int[]{1, 1, 1}.OrderByDescending (x => x.ToString ()),
				new int[]{1, 1, 1}));
		}

		[Test]
		public void TestReferenceTypeReferenceKeyThereSequence ()
		{
			Assert.That (SL.Enumerable.SequenceEqual (
				new string[]{"Capsule", "Cube", "Sphere"}.OrderByDescending (x => x),
				new string[]{"Sphere", "Cube",  "Capsule"}));
			Assert.That (SL.Enumerable.SequenceEqual (
				new string[]{"Capsule", "Sphere", "Cube"}.OrderByDescending (x => x),
				new string[]{"Sphere", "Cube",  "Capsule"}));
			Assert.That (SL.Enumerable.SequenceEqual (
				new string[]{"Cube", "Capsule", "Sphere"}.OrderByDescending (x => x),
				new string[]{"Sphere", "Cube",  "Capsule"}));
			Assert.That (SL.Enumerable.SequenceEqual (
				new string[]{"Sphere", "Capsule", "Cube"}.OrderByDescending (x => x),
				new string[]{"Sphere", "Cube",  "Capsule"}));
			Assert.That (SL.Enumerable.SequenceEqual (
				new string[]{"Cube", "Sphere", "Capsule"}.OrderByDescending (x => x),
				new string[]{"Sphere", "Cube",  "Capsule"}));
			Assert.That (SL.Enumerable.SequenceEqual (
				new string[]{"Sphere", "Cube", "Capsule"}.OrderByDescending (x => x),
				new string[]{"Sphere", "Cube",  "Capsule"}));

			Assert.That (SL.Enumerable.SequenceEqual (
				new string[]{"Cube", "Cube", "Capsule"}.OrderByDescending (x => x),
				new string[]{"Cube", "Cube", "Capsule"}));
			Assert.That (SL.Enumerable.SequenceEqual (
				new string[]{"Cube", "Capsule", "Cube"}.OrderByDescending (x => x),
				new string[]{"Cube", "Cube", "Capsule"}));
			Assert.That (SL.Enumerable.SequenceEqual (
				new string[]{"Capsule", "Cube", "Cube"}.OrderByDescending (x => x),
				new string[]{"Cube", "Cube", "Capsule"}));

			Assert.That (SL.Enumerable.SequenceEqual (
				new string[]{"Cube", "Cube", "Cube"}.OrderByDescending (x => x),
				new string[]{"Cube", "Cube", "Cube"}));
		}

		[Test]
		public void TestReferenceTypeValueKeyThereSequence ()
		{
			Assert.That (SL.Enumerable.SequenceEqual (
				new string[]{"Capsule", "Cube", "Sphere"}.OrderByDescending (x => x.Length),
				new string[]{"Capsule", "Sphere", "Cube"}));
			Assert.That (SL.Enumerable.SequenceEqual (
				new string[]{"Capsule", "Sphere", "Cube"}.OrderByDescending (x => x.Length),
				new string[]{"Capsule", "Sphere", "Cube"}));
			Assert.That (SL.Enumerable.SequenceEqual (
				new string[]{"Cube", "Capsule", "Sphere"}.OrderByDescending (x => x.Length),
				new string[]{"Capsule", "Sphere", "Cube"}));
			Assert.That (SL.Enumerable.SequenceEqual (
				new string[]{"Sphere", "Capsule", "Cube"}.OrderByDescending (x => x.Length),
				new string[]{"Capsule", "Sphere", "Cube"}));
			Assert.That (SL.Enumerable.SequenceEqual (
				new string[]{"Cube", "Sphere", "Capsule"}.OrderByDescending (x => x.Length),
				new string[]{"Capsule", "Sphere", "Cube"}));
			Assert.That (SL.Enumerable.SequenceEqual (
				new string[]{"Sphere", "Cube", "Capsule"}.OrderByDescending (x => x.Length),
				new string[]{"Capsule", "Sphere", "Cube"}));

			Assert.That (SL.Enumerable.SequenceEqual (
				new string[]{"Cube", "Cube", "Capsule"}.OrderByDescending (x => x.Length),
				new string[]{"Capsule", "Cube", "Cube"}));
			Assert.That (SL.Enumerable.SequenceEqual (
				new string[]{"Cube", "Capsule", "Cube"}.OrderByDescending (x => x.Length),
				new string[]{"Capsule", "Cube", "Cube"}));
			Assert.That (SL.Enumerable.SequenceEqual (
				new string[]{"Capsule", "Cube", "Cube"}.OrderByDescending (x => x.Length),
				new string[]{"Capsule", "Cube", "Cube"}));

			Assert.That (SL.Enumerable.SequenceEqual (
				new string[]{"Cube", "Cube", "Cube"}.OrderByDescending (x => x.Length),
				new string[]{"Cube", "Cube", "Cube"}));
		}
		#endregion

	}
}
