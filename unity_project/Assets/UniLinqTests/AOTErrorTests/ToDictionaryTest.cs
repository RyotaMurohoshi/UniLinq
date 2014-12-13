using System;
using System.Collections.Generic;
using UniLinq;
using NUnit.Framework;

namespace UniLinqTest
{
	[TestFixture]
	[Category("UniLinqTests")]
	public class ToDictionaryTest
	{
		#region value_type_key_selector
		[Test]
		public void TestValueType_ValueKey ()
		{
			int[] ints = new [] {0, 1, 2, 3, 4, 5, 6};
			Dictionary<int, int> dict = ints.ToDictionary (keySelector: it => it);

			Assert.That (dict.Count, Is.EqualTo (ints.Length));
			foreach (int element in ints) {
				Assert.That (dict [element], Is.EqualTo (element));
			}
		}

		[Test]
		public void TestValueType_ReferenceKey ()
		{
			int[] ints = new [] {0, 1, 2, 3, 4, 5, 6};
			Dictionary<string, int> dict = ints.ToDictionary (keySelector: it => it.ToString ());

			Assert.That (dict.Count, Is.EqualTo (ints.Length));
			foreach (int element in ints) {
				string key = element.ToString ();
				Assert.That (dict [key], Is.EqualTo (element));
			}
		}
		#endregion

		#region value_type_key_selector_comparer
		[Test]
		public void TestValueType_ValueKey_Comparer ()
		{
			IEqualityComparer<int> comparer = EqualityComparer<int>.Default;
			int[] ints = new [] {0, 1, 2, 3, 4, 5, 6};

			Dictionary<int, int> dict = ints.ToDictionary (keySelector: it => it, comparer: comparer);

			Assert.That (dict.Count, Is.EqualTo (ints.Length));
			foreach (int element in ints) {
				Assert.That (dict [element], Is.EqualTo (element));
			}
		}

		[Test]
		public void TestValueType_ReferenceKey_Comparer ()
		{
			IEqualityComparer<string> comparer = EqualityComparer<string>.Default;
			int[] ints = new [] {0, 1, 2, 3, 4, 5, 6};

			Dictionary<string, int> dict = ints.ToDictionary (keySelector: it => it.ToString (), comparer: comparer);

			Assert.That (dict.Count, Is.EqualTo (ints.Length));
			foreach (int element in ints) {
				string key = element.ToString ();
				Assert.That (dict [key], Is.EqualTo (element));
			}
		}
		#endregion

		#region value_type_key_selector_element_selector
		[Test]
		public void TestValueType_ValueKey_ValueElement ()
		{
			int[] ints = new [] {0, 1, 2, 3, 4, 5, 6};
			Dictionary<int, int> dict = ints.ToDictionary (keySelector: it => it, elementSelector: it => it);

			Assert.That (dict.Count, Is.EqualTo (ints.Length));
			foreach (int element in ints) {
				Assert.That (dict [element], Is.EqualTo (element));
			}
		}

		[Test]
		public void TestValueType_ValueKey_ReferenceElement ()
		{
			int[] ints = new [] {0, 1, 2, 3, 4, 5, 6};
			Dictionary<int, string> dict = ints.ToDictionary (keySelector: it => it, elementSelector: it => it.ToString ());

			Assert.That (dict.Count, Is.EqualTo (ints.Length));
			foreach (int element in ints) {
				string dictElement = element.ToString ();
				Assert.That (dict [element], Is.EqualTo (dictElement));
			}
		}

		[Test]
		public void TestValueType_ReferenceKey_ValueElement ()
		{
			int[] ints = new [] {0, 1, 2, 3, 4, 5, 6};
			Dictionary<string, int> dict = ints.ToDictionary (keySelector: it => it.ToString (), elementSelector: it => it);

			Assert.That (dict.Count, Is.EqualTo (ints.Length));
			foreach (int element in ints) {
				string key = element.ToString ();
				Assert.That (dict [key], Is.EqualTo (element));
			}
		}

		[Test]
		public void TestValueType_ReferenceKey_ReferenceElement ()
		{
			int[] ints = new [] {0, 1, 2, 3, 4, 5, 6};
			Dictionary<string, string> dict = ints.ToDictionary (keySelector: it => it.ToString (), elementSelector: it => it.ToString ());

			Assert.That (dict.Count, Is.EqualTo (ints.Length));
			foreach (int element in ints) {
				string key = element.ToString ();
				string dictElement = element.ToString ();
				Assert.That (dict [key], Is.EqualTo (dictElement));
			}
		}
		#endregion

		#region value_type_key_selector_element_selector_comparer
		[Test]
		public void TestValueType_ValueKey_ValueElement_Comparer ()
		{
			IEqualityComparer<int> comparer = EqualityComparer<int>.Default;
			int[] ints = new [] {0, 1, 2, 3, 4, 5, 6};
			Dictionary<int, int> dict = ints.ToDictionary (keySelector: it => it, elementSelector: it => it, comparer: comparer);

			Assert.That (dict.Count, Is.EqualTo (ints.Length));
			foreach (int element in ints) {
				Assert.That (dict [element], Is.EqualTo (element));
			}
		}

		[Test]
		public void TestValueType_ValueKey_ReferenceElement_Comparer ()
		{
			IEqualityComparer<int> comparer = EqualityComparer<int>.Default;
			int[] ints = new [] {0, 1, 2, 3, 4, 5, 6};
			Dictionary<int, string> dict = ints.ToDictionary (keySelector: it => it, elementSelector: it => it.ToString (), comparer: comparer);

			Assert.That (dict.Count, Is.EqualTo (ints.Length));
			foreach (int element in ints) {
				string dictElement = element.ToString ();
				Assert.That (dict [element], Is.EqualTo (dictElement));
			}
		}

		[Test]
		public void TestValueType_ReferenceKey_ValueElement_Comparer ()
		{
			IEqualityComparer<string> comparer = EqualityComparer<string>.Default;
			int[] ints = new [] {0, 1, 2, 3, 4, 5, 6};
			Dictionary<string, int> dict = ints.ToDictionary (keySelector: it => it.ToString (), elementSelector: it => it, comparer: comparer);

			Assert.That (dict.Count, Is.EqualTo (ints.Length));
			foreach (int element in ints) {
				string key = element.ToString ();
				Assert.That (dict [key], Is.EqualTo (element));
			}
		}

		[Test]
		public void TestValueType_ReferenceKey_ReferenceElement_Comparer ()
		{
			IEqualityComparer<string> comparer = EqualityComparer<string>.Default;
			int[] ints = new [] {0, 1, 2, 3, 4, 5, 6};
			Dictionary<string, string> dict = ints.ToDictionary (keySelector: it => it.ToString (), elementSelector: it => it.ToString (), comparer: comparer);

			Assert.That (dict.Count, Is.EqualTo (ints.Length));
			foreach (int element in ints) {
				string key = element.ToString ();
				string dictElement = element.ToString ();
				Assert.That (dict [key], Is.EqualTo (dictElement));
			}
		}
		#endregion

		#region reference_type_key_selector
		[Test]
		public void TestReferenceType_ValueKey ()
		{
			string[] strings = new [] {"0", "1", "2", "3", "4", "5", "6"};

			Dictionary<int, string> dict = strings.ToDictionary (keySelector: it => int.Parse (it));

			Assert.That (dict.Count, Is.EqualTo (strings.Length));
			foreach (string element in strings) {
				int key = int.Parse (element);
				Assert.That (dict [key], Is.EqualTo (element));
			}
		}

		[Test]
		public void TestReferenceType_ReferenceKey ()
		{
			string[] strings = new [] {"0", "1", "2", "3", "4", "5", "6"};

			Dictionary<string, string> dict = strings.ToDictionary (keySelector: it => it);

			Assert.That (dict.Count, Is.EqualTo (strings.Length));
			foreach (string element in strings) {
				Assert.That (dict [element], Is.EqualTo (element));
			}
		}
		#endregion

		#region reference_type_key_selector_comparer
		[Test]
		public void TestReferenceType_ValueKey_Comparer ()
		{
			IEqualityComparer<int> comparer = EqualityComparer<int>.Default;
			string[] strings = new [] {"0", "1", "2", "3", "4", "5", "6"};

			Dictionary<int, string> dict = strings.ToDictionary (keySelector: it => int.Parse (it), comparer: comparer);

			Assert.That (dict.Count, Is.EqualTo (strings.Length));
			foreach (string element in strings) {
				int key = int.Parse (element);
				Assert.That (dict [key], Is.EqualTo (element));
			}
		}

		[Test]
		public void TestReferenceType_ReferenceKey_Comparer ()
		{
			IEqualityComparer<string> comparer = EqualityComparer<string>.Default;
			string[] strings = new [] {"0", "1", "2", "3", "4", "5", "6"};

			Dictionary<string, string> dict = strings.ToDictionary (keySelector: it => it, comparer: comparer);

			Assert.That (dict.Count, Is.EqualTo (strings.Length));
			foreach (string element in strings) {
				Assert.That (dict [element], Is.EqualTo (element));
			}
		}
		#endregion

		#region reference_type_key_selector_element_selector
		[Test]
		public void TestReferenceType_ValueKey_ValueElement ()
		{
			string[] strings = new [] {"0", "1", "2", "3", "4", "5", "6"};
			Dictionary<int, int> dict = strings.ToDictionary (keySelector: it => int.Parse (it), elementSelector: it => int.Parse (it));

			Assert.That (dict.Count, Is.EqualTo (strings.Length));

			foreach (string element in strings) {
				Assert.That (dict [int.Parse (element)], Is.EqualTo (int.Parse (element)));
			}
		}

		[Test]
		public void TestReferenceType_ValueKey_ReferenceElement ()
		{
			string[] strings = new [] {"0", "1", "2", "3", "4", "5", "6"};
			Dictionary<int, string> dict = strings.ToDictionary (keySelector: it => int.Parse (it), elementSelector: it => it);

			Assert.That (dict.Count, Is.EqualTo (strings.Length));

			foreach (string element in strings) {
				Assert.That (dict [int.Parse (element)], Is.EqualTo (element));
			}
		}

		[Test]
		public void TestReferenceType_ReferenceKey_ValueElement ()
		{
			string[] strings = new [] {"0", "1", "2", "3", "4", "5", "6"};
			Dictionary<string, int> dict = strings.ToDictionary (keySelector: it => it, elementSelector: it => int.Parse (it));

			Assert.That (dict.Count, Is.EqualTo (strings.Length));

			foreach (string element in strings) {
				Assert.That (dict [element], Is.EqualTo (int.Parse (element)));
			}
		}

		[Test]
		public void TestReferenceType_ReferenceKey_ReferenceElement ()
		{
			string[] strings = new [] {"0", "1", "2", "3", "4", "5", "6"};
			Dictionary<string, string> dict = strings.ToDictionary (keySelector: it => it, elementSelector: it => it);

			Assert.That (dict.Count, Is.EqualTo (strings.Length));

			foreach (string element in strings) {
				Assert.That (dict [element], Is.EqualTo (element));
			}
		}
		#endregion

		#region reference_type_key_selector_element_selector_comparer
		[Test]
		public void TestReferenceType_ValueKey_ValueElement_Comparer ()
		{
			IEqualityComparer<int> comparer = EqualityComparer<int>.Default;
			string[] strings = new [] {"0", "1", "2", "3", "4", "5", "6"};
			Dictionary<int, int> dict = strings.ToDictionary (keySelector: it => int.Parse (it), elementSelector: it => int.Parse (it), comparer: comparer);

			Assert.That (dict.Count, Is.EqualTo (strings.Length));

			foreach (string element in strings) {
				Assert.That (dict [int.Parse (element)], Is.EqualTo (int.Parse (element)));
			}
		}

		[Test]
		public void TestReferenceType_ValueKey_ReferenceElement_Comparer ()
		{
			IEqualityComparer<int> comparer = EqualityComparer<int>.Default;
			string[] strings = new [] {"0", "1", "2", "3", "4", "5", "6"};
			Dictionary<int, string> dict = strings.ToDictionary (keySelector: it => int.Parse (it), elementSelector: it => it, comparer: comparer);

			Assert.That (dict.Count, Is.EqualTo (strings.Length));

			foreach (string element in strings) {
				Assert.That (dict [int.Parse (element)], Is.EqualTo (element));
			}
		}

		[Test]
		public void TestReferenceType_ReferenceKey_ValueElement_Comparer ()
		{
			IEqualityComparer<string> comparer = EqualityComparer<string>.Default;
			string[] strings = new [] {"0", "1", "2", "3", "4", "5", "6"};
			Dictionary<string, int> dict = strings.ToDictionary (keySelector: it => it, elementSelector: it => int.Parse (it), comparer: comparer);

			Assert.That (dict.Count, Is.EqualTo (strings.Length));

			foreach (string element in strings) {
				Assert.That (dict [element], Is.EqualTo (int.Parse (element)));
			}
		}

		[Test]
		public void TestReferenceType_ReferenceKey_ReferenceElement_Comparer ()
		{
			IEqualityComparer<string> comparer = EqualityComparer<string>.Default;
			string[] strings = new [] {"0", "1", "2", "3", "4", "5", "6"};
			Dictionary<string, string> dict = strings.ToDictionary (keySelector: it => it, elementSelector: it => it, comparer: comparer);

			Assert.That (dict.Count, Is.EqualTo (strings.Length));

			foreach (string element in strings) {
				Assert.That (dict [element], Is.EqualTo (element));
			}
		}
		#endregion

		#region null_comparer
		[Test]
		public void TestValueType_ValueKey_NullComparer ()
		{
			int[] ints = new [] {0, 1, 2, 3, 4, 5, 6};

			Dictionary<int, int> dict = ints.ToDictionary (keySelector: it => it, comparer: null);

			Assert.That (dict.Count, Is.EqualTo (ints.Length));
			foreach (int element in ints) {
				Assert.That (dict [element], Is.EqualTo (element));
			}
		}

		[Test]
		public void TestValueType_ReferenceKey_NullComparer ()
		{
			int[] ints = new [] {0, 1, 2, 3, 4, 5, 6};

			Dictionary<string, int> dict = ints.ToDictionary (keySelector: it => it.ToString (), comparer: null);

			Assert.That (dict.Count, Is.EqualTo (ints.Length));
			foreach (int element in ints) {
				string key = element.ToString ();
				Assert.That (dict [key], Is.EqualTo (element));
			}
		}

		[Test]
		public void TestReferenceType_ValueKey_NullComparer ()
		{
			string[] strings = new [] {"0", "1", "2", "3", "4", "5", "6"};

			Dictionary<int, string> dict = strings.ToDictionary (keySelector: it => int.Parse (it), comparer: null);

			Assert.That (dict.Count, Is.EqualTo (strings.Length));
			foreach (string element in strings) {
				int key = int.Parse (element);
				Assert.That (dict [key], Is.EqualTo (element));
			}
		}

		[Test]
		public void TestReferenceType_ReferenceKey_NullComparer ()
		{
			string[] strings = new [] {"0", "1", "2", "3", "4", "5", "6"};

			Dictionary<string, string> dict = strings.ToDictionary (keySelector: it => it, comparer: null);

			Assert.That (dict.Count, Is.EqualTo (strings.Length));
			foreach (string element in strings) {
				Assert.That (dict [element], Is.EqualTo (element));
			}
		}

		[Test]
		public void TestValueType_ValueKey_ValueElement_NullComparer ()
		{
			int[] ints = new [] {0, 1, 2, 3, 4, 5, 6};
			Dictionary<int, int> dict = ints.ToDictionary (keySelector: it => it, elementSelector: it => it, comparer: null);

			Assert.That (dict.Count, Is.EqualTo (ints.Length));
			foreach (int element in ints) {
				Assert.That (dict [element], Is.EqualTo (element));
			}
		}

		[Test]
		public void TestValueType_ValueKey_ReferenceElement_NullComparer ()
		{
			int[] ints = new [] {0, 1, 2, 3, 4, 5, 6};
			Dictionary<int, string> dict = ints.ToDictionary (keySelector: it => it, elementSelector: it => it.ToString (), comparer: null);

			Assert.That (dict.Count, Is.EqualTo (ints.Length));
			foreach (int element in ints) {
				string dictElement = element.ToString ();
				Assert.That (dict [element], Is.EqualTo (dictElement));
			}
		}

		[Test]
		public void TestValueType_ReferenceKey_ValueElement_NullComparer ()
		{
			int[] ints = new [] {0, 1, 2, 3, 4, 5, 6};
			Dictionary<string, int> dict = ints.ToDictionary (keySelector: it => it.ToString (), elementSelector: it => it, comparer: null);

			Assert.That (dict.Count, Is.EqualTo (ints.Length));
			foreach (int element in ints) {
				string key = element.ToString ();
				Assert.That (dict [key], Is.EqualTo (element));
			}
		}

		[Test]
		public void TestValueType_ReferenceKey_ReferenceElement_NullComparer ()
		{
			int[] ints = new [] {0, 1, 2, 3, 4, 5, 6};
			Dictionary<string, string> dict = ints.ToDictionary (keySelector: it => it.ToString (), elementSelector: it => it.ToString (), comparer: null);

			Assert.That (dict.Count, Is.EqualTo (ints.Length));
			foreach (int element in ints) {
				string key = element.ToString ();
				string dictElement = element.ToString ();
				Assert.That (dict [key], Is.EqualTo (dictElement));
			}
		}

		[Test]
		public void TestReferenceType_ValueKey_ValueElement_NullComparer ()
		{
			string[] strings = new [] {"0", "1", "2", "3", "4", "5", "6"};
			Dictionary<int, int> dict = strings.ToDictionary (keySelector: it => int.Parse (it), elementSelector: it => int.Parse (it), comparer: null);

			Assert.That (dict.Count, Is.EqualTo (strings.Length));

			foreach (string element in strings) {
				Assert.That (dict [int.Parse (element)], Is.EqualTo (int.Parse (element)));
			}
		}

		[Test]
		public void TestReferenceType_ValueKey_ReferenceElement_NullComparer ()
		{
			string[] strings = new [] {"0", "1", "2", "3", "4", "5", "6"};
			Dictionary<int, string> dict = strings.ToDictionary (keySelector: it => int.Parse (it), elementSelector: it => it, comparer: null);

			Assert.That (dict.Count, Is.EqualTo (strings.Length));

			foreach (string element in strings) {
				Assert.That (dict [int.Parse (element)], Is.EqualTo (element));
			}
		}

		[Test]
		public void TestReferenceType_ReferenceKey_ValueElement_NullComparer ()
		{
			string[] strings = new [] {"0", "1", "2", "3", "4", "5", "6"};
			Dictionary<string, int> dict = strings.ToDictionary (keySelector: it => it, elementSelector: it => int.Parse (it), comparer: null);

			Assert.That (dict.Count, Is.EqualTo (strings.Length));

			foreach (string element in strings) {
				Assert.That (dict [element], Is.EqualTo (int.Parse (element)));
			}
		}

		[Test]
		public void TestReferenceType_ReferenceKey_ReferenceElement_NullComparer ()
		{
			string[] strings = new [] {"0", "1", "2", "3", "4", "5", "6"};
			Dictionary<string, string> dict = strings.ToDictionary (keySelector: it => it, elementSelector: it => it, comparer: null);

			Assert.That (dict.Count, Is.EqualTo (strings.Length));

			foreach (string element in strings) {
				Assert.That (dict [element], Is.EqualTo (element));
			}
		}
		#endregion

		#region key_duplicate_exception
		[Test]
		public void TestValueTypeKeyDuplicate ()
		{
			int[] ints = new [] {0, 1, 1};
			Assert.Throws<ArgumentException> (() => ints.ToDictionary (keySelector: it => it));
			Assert.Throws<ArgumentException> (() => ints.ToDictionary (keySelector: it => it, elementSelector: it => it));
			Assert.Throws<ArgumentException> (() => ints.ToDictionary (keySelector: it => it, comparer: EqualityComparer<int>.Default));
			Assert.Throws<ArgumentException> (() => ints.ToDictionary (keySelector: it => it, elementSelector: it => it, comparer: EqualityComparer<int>.Default));
		}

		[Test]
		public void TestReferenceTypeKeyDuplicate ()
		{
			string[] strings = new [] {"0", "1", "1"};
			Assert.Throws<ArgumentException> (() => strings.ToDictionary (keySelector: it => it));
			Assert.Throws<ArgumentException> (() => strings.ToDictionary (keySelector: it => it, elementSelector: it => it));
			Assert.Throws<ArgumentException> (() => strings.ToDictionary (keySelector: it => it, comparer: EqualityComparer<string>.Default));
			Assert.Throws<ArgumentException> (() => strings.ToDictionary (keySelector: it => it, elementSelector: it => it, comparer: EqualityComparer<string>.Default));
		}
		#endregion

		#region null_exception
		[Test]
		public void TestValueType_NullArgumentExceptions ()
		{
			int[] ints = new [] {0, 1, 2, 3, 4, 5, 6};
			IEqualityComparer<int> comparer = EqualityComparer<int>.Default;
			Func<int, int> func = it => it;

			Assert.Throws<ArgumentNullException> (() => ints.ToDictionary<int, int> (keySelector: null));
			Assert.Throws<ArgumentNullException> (() => ints.ToDictionary<int, int> (keySelector: null, comparer: comparer));

			Assert.Throws<ArgumentNullException> (() => ints.ToDictionary<int, int, int> (keySelector: null, elementSelector: func));
			Assert.Throws<ArgumentNullException> (() => ints.ToDictionary<int, int, int> (keySelector: null, elementSelector: func, comparer: comparer));

			Assert.Throws<ArgumentNullException> (() => ints.ToDictionary<int, int, int> (keySelector: func, elementSelector: null));
			Assert.Throws<ArgumentNullException> (() => ints.ToDictionary<int, int, int> (keySelector: func, elementSelector: null, comparer: comparer));

			Assert.Throws<ArgumentNullException> (() => ints.ToDictionary<int, int, int> (keySelector: null, elementSelector: null));
			Assert.Throws<ArgumentNullException> (() => ints.ToDictionary<int, int, int> (keySelector: null, elementSelector: null, comparer: comparer));
		}

		[Test]
		public void TestReferenceType_NullArgumentExceptions ()
		{
			string[] strings = new [] {"0", "1", "2", "3", "4", "5", "6"};
			IEqualityComparer<string> comparer = EqualityComparer<string>.Default;
			Func<string, string> func = it => it;

			Assert.Throws<ArgumentNullException> (() => strings.ToDictionary<string, string> (keySelector: null));
			Assert.Throws<ArgumentNullException> (() => strings.ToDictionary<string, string> (keySelector: null, comparer: comparer));

			Assert.Throws<ArgumentNullException> (() => strings.ToDictionary<string, string, string> (keySelector: null, elementSelector: func));
			Assert.Throws<ArgumentNullException> (() => strings.ToDictionary<string, string, string> (keySelector: null, elementSelector: func, comparer: comparer));

			Assert.Throws<ArgumentNullException> (() => strings.ToDictionary<string, string, string> (keySelector: func, elementSelector: null));
			Assert.Throws<ArgumentNullException> (() => strings.ToDictionary<string, string, string> (keySelector: func, elementSelector: null, comparer: comparer));

			Assert.Throws<ArgumentNullException> (() => strings.ToDictionary<string, string, string> (keySelector: null, elementSelector: null));
			Assert.Throws<ArgumentNullException> (() => strings.ToDictionary<string, string, string> (keySelector: null, elementSelector: null, comparer: comparer));
		}
		#endregion

		#region null_key_exception
		[Test]
		public void TestValueType_NullKeyExceptions ()
		{
			int[] ints = new [] {0, 1, 2, 3, 4, 5, 6};
			IEqualityComparer<string> comparer = EqualityComparer<string>.Default;
			Func<int, string> nullKeyFunc = it => null;
			Func<int, int> func = it => it;

			Assert.Throws<ArgumentNullException> (() => ints.ToDictionary<int, string> (keySelector: nullKeyFunc));
			Assert.Throws<ArgumentNullException> (() => ints.ToDictionary<int, string> (keySelector: nullKeyFunc, comparer: comparer));
			Assert.Throws<ArgumentNullException> (() => ints.ToDictionary<int, string, int> (keySelector: nullKeyFunc, elementSelector: func));
			Assert.Throws<ArgumentNullException> (() => ints.ToDictionary<int, string, int> (keySelector: nullKeyFunc, elementSelector: func, comparer: comparer));
		}

		[Test]
		public void TestReferenceType_NullKeyExceptions ()
		{
			string[] strings = new [] {"0", "1", "2", "3", "4", "5", "6"};
			IEqualityComparer<string> comparer = EqualityComparer<string>.Default;
			Func<string, string> nullKeyFunc = it => null;
			Func<string, string> func = it => it;

			Assert.Throws<ArgumentNullException> (() => strings.ToDictionary<string, string> (keySelector: nullKeyFunc));
			Assert.Throws<ArgumentNullException> (() => strings.ToDictionary<string, string> (keySelector: nullKeyFunc, comparer: comparer));
			Assert.Throws<ArgumentNullException> (() => strings.ToDictionary<string, string, string> (keySelector: nullKeyFunc, elementSelector: func));
			Assert.Throws<ArgumentNullException> (() => strings.ToDictionary<string, string, string> (keySelector: nullKeyFunc, elementSelector: func, comparer: comparer));
		}
		#endregion
	}
}