using System;
using System.Collections.Generic;
using UniLinq;
using NUnit.Framework;
using SL = System.Linq;
using UnityEngine;

namespace UniLinqTest
{
	[TestFixture]
	[Category("UniLinqTests")]
	class ThenByTest
	{
		#region empty_sequence
		[Test]
		public void TestEmptySequence ()
		{
			Assert.That (SL.Enumerable.SequenceEqual (
				new int[0].OrderBy (x => x).ThenBy (x => x),
				new int[0]));
			Assert.That (SL.Enumerable.SequenceEqual (
				new int[0].OrderBy (x => x).ThenBy (x => x.ToString ()),
				new int[0]));
			Assert.That (SL.Enumerable.SequenceEqual (
				new int[0].OrderBy (x => x.ToString ()).ThenBy (x => x),
				new int[0]));
			Assert.That (SL.Enumerable.SequenceEqual (
				new int[0].OrderBy (x => x.ToString ()).ThenBy (x => x.ToString ()),
				new int[0]));

			Assert.That (SL.Enumerable.SequenceEqual (
				new string[0].OrderBy (x => x).ThenBy (x => x),
				new string[0]));
			Assert.That (SL.Enumerable.SequenceEqual (
				new string[0].OrderBy (x => x).ThenBy (x => x.Length),
				new string[0]));
			Assert.That (SL.Enumerable.SequenceEqual (
				new string[0].OrderBy (x => x.Length).ThenBy (x => x),
				new string[0]));
			Assert.That (SL.Enumerable.SequenceEqual (
				new string[0].OrderBy (x => x.Length).ThenBy (x => x.Length),
				new string[0]));
		}
		#endregion

		#region single_sequence
		[Test]
		public void TestSingleSequence ()
		{
			Assert.That (SL.Enumerable.SequenceEqual (
				new int[]{1}.OrderBy (x => x).ThenBy (x => x),
				new int[]{1}));
			Assert.That (SL.Enumerable.SequenceEqual (
				new int[]{1}.OrderBy (x => x).ThenBy (x => x.ToString ()),
				new int[]{1}));
			Assert.That (SL.Enumerable.SequenceEqual (
				new int[]{1}.OrderBy (x => x.ToString ()).ThenBy (x => x),
				new int[]{1}));
			Assert.That (SL.Enumerable.SequenceEqual (
				new int[]{1}.OrderBy (x => x.ToString ()).ThenBy (x => x.ToString ()),
				new int[]{1}));

			Assert.That (SL.Enumerable.SequenceEqual (
				new string[]{"Cube"}.OrderBy (x => x).ThenBy (x => x),
				new string[]{"Cube"}));
			Assert.That (SL.Enumerable.SequenceEqual (
				new string[]{"Cube"}.OrderBy (x => x).ThenBy (x => x.Length),
				new string[]{"Cube"}));
			Assert.That (SL.Enumerable.SequenceEqual (
				new string[]{"Cube"}.OrderBy (x => x.Length).ThenBy (x => x),
				new string[]{"Cube"}));
			Assert.That (SL.Enumerable.SequenceEqual (
				new string[]{"Cube"}.OrderBy (x => x.Length).ThenBy (x => x.Length),
				new string[]{"Cube"}));
		}
		#endregion

		#region contain_null
		[Test]
		public void TestNullContainOrderBy ()
		{
			Assert.That (SL.Enumerable.SequenceEqual (
				new string[]{null}.OrderBy (x => x).ThenBy (x => x),
				new string[]{null}));
			Assert.That (SL.Enumerable.SequenceEqual (
				new string[]{null, null}.OrderBy (x => x).ThenBy (x => x),
				new string[]{null, null}));
			Assert.That (SL.Enumerable.SequenceEqual (
				new string[]{null, null, null}.OrderBy (x => x).ThenBy (x => x),
				new string[]{null, null, null}));

			Assert.That (SL.Enumerable.SequenceEqual (
				new string[]{null, "Cube"}.OrderBy (x => x).ThenBy (x => x),
				new string[]{null, "Cube"}));
			Assert.That (SL.Enumerable.SequenceEqual (
				new string[]{"Cube", null}.OrderBy (x => x).ThenBy (x => x),
				new string[]{null, "Cube"}));

			Assert.That (SL.Enumerable.SequenceEqual (
				new string[]{null, "Cube", "Sphere"}.OrderBy (x => x).ThenBy (x => x),
				new string[]{null, "Cube", "Sphere"}));
			Assert.That (SL.Enumerable.SequenceEqual (
				new string[]{null, "Sphere", "Cube"}.OrderBy (x => x).ThenBy (x => x),
				new string[]{null, "Cube", "Sphere"}));
			Assert.That (SL.Enumerable.SequenceEqual (
				new string[]{"Cube", null, "Sphere"}.OrderBy (x => x).ThenBy (x => x),
				new string[]{null, "Cube", "Sphere"}));
			Assert.That (SL.Enumerable.SequenceEqual (
				new string[]{"Sphere", null, "Cube"}.OrderBy (x => x).ThenBy (x => x),
				new string[]{null, "Cube", "Sphere"}));
			Assert.That (SL.Enumerable.SequenceEqual (
				new string[]{"Cube", "Sphere", null}.OrderBy (x => x).ThenBy (x => x),
				new string[]{null, "Cube", "Sphere"}));
			Assert.That (SL.Enumerable.SequenceEqual (
				new string[]{"Sphere", "Cube", null}.OrderBy (x => x).ThenBy (x => x),
				new string[]{null, "Cube", "Sphere"}));
		}
		#endregion

		#region two_value_type_seqence

		[Test]
		public void TestValueTypeOrderByValueKeyThenByValueKeyTwoSequence ()
		{
			Assert.That (SL.Enumerable.SequenceEqual (
				new Vector2[]{Vector2.right, Vector2.one}.OrderBy (v => v.x).ThenBy (v => v.y),
				new Vector2[]{Vector2.right, Vector2.one}));
			Assert.That (SL.Enumerable.SequenceEqual (
				new Vector2[]{Vector2.right, Vector2.one}.OrderBy (v => v.y).ThenBy (v => v.x),
				new Vector2[]{Vector2.right, Vector2.one}));
			Assert.That (SL.Enumerable.SequenceEqual (
				new Vector2[]{Vector2.one, Vector2.right}.OrderBy (v => v.x).ThenBy (v => v.y),
				new Vector2[]{Vector2.right, Vector2.one}));
			Assert.That (SL.Enumerable.SequenceEqual (
				new Vector2[]{Vector2.one, Vector2.right}.OrderBy (v => v.y).ThenBy (v => v.x),
				new Vector2[]{Vector2.right, Vector2.one}));

			Assert.That (SL.Enumerable.SequenceEqual (
				new Vector2[]{Vector2.up, Vector2.one}.OrderBy (v => v.x).ThenBy (v => v.y),
				new Vector2[]{Vector2.up, Vector2.one}));
			Assert.That (SL.Enumerable.SequenceEqual (
				new Vector2[]{Vector2.up, Vector2.one}.OrderBy (v => v.y).ThenBy (v => v.x),
				new Vector2[]{Vector2.up, Vector2.one}));
			Assert.That (SL.Enumerable.SequenceEqual (
				new Vector2[]{Vector2.one, Vector2.up}.OrderBy (v => v.x).ThenBy (v => v.y),
				new Vector2[]{Vector2.up, Vector2.one}));
			Assert.That (SL.Enumerable.SequenceEqual (
				new Vector2[]{Vector2.one, Vector2.up}.OrderBy (v => v.y).ThenBy (v => v.x),
				new Vector2[]{Vector2.up, Vector2.one}));

			Assert.That (SL.Enumerable.SequenceEqual (
				new Vector2[]{Vector2.up, Vector2.right}.OrderBy (v => v.x).ThenBy (v => v.y),
				new Vector2[]{Vector2.up, Vector2.right}));
			Assert.That (SL.Enumerable.SequenceEqual (
				new Vector2[]{Vector2.up, Vector2.right}.OrderBy (v => v.y).ThenBy (v => v.x),
				new Vector2[]{Vector2.right, Vector2.up}));
			Assert.That (SL.Enumerable.SequenceEqual (
				new Vector2[]{Vector2.right, Vector2.up}.OrderBy (v => v.x).ThenBy (v => v.y),
				new Vector2[]{Vector2.up, Vector2.right}));
			Assert.That (SL.Enumerable.SequenceEqual (
				new Vector2[]{Vector2.right, Vector2.up}.OrderBy (v => v.y).ThenBy (v => v.x),
				new Vector2[]{Vector2.right, Vector2.up}));

			Assert.That (SL.Enumerable.SequenceEqual (
				new Vector2[]{Vector2.one, Vector2.one}.OrderBy (v => v.y).ThenBy (v => v.x),
				new Vector2[]{Vector2.one, Vector2.one}));
			Assert.That (SL.Enumerable.SequenceEqual (
				new Vector2[]{Vector2.one, Vector2.one}.OrderBy (v => v.x).ThenBy (v => v.y),
				new Vector2[]{Vector2.one, Vector2.one}));
		}

		[Test]
		public void TestValueTypeOrderByValueKeyThenByReferenceKeyTwoSequence ()
		{
			Assert.That (SL.Enumerable.SequenceEqual (
				new Vector2[]{Vector2.right, Vector2.one}.OrderBy (v => v.x).ThenBy (v => v.y.ToString ()),
				new Vector2[]{Vector2.right, Vector2.one}));
			Assert.That (SL.Enumerable.SequenceEqual (
				new Vector2[]{Vector2.right, Vector2.one}.OrderBy (v => v.y).ThenBy (v => v.x.ToString ()),
				new Vector2[]{Vector2.right, Vector2.one}));
			Assert.That (SL.Enumerable.SequenceEqual (
				new Vector2[]{Vector2.one, Vector2.right}.OrderBy (v => v.x).ThenBy (v => v.y.ToString ()),
				new Vector2[]{Vector2.right, Vector2.one}));
			Assert.That (SL.Enumerable.SequenceEqual (
				new Vector2[]{Vector2.one, Vector2.right}.OrderBy (v => v.y).ThenBy (v => v.x.ToString ()),
				new Vector2[]{Vector2.right, Vector2.one}));

			Assert.That (SL.Enumerable.SequenceEqual (
				new Vector2[]{Vector2.up, Vector2.one}.OrderBy (v => v.x).ThenBy (v => v.y.ToString ()),
				new Vector2[]{Vector2.up, Vector2.one}));
			Assert.That (SL.Enumerable.SequenceEqual (
				new Vector2[]{Vector2.up, Vector2.one}.OrderBy (v => v.y).ThenBy (v => v.x.ToString ()),
				new Vector2[]{Vector2.up, Vector2.one}));
			Assert.That (SL.Enumerable.SequenceEqual (
				new Vector2[]{Vector2.one, Vector2.up}.OrderBy (v => v.x).ThenBy (v => v.y.ToString ()),
				new Vector2[]{Vector2.up, Vector2.one}));
			Assert.That (SL.Enumerable.SequenceEqual (
				new Vector2[]{Vector2.one, Vector2.up}.OrderBy (v => v.y).ThenBy (v => v.x.ToString ()),
				new Vector2[]{Vector2.up, Vector2.one}));

			Assert.That (SL.Enumerable.SequenceEqual (
				new Vector2[]{Vector2.up, Vector2.right}.OrderBy (v => v.x).ThenBy (v => v.y.ToString ()),
				new Vector2[]{Vector2.up, Vector2.right}));
			Assert.That (SL.Enumerable.SequenceEqual (
				new Vector2[]{Vector2.up, Vector2.right}.OrderBy (v => v.y).ThenBy (v => v.x.ToString ()),
				new Vector2[]{Vector2.right, Vector2.up}));
			Assert.That (SL.Enumerable.SequenceEqual (
				new Vector2[]{Vector2.right, Vector2.up}.OrderBy (v => v.x).ThenBy (v => v.y.ToString ()),
				new Vector2[]{Vector2.up, Vector2.right}));
			Assert.That (SL.Enumerable.SequenceEqual (
				new Vector2[]{Vector2.right, Vector2.up}.OrderBy (v => v.y).ThenBy (v => v.x.ToString ()),
				new Vector2[]{Vector2.right, Vector2.up}));

			Assert.That (SL.Enumerable.SequenceEqual (
				new Vector2[]{Vector2.one, Vector2.one}.OrderBy (v => v.y).ThenBy (v => v.x.ToString ()),
				new Vector2[]{Vector2.one, Vector2.one}));
			Assert.That (SL.Enumerable.SequenceEqual (
				new Vector2[]{Vector2.one, Vector2.one}.OrderBy (v => v.x).ThenBy (v => v.y.ToString ()),
				new Vector2[]{Vector2.one, Vector2.one}));
		}

		[Test]
		public void TestValueTypeOrderByReferenceKeyThenByValueKeyTwoSequence ()
		{
			Assert.That (SL.Enumerable.SequenceEqual (
				new Vector2[]{Vector2.right, Vector2.one}.OrderBy (v => v.x.ToString ()).ThenBy (v => v.y),
				new Vector2[]{Vector2.right, Vector2.one}));
			Assert.That (SL.Enumerable.SequenceEqual (
				new Vector2[]{Vector2.right, Vector2.one}.OrderBy (v => v.y.ToString ()).ThenBy (v => v.x),
				new Vector2[]{Vector2.right, Vector2.one}));
			Assert.That (SL.Enumerable.SequenceEqual (
				new Vector2[]{Vector2.one, Vector2.right}.OrderBy (v => v.x.ToString ()).ThenBy (v => v.y),
				new Vector2[]{Vector2.right, Vector2.one}));
			Assert.That (SL.Enumerable.SequenceEqual (
				new Vector2[]{Vector2.one, Vector2.right}.OrderBy (v => v.y.ToString ()).ThenBy (v => v.x),
				new Vector2[]{Vector2.right, Vector2.one}));

			Assert.That (SL.Enumerable.SequenceEqual (
				new Vector2[]{Vector2.up, Vector2.one}.OrderBy (v => v.x.ToString ()).ThenBy (v => v.y),
				new Vector2[]{Vector2.up, Vector2.one}));
			Assert.That (SL.Enumerable.SequenceEqual (
				new Vector2[]{Vector2.up, Vector2.one}.OrderBy (v => v.y.ToString ()).ThenBy (v => v.x),
				new Vector2[]{Vector2.up, Vector2.one}));
			Assert.That (SL.Enumerable.SequenceEqual (
				new Vector2[]{Vector2.one, Vector2.up}.OrderBy (v => v.x.ToString ()).ThenBy (v => v.y),
				new Vector2[]{Vector2.up, Vector2.one}));
			Assert.That (SL.Enumerable.SequenceEqual (
				new Vector2[]{Vector2.one, Vector2.up}.OrderBy (v => v.y.ToString ()).ThenBy (v => v.x),
				new Vector2[]{Vector2.up, Vector2.one}));

			Assert.That (SL.Enumerable.SequenceEqual (
				new Vector2[]{Vector2.up, Vector2.right}.OrderBy (v => v.x.ToString ()).ThenBy (v => v.y),
				new Vector2[]{Vector2.up, Vector2.right}));
			Assert.That (SL.Enumerable.SequenceEqual (
				new Vector2[]{Vector2.up, Vector2.right}.OrderBy (v => v.y.ToString ()).ThenBy (v => v.x),
				new Vector2[]{Vector2.right, Vector2.up}));
			Assert.That (SL.Enumerable.SequenceEqual (
				new Vector2[]{Vector2.right, Vector2.up}.OrderBy (v => v.x.ToString ()).ThenBy (v => v.y),
				new Vector2[]{Vector2.up, Vector2.right}));
			Assert.That (SL.Enumerable.SequenceEqual (
				new Vector2[]{Vector2.right, Vector2.up}.OrderBy (v => v.y.ToString ()).ThenBy (v => v.x),
				new Vector2[]{Vector2.right, Vector2.up}));

			Assert.That (SL.Enumerable.SequenceEqual (
				new Vector2[]{Vector2.one, Vector2.one}.OrderBy (v => v.y.ToString ()).ThenBy (v => v.x),
			new Vector2[]{Vector2.one, Vector2.one}));
			Assert.That (SL.Enumerable.SequenceEqual (
				new Vector2[]{Vector2.one, Vector2.one}.OrderBy (v => v.x.ToString ()).ThenBy (v => v.y),
				new Vector2[]{Vector2.one, Vector2.one}));
		}

		[Test]
		public void TestValueTypeOrderByReferenceKeyThenByReferenceKeyTwoSequence ()
		{
			Assert.That (SL.Enumerable.SequenceEqual (
				new Vector2[]{Vector2.right, Vector2.one}.OrderBy (v => v.x.ToString ()).ThenBy (v => v.y.ToString ()),
				new Vector2[]{Vector2.right, Vector2.one}));
			Assert.That (SL.Enumerable.SequenceEqual (
				new Vector2[]{Vector2.right, Vector2.one}.OrderBy (v => v.y.ToString ()).ThenBy (v => v.x.ToString ()),
				new Vector2[]{Vector2.right, Vector2.one}));
			Assert.That (SL.Enumerable.SequenceEqual (
				new Vector2[]{Vector2.one, Vector2.right}.OrderBy (v => v.x.ToString ()).ThenBy (v => v.y.ToString ()),
				new Vector2[]{Vector2.right, Vector2.one}));
			Assert.That (SL.Enumerable.SequenceEqual (
				new Vector2[]{Vector2.one, Vector2.right}.OrderBy (v => v.y.ToString ()).ThenBy (v => v.x.ToString ()),
				new Vector2[]{Vector2.right, Vector2.one}));

			Assert.That (SL.Enumerable.SequenceEqual (
				new Vector2[]{Vector2.up, Vector2.one}.OrderBy (v => v.x.ToString ()).ThenBy (v => v.y.ToString ()),
				new Vector2[]{Vector2.up, Vector2.one}));
			Assert.That (SL.Enumerable.SequenceEqual (
				new Vector2[]{Vector2.up, Vector2.one}.OrderBy (v => v.y.ToString ()).ThenBy (v => v.x.ToString ()),
				new Vector2[]{Vector2.up, Vector2.one}));
			Assert.That (SL.Enumerable.SequenceEqual (
				new Vector2[]{Vector2.one, Vector2.up}.OrderBy (v => v.x.ToString ()).ThenBy (v => v.y.ToString ()),
				new Vector2[]{Vector2.up, Vector2.one}));
			Assert.That (SL.Enumerable.SequenceEqual (
				new Vector2[]{Vector2.one, Vector2.up}.OrderBy (v => v.y.ToString ()).ThenBy (v => v.x.ToString ()),
				new Vector2[]{Vector2.up, Vector2.one}));

			Assert.That (SL.Enumerable.SequenceEqual (
				new Vector2[]{Vector2.up, Vector2.right}.OrderBy (v => v.x.ToString ()).ThenBy (v => v.y.ToString ()),
				new Vector2[]{Vector2.up, Vector2.right}));
			Assert.That (SL.Enumerable.SequenceEqual (
				new Vector2[]{Vector2.up, Vector2.right}.OrderBy (v => v.y.ToString ()).ThenBy (v => v.x.ToString ()),
				new Vector2[]{Vector2.right, Vector2.up}));
			Assert.That (SL.Enumerable.SequenceEqual (
				new Vector2[]{Vector2.right, Vector2.up}.OrderBy (v => v.x.ToString ()).ThenBy (v => v.y.ToString ()),
				new Vector2[]{Vector2.up, Vector2.right}));
			Assert.That (SL.Enumerable.SequenceEqual (
				new Vector2[]{Vector2.right, Vector2.up}.OrderBy (v => v.y.ToString ()).ThenBy (v => v.x.ToString ()),
				new Vector2[]{Vector2.right, Vector2.up}));

			Assert.That (SL.Enumerable.SequenceEqual (
				new Vector2[]{Vector2.one, Vector2.one}.OrderBy (v => v.y.ToString ()).ThenBy (v => v.x.ToString ()),
				new Vector2[]{Vector2.one, Vector2.one}));
			Assert.That (SL.Enumerable.SequenceEqual (
				new Vector2[]{Vector2.one, Vector2.one}.OrderBy (v => v.x.ToString ()).ThenBy (v => v.y.ToString ()),
				new Vector2[]{Vector2.one, Vector2.one}));
		}
		#endregion

		#region two_reference_type_seqence
		[Test]
		public void TestReferenceTypeTwoSequence ()
		{
			Assert.That (SL.Enumerable.SequenceEqual (
				new string[]{"Cube", "Sphere"}.OrderBy (x => x).ThenBy (x => x),
				new string[]{"Cube", "Sphere"}));
			Assert.That (SL.Enumerable.SequenceEqual (
				new string[]{"Sphere", "Cube"}.OrderBy (x => x).ThenBy (x => x),
				new string[]{"Cube", "Sphere"}));
			Assert.That (SL.Enumerable.SequenceEqual (
				new string[]{"Cube", "Capsule"}.OrderBy (x => x).ThenBy (x => x),
				new string[]{"Capsule", "Cube"}));
			Assert.That (SL.Enumerable.SequenceEqual (
				new string[]{"Capsule", "Cube"}.OrderBy (x => x).ThenBy (x => x),
				new string[]{"Capsule", "Cube"}));

			Assert.That (SL.Enumerable.SequenceEqual (
				new string[]{"Cube", "Sphere"}.OrderBy (x => x.Length).ThenBy (x => x),
				new string[]{"Cube", "Sphere"}));
			Assert.That (SL.Enumerable.SequenceEqual (
				new string[]{"Sphere", "Cube"}.OrderBy (x => x.Length).ThenBy (x => x),
				new string[]{"Cube", "Sphere"}));
			Assert.That (SL.Enumerable.SequenceEqual (
				new string[]{"Cube", "Capsule"}.OrderBy (x => x.Length).ThenBy (x => x),
				new string[]{"Cube", "Capsule"}));
			Assert.That (SL.Enumerable.SequenceEqual (
				new string[]{"Capsule", "Cube"}.OrderBy (x => x.Length).ThenBy (x => x),
				new string[]{"Cube", "Capsule"}));

			Assert.That (SL.Enumerable.SequenceEqual (
				new string[]{"Cube", "Sphere"}.OrderBy (x => x).ThenBy (x => x.Length),
				new string[]{"Cube", "Sphere"}));
			Assert.That (SL.Enumerable.SequenceEqual (
				new string[]{"Sphere", "Cube"}.OrderBy (x => x).ThenBy (x => x.Length),
				new string[]{"Cube", "Sphere"}));
			Assert.That (SL.Enumerable.SequenceEqual (
				new string[]{"Cube", "Capsule"}.OrderBy (x => x).ThenBy (x => x.Length),
				new string[]{"Capsule", "Cube"}));
			Assert.That (SL.Enumerable.SequenceEqual (
				new string[]{"Capsule", "Cube"}.OrderBy (x => x).ThenBy (x => x.Length),
				new string[]{"Capsule", "Cube"}));

			Assert.That (SL.Enumerable.SequenceEqual (
				new string[]{"Cube", "Sphere"}.OrderBy (x => x.Length).ThenBy (x => x.Length),
				new string[]{"Cube", "Sphere"}));
			Assert.That (SL.Enumerable.SequenceEqual (
				new string[]{"Sphere", "Cube"}.OrderBy (x => x.Length).ThenBy (x => x.Length),
				new string[]{"Cube", "Sphere"}));
			Assert.That (SL.Enumerable.SequenceEqual (
				new string[]{"Cube", "Capsule"}.OrderBy (x => x.Length).ThenBy (x => x.Length),
				new string[]{"Cube", "Capsule"}));
			Assert.That (SL.Enumerable.SequenceEqual (
				new string[]{"Capsule", "Cube"}.OrderBy (x => x.Length).ThenBy (x => x.Length),
				new string[]{"Cube", "Capsule"}));

			Assert.That (SL.Enumerable.SequenceEqual (
				new string[]{"Cube", "Cube"}.OrderBy (x => x).ThenBy (x => x),
				new string[]{"Cube", "Cube"}));
			Assert.That (SL.Enumerable.SequenceEqual (
				new string[]{"Cube", "Cube"}.OrderBy (x => x.Length).ThenBy (x => x),
				new string[]{"Cube", "Cube"}));
			Assert.That (SL.Enumerable.SequenceEqual (
				new string[]{"Cube", "Cube"}.OrderBy (x => x).ThenBy (x => x.Length),
				new string[]{"Cube", "Cube"}));
			Assert.That (SL.Enumerable.SequenceEqual (
				new string[]{"Cube", "Cube"}.OrderBy (x => x.Length).ThenBy (x => x.Length),
				new string[]{"Cube", "Cube"}));
		}
		#endregion

		#region three_value_type_seqence
		[Test]
		public void TestValueTypeOrderByValueKeyThenByValueKeyThreeSequence ()
		{
			Assert.That (SL.Enumerable.SequenceEqual (
				new Vector2[]{Vector2.up, Vector2.right, Vector2.one}.OrderBy (v => v.x).ThenBy (v => v.y),
				new Vector2[]{Vector2.up, Vector2.right, Vector2.one}));
			Assert.That (SL.Enumerable.SequenceEqual (
				new Vector2[]{Vector2.up, Vector2.one, Vector2.right}.OrderBy (v => v.x).ThenBy (v => v.y),
				new Vector2[]{Vector2.up, Vector2.right, Vector2.one}));
			Assert.That (SL.Enumerable.SequenceEqual (
				new Vector2[]{Vector2.right, Vector2.up, Vector2.one}.OrderBy (v => v.x).ThenBy (v => v.y),
				new Vector2[]{Vector2.up, Vector2.right, Vector2.one}));
			Assert.That (SL.Enumerable.SequenceEqual (
				new Vector2[]{Vector2.right, Vector2.one, Vector2.up}.OrderBy (v => v.x).ThenBy (v => v.y),
				new Vector2[]{Vector2.up, Vector2.right, Vector2.one}));
			Assert.That (SL.Enumerable.SequenceEqual (
				new Vector2[]{Vector2.one, Vector2.up, Vector2.right}.OrderBy (v => v.x).ThenBy (v => v.y),
				new Vector2[]{Vector2.up, Vector2.right, Vector2.one}));
			Assert.That (SL.Enumerable.SequenceEqual (
				new Vector2[]{Vector2.one, Vector2.right, Vector2.up}.OrderBy (v => v.x).ThenBy (v => v.y),
				new Vector2[]{Vector2.up, Vector2.right, Vector2.one}));

			Assert.That (SL.Enumerable.SequenceEqual (
				new Vector2[]{Vector2.up, Vector2.right, Vector2.one}.OrderBy (v => v.y).ThenBy (v => v.x),
				new Vector2[]{Vector2.right, Vector2.up, Vector2.one}));
			Assert.That (SL.Enumerable.SequenceEqual (
				new Vector2[]{Vector2.up, Vector2.one, Vector2.right}.OrderBy (v => v.y).ThenBy (v => v.x),
				new Vector2[]{Vector2.right, Vector2.up, Vector2.one}));
			Assert.That (SL.Enumerable.SequenceEqual (
				new Vector2[]{Vector2.right, Vector2.up, Vector2.one}.OrderBy (v => v.y).ThenBy (v => v.x),
				new Vector2[]{Vector2.right, Vector2.up, Vector2.one}));
			Assert.That (SL.Enumerable.SequenceEqual (
				new Vector2[]{Vector2.right, Vector2.one, Vector2.up}.OrderBy (v => v.y).ThenBy (v => v.x),
				new Vector2[]{Vector2.right, Vector2.up, Vector2.one}));
			Assert.That (SL.Enumerable.SequenceEqual (
				new Vector2[]{Vector2.one, Vector2.up, Vector2.right}.OrderBy (v => v.y).ThenBy (v => v.x),
				new Vector2[]{Vector2.right, Vector2.up, Vector2.one}));
			Assert.That (SL.Enumerable.SequenceEqual (
				new Vector2[]{Vector2.one, Vector2.right, Vector2.up}.OrderBy (v => v.y).ThenBy (v => v.x),
				new Vector2[]{Vector2.right, Vector2.up, Vector2.one}));

			Assert.That (SL.Enumerable.SequenceEqual (
				new Vector2[]{Vector2.one, Vector2.one, Vector2.up}.OrderBy (v => v.y).ThenBy (v => v.x),
				new Vector2[]{Vector2.up, Vector2.one, Vector2.one}));
			Assert.That (SL.Enumerable.SequenceEqual (
				new Vector2[]{Vector2.one, Vector2.up, Vector2.one}.OrderBy (v => v.y).ThenBy (v => v.x),
				new Vector2[]{Vector2.up, Vector2.one, Vector2.one}));
			Assert.That (SL.Enumerable.SequenceEqual (
				new Vector2[]{Vector2.up, Vector2.one, Vector2.one}.OrderBy (v => v.y).ThenBy (v => v.x),
				new Vector2[]{Vector2.up, Vector2.one, Vector2.one}));

			Assert.That (SL.Enumerable.SequenceEqual (
				new Vector2[]{Vector2.one, Vector2.one, Vector2.up}.OrderBy (v => v.x).ThenBy (v => v.y),
				new Vector2[]{Vector2.up, Vector2.one, Vector2.one}));
			Assert.That (SL.Enumerable.SequenceEqual (
				new Vector2[]{Vector2.one, Vector2.up, Vector2.one}.OrderBy (v => v.x).ThenBy (v => v.y),
				new Vector2[]{Vector2.up, Vector2.one, Vector2.one}));
			Assert.That (SL.Enumerable.SequenceEqual (
				new Vector2[]{Vector2.up, Vector2.one, Vector2.one}.OrderBy (v => v.x).ThenBy (v => v.y),
				new Vector2[]{Vector2.up, Vector2.one, Vector2.one}));

			Assert.That (SL.Enumerable.SequenceEqual (
				new Vector2[]{Vector2.one, Vector2.one, Vector2.one}.OrderBy (v => v.y).ThenBy (v => v.x),
				new Vector2[]{Vector2.one, Vector2.one, Vector2.one}));
			Assert.That (SL.Enumerable.SequenceEqual (
				new Vector2[]{Vector2.one, Vector2.one, Vector2.one}.OrderBy (v => v.x).ThenBy (v => v.y),
				new Vector2[]{Vector2.one, Vector2.one, Vector2.one}));
		}

		[Test]
		public void TestValueTypeOrderByReferenceKeyThenByValueKeyThreeSequence ()
		{
			Assert.That (SL.Enumerable.SequenceEqual (
				new Vector2[]{Vector2.up, Vector2.right, Vector2.one}.OrderBy (v => v.x.ToString ()).ThenBy (v => v.y),
				new Vector2[]{Vector2.up, Vector2.right, Vector2.one}));
			Assert.That (SL.Enumerable.SequenceEqual (
				new Vector2[]{Vector2.up, Vector2.one, Vector2.right}.OrderBy (v => v.x.ToString ()).ThenBy (v => v.y),
				new Vector2[]{Vector2.up, Vector2.right, Vector2.one}));
			Assert.That (SL.Enumerable.SequenceEqual (
				new Vector2[]{Vector2.right, Vector2.up, Vector2.one}.OrderBy (v => v.x.ToString ()).ThenBy (v => v.y),
				new Vector2[]{Vector2.up, Vector2.right, Vector2.one}));
			Assert.That (SL.Enumerable.SequenceEqual (
				new Vector2[]{Vector2.right, Vector2.one, Vector2.up}.OrderBy (v => v.x.ToString ()).ThenBy (v => v.y),
				new Vector2[]{Vector2.up, Vector2.right, Vector2.one}));
			Assert.That (SL.Enumerable.SequenceEqual (
				new Vector2[]{Vector2.one, Vector2.up, Vector2.right}.OrderBy (v => v.x.ToString ()).ThenBy (v => v.y),
				new Vector2[]{Vector2.up, Vector2.right, Vector2.one}));
			Assert.That (SL.Enumerable.SequenceEqual (
				new Vector2[]{Vector2.one, Vector2.right, Vector2.up}.OrderBy (v => v.x.ToString ()).ThenBy (v => v.y),
				new Vector2[]{Vector2.up, Vector2.right, Vector2.one}));

			Assert.That (SL.Enumerable.SequenceEqual (
				new Vector2[]{Vector2.up, Vector2.right, Vector2.one}.OrderBy (v => v.y.ToString ()).ThenBy (v => v.x),
				new Vector2[]{Vector2.right, Vector2.up, Vector2.one}));
			Assert.That (SL.Enumerable.SequenceEqual (
				new Vector2[]{Vector2.up, Vector2.one, Vector2.right}.OrderBy (v => v.y.ToString ()).ThenBy (v => v.x),
				new Vector2[]{Vector2.right, Vector2.up, Vector2.one}));
			Assert.That (SL.Enumerable.SequenceEqual (
				new Vector2[]{Vector2.right, Vector2.up, Vector2.one}.OrderBy (v => v.y.ToString ()).ThenBy (v => v.x),
				new Vector2[]{Vector2.right, Vector2.up, Vector2.one}));
			Assert.That (SL.Enumerable.SequenceEqual (
				new Vector2[]{Vector2.right, Vector2.one, Vector2.up}.OrderBy (v => v.y.ToString ()).ThenBy (v => v.x),
				new Vector2[]{Vector2.right, Vector2.up, Vector2.one}));
			Assert.That (SL.Enumerable.SequenceEqual (
				new Vector2[]{Vector2.one, Vector2.up, Vector2.right}.OrderBy (v => v.y.ToString ()).ThenBy (v => v.x),
				new Vector2[]{Vector2.right, Vector2.up, Vector2.one}));
			Assert.That (SL.Enumerable.SequenceEqual (
				new Vector2[]{Vector2.one, Vector2.right, Vector2.up}.OrderBy (v => v.y.ToString ()).ThenBy (v => v.x),
				new Vector2[]{Vector2.right, Vector2.up, Vector2.one}));

			Assert.That (SL.Enumerable.SequenceEqual (
				new Vector2[]{Vector2.one, Vector2.one, Vector2.up}.OrderBy (v => v.y.ToString ()).ThenBy (v => v.x),
				new Vector2[]{Vector2.up, Vector2.one, Vector2.one}));
			Assert.That (SL.Enumerable.SequenceEqual (
				new Vector2[]{Vector2.one, Vector2.up, Vector2.one}.OrderBy (v => v.y.ToString ()).ThenBy (v => v.x),
				new Vector2[]{Vector2.up, Vector2.one, Vector2.one}));
			Assert.That (SL.Enumerable.SequenceEqual (
				new Vector2[]{Vector2.up, Vector2.one, Vector2.one}.OrderBy (v => v.y.ToString ()).ThenBy (v => v.x),
				new Vector2[]{Vector2.up, Vector2.one, Vector2.one}));

			Assert.That (SL.Enumerable.SequenceEqual (
				new Vector2[]{Vector2.one, Vector2.one, Vector2.up}.OrderBy (v => v.x.ToString ()).ThenBy (v => v.y),
				new Vector2[]{Vector2.up, Vector2.one, Vector2.one}));
			Assert.That (SL.Enumerable.SequenceEqual (
				new Vector2[]{Vector2.one, Vector2.up, Vector2.one}.OrderBy (v => v.x.ToString ()).ThenBy (v => v.y),
				new Vector2[]{Vector2.up, Vector2.one, Vector2.one}));
			Assert.That (SL.Enumerable.SequenceEqual (
				new Vector2[]{Vector2.up, Vector2.one, Vector2.one}.OrderBy (v => v.x.ToString ()).ThenBy (v => v.y),
				new Vector2[]{Vector2.up, Vector2.one, Vector2.one}));

			Assert.That (SL.Enumerable.SequenceEqual (
				new Vector2[]{Vector2.one, Vector2.one, Vector2.one}.OrderBy (v => v.y.ToString ()).ThenBy (v => v.x),
				new Vector2[]{Vector2.one, Vector2.one, Vector2.one}));
			Assert.That (SL.Enumerable.SequenceEqual (
				new Vector2[]{Vector2.one, Vector2.one, Vector2.one}.OrderBy (v => v.x.ToString ()).ThenBy (v => v.y),
				new Vector2[]{Vector2.one, Vector2.one, Vector2.one}));
		}

		[Test]
		public void TestValueTypeOrderByValueKeyThenByReferenceKeyThreeSequence ()
		{
			Assert.That (SL.Enumerable.SequenceEqual (
				new Vector2[]{Vector2.up, Vector2.right, Vector2.one}.OrderBy (v => v.x).ThenBy (v => v.y.ToString ()),
				new Vector2[]{Vector2.up, Vector2.right, Vector2.one}));
			Assert.That (SL.Enumerable.SequenceEqual (
				new Vector2[]{Vector2.up, Vector2.one, Vector2.right}.OrderBy (v => v.x).ThenBy (v => v.y.ToString ()),
				new Vector2[]{Vector2.up, Vector2.right, Vector2.one}));
			Assert.That (SL.Enumerable.SequenceEqual (
				new Vector2[]{Vector2.right, Vector2.up, Vector2.one}.OrderBy (v => v.x).ThenBy (v => v.y.ToString ()),
				new Vector2[]{Vector2.up, Vector2.right, Vector2.one}));
			Assert.That (SL.Enumerable.SequenceEqual (
				new Vector2[]{Vector2.right, Vector2.one, Vector2.up}.OrderBy (v => v.x).ThenBy (v => v.y.ToString ()),
				new Vector2[]{Vector2.up, Vector2.right, Vector2.one}));
			Assert.That (SL.Enumerable.SequenceEqual (
				new Vector2[]{Vector2.one, Vector2.up, Vector2.right}.OrderBy (v => v.x).ThenBy (v => v.y.ToString ()),
				new Vector2[]{Vector2.up, Vector2.right, Vector2.one}));
			Assert.That (SL.Enumerable.SequenceEqual (
				new Vector2[]{Vector2.one, Vector2.right, Vector2.up}.OrderBy (v => v.x).ThenBy (v => v.y.ToString ()),
				new Vector2[]{Vector2.up, Vector2.right, Vector2.one}));

			Assert.That (SL.Enumerable.SequenceEqual (
				new Vector2[]{Vector2.up, Vector2.right, Vector2.one}.OrderBy (v => v.y).ThenBy (v => v.x.ToString ()),
				new Vector2[]{Vector2.right, Vector2.up, Vector2.one}));
			Assert.That (SL.Enumerable.SequenceEqual (
				new Vector2[]{Vector2.up, Vector2.one, Vector2.right}.OrderBy (v => v.y).ThenBy (v => v.x.ToString ()),
				new Vector2[]{Vector2.right, Vector2.up, Vector2.one}));
			Assert.That (SL.Enumerable.SequenceEqual (
				new Vector2[]{Vector2.right, Vector2.up, Vector2.one}.OrderBy (v => v.y).ThenBy (v => v.x.ToString ()),
				new Vector2[]{Vector2.right, Vector2.up, Vector2.one}));
			Assert.That (SL.Enumerable.SequenceEqual (
				new Vector2[]{Vector2.right, Vector2.one, Vector2.up}.OrderBy (v => v.y).ThenBy (v => v.x.ToString ()),
				new Vector2[]{Vector2.right, Vector2.up, Vector2.one}));
			Assert.That (SL.Enumerable.SequenceEqual (
				new Vector2[]{Vector2.one, Vector2.up, Vector2.right}.OrderBy (v => v.y).ThenBy (v => v.x.ToString ()),
				new Vector2[]{Vector2.right, Vector2.up, Vector2.one}));
			Assert.That (SL.Enumerable.SequenceEqual (
				new Vector2[]{Vector2.one, Vector2.right, Vector2.up}.OrderBy (v => v.y).ThenBy (v => v.x.ToString ()),
				new Vector2[]{Vector2.right, Vector2.up, Vector2.one}));

			Assert.That (SL.Enumerable.SequenceEqual (
				new Vector2[]{Vector2.one, Vector2.one, Vector2.up}.OrderBy (v => v.y).ThenBy (v => v.x.ToString ()),
				new Vector2[]{Vector2.up, Vector2.one, Vector2.one}));
			Assert.That (SL.Enumerable.SequenceEqual (
				new Vector2[]{Vector2.one, Vector2.up, Vector2.one}.OrderBy (v => v.y).ThenBy (v => v.x.ToString ()),
				new Vector2[]{Vector2.up, Vector2.one, Vector2.one}));
			Assert.That (SL.Enumerable.SequenceEqual (
				new Vector2[]{Vector2.up, Vector2.one, Vector2.one}.OrderBy (v => v.y).ThenBy (v => v.x.ToString ()),
				new Vector2[]{Vector2.up, Vector2.one, Vector2.one}));

			Assert.That (SL.Enumerable.SequenceEqual (
				new Vector2[]{Vector2.one, Vector2.one, Vector2.up}.OrderBy (v => v.x).ThenBy (v => v.y.ToString ()),
				new Vector2[]{Vector2.up, Vector2.one, Vector2.one}));
			Assert.That (SL.Enumerable.SequenceEqual (
				new Vector2[]{Vector2.one, Vector2.up, Vector2.one}.OrderBy (v => v.x).ThenBy (v => v.y.ToString ()),
				new Vector2[]{Vector2.up, Vector2.one, Vector2.one}));
			Assert.That (SL.Enumerable.SequenceEqual (
				new Vector2[]{Vector2.up, Vector2.one, Vector2.one}.OrderBy (v => v.x).ThenBy (v => v.y.ToString ()),
				new Vector2[]{Vector2.up, Vector2.one, Vector2.one}));

			Assert.That (SL.Enumerable.SequenceEqual (
				new Vector2[]{Vector2.one, Vector2.one, Vector2.one}.OrderBy (v => v.y).ThenBy (v => v.x.ToString ()),
				new Vector2[]{Vector2.one, Vector2.one, Vector2.one}));
			Assert.That (SL.Enumerable.SequenceEqual (
				new Vector2[]{Vector2.one, Vector2.one, Vector2.one}.OrderBy (v => v.x).ThenBy (v => v.y.ToString ()),
				new Vector2[]{Vector2.one, Vector2.one, Vector2.one}));
		}

		[Test]
		public void TestValueTypeOrderByReferenceKeyThenByReferenceKeyThreeSequence ()
		{
			Assert.That (SL.Enumerable.SequenceEqual (
				new Vector2[]{Vector2.up, Vector2.right, Vector2.one}.OrderBy (v => v.x.ToString ()).ThenBy (v => v.y.ToString ()),
				new Vector2[]{Vector2.up, Vector2.right, Vector2.one}));
			Assert.That (SL.Enumerable.SequenceEqual (
				new Vector2[]{Vector2.up, Vector2.one, Vector2.right}.OrderBy (v => v.x.ToString ()).ThenBy (v => v.y.ToString ()),
				new Vector2[]{Vector2.up, Vector2.right, Vector2.one}));
			Assert.That (SL.Enumerable.SequenceEqual (
				new Vector2[]{Vector2.right, Vector2.up, Vector2.one}.OrderBy (v => v.x.ToString ()).ThenBy (v => v.y.ToString ()),
				new Vector2[]{Vector2.up, Vector2.right, Vector2.one}));
			Assert.That (SL.Enumerable.SequenceEqual (
				new Vector2[]{Vector2.right, Vector2.one, Vector2.up}.OrderBy (v => v.x.ToString ()).ThenBy (v => v.y.ToString ()),
				new Vector2[]{Vector2.up, Vector2.right, Vector2.one}));
			Assert.That (SL.Enumerable.SequenceEqual (
				new Vector2[]{Vector2.one, Vector2.up, Vector2.right}.OrderBy (v => v.x.ToString ()).ThenBy (v => v.y.ToString ()),
				new Vector2[]{Vector2.up, Vector2.right, Vector2.one}));
			Assert.That (SL.Enumerable.SequenceEqual (
				new Vector2[]{Vector2.one, Vector2.right, Vector2.up}.OrderBy (v => v.x.ToString ()).ThenBy (v => v.y.ToString ()),
				new Vector2[]{Vector2.up, Vector2.right, Vector2.one}));

			Assert.That (SL.Enumerable.SequenceEqual (
				new Vector2[]{Vector2.up, Vector2.right, Vector2.one}.OrderBy (v => v.y.ToString ()).ThenBy (v => v.x.ToString ()),
				new Vector2[]{Vector2.right, Vector2.up, Vector2.one}));
			Assert.That (SL.Enumerable.SequenceEqual (
				new Vector2[]{Vector2.up, Vector2.one, Vector2.right}.OrderBy (v => v.y.ToString ()).ThenBy (v => v.x.ToString ()),
				new Vector2[]{Vector2.right, Vector2.up, Vector2.one}));
			Assert.That (SL.Enumerable.SequenceEqual (
				new Vector2[]{Vector2.right, Vector2.up, Vector2.one}.OrderBy (v => v.y.ToString ()).ThenBy (v => v.x.ToString ()),
				new Vector2[]{Vector2.right, Vector2.up, Vector2.one}));
			Assert.That (SL.Enumerable.SequenceEqual (
				new Vector2[]{Vector2.right, Vector2.one, Vector2.up}.OrderBy (v => v.y.ToString ()).ThenBy (v => v.x.ToString ()),
				new Vector2[]{Vector2.right, Vector2.up, Vector2.one}));
			Assert.That (SL.Enumerable.SequenceEqual (
				new Vector2[]{Vector2.one, Vector2.up, Vector2.right}.OrderBy (v => v.y.ToString ()).ThenBy (v => v.x.ToString ()),
				new Vector2[]{Vector2.right, Vector2.up, Vector2.one}));
			Assert.That (SL.Enumerable.SequenceEqual (
				new Vector2[]{Vector2.one, Vector2.right, Vector2.up}.OrderBy (v => v.y.ToString ()).ThenBy (v => v.x.ToString ()),
				new Vector2[]{Vector2.right, Vector2.up, Vector2.one}));

			Assert.That (SL.Enumerable.SequenceEqual (
				new Vector2[]{Vector2.one, Vector2.one, Vector2.up}.OrderBy (v => v.y.ToString ()).ThenBy (v => v.x.ToString ()),
				new Vector2[]{Vector2.up, Vector2.one, Vector2.one}));
			Assert.That (SL.Enumerable.SequenceEqual (
				new Vector2[]{Vector2.one, Vector2.up, Vector2.one}.OrderBy (v => v.y.ToString ()).ThenBy (v => v.x.ToString ()),
				new Vector2[]{Vector2.up, Vector2.one, Vector2.one}));
			Assert.That (SL.Enumerable.SequenceEqual (
				new Vector2[]{Vector2.up, Vector2.one, Vector2.one}.OrderBy (v => v.y.ToString ()).ThenBy (v => v.x.ToString ()),
				new Vector2[]{Vector2.up, Vector2.one, Vector2.one}));

			Assert.That (SL.Enumerable.SequenceEqual (
				new Vector2[]{Vector2.one, Vector2.one, Vector2.up}.OrderBy (v => v.x.ToString ()).ThenBy (v => v.y.ToString ()),
				new Vector2[]{Vector2.up, Vector2.one, Vector2.one}));
			Assert.That (SL.Enumerable.SequenceEqual (
				new Vector2[]{Vector2.one, Vector2.up, Vector2.one}.OrderBy (v => v.x.ToString ()).ThenBy (v => v.y.ToString ()),
				new Vector2[]{Vector2.up, Vector2.one, Vector2.one}));
			Assert.That (SL.Enumerable.SequenceEqual (
				new Vector2[]{Vector2.up, Vector2.one, Vector2.one}.OrderBy (v => v.x.ToString ()).ThenBy (v => v.y.ToString ()),
				new Vector2[]{Vector2.up, Vector2.one, Vector2.one}));

			Assert.That (SL.Enumerable.SequenceEqual (
				new Vector2[]{Vector2.one, Vector2.one, Vector2.one}.OrderBy (v => v.y.ToString ()).ThenBy (v => v.x.ToString ()),
				new Vector2[]{Vector2.one, Vector2.one, Vector2.one}));
			Assert.That (SL.Enumerable.SequenceEqual (
				new Vector2[]{Vector2.one, Vector2.one, Vector2.one}.OrderBy (v => v.x.ToString ()).ThenBy (v => v.y.ToString ()),
				new Vector2[]{Vector2.one, Vector2.one, Vector2.one}));
		}
		#endregion

		#region theree_reference_type_seqence
		[Test]
		public void TestReferenceTypeThreeSequence ()
		{
			Assert.That (SL.Enumerable.SequenceEqual (
				new string[]{"Cube", "Capsule", "Quad"}.OrderBy (x => x).ThenBy (x => x),
				new string[]{"Capsule", "Cube", "Quad"}));
			Assert.That (SL.Enumerable.SequenceEqual (
				new string[]{"Cube", "Quad", "Capsule"}.OrderBy (x => x).ThenBy (x => x),
				new string[]{"Capsule", "Cube", "Quad"}));
			Assert.That (SL.Enumerable.SequenceEqual (
				new string[]{"Capsule", "Cube", "Quad"}.OrderBy (x => x).ThenBy (x => x),
				new string[]{"Capsule", "Cube", "Quad"}));
			Assert.That (SL.Enumerable.SequenceEqual (
				new string[]{"Capsule", "Quad", "Cube"}.OrderBy (x => x).ThenBy (x => x),
				new string[]{"Capsule", "Cube", "Quad"}));
			Assert.That (SL.Enumerable.SequenceEqual (
				new string[]{"Quad", "Cube", "Capsule"}.OrderBy (x => x).ThenBy (x => x),
				new string[]{"Capsule", "Cube", "Quad"}));
			Assert.That (SL.Enumerable.SequenceEqual (
				new string[]{"Quad", "Capsule", "Cube"}.OrderBy (x => x).ThenBy (x => x),
				new string[]{"Capsule", "Cube", "Quad"}));

			Assert.That (SL.Enumerable.SequenceEqual (
				new string[]{"Cube", "Capsule", "Quad"}.OrderBy (x => x.Length).ThenBy (x => x),
				new string[]{"Cube", "Quad", "Capsule"}));
			Assert.That (SL.Enumerable.SequenceEqual (
				new string[]{"Cube", "Quad", "Capsule"}.OrderBy (x => x.Length).ThenBy (x => x),
				new string[]{"Cube", "Quad", "Capsule"}));
			Assert.That (SL.Enumerable.SequenceEqual (
				new string[]{"Capsule", "Cube", "Quad"}.OrderBy (x => x.Length).ThenBy (x => x),
				new string[]{"Cube", "Quad", "Capsule"}));
			Assert.That (SL.Enumerable.SequenceEqual (
				new string[]{"Capsule", "Quad", "Cube"}.OrderBy (x => x.Length).ThenBy (x => x),
				new string[]{"Cube", "Quad", "Capsule"}));
			Assert.That (SL.Enumerable.SequenceEqual (
				new string[]{"Quad", "Cube", "Capsule"}.OrderBy (x => x.Length).ThenBy (x => x),
				new string[]{"Cube", "Quad", "Capsule"}));
			Assert.That (SL.Enumerable.SequenceEqual (
				new string[]{"Quad", "Capsule", "Cube"}.OrderBy (x => x.Length).ThenBy (x => x),
				new string[]{"Cube", "Quad", "Capsule"}));

			Assert.That (SL.Enumerable.SequenceEqual (
				new string[]{"Cube", "Capsule", "Quad"}.OrderBy (x => x).ThenBy (x => x.Length),
				new string[]{"Capsule", "Cube", "Quad"}));
			Assert.That (SL.Enumerable.SequenceEqual (
				new string[]{"Cube", "Quad", "Capsule"}.OrderBy (x => x).ThenBy (x => x.Length),
				new string[]{"Capsule", "Cube", "Quad"}));
			Assert.That (SL.Enumerable.SequenceEqual (
				new string[]{"Capsule", "Cube", "Quad"}.OrderBy (x => x).ThenBy (x => x.Length),
				new string[]{"Capsule", "Cube", "Quad"}));
			Assert.That (SL.Enumerable.SequenceEqual (
				new string[]{"Capsule", "Quad", "Cube"}.OrderBy (x => x).ThenBy (x => x.Length),
				new string[]{"Capsule", "Cube", "Quad"}));
			Assert.That (SL.Enumerable.SequenceEqual (
				new string[]{"Quad", "Cube", "Capsule"}.OrderBy (x => x).ThenBy (x => x.Length),
				new string[]{"Capsule", "Cube", "Quad"}));
			Assert.That (SL.Enumerable.SequenceEqual (
				new string[]{"Quad", "Capsule", "Cube"}.OrderBy (x => x).ThenBy (x => x.Length),
				new string[]{"Capsule", "Cube", "Quad"}));

			Assert.That (SL.Enumerable.SequenceEqual (
				new string[]{"Cube", "Capsule", "Quad"}.OrderBy (x => x.Length).ThenBy (x => x.Length),
				new string[]{"Cube", "Quad", "Capsule"}));
			Assert.That (SL.Enumerable.SequenceEqual (
				new string[]{"Cube", "Quad", "Capsule"}.OrderBy (x => x.Length).ThenBy (x => x.Length),
				new string[]{"Cube", "Quad", "Capsule"}));
			Assert.That (SL.Enumerable.SequenceEqual (
				new string[]{"Capsule", "Cube", "Quad"}.OrderBy (x => x.Length).ThenBy (x => x.Length),
				new string[]{"Cube", "Quad", "Capsule"}));
			Assert.That (SL.Enumerable.SequenceEqual (
				new string[]{"Capsule", "Quad", "Cube"}.OrderBy (x => x.Length).ThenBy (x => x.Length),
				new string[]{"Quad", "Cube", "Capsule"}));
			Assert.That (SL.Enumerable.SequenceEqual (
				new string[]{"Quad", "Cube", "Capsule"}.OrderBy (x => x.Length).ThenBy (x => x.Length),
				new string[]{"Quad", "Cube", "Capsule"}));
			Assert.That (SL.Enumerable.SequenceEqual (
				new string[]{"Quad", "Capsule", "Cube"}.OrderBy (x => x.Length).ThenBy (x => x.Length),
				new string[]{"Quad", "Cube", "Capsule"}));

			Assert.That (SL.Enumerable.SequenceEqual (
				new string[]{"Cube", "Cube", "Capsule"}.OrderBy (x => x).ThenBy (x => x),
				new string[]{"Capsule", "Cube", "Cube"}));
			Assert.That (SL.Enumerable.SequenceEqual (
				new string[]{"Cube", "Capsule", "Cube"}.OrderBy (x => x).ThenBy (x => x),
				new string[]{"Capsule", "Cube", "Cube"}));
			Assert.That (SL.Enumerable.SequenceEqual (
				new string[]{"Capsule", "Cube", "Cube"}.OrderBy (x => x).ThenBy (x => x),
				new string[]{"Capsule", "Cube", "Cube"}));

			Assert.That (SL.Enumerable.SequenceEqual (
				new string[]{"Cube", "Cube", "Capsule"}.OrderBy (x => x.Length).ThenBy (x => x),
				new string[]{"Cube", "Cube", "Capsule"}));
			Assert.That (SL.Enumerable.SequenceEqual (
				new string[]{"Cube", "Capsule", "Cube"}.OrderBy (x => x.Length).ThenBy (x => x),
				new string[]{"Cube", "Cube", "Capsule"}));
			Assert.That (SL.Enumerable.SequenceEqual (
				new string[]{"Capsule", "Cube", "Cube"}.OrderBy (x => x.Length).ThenBy (x => x),
				new string[]{"Cube", "Cube", "Capsule"}));

			Assert.That (SL.Enumerable.SequenceEqual (
				new string[]{"Cube", "Cube", "Capsule"}.OrderBy (x => x).ThenBy (x => x.Length),
				new string[]{"Capsule", "Cube", "Cube"}));
			Assert.That (SL.Enumerable.SequenceEqual (
				new string[]{"Cube", "Capsule", "Cube"}.OrderBy (x => x).ThenBy (x => x.Length),
				new string[]{"Capsule", "Cube", "Cube"}));
			Assert.That (SL.Enumerable.SequenceEqual (
				new string[]{"Capsule", "Cube", "Cube"}.OrderBy (x => x).ThenBy (x => x.Length),
				new string[]{"Capsule", "Cube", "Cube"}));

			Assert.That (SL.Enumerable.SequenceEqual (
				new string[]{"Cube", "Cube", "Capsule"}.OrderBy (x => x.Length).ThenBy (x => x.Length),
				new string[]{"Cube", "Cube", "Capsule"}));
			Assert.That (SL.Enumerable.SequenceEqual (
				new string[]{"Cube", "Capsule", "Cube"}.OrderBy (x => x.Length).ThenBy (x => x.Length),
				new string[]{"Cube", "Cube", "Capsule"}));
			Assert.That (SL.Enumerable.SequenceEqual (
				new string[]{"Capsule", "Cube", "Cube"}.OrderBy (x => x.Length).ThenBy (x => x.Length),
				new string[]{"Cube", "Cube", "Capsule"}));

			Assert.That (SL.Enumerable.SequenceEqual (
				new string[]{"Cube", "Cube", "Cube"}.OrderBy (x => x).ThenBy (x => x),
				new string[]{"Cube", "Cube", "Cube"}));
			Assert.That (SL.Enumerable.SequenceEqual (
				new string[]{"Cube", "Cube", "Cube"}.OrderBy (x => x.Length).ThenBy (x => x),
				new string[]{"Cube", "Cube", "Cube"}));
			Assert.That (SL.Enumerable.SequenceEqual (
				new string[]{"Cube", "Cube", "Cube"}.OrderBy (x => x).ThenBy (x => x.Length),
				new string[]{"Cube", "Cube", "Cube"}));
			Assert.That (SL.Enumerable.SequenceEqual (
				new string[]{"Cube", "Cube", "Cube"}.OrderBy (x => x.Length).ThenBy (x => x.Length),
				new string[]{"Cube", "Cube", "Cube"}));
		}
		#endregion

		[Test]
		public void TestPersonOrdering ()
		{
			Person taroSuzuki = new Person {
				FirstName = "Taro",
				LastName = "Suzuki"
			};
			Person jiroSuzuki = new Person {
				FirstName = "Jiro",
				LastName = "Suzuki"
			};
			Person taroSato = new Person {
				FirstName = "Taro",
				LastName = "Sato"
			};

			List<Person> personList = new List<Person> { taroSuzuki, jiroSuzuki, taroSato };

			Assert.That (SL.Enumerable.SequenceEqual (
				personList.OrderBy (person => person.LastName).ThenBy (person => person.FirstName),
				new []{taroSato, jiroSuzuki, taroSuzuki}));
		}

		public class Person
		{
			public string LastName { get; set; }
			public string FirstName { get; set; }
		}
	}
}
