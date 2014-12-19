using System;
using System.Collections.Generic;
using UniLinq;
using NUnit.Framework;
using SL = System.Linq;

namespace UniLinqTest
{
	[TestFixture]
	[Category("UniLinqTests")]
	class GroupJoinTest
	{
		#region sample_data
		[Test]
		public void TestPlayDataOuterStageDataInnerPlayLog ()
		{
			StageData[] stageDataArray = new StageData[] {
				new StageData { Id = 0, Name = "Stage0"},
				new StageData { Id = 1, Name = "Stage1"},
				new StageData { Id = 2, Name =  "Stage2"},
			};

			PlayLog[] playLogArray = new PlayLog[]{
				new PlayLog { StageId = 0, Score = 1},
				new PlayLog { StageId = 1, Score = 2},
				new PlayLog { StageId = 2, Score = 3},
				new PlayLog { StageId = 0, Score = 4},
				new PlayLog { StageId = 1, Score = 5},
				new PlayLog { StageId = 1, Score = 6},
				new PlayLog { StageId = 2, Score = 7},
			};

			IEnumerable<StagePlayData> stagePlayDataEnumerable = stageDataArray.GroupJoin<StageData, PlayLog, int, StagePlayData> (
				inner: playLogArray,
				outerKeySelector: (StageData stageData) => stageData.Id,
				innerKeySelector: (PlayLog playLog) => playLog.StageId,
				resultSelector: (StageData stageData, IEnumerable<PlayLog> playLogs) =>
					new StagePlayData {
						StageName = stageData.Name,
						ScoreList = playLogs.Select (it => it.Score).ToList ()
					}
			);

			Assert.That (stagePlayDataEnumerable.Count (), Is.EqualTo (3));

			Assert.That (stagePlayDataEnumerable.ElementAt (0).StageName, Is.EqualTo ("Stage0"));
			Assert.That (SL.Enumerable.SequenceEqual (stagePlayDataEnumerable.ElementAt (0).ScoreList, new [] {
				1,
				4
			}));

			Assert.That (stagePlayDataEnumerable.ElementAt (1).StageName, Is.EqualTo ("Stage1"));
			Assert.That (SL.Enumerable.SequenceEqual (stagePlayDataEnumerable.ElementAt (1).ScoreList, new [] {
				2,
				5,
				6
			}));

			Assert.That (stagePlayDataEnumerable.ElementAt (2).StageName, Is.EqualTo ("Stage2"));
			Assert.That (SL.Enumerable.SequenceEqual (stagePlayDataEnumerable.ElementAt (2).ScoreList, new [] {
				3,
				7
			}));
		}
		#endregion

		#region value_outer_value_inner
		[Test]
		public void ValueOuter_ValueInner_ValueKey_ValueResult ()
		{
			int[] outer = new [] {0, 1, 2, 3, 4, 5, 6};
			int[] inner = new [] {0, 1, 2, 3, 4, 5, 6};

			IEnumerable<int> result = outer.GroupJoin<int, int, int, int> (inner: inner, outerKeySelector: it => it, innerKeySelector: it => it, resultSelector: (o, i) => o);
			Assert.That (result.Count (), Is.EqualTo (result.Count ()));
			for (int i = 0; i < outer.Length; i++) {
				Assert.That (outer [i], Is.EqualTo (result.ElementAt (i)));
			}
		}

		[Test]
		public void ValueOuter_ValueInner_ValueKey_ReferenceResult ()
		{
			int[] outer = new [] {0, 1, 2, 3, 4, 5, 6};
			int[] inner = new [] {0, 1, 2, 3, 4, 5, 6};

			IEnumerable<string> result = outer.GroupJoin<int, int, int, string> (inner: inner, outerKeySelector: it => it, innerKeySelector: it => it, resultSelector: (o, i) => o.ToString ());
			Assert.That (result.Count (), Is.EqualTo (result.Count ()));
			for (int i = 0; i < outer.Length; i++) {
				string value = outer [i].ToString ();
				Assert.That (value, Is.EqualTo (result.ElementAt (i)));
			}
		}

		[Test]
		public void ValueOuter_ValueInner_ReferenceKey_ValueResult ()
		{
			int[] outer = new [] {0, 1, 2, 3, 4, 5, 6};
			int[] inner = new [] {0, 1, 2, 3, 4, 5, 6};

			IEnumerable<int> result = outer.GroupJoin<int, int, string, int> (inner: inner, outerKeySelector: it => it.ToString (), innerKeySelector: it => it.ToString (), resultSelector: (o, i) => o);
			Assert.That (result.Count (), Is.EqualTo (result.Count ()));
			for (int i = 0; i < outer.Length; i++) {
				Assert.That (outer [i], Is.EqualTo (result.ElementAt (i)));
			}
		}

		[Test]
		public void ValueOuterValueInner__ReferenceKey_ReferenceResult ()
		{
			int[] outer = new [] {0, 1, 2, 3, 4, 5, 6};
			int[] inner = new [] {0, 1, 2, 3, 4, 5, 6};

			IEnumerable<string> result = outer.GroupJoin<int, int, string, string> (inner: inner, outerKeySelector: it => it.ToString (), innerKeySelector: it => it.ToString (), resultSelector: (o, i) => o.ToString ());
			Assert.That (result.Count (), Is.EqualTo (result.Count ()));
			for (int i = 0; i < outer.Length; i++) {
				string value = outer [i].ToString ();
				Assert.That (value, Is.EqualTo (result.ElementAt (i)));
			}
		}
		#endregion

		#region value_outer_reference_inner

		[Test]
		public void ValueOuter_ReferenceInner_ValueKey_ValueResult ()
		{
			int[] outer = new [] {0, 1, 2, 3, 4, 5, 6};
			string[] inner = new [] {"0", "1", "2", "3", "4", "5", "6"};

			IEnumerable<int> result = outer.GroupJoin<int, string, int, int> (inner: inner, outerKeySelector: it => it, innerKeySelector: it => int.Parse (it), resultSelector: (o, i) => o);

			Assert.That (result.Count (), Is.EqualTo (result.Count ()));
			for (int i = 0; i < outer.Length; i++) {
				Assert.That (outer [i], Is.EqualTo (result.ElementAt (i)));
			}
		}

		[Test]
		public void ValueOuter_ReferenceInner_ValueKey_ReferenceResult ()
		{
			int[] outer = new [] {0, 1, 2, 3, 4, 5, 6};
			string[] inner = new [] {"0", "1", "2", "3", "4", "5", "6"};

			IEnumerable<string> result = outer.GroupJoin<int, string, int, string> (inner: inner, outerKeySelector: it => it, innerKeySelector: it => int.Parse (it), resultSelector: (o, i) => o.ToString ());

			Assert.That (result.Count (), Is.EqualTo (result.Count ()));
			for (int i = 0; i < outer.Length; i++) {
				string value = outer [i].ToString ();
				Assert.That (value, Is.EqualTo (result.ElementAt (i)));
			}
		}

		[Test]
		public void ValueOuter_ReferenceInner_ReferenceKey_ValueResult ()
		{
			int[] outer = new [] {0, 1, 2, 3, 4, 5, 6};
			string[] inner = new [] {"0", "1", "2", "3", "4", "5", "6"};

			IEnumerable<int> result = outer.GroupJoin<int, string, string, int> (inner: inner, outerKeySelector: it => it.ToString (), innerKeySelector: it => it, resultSelector: (o, i) => o);

			Assert.That (result.Count (), Is.EqualTo (result.Count ()));
			for (int i = 0; i < outer.Length; i++) {
				Assert.That (outer [i], Is.EqualTo (result.ElementAt (i)));
			}
		}

		[Test]
		public void ValueOuter_ReferenceInner_ReferenceKey_ReferenceResult ()
		{
			int[] outer = new [] {0, 1, 2, 3, 4, 5, 6};
			string[] inner = new [] {"0", "1", "2", "3", "4", "5", "6"};

			IEnumerable<string> result = outer.GroupJoin<int, string, string, string> (inner: inner, outerKeySelector: it => it.ToString (), innerKeySelector: it => it, resultSelector: (o, i) => o.ToString ());

			Assert.That (result.Count (), Is.EqualTo (result.Count ()));
			for (int i = 0; i < outer.Length; i++) {
				string value = outer [i].ToString ();
				Assert.That (value, Is.EqualTo (result.ElementAt (i)));
			}
		}
		#endregion

		#region reference_outer_value_inner
		[Test]
		public void ReferenceOuter_ValueInner_ValueKey_ValueResult ()
		{
			string[] outer = new [] {"0", "1", "2", "3", "4", "5", "6"};
			int[] inner = new [] {0, 1, 2, 3, 4, 5, 6};

			IEnumerable<int> result = outer.GroupJoin<string, int, int, int> (inner: inner, outerKeySelector: it => int.Parse (it), innerKeySelector: it => it, resultSelector: (o, i) => int.Parse (o));
			Assert.That (result.Count (), Is.EqualTo (result.Count ()));
			for (int i = 0; i < outer.Length; i++) {
				int value = int.Parse (outer [i]);
				Assert.That (value, Is.EqualTo (result.ElementAt (i)));
			}
		}

		[Test]
		public void ReferenceOuter_ValueInner_ValueKey_ReferenceResult ()
		{
			string[] outer = new [] {"0", "1", "2", "3", "4", "5", "6"};
			int[] inner = new [] {0, 1, 2, 3, 4, 5, 6};

			IEnumerable<string> result = outer.GroupJoin<string, int, int, string> (inner: inner, outerKeySelector: it => int.Parse (it), innerKeySelector: it => it, resultSelector: (o, i) => o);
			Assert.That (result.Count (), Is.EqualTo (result.Count ()));
			for (int i = 0; i < outer.Length; i++) {
				Assert.That (outer [i], Is.EqualTo (result.ElementAt (i)));
			}
		}

		[Test]
		public void ReferenceOuter_ValueInner_ReferenceKey_ValueResult ()
		{
			string[] outer = new [] {"0", "1", "2", "3", "4", "5", "6"};
			int[] inner = new [] {0, 1, 2, 3, 4, 5, 6};

			IEnumerable<int> result = outer.GroupJoin<string, int, string, int> (inner: inner, outerKeySelector: it => it, innerKeySelector: it => it.ToString (), resultSelector: (o, i) => int.Parse (o));
			Assert.That (result.Count (), Is.EqualTo (result.Count ()));
			for (int i = 0; i < outer.Length; i++) {
				int value = int.Parse (outer [i]);
				Assert.That (value, Is.EqualTo (result.ElementAt (i)));
			}
		}

		[Test]
		public void ReferenceOuter_ValueInner_ReferenceKey_ReferenceResult ()
		{
			string[] outer = new [] {"0", "1", "2", "3", "4", "5", "6"};
			int[] inner = new [] {0, 1, 2, 3, 4, 5, 6};

			IEnumerable<string> result = outer.GroupJoin<string, int, string, string> (inner: inner, outerKeySelector: it => it, innerKeySelector: it => it.ToString (), resultSelector: (o, i) => o);
			Assert.That (result.Count (), Is.EqualTo (result.Count ()));
			for (int i = 0; i < outer.Length; i++) {
				Assert.That (outer [i], Is.EqualTo (result.ElementAt (i)));
			}
		}
		#endregion

		#region reference_outer_reference_inner
		[Test]
		public void ReferenceOuter_ReferenceInner_ValueKey_ValueResult ()
		{
			string[] outer = new [] {"0", "1", "2", "3", "4", "5", "6"};
			string[] inner = new [] {"0", "1", "2", "3", "4", "5", "6"};

			IEnumerable<int> result = outer.GroupJoin<string, string, int, int> (inner: inner, outerKeySelector: it => int.Parse (it), innerKeySelector: it => int.Parse (it), resultSelector: (o, i) => int.Parse (o));
			Assert.That (result.Count (), Is.EqualTo (result.Count ()));
			for (int i = 0; i < outer.Length; i++) {
				int value = int.Parse (outer [i]);
				Assert.That (value, Is.EqualTo (result.ElementAt (i)));
			}
		}

		[Test]
		public void ReferenceOuter_ReferenceInner_ValueKey_ReferenceResult ()
		{
			string[] outer = new [] {"0", "1", "2", "3", "4", "5", "6"};
			string[] inner = new [] {"0", "1", "2", "3", "4", "5", "6"};

			IEnumerable<string> result = outer.GroupJoin<string, string, int, string> (inner: inner, outerKeySelector: it => int.Parse (it), innerKeySelector: it => int.Parse (it), resultSelector: (o, i) => o);
			Assert.That (result.Count (), Is.EqualTo (result.Count ()));
			for (int i = 0; i < outer.Length; i++) {
				Assert.That (outer [i], Is.EqualTo (result.ElementAt (i)));
			}
		}

		[Test]
		public void ReferenceOuter_ReferenceInner_ReferenceKey_ValueResult ()
		{
			string[] outer = new [] {"0", "1", "2", "3", "4", "5", "6"};
			string[] inner = new [] {"0", "1", "2", "3", "4", "5", "6"};

			IEnumerable<int> result = outer.GroupJoin<string, string, string, int> (inner: inner, outerKeySelector: it => it, innerKeySelector: it => it, resultSelector: (o, i) => int.Parse (o));
			Assert.That (result.Count (), Is.EqualTo (result.Count ()));
			for (int i = 0; i < outer.Length; i++) {
				int value = int.Parse (outer [i]);
				Assert.That (value, Is.EqualTo (result.ElementAt (i)));
			}
		}

		[Test]
		public void ReferenceOuter_ReferenceInner_ReferenceKey_ReferenceResult ()
		{
			string[] outer = new [] {"0", "1", "2", "3", "4", "5", "6"};
			string[] inner = new [] {"0", "1", "2", "3", "4", "5", "6"};

			IEnumerable<string> result = outer.GroupJoin<string, string, string, string> (inner: inner, outerKeySelector: it => it, innerKeySelector: it => it, resultSelector: (o, i) => o);
			Assert.That (result.Count (), Is.EqualTo (result.Count ()));
			for (int i = 0; i < outer.Length; i++) {
				Assert.That (outer [i], Is.EqualTo (result.ElementAt (i)));
			}
		}
		#endregion

		#region value_outer_value_inner_comparer
		[Test]
		public void ValueOuter_ValueInner_ValueKey_ValueResult_Comparer ()
		{
			IEqualityComparer<int> comparer = EqualityComparer<int>.Default;
			int[] outer = new [] {0, 1, 2, 3, 4, 5, 6};
			int[] inner = new [] {0, 1, 2, 3, 4, 5, 6};

			IEnumerable<int> result = outer.GroupJoin<int, int, int, int> (inner: inner, outerKeySelector: it => it, innerKeySelector: it => it, resultSelector: (o, i) => o, comparer: comparer);
			Assert.That (result.Count (), Is.EqualTo (result.Count ()));
			for (int i = 0; i < outer.Length; i++) {
				Assert.That (outer [i], Is.EqualTo (result.ElementAt (i)));
			}
		}

		[Test]
		public void ValueOuter_ValueInner_ValueKey_ReferenceResult_Comparer ()
		{
			IEqualityComparer<int> comparer = EqualityComparer<int>.Default;
			int[] outer = new [] {0, 1, 2, 3, 4, 5, 6};
			int[] inner = new [] {0, 1, 2, 3, 4, 5, 6};

			IEnumerable<string> result = outer.GroupJoin<int, int, int, string> (inner: inner, outerKeySelector: it => it, innerKeySelector: it => it, resultSelector: (o, i) => o.ToString (), comparer: comparer);
			Assert.That (result.Count (), Is.EqualTo (result.Count ()));
			for (int i = 0; i < outer.Length; i++) {
				string value = outer [i].ToString ();
				Assert.That (value, Is.EqualTo (result.ElementAt (i)));
			}
		}

		[Test]
		public void ValueOuter_ValueInner_ReferenceKey_ValueResult_Comparer ()
		{
			IEqualityComparer<string> comparer = EqualityComparer<string>.Default;
			int[] outer = new [] {0, 1, 2, 3, 4, 5, 6};
			int[] inner = new [] {0, 1, 2, 3, 4, 5, 6};

			IEnumerable<int> result = outer.GroupJoin<int, int, string, int> (inner: inner, outerKeySelector: it => it.ToString (), innerKeySelector: it => it.ToString (), resultSelector: (o, i) => o, comparer: comparer);
			Assert.That (result.Count (), Is.EqualTo (result.Count ()));
			for (int i = 0; i < outer.Length; i++) {
				Assert.That (outer [i], Is.EqualTo (result.ElementAt (i)));
			}
		}

		[Test]
		public void ValueOuterValueInner__ReferenceKey_ReferenceResult_Comparer ()
		{
			IEqualityComparer<string> comparer = EqualityComparer<string>.Default;
			int[] outer = new [] {0, 1, 2, 3, 4, 5, 6};
			int[] inner = new [] {0, 1, 2, 3, 4, 5, 6};

			IEnumerable<string> result = outer.GroupJoin<int, int, string, string> (inner: inner, outerKeySelector: it => it.ToString (), innerKeySelector: it => it.ToString (), resultSelector: (o, i) => o.ToString (), comparer: comparer);
			Assert.That (result.Count (), Is.EqualTo (result.Count ()));
			for (int i = 0; i < outer.Length; i++) {
				string value = outer [i].ToString ();
				Assert.That (value, Is.EqualTo (result.ElementAt (i)));
			}
		}
		#endregion

		#region value_outer_reference_inner_comparer

		[Test]
		public void ValueOuter_ReferenceInner_ValueKey_ValueResult_Comparer ()
		{
			IEqualityComparer<int> comparer = EqualityComparer<int>.Default;
			int[] outer = new [] {0, 1, 2, 3, 4, 5, 6};
			string[] inner = new [] {"0", "1", "2", "3", "4", "5", "6"};

			IEnumerable<int> result = outer.GroupJoin<int, string, int, int> (inner: inner, outerKeySelector: it => it, innerKeySelector: it => int.Parse (it), resultSelector: (o, i) => o, comparer: comparer);

			Assert.That (result.Count (), Is.EqualTo (result.Count ()));
			for (int i = 0; i < outer.Length; i++) {
				Assert.That (outer [i], Is.EqualTo (result.ElementAt (i)));
			}
		}

		[Test]
		public void ValueOuter_ReferenceInner_ValueKey_ReferenceResult_Comparer ()
		{
			IEqualityComparer<int> comparer = EqualityComparer<int>.Default;
			int[] outer = new [] {0, 1, 2, 3, 4, 5, 6};
			string[] inner = new [] {"0", "1", "2", "3", "4", "5", "6"};

			IEnumerable<string> result = outer.GroupJoin<int, string, int, string> (inner: inner, outerKeySelector: it => it, innerKeySelector: it => int.Parse (it), resultSelector: (o, i) => o.ToString (), comparer: comparer);

			Assert.That (result.Count (), Is.EqualTo (result.Count ()));
			for (int i = 0; i < outer.Length; i++) {
				string value = outer [i].ToString ();
				Assert.That (value, Is.EqualTo (result.ElementAt (i)));
			}
		}

		[Test]
		public void ValueOuter_ReferenceInner_ReferenceKey_ValueResult_Comparer ()
		{
			IEqualityComparer<string> comparer = EqualityComparer<string>.Default;
			int[] outer = new [] {0, 1, 2, 3, 4, 5, 6};
			string[] inner = new [] {"0", "1", "2", "3", "4", "5", "6"};

			IEnumerable<int> result = outer.GroupJoin<int, string, string, int> (inner: inner, outerKeySelector: it => it.ToString (), innerKeySelector: it => it, resultSelector: (o, i) => o, comparer: comparer);

			Assert.That (result.Count (), Is.EqualTo (result.Count ()));
			for (int i = 0; i < outer.Length; i++) {
				Assert.That (outer [i], Is.EqualTo (result.ElementAt (i)));
			}
		}

		[Test]
		public void ValueOuter_ReferenceInner_ReferenceKey_ReferenceResult_Comparer ()
		{
			IEqualityComparer<string> comparer = EqualityComparer<string>.Default;
			int[] outer = new [] {0, 1, 2, 3, 4, 5, 6};
			string[] inner = new [] {"0", "1", "2", "3", "4", "5", "6"};

			IEnumerable<string> result = outer.GroupJoin<int, string, string, string> (inner: inner, outerKeySelector: it => it.ToString (), innerKeySelector: it => it, resultSelector: (o, i) => o.ToString (), comparer: comparer);

			Assert.That (result.Count (), Is.EqualTo (result.Count ()));
			for (int i = 0; i < outer.Length; i++) {
				string value = outer [i].ToString ();
				Assert.That (value, Is.EqualTo (result.ElementAt (i)));
			}
		}
		#endregion

		#region reference_outer_value_inner_comparer
		[Test]
		public void ReferenceOuter_ValueInner_ValueKey_ValueResult_Comparer ()
		{
			IEqualityComparer<int> comparer = EqualityComparer<int>.Default;
			string[] outer = new [] {"0", "1", "2", "3", "4", "5", "6"};
			int[] inner = new [] {0, 1, 2, 3, 4, 5, 6};

			IEnumerable<int> result = outer.GroupJoin<string, int, int, int> (inner: inner, outerKeySelector: it => int.Parse (it), innerKeySelector: it => it, resultSelector: (o, i) => int.Parse (o), comparer: comparer);
			Assert.That (result.Count (), Is.EqualTo (result.Count ()));
			for (int i = 0; i < outer.Length; i++) {
				int value = int.Parse (outer [i]);
				Assert.That (value, Is.EqualTo (result.ElementAt (i)));
			}
		}

		[Test]
		public void ReferenceOuter_ValueInner_ValueKey_ReferenceResult_Comparer ()
		{
			IEqualityComparer<int> comparer = EqualityComparer<int>.Default;
			string[] outer = new [] {"0", "1", "2", "3", "4", "5", "6"};
			int[] inner = new [] {0, 1, 2, 3, 4, 5, 6};

			IEnumerable<string> result = outer.GroupJoin<string, int, int, string> (inner: inner, outerKeySelector: it => int.Parse (it), innerKeySelector: it => it, resultSelector: (o, i) => o, comparer: comparer);
			Assert.That (result.Count (), Is.EqualTo (result.Count ()));
			for (int i = 0; i < outer.Length; i++) {
				Assert.That (outer [i], Is.EqualTo (result.ElementAt (i)));
			}
		}

		[Test]
		public void ReferenceOuter_ValueInner_ReferenceKey_ValueResult_Comparer ()
		{
			IEqualityComparer<string> comparer = EqualityComparer<string>.Default;
			string[] outer = new [] {"0", "1", "2", "3", "4", "5", "6"};
			int[] inner = new [] {0, 1, 2, 3, 4, 5, 6};

			IEnumerable<int> result = outer.GroupJoin<string, int, string, int> (inner: inner, outerKeySelector: it => it, innerKeySelector: it => it.ToString (), resultSelector: (o, i) => int.Parse (o), comparer: comparer);
			Assert.That (result.Count (), Is.EqualTo (result.Count ()));
			for (int i = 0; i < outer.Length; i++) {
				int value = int.Parse (outer [i]);
				Assert.That (value, Is.EqualTo (result.ElementAt (i)));
			}
		}

		[Test]
		public void ReferenceOuter_ValueInner_ReferenceKey_ReferenceResult_Comparer ()
		{
			IEqualityComparer<string> comparer = EqualityComparer<string>.Default;
			string[] outer = new [] {"0", "1", "2", "3", "4", "5", "6"};
			int[] inner = new [] {0, 1, 2, 3, 4, 5, 6};

			IEnumerable<string> result = outer.GroupJoin<string, int, string, string> (inner: inner, outerKeySelector: it => it, innerKeySelector: it => it.ToString (), resultSelector: (o, i) => o, comparer: comparer);
			Assert.That (result.Count (), Is.EqualTo (result.Count ()));
			for (int i = 0; i < outer.Length; i++) {
				Assert.That (outer [i], Is.EqualTo (result.ElementAt (i)));
			}
		}
		#endregion

		#region reference_outer_reference_inner_comparer
		[Test]
		public void ReferenceOuter_ReferenceInner_ValueKey_ValueResult_Comparer ()
		{
			IEqualityComparer<int> comparer = EqualityComparer<int>.Default;
			string[] outer = new [] {"0", "1", "2", "3", "4", "5", "6"};
			string[] inner = new [] {"0", "1", "2", "3", "4", "5", "6"};

			IEnumerable<int> result = outer.GroupJoin<string, string, int, int> (inner: inner, outerKeySelector: it => int.Parse (it), innerKeySelector: it => int.Parse (it), resultSelector: (o, i) => int.Parse (o), comparer: comparer);
			Assert.That (result.Count (), Is.EqualTo (result.Count ()));
			for (int i = 0; i < outer.Length; i++) {
				int value = int.Parse (outer [i]);
				Assert.That (value, Is.EqualTo (result.ElementAt (i)));
			}
		}

		[Test]
		public void ReferenceOuter_ReferenceInner_ValueKey_ReferenceResult_Comparer ()
		{
			IEqualityComparer<int> comparer = EqualityComparer<int>.Default;
			string[] outer = new [] {"0", "1", "2", "3", "4", "5", "6"};
			string[] inner = new [] {"0", "1", "2", "3", "4", "5", "6"};

			IEnumerable<string> result = outer.GroupJoin<string, string, int, string> (inner: inner, outerKeySelector: it => int.Parse (it), innerKeySelector: it => int.Parse (it), resultSelector: (o, i) => o, comparer: comparer);
			Assert.That (result.Count (), Is.EqualTo (result.Count ()));
			for (int i = 0; i < outer.Length; i++) {
				Assert.That (outer [i], Is.EqualTo (result.ElementAt (i)));
			}
		}

		[Test]
		public void ReferenceOuter_ReferenceInner_ReferenceKey_ValueResult_Comparer ()
		{
			IEqualityComparer<string> comparer = EqualityComparer<string>.Default;
			string[] outer = new [] {"0", "1", "2", "3", "4", "5", "6"};
			string[] inner = new [] {"0", "1", "2", "3", "4", "5", "6"};

			IEnumerable<int> result = outer.GroupJoin<string, string, string, int> (inner: inner, outerKeySelector: it => it, innerKeySelector: it => it, resultSelector: (o, i) => int.Parse (o), comparer: comparer);
			Assert.That (result.Count (), Is.EqualTo (result.Count ()));
			for (int i = 0; i < outer.Length; i++) {
				int value = int.Parse (outer [i]);
				Assert.That (value, Is.EqualTo (result.ElementAt (i)));
			}
		}

		[Test]
		public void ReferenceOuter_ReferenceInner_ReferenceKey_ReferenceResult_Comparer ()
		{
			IEqualityComparer<string> comparer = EqualityComparer<string>.Default;
			string[] outer = new [] {"0", "1", "2", "3", "4", "5", "6"};
			string[] inner = new [] {"0", "1", "2", "3", "4", "5", "6"};

			IEnumerable<string> result = outer.GroupJoin<string, string, string, string> (inner: inner, outerKeySelector: it => it, innerKeySelector: it => it, resultSelector: (o, i) => o, comparer: comparer);
			Assert.That (result.Count (), Is.EqualTo (result.Count ()));
			for (int i = 0; i < outer.Length; i++) {
				Assert.That (outer [i], Is.EqualTo (result.ElementAt (i)));
			}
		}
		#endregion

		#region null_exception
		[Test]
		public void TestArgumentNullException ()
		{
			int[] outer = new [] {0, 1, 2, 3, 4, 5, 6};
			int[] inner = new [] {0, 1, 2, 3, 4, 5, 6};
			Func<int, int> intToInt = it => it;
			Func<int, IEnumerable<int>, int> intIntEnumerableToInt = (o, i) => o;

			Assert.Throws<ArgumentNullException> (() => Enumerable.GroupJoin<int, int, int, int> (outer, inner, intToInt, intToInt, null));
			Assert.Throws<ArgumentNullException> (() => Enumerable.GroupJoin<int, int, int, int> (outer, inner, intToInt, null, intIntEnumerableToInt));
			Assert.Throws<ArgumentNullException> (() => Enumerable.GroupJoin<int, int, int, int> (outer, inner, intToInt, null, null));
			Assert.Throws<ArgumentNullException> (() => Enumerable.GroupJoin<int, int, int, int> (outer, inner, null, intToInt, intIntEnumerableToInt));
			Assert.Throws<ArgumentNullException> (() => Enumerable.GroupJoin<int, int, int, int> (outer, inner, null, intToInt, null));
			Assert.Throws<ArgumentNullException> (() => Enumerable.GroupJoin<int, int, int, int> (outer, inner, null, null, intIntEnumerableToInt));
			Assert.Throws<ArgumentNullException> (() => Enumerable.GroupJoin<int, int, int, int> (outer, inner, null, null, null));
			Assert.Throws<ArgumentNullException> (() => Enumerable.GroupJoin<int, int, int, int> (outer, null, intToInt, intToInt, intIntEnumerableToInt));
			Assert.Throws<ArgumentNullException> (() => Enumerable.GroupJoin<int, int, int, int> (outer, null, intToInt, intToInt, null));
			Assert.Throws<ArgumentNullException> (() => Enumerable.GroupJoin<int, int, int, int> (outer, null, intToInt, null, intIntEnumerableToInt));
			Assert.Throws<ArgumentNullException> (() => Enumerable.GroupJoin<int, int, int, int> (outer, null, intToInt, null, null));
			Assert.Throws<ArgumentNullException> (() => Enumerable.GroupJoin<int, int, int, int> (outer, null, null, intToInt, intIntEnumerableToInt));
			Assert.Throws<ArgumentNullException> (() => Enumerable.GroupJoin<int, int, int, int> (outer, null, null, intToInt, null));
			Assert.Throws<ArgumentNullException> (() => Enumerable.GroupJoin<int, int, int, int> (outer, null, null, null, intIntEnumerableToInt));
			Assert.Throws<ArgumentNullException> (() => Enumerable.GroupJoin<int, int, int, int> (outer, null, null, null, null));
			Assert.Throws<ArgumentNullException> (() => Enumerable.GroupJoin<int, int, int, int> (null, inner, intToInt, intToInt, intIntEnumerableToInt));
			Assert.Throws<ArgumentNullException> (() => Enumerable.GroupJoin<int, int, int, int> (null, inner, intToInt, intToInt, null));
			Assert.Throws<ArgumentNullException> (() => Enumerable.GroupJoin<int, int, int, int> (null, inner, intToInt, null, intIntEnumerableToInt));
			Assert.Throws<ArgumentNullException> (() => Enumerable.GroupJoin<int, int, int, int> (null, inner, intToInt, null, null));
			Assert.Throws<ArgumentNullException> (() => Enumerable.GroupJoin<int, int, int, int> (null, inner, null, intToInt, intIntEnumerableToInt));
			Assert.Throws<ArgumentNullException> (() => Enumerable.GroupJoin<int, int, int, int> (null, inner, null, intToInt, null));
			Assert.Throws<ArgumentNullException> (() => Enumerable.GroupJoin<int, int, int, int> (null, inner, null, null, intIntEnumerableToInt));
			Assert.Throws<ArgumentNullException> (() => Enumerable.GroupJoin<int, int, int, int> (null, inner, null, null, null));
			Assert.Throws<ArgumentNullException> (() => Enumerable.GroupJoin<int, int, int, int> (null, null, intToInt, intToInt, intIntEnumerableToInt));
			Assert.Throws<ArgumentNullException> (() => Enumerable.GroupJoin<int, int, int, int> (null, null, intToInt, intToInt, null));
			Assert.Throws<ArgumentNullException> (() => Enumerable.GroupJoin<int, int, int, int> (null, null, intToInt, null, intIntEnumerableToInt));
			Assert.Throws<ArgumentNullException> (() => Enumerable.GroupJoin<int, int, int, int> (null, null, intToInt, null, null));
			Assert.Throws<ArgumentNullException> (() => Enumerable.GroupJoin<int, int, int, int> (null, null, null, intToInt, intIntEnumerableToInt));
			Assert.Throws<ArgumentNullException> (() => Enumerable.GroupJoin<int, int, int, int> (null, null, null, intToInt, null));
			Assert.Throws<ArgumentNullException> (() => Enumerable.GroupJoin<int, int, int, int> (null, null, null, null, intIntEnumerableToInt));
			Assert.Throws<ArgumentNullException> (() => Enumerable.GroupJoin<int, int, int, int> (null, null, null, null, null));
		}
		#endregion
	}
}
