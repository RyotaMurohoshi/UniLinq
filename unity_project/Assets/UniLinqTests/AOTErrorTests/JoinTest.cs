using System;
using System.Collections.Generic;
using UniLinq;
using NUnit.Framework;

namespace UniLinqTest
{
	[TestFixture]
	[Category("UniLinqTests")]
	class JoinTest
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

			IEnumerable<PlayData> playDataEnumerable = stageDataArray.Join<StageData, PlayLog, int, PlayData> (
				inner: playLogArray,
				outerKeySelector: (StageData stageData) => stageData.Id,
				innerKeySelector: (PlayLog playLog) => playLog.StageId,
				resultSelector: (StageData stageData, PlayLog playLog) => new PlayData { StageName = stageData.Name, Score = playLog.Score});

			Assert.That (playDataEnumerable.Count (), Is.EqualTo (7));

			Assert.That (playDataEnumerable.ElementAt (0).StageName, Is.EqualTo ("Stage0"));
			Assert.That (playDataEnumerable.ElementAt (0).Score, Is.EqualTo (1));

			Assert.That (playDataEnumerable.ElementAt (1).StageName, Is.EqualTo ("Stage0"));
			Assert.That (playDataEnumerable.ElementAt (1).Score, Is.EqualTo (4));

			Assert.That (playDataEnumerable.ElementAt (2).StageName, Is.EqualTo ("Stage1"));
			Assert.That (playDataEnumerable.ElementAt (2).Score, Is.EqualTo (2));

			Assert.That (playDataEnumerable.ElementAt (3).StageName, Is.EqualTo ("Stage1"));
			Assert.That (playDataEnumerable.ElementAt (3).Score, Is.EqualTo (5));

			Assert.That (playDataEnumerable.ElementAt (4).StageName, Is.EqualTo ("Stage1"));
			Assert.That (playDataEnumerable.ElementAt (4).Score, Is.EqualTo (6));

			Assert.That (playDataEnumerable.ElementAt (5).StageName, Is.EqualTo ("Stage2"));
			Assert.That (playDataEnumerable.ElementAt (5).Score, Is.EqualTo (3));

			Assert.That (playDataEnumerable.ElementAt (6).StageName, Is.EqualTo ("Stage2"));
			Assert.That (playDataEnumerable.ElementAt (6).Score, Is.EqualTo (7));
		}

		[Test]
		public void TestPlayDataOuterPlayLogInnerStageData ()
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

			IEnumerable<PlayData> playDataEnumerable = playLogArray.Join<PlayLog, StageData, int, PlayData> (
				inner: stageDataArray,
				outerKeySelector: (PlayLog playLog) => playLog.StageId,
				innerKeySelector: (StageData stageData) => stageData.Id,
				resultSelector: (PlayLog playLog, StageData stageData) => new PlayData { StageName = stageData.Name, Score = playLog.Score});

			Assert.That (playDataEnumerable.Count (), Is.EqualTo (7));

			Assert.That (playDataEnumerable.ElementAt (0).StageName, Is.EqualTo ("Stage0"));
			Assert.That (playDataEnumerable.ElementAt (0).Score, Is.EqualTo (1));

			Assert.That (playDataEnumerable.ElementAt (1).StageName, Is.EqualTo ("Stage1"));
			Assert.That (playDataEnumerable.ElementAt (1).Score, Is.EqualTo (2));

			Assert.That (playDataEnumerable.ElementAt (2).StageName, Is.EqualTo ("Stage2"));
			Assert.That (playDataEnumerable.ElementAt (2).Score, Is.EqualTo (3));

			Assert.That (playDataEnumerable.ElementAt (3).StageName, Is.EqualTo ("Stage0"));
			Assert.That (playDataEnumerable.ElementAt (3).Score, Is.EqualTo (4));

			Assert.That (playDataEnumerable.ElementAt (4).StageName, Is.EqualTo ("Stage1"));
			Assert.That (playDataEnumerable.ElementAt (4).Score, Is.EqualTo (5));

			Assert.That (playDataEnumerable.ElementAt (5).StageName, Is.EqualTo ("Stage1"));
			Assert.That (playDataEnumerable.ElementAt (5).Score, Is.EqualTo (6));

			Assert.That (playDataEnumerable.ElementAt (6).StageName, Is.EqualTo ("Stage2"));
			Assert.That (playDataEnumerable.ElementAt (6).Score, Is.EqualTo (7));
		}
		#endregion

		#region value_outer_value_inner
		[Test]
		public void ValueOuter_ValueInner_ValueKey_ValueResult ()
		{
			int[] outer = new [] {0, 1, 2, 3, 4, 5, 6};
			int[] inner = new [] {0, 1, 2, 3, 4, 5, 6};

			IEnumerable<int> result = outer.Join<int, int, int, int> (inner: inner, outerKeySelector: it => it, innerKeySelector: it => it, resultSelector: (o, i) => o);
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

			IEnumerable<string> result = outer.Join<int, int, int, string> (inner: inner, outerKeySelector: it => it, innerKeySelector: it => it, resultSelector: (o, i) => o.ToString ());
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

			IEnumerable<int> result = outer.Join<int, int, string, int> (inner: inner, outerKeySelector: it => it.ToString (), innerKeySelector: it => it.ToString (), resultSelector: (o, i) => o);
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

			IEnumerable<string> result = outer.Join<int, int, string, string> (inner: inner, outerKeySelector: it => it.ToString (), innerKeySelector: it => it.ToString (), resultSelector: (o, i) => o.ToString ());
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

			IEnumerable<int> result = outer.Join<int, string, int, int> (inner: inner, outerKeySelector: it => it, innerKeySelector: it => int.Parse (it), resultSelector: (o, i) => o);

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

			IEnumerable<string> result = outer.Join<int, string, int, string> (inner: inner, outerKeySelector: it => it, innerKeySelector: it => int.Parse (it), resultSelector: (o, i) => o.ToString ());

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

			IEnumerable<int> result = outer.Join<int, string, string, int> (inner: inner, outerKeySelector: it => it.ToString (), innerKeySelector: it => it, resultSelector: (o, i) => o);

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

			IEnumerable<string> result = outer.Join<int, string, string, string> (inner: inner, outerKeySelector: it => it.ToString (), innerKeySelector: it => it, resultSelector: (o, i) => o.ToString ());

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

			IEnumerable<int> result = outer.Join<string, int, int, int> (inner: inner, outerKeySelector: it => int.Parse (it), innerKeySelector: it => it, resultSelector: (o, i) => int.Parse (o));
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

			IEnumerable<string> result = outer.Join<string, int, int, string> (inner: inner, outerKeySelector: it => int.Parse (it), innerKeySelector: it => it, resultSelector: (o, i) => o);
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

			IEnumerable<int> result = outer.Join<string, int, string, int> (inner: inner, outerKeySelector: it => it, innerKeySelector: it => it.ToString (), resultSelector: (o, i) => int.Parse (o));
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

			IEnumerable<string> result = outer.Join<string, int, string, string> (inner: inner, outerKeySelector: it => it, innerKeySelector: it => it.ToString (), resultSelector: (o, i) => o);
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

			IEnumerable<int> result = outer.Join<string, string, int, int> (inner: inner, outerKeySelector: it => int.Parse (it), innerKeySelector: it => int.Parse (it), resultSelector: (o, i) => int.Parse (o));
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

			IEnumerable<string> result = outer.Join<string, string, int, string> (inner: inner, outerKeySelector: it => int.Parse (it), innerKeySelector: it => int.Parse (it), resultSelector: (o, i) => o);
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

			IEnumerable<int> result = outer.Join<string, string, string, int> (inner: inner, outerKeySelector: it => it, innerKeySelector: it => it, resultSelector: (o, i) => int.Parse (o));
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

			IEnumerable<string> result = outer.Join<string, string, string, string> (inner: inner, outerKeySelector: it => it, innerKeySelector: it => it, resultSelector: (o, i) => o);
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

			IEnumerable<int> result = outer.Join<int, int, int, int> (inner: inner, outerKeySelector: it => it, innerKeySelector: it => it, resultSelector: (o, i) => o, comparer: comparer);
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

			IEnumerable<string> result = outer.Join<int, int, int, string> (inner: inner, outerKeySelector: it => it, innerKeySelector: it => it, resultSelector: (o, i) => o.ToString (), comparer: comparer);
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

			IEnumerable<int> result = outer.Join<int, int, string, int> (inner: inner, outerKeySelector: it => it.ToString (), innerKeySelector: it => it.ToString (), resultSelector: (o, i) => o, comparer: comparer);
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

			IEnumerable<string> result = outer.Join<int, int, string, string> (inner: inner, outerKeySelector: it => it.ToString (), innerKeySelector: it => it.ToString (), resultSelector: (o, i) => o.ToString (), comparer: comparer);
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

			IEnumerable<int> result = outer.Join<int, string, int, int> (inner: inner, outerKeySelector: it => it, innerKeySelector: it => int.Parse (it), resultSelector: (o, i) => o, comparer: comparer);

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

			IEnumerable<string> result = outer.Join<int, string, int, string> (inner: inner, outerKeySelector: it => it, innerKeySelector: it => int.Parse (it), resultSelector: (o, i) => o.ToString (), comparer: comparer);

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

			IEnumerable<int> result = outer.Join<int, string, string, int> (inner: inner, outerKeySelector: it => it.ToString (), innerKeySelector: it => it, resultSelector: (o, i) => o, comparer: comparer);

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

			IEnumerable<string> result = outer.Join<int, string, string, string> (inner: inner, outerKeySelector: it => it.ToString (), innerKeySelector: it => it, resultSelector: (o, i) => o.ToString (), comparer: comparer);

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

			IEnumerable<int> result = outer.Join<string, int, int, int> (inner: inner, outerKeySelector: it => int.Parse (it), innerKeySelector: it => it, resultSelector: (o, i) => int.Parse (o), comparer: comparer);
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

			IEnumerable<string> result = outer.Join<string, int, int, string> (inner: inner, outerKeySelector: it => int.Parse (it), innerKeySelector: it => it, resultSelector: (o, i) => o, comparer: comparer);
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

			IEnumerable<int> result = outer.Join<string, int, string, int> (inner: inner, outerKeySelector: it => it, innerKeySelector: it => it.ToString (), resultSelector: (o, i) => int.Parse (o), comparer: comparer);
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

			IEnumerable<string> result = outer.Join<string, int, string, string> (inner: inner, outerKeySelector: it => it, innerKeySelector: it => it.ToString (), resultSelector: (o, i) => o, comparer: comparer);
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

			IEnumerable<int> result = outer.Join<string, string, int, int> (inner: inner, outerKeySelector: it => int.Parse (it), innerKeySelector: it => int.Parse (it), resultSelector: (o, i) => int.Parse (o), comparer: comparer);
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

			IEnumerable<string> result = outer.Join<string, string, int, string> (inner: inner, outerKeySelector: it => int.Parse (it), innerKeySelector: it => int.Parse (it), resultSelector: (o, i) => o, comparer: comparer);
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

			IEnumerable<int> result = outer.Join<string, string, string, int> (inner: inner, outerKeySelector: it => it, innerKeySelector: it => it, resultSelector: (o, i) => int.Parse (o), comparer: comparer);
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

			IEnumerable<string> result = outer.Join<string, string, string, string> (inner: inner, outerKeySelector: it => it, innerKeySelector: it => it, resultSelector: (o, i) => o, comparer: comparer);
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
			Func<int, int, int> intIntToInt = (o, i) => o;

			Assert.Throws<ArgumentNullException> (() => Enumerable.Join<int, int, int, int> (outer, inner, intToInt, intToInt, null));
			Assert.Throws<ArgumentNullException> (() => Enumerable.Join<int, int, int, int> (outer, inner, intToInt, null, intIntToInt));
			Assert.Throws<ArgumentNullException> (() => Enumerable.Join<int, int, int, int> (outer, inner, intToInt, null, null));
			Assert.Throws<ArgumentNullException> (() => Enumerable.Join<int, int, int, int> (outer, inner, null, intToInt, intIntToInt));
			Assert.Throws<ArgumentNullException> (() => Enumerable.Join<int, int, int, int> (outer, inner, null, intToInt, null));
			Assert.Throws<ArgumentNullException> (() => Enumerable.Join<int, int, int, int> (outer, inner, null, null, intIntToInt));
			Assert.Throws<ArgumentNullException> (() => Enumerable.Join<int, int, int, int> (outer, inner, null, null, null));
			Assert.Throws<ArgumentNullException> (() => Enumerable.Join<int, int, int, int> (outer, null, intToInt, intToInt, intIntToInt));
			Assert.Throws<ArgumentNullException> (() => Enumerable.Join<int, int, int, int> (outer, null, intToInt, intToInt, null));
			Assert.Throws<ArgumentNullException> (() => Enumerable.Join<int, int, int, int> (outer, null, intToInt, null, intIntToInt));
			Assert.Throws<ArgumentNullException> (() => Enumerable.Join<int, int, int, int> (outer, null, intToInt, null, null));
			Assert.Throws<ArgumentNullException> (() => Enumerable.Join<int, int, int, int> (outer, null, null, intToInt, intIntToInt));
			Assert.Throws<ArgumentNullException> (() => Enumerable.Join<int, int, int, int> (outer, null, null, intToInt, null));
			Assert.Throws<ArgumentNullException> (() => Enumerable.Join<int, int, int, int> (outer, null, null, null, intIntToInt));
			Assert.Throws<ArgumentNullException> (() => Enumerable.Join<int, int, int, int> (outer, null, null, null, null));
			Assert.Throws<ArgumentNullException> (() => Enumerable.Join<int, int, int, int> (null, inner, intToInt, intToInt, intIntToInt));
			Assert.Throws<ArgumentNullException> (() => Enumerable.Join<int, int, int, int> (null, inner, intToInt, intToInt, null));
			Assert.Throws<ArgumentNullException> (() => Enumerable.Join<int, int, int, int> (null, inner, intToInt, null, intIntToInt));
			Assert.Throws<ArgumentNullException> (() => Enumerable.Join<int, int, int, int> (null, inner, intToInt, null, null));
			Assert.Throws<ArgumentNullException> (() => Enumerable.Join<int, int, int, int> (null, inner, null, intToInt, intIntToInt));
			Assert.Throws<ArgumentNullException> (() => Enumerable.Join<int, int, int, int> (null, inner, null, intToInt, null));
			Assert.Throws<ArgumentNullException> (() => Enumerable.Join<int, int, int, int> (null, inner, null, null, intIntToInt));
			Assert.Throws<ArgumentNullException> (() => Enumerable.Join<int, int, int, int> (null, inner, null, null, null));
			Assert.Throws<ArgumentNullException> (() => Enumerable.Join<int, int, int, int> (null, null, intToInt, intToInt, intIntToInt));
			Assert.Throws<ArgumentNullException> (() => Enumerable.Join<int, int, int, int> (null, null, intToInt, intToInt, null));
			Assert.Throws<ArgumentNullException> (() => Enumerable.Join<int, int, int, int> (null, null, intToInt, null, intIntToInt));
			Assert.Throws<ArgumentNullException> (() => Enumerable.Join<int, int, int, int> (null, null, intToInt, null, null));
			Assert.Throws<ArgumentNullException> (() => Enumerable.Join<int, int, int, int> (null, null, null, intToInt, intIntToInt));
			Assert.Throws<ArgumentNullException> (() => Enumerable.Join<int, int, int, int> (null, null, null, intToInt, null));
			Assert.Throws<ArgumentNullException> (() => Enumerable.Join<int, int, int, int> (null, null, null, null, intIntToInt));
			Assert.Throws<ArgumentNullException> (() => Enumerable.Join<int, int, int, int> (null, null, null, null, null));
		}
		#endregion
	}
}