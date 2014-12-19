using System;
using System.Collections.Generic;
using UniLinq;
using NUnit.Framework;
using UnityEngine;

namespace UniLinqTest
{
	[TestFixture]
	[Category("UniLinqTests")]
	class ToLookupTest
	{
		#region strings
		[Test]
		public void TestStrings ()
		{
			string[] strings = new string[] {
				"Cube",
				"Sphere",
				"Capsule",
				"Cylinder",
				"Plane",
				"Quad"
			};
			ILookup<int, string> lookup = strings.ToLookup (keySelector: it => it.Length, elementSelector: it => it.ToLower ());

			Assert.That (lookup.Count, Is.EqualTo (5));

			Assert.That (lookup.ElementAt (0).Key, Is.EqualTo (4));
			Assert.That (lookup.ElementAt (0).ElementAtOrDefault (0), Is.EqualTo ("cube"));
			Assert.That (lookup.ElementAt (0).ElementAtOrDefault (1), Is.EqualTo ("quad"));

			Assert.That (lookup.ElementAt (1).Key, Is.EqualTo (6));
			Assert.That (lookup.ElementAt (1).ElementAtOrDefault (0), Is.EqualTo ("sphere"));

			Assert.That (lookup.ElementAt (2).Key, Is.EqualTo (7));
			Assert.That (lookup.ElementAt (2).ElementAtOrDefault (0), Is.EqualTo ("capsule"));

			Assert.That (lookup.ElementAt (3).Key, Is.EqualTo (8));
			Assert.That (lookup.ElementAt (3).ElementAtOrDefault (0), Is.EqualTo ("cylinder"));

			Assert.That (lookup.ElementAt (4).Key, Is.EqualTo (5));
			Assert.That (lookup.ElementAt (4).ElementAtOrDefault (0), Is.EqualTo ("plane"));
		}
		#endregion

		#region value_type_key_selector
		[Test]
		public void TestValueType_ValueKey ()
		{
			int[] ints = new [] {0, 1, 2, 3, 4, 5, 6};

			ILookup<int, int> lookup = ints.ToLookup (keySelector: it => it);

			Assert.That (lookup.Count, Is.EqualTo (ints.Length));
			foreach (int element in ints) {
				IEnumerable<int> enumerable = lookup [element];
				Assert.That (enumerable.Count (), Is.EqualTo (1));
				Assert.That (enumerable.ElementAt (0), Is.EqualTo (element));
			}
		}

		[Test]
		public void TestValueType_ReferenceKey ()
		{
			int[] ints = new [] {0, 1, 2, 3, 4, 5, 6};

			ILookup<string, int> lookup = ints.ToLookup (keySelector: it => it.ToString ());

			Assert.That (lookup.Count, Is.EqualTo (ints.Length));
			foreach (int element in ints) {
				string key = element.ToString ();
				IEnumerable<int> enumerable = lookup [key];
				Assert.That (enumerable.Count (), Is.EqualTo (1));
				Assert.That (enumerable.ElementAt (0), Is.EqualTo (element));
			}
		}
		#endregion

		#region value_type_key_selector_comparer
		[Test]
		public void TestValueType_ValueKey_Comparer ()
		{
			IEqualityComparer<int> comparer = EqualityComparer<int>.Default;
			int[] ints = new [] {0, 1, 2, 3, 4, 5, 6};

			ILookup<int, int> lookup = ints.ToLookup (keySelector: it => it, comparer: comparer);

			Assert.That (lookup.Count, Is.EqualTo (ints.Length));
			foreach (int element in ints) {
				IEnumerable<int> enumerable = lookup [element];
				Assert.That (enumerable.Count (), Is.EqualTo (1));
				Assert.That (enumerable.ElementAt (0), Is.EqualTo (element));
			}
		}

		[Test]
		public void TestValueType_ReferenceKey_Comparer ()
		{
			IEqualityComparer<string> comparer = EqualityComparer<string>.Default;
			int[] ints = new [] {0, 1, 2, 3, 4, 5, 6};

			ILookup<string, int> lookup = ints.ToLookup (keySelector: it => it.ToString (), comparer: comparer);

			Assert.That (lookup.Count, Is.EqualTo (ints.Length));
			foreach (int element in ints) {
				string key = element.ToString ();
				IEnumerable<int> enumerable = lookup [key];
				Assert.That (enumerable.Count (), Is.EqualTo (1));
				Assert.That (enumerable.ElementAt (0), Is.EqualTo (element));
			}
		}
		#endregion

		#region value_type_key_selecor_element_selector
		[Test]
		public void TestValueType_ValueKey_ValueElement ()
		{
			int[] ints = new [] {0, 1, 2, 3, 4, 5, 6};

			ILookup<int, int> lookup = ints.ToLookup (keySelector: it => it, elementSelector: it => it);

			Assert.That (lookup.Count, Is.EqualTo (ints.Length));
			foreach (int element in ints) {
				IEnumerable<int> enumerable = lookup [element];
				Assert.That (enumerable.Count (), Is.EqualTo (1));
				Assert.That (enumerable.ElementAt (0), Is.EqualTo (element));
			}
		}

		[Test]
		public void TestValueType_ValueKey_ReferenceElement ()
		{
			int[] ints = new [] {0, 1, 2, 3, 4, 5, 6};

			ILookup<int, string> lookup = ints.ToLookup (keySelector: it => it, elementSelector: it => it.ToString ());

			Assert.That (lookup.Count, Is.EqualTo (ints.Length));
			foreach (int element in ints) {
				string value = element.ToString ();
				IEnumerable<string> enumerable = lookup [element];
				Assert.That (enumerable.Count (), Is.EqualTo (1));
				Assert.That (enumerable.ElementAt (0), Is.EqualTo (value));
			}
		}

		[Test]
		public void TestValueType_ReferenceKey_ValueElement ()
		{
			int[] ints = new [] {0, 1, 2, 3, 4, 5, 6};

			ILookup<string, int> lookup = ints.ToLookup (keySelector: it => it.ToString (), elementSelector: it => it);

			Assert.That (lookup.Count, Is.EqualTo (ints.Length));
			foreach (int element in ints) {
				string key = element.ToString ();
				IEnumerable<int> enumerable = lookup [key];
				Assert.That (enumerable.Count (), Is.EqualTo (1));
				Assert.That (enumerable.ElementAt (0), Is.EqualTo (element));
			}
		}

		[Test]
		public void TestValueType_ReferenceKey_ReferenceElement ()
		{
			int[] ints = new [] {0, 1, 2, 3, 4, 5, 6};

			ILookup<string, string> lookup = ints.ToLookup (keySelector: it => it.ToString (), elementSelector: it => it.ToString ());

			Assert.That (lookup.Count, Is.EqualTo (ints.Length));
			foreach (int element in ints) {
				string key = element.ToString ();
				string value = element.ToString ();
				IEnumerable<string> enumerable = lookup [key];
				Assert.That (enumerable.Count (), Is.EqualTo (1));
				Assert.That (enumerable.ElementAt (0), Is.EqualTo (value));
			}
		}
		#endregion

		#region value_type_key_selecor_element_selector_comparer
		[Test]
		public void TestValueType_ValueKey_ValueElement_Comparer ()
		{
			IEqualityComparer<int> comparer = EqualityComparer<int>.Default;
			int[] ints = new [] {0, 1, 2, 3, 4, 5, 6};

			ILookup<int, int> lookup = ints.ToLookup (keySelector: it => it, elementSelector: it => it, comparer: comparer);

			Assert.That (lookup.Count, Is.EqualTo (ints.Length));
			foreach (int element in ints) {
				IEnumerable<int> enumerable = lookup [element];
				Assert.That (enumerable.Count (), Is.EqualTo (1));
				Assert.That (enumerable.ElementAt (0), Is.EqualTo (element));
			}
		}

		[Test]
		public void TestValueType_ValueKey_ReferenceElement_Comparer ()
		{
			IEqualityComparer<int> comparer = EqualityComparer<int>.Default;
			int[] ints = new [] {0, 1, 2, 3, 4, 5, 6};

			ILookup<int, string> lookup = ints.ToLookup (keySelector: it => it, elementSelector: it => it.ToString (), comparer: comparer);

			Assert.That (lookup.Count, Is.EqualTo (ints.Length));
			foreach (int element in ints) {
				string value = element.ToString ();
				IEnumerable<string> enumerable = lookup [element];
				Assert.That (enumerable.Count (), Is.EqualTo (1));
				Assert.That (enumerable.ElementAt (0), Is.EqualTo (value));
			}
		}

		[Test]
		public void TestValueType_ReferenceKey_ValueElement_Comparer ()
		{
			IEqualityComparer<string> comparer = EqualityComparer<string>.Default;
			int[] ints = new [] {0, 1, 2, 3, 4, 5, 6};

			ILookup<string, int> lookup = ints.ToLookup (keySelector: it => it.ToString (), elementSelector: it => it, comparer: comparer);

			Assert.That (lookup.Count, Is.EqualTo (ints.Length));
			foreach (int element in ints) {
				string key = element.ToString ();
				IEnumerable<int> enumerable = lookup [key];
				Assert.That (enumerable.Count (), Is.EqualTo (1));
				Assert.That (enumerable.ElementAt (0), Is.EqualTo (element));
			}
		}

		[Test]
		public void TestValueType_ReferenceKey_ReferenceElement_Comparer ()
		{
			IEqualityComparer<string> comparer = EqualityComparer<string>.Default;
			int[] ints = new [] {0, 1, 2, 3, 4, 5, 6};

			ILookup<string, string> lookup = ints.ToLookup (keySelector: it => it.ToString (), elementSelector: it => it.ToString (), comparer: comparer);

			Assert.That (lookup.Count, Is.EqualTo (ints.Length));
			foreach (int element in ints) {
				string key = element.ToString ();
				string value = element.ToString ();
				IEnumerable<string> enumerable = lookup [key];
				Assert.That (enumerable.Count (), Is.EqualTo (1));
				Assert.That (enumerable.ElementAt (0), Is.EqualTo (value));
			}
		}
		#endregion

		#region reference_type_key_selector
		[Test]
		public void TestReferenceType_ValueKey ()
		{
			string[] strings = new [] {"0", "1", "2", "3", "4", "5", "6"};

			ILookup<int, string> lookup = strings.ToLookup (keySelector: it => int.Parse (it));

			Assert.That (lookup.Count, Is.EqualTo (strings.Length));
			foreach (string element in strings) {
				int key = int.Parse (element);
				IEnumerable<string> enumerable = lookup [key];
				Assert.That (enumerable.Count (), Is.EqualTo (1));
				Assert.That (enumerable.ElementAt (0), Is.EqualTo (element));
			}
		}

		[Test]
		public void TestReferenceType_ReferenceKey ()
		{
			string[] strings = new [] {"0", "1", "2", "3", "4", "5", "6"};

			ILookup<string, string> lookup = strings.ToLookup (keySelector: it => it);

			Assert.That (lookup.Count, Is.EqualTo (strings.Length));
			foreach (string element in strings) {
				IEnumerable<string> enumerable = lookup [element];
				Assert.That (enumerable.Count (), Is.EqualTo (1));
				Assert.That (enumerable.ElementAt (0), Is.EqualTo (element));
			}
		}
		#endregion

		#region reference_type_key_selector_comparer
		[Test]
		public void TestReferenceType_ValueKey_Comparer ()
		{
			IEqualityComparer<int> comparer = EqualityComparer<int>.Default;
			string[] strings = new [] {"0", "1", "2", "3", "4", "5", "6"};

			ILookup<int, string> lookup = strings.ToLookup (keySelector: it => int.Parse (it), comparer: comparer);

			Assert.That (lookup.Count, Is.EqualTo (strings.Length));
			foreach (string element in strings) {
				int key = int.Parse (element);
				IEnumerable<string> enumerable = lookup [key];
				Assert.That (enumerable.Count (), Is.EqualTo (1));
				Assert.That (enumerable.ElementAt (0), Is.EqualTo (element));
			}
		}

		[Test]
		public void TestReferenceType_ReferenceKey_Comparer ()
		{
			IEqualityComparer<string> comparer = EqualityComparer<string>.Default;
			string[] strings = new [] {"0", "1", "2", "3", "4", "5", "6"};

			ILookup<string, string> lookup = strings.ToLookup (keySelector: it => it, comparer: comparer);

			Assert.That (lookup.Count, Is.EqualTo (strings.Length));
			foreach (string element in strings) {
				IEnumerable<string> enumerable = lookup [element];
				Assert.That (enumerable.Count (), Is.EqualTo (1));
				Assert.That (enumerable.ElementAt (0), Is.EqualTo (element));
			}
		}
		#endregion

		#region reference_type_key_selector_element_selector
		[Test]
		public void TestReferenceType_ValueKey_ValueElement ()
		{
			string[] strings = new [] {"0", "1", "2", "3", "4", "5", "6"};

			ILookup<int, int> lookup = strings.ToLookup (keySelector: it => int.Parse (it), elementSelector: it => int.Parse (it));

			Assert.That (lookup.Count, Is.EqualTo (strings.Length));
			foreach (string element in strings) {
				int key = int.Parse (element);
				int value = int.Parse (element);
				IEnumerable<int> enumerable = lookup [key];
				Assert.That (enumerable.Count (), Is.EqualTo (1));
				Assert.That (enumerable.ElementAt (0), Is.EqualTo (value));
			}
		}

		[Test]
		public void TestReferenceType_ValueKey_ReferenceElement ()
		{
			string[] strings = new [] {"0", "1", "2", "3", "4", "5", "6"};

			ILookup<int, string> lookup = strings.ToLookup (keySelector: it => int.Parse (it), elementSelector: it => it);

			Assert.That (lookup.Count, Is.EqualTo (strings.Length));
			foreach (string element in strings) {
				int key = int.Parse (element);
				IEnumerable<string> enumerable = lookup [key];
				Assert.That (enumerable.Count (), Is.EqualTo (1));
				Assert.That (enumerable.ElementAt (0), Is.EqualTo (element));
			}
		}

		[Test]
		public void TestReferenceType_ReferenceKey_ValueElement ()
		{
			string[] strings = new [] {"0", "1", "2", "3", "4", "5", "6"};

			ILookup<string, int> lookup = strings.ToLookup (keySelector: it => it, elementSelector: it => int.Parse (it));

			Assert.That (lookup.Count, Is.EqualTo (strings.Length));
			foreach (string element in strings) {
				int value = int.Parse (element);
				IEnumerable<int> enumerable = lookup [element];
				Assert.That (enumerable.Count (), Is.EqualTo (1));
				Assert.That (enumerable.ElementAt (0), Is.EqualTo (value));
			}
		}

		[Test]
		public void TestReferenceType_ReferenceKey_ReferenceElement ()
		{
			IEqualityComparer<string> comparer = EqualityComparer<string>.Default;
			string[] strings = new [] {"0", "1", "2", "3", "4", "5", "6"};

			ILookup<string, string> lookup = strings.ToLookup (keySelector: it => it, elementSelector: it => it, comparer: comparer);

			Assert.That (lookup.Count, Is.EqualTo (strings.Length));
			foreach (string element in strings) {
				IEnumerable<string> enumerable = lookup [element];
				Assert.That (enumerable.Count (), Is.EqualTo (1));
				Assert.That (enumerable.ElementAt (0), Is.EqualTo (element));
			}
		}
		#endregion

		#region reference_type_key_selector_element_selector_comparer
		[Test]
		public void TestReferenceType_ValueKey_ValueElement_Comparer ()
		{
			IEqualityComparer<int> comparer = EqualityComparer<int>.Default;
			string[] strings = new [] {"0", "1", "2", "3", "4", "5", "6"};

			ILookup<int, int> lookup = strings.ToLookup (keySelector: it => int.Parse (it), elementSelector: it => int.Parse (it), comparer: comparer);

			Assert.That (lookup.Count, Is.EqualTo (strings.Length));
			foreach (string element in strings) {
				int key = int.Parse (element);
				int value = int.Parse (element);
				IEnumerable<int> enumerable = lookup [key];
				Assert.That (enumerable.Count (), Is.EqualTo (1));
				Assert.That (enumerable.ElementAt (0), Is.EqualTo (value));
			}
		}

		[Test]
		public void TestReferenceType_ValueKey_ReferenceElement_Comparer ()
		{
			IEqualityComparer<int> comparer = EqualityComparer<int>.Default;
			string[] strings = new [] {"0", "1", "2", "3", "4", "5", "6"};

			ILookup<int, string> lookup = strings.ToLookup (keySelector: it => int.Parse (it), elementSelector: it => it, comparer: comparer);

			Assert.That (lookup.Count, Is.EqualTo (strings.Length));
			foreach (string element in strings) {
				int key = int.Parse (element);
				IEnumerable<string> enumerable = lookup [key];
				Assert.That (enumerable.Count (), Is.EqualTo (1));
				Assert.That (enumerable.ElementAt (0), Is.EqualTo (element));
			}
		}

		[Test]
		public void TestReferenceType_ReferenceKey_ValueElement_Comparer ()
		{
			IEqualityComparer<string> comparer = EqualityComparer<string>.Default;
			string[] strings = new [] {"0", "1", "2", "3", "4", "5", "6"};

			ILookup<string, int> lookup = strings.ToLookup (keySelector: it => it, elementSelector: it => int.Parse (it), comparer: comparer);

			Assert.That (lookup.Count, Is.EqualTo (strings.Length));
			foreach (string element in strings) {
				int value = int.Parse (element);
				IEnumerable<int> enumerable = lookup [element];
				Assert.That (enumerable.Count (), Is.EqualTo (1));
				Assert.That (enumerable.ElementAt (0), Is.EqualTo (value));
			}
		}

		[Test]
		public void TestReferenceType_ReferenceKey_ReferenceElement_Comparer ()
		{
			IEqualityComparer<string> comparer = EqualityComparer<string>.Default;
			string[] strings = new [] {"0", "1", "2", "3", "4", "5", "6"};

			ILookup<string, string> lookup = strings.ToLookup (keySelector: it => it, elementSelector: it => it, comparer: comparer);

			Assert.That (lookup.Count, Is.EqualTo (strings.Length));
			foreach (string element in strings) {
				IEnumerable<string> enumerable = lookup [element];
				Assert.That (enumerable.Count (), Is.EqualTo (1));
				Assert.That (enumerable.ElementAt (0), Is.EqualTo (element));
			}
		}
		#endregion

		#region null_comparer
		[Test]
		public void TestValueType_ValueKey_NullComparer ()
		{
			int[] ints = new [] {0, 1, 2, 3, 4, 5, 6};

			ILookup<int, int> lookup = ints.ToLookup (keySelector: it => it, comparer: null);

			Assert.That (lookup.Count, Is.EqualTo (ints.Length));
			foreach (int element in ints) {
				IEnumerable<int> enumerable = lookup [element];
				Assert.That (enumerable.Count (), Is.EqualTo (1));
				Assert.That (enumerable.ElementAt (0), Is.EqualTo (element));
			}
		}

		[Test]
		public void TestValueType_ReferenceKey_NullComparer ()
		{
			int[] ints = new [] {0, 1, 2, 3, 4, 5, 6};

			ILookup<string, int> lookup = ints.ToLookup (keySelector: it => it.ToString (), comparer: null);

			Assert.That (lookup.Count, Is.EqualTo (ints.Length));
			foreach (int element in ints) {
				string key = element.ToString ();
				IEnumerable<int> enumerable = lookup [key];
				Assert.That (enumerable.Count (), Is.EqualTo (1));
				Assert.That (enumerable.ElementAt (0), Is.EqualTo (element));
			}
		}

		[Test]
		public void TestReferenceType_ValueKey_NullComparer ()
		{
			string[] strings = new [] {"0", "1", "2", "3", "4", "5", "6"};

			ILookup<int, string> lookup = strings.ToLookup (keySelector: it => int.Parse (it), comparer: null);

			Assert.That (lookup.Count, Is.EqualTo (strings.Length));
			foreach (string element in strings) {
				int key = int.Parse (element);
				IEnumerable<string> enumerable = lookup [key];
				Assert.That (enumerable.Count (), Is.EqualTo (1));
				Assert.That (enumerable.ElementAt (0), Is.EqualTo (element));
			}
		}

		[Test]
		public void TestReferenceType_ReferenceKey_NullComparer ()
		{
			string[] strings = new [] {"0", "1", "2", "3", "4", "5", "6"};

			ILookup<string, string> lookup = strings.ToLookup (keySelector: it => it, comparer: null);

			Assert.That (lookup.Count, Is.EqualTo (strings.Length));
			foreach (string element in strings) {
				IEnumerable<string> enumerable = lookup [element];
				Assert.That (enumerable.Count (), Is.EqualTo (1));
				Assert.That (enumerable.ElementAt (0), Is.EqualTo (element));
			}
		}

		[Test]
		public void TestValueType_ValueKey_ValueElement_NullComparer ()
		{
			int[] ints = new [] {0, 1, 2, 3, 4, 5, 6};

			ILookup<int, int> lookup = ints.ToLookup (keySelector: it => it, elementSelector: it => it, comparer: null);

			Assert.That (lookup.Count, Is.EqualTo (ints.Length));
			foreach (int element in ints) {
				IEnumerable<int> enumerable = lookup [element];
				Assert.That (enumerable.Count (), Is.EqualTo (1));
				Assert.That (enumerable.ElementAt (0), Is.EqualTo (element));
			}
		}

		[Test]
		public void TestValueType_ValueKey_ReferenceElement_NullComparer ()
		{
			int[] ints = new [] {0, 1, 2, 3, 4, 5, 6};

			ILookup<int, string> lookup = ints.ToLookup (keySelector: it => it, elementSelector: it => it.ToString (), comparer: null);

			Assert.That (lookup.Count, Is.EqualTo (ints.Length));
			foreach (int element in ints) {
				string value = element.ToString ();
				IEnumerable<string> enumerable = lookup [element];
				Assert.That (enumerable.Count (), Is.EqualTo (1));
				Assert.That (enumerable.ElementAt (0), Is.EqualTo (value));
			}
		}

		[Test]
		public void TestValueType_ReferenceKey_ValueElement_NullComparer ()
		{
			int[] ints = new [] {0, 1, 2, 3, 4, 5, 6};

			ILookup<string, int> lookup = ints.ToLookup (keySelector: it => it.ToString (), elementSelector: it => it, comparer: null);

			Assert.That (lookup.Count, Is.EqualTo (ints.Length));
			foreach (int element in ints) {
				string key = element.ToString ();
				IEnumerable<int> enumerable = lookup [key];
				Assert.That (enumerable.Count (), Is.EqualTo (1));
				Assert.That (enumerable.ElementAt (0), Is.EqualTo (element));
			}
		}

		[Test]
		public void TestValueType_ReferenceKey_ReferenceElement_NullComparer ()
		{
			int[] ints = new [] {0, 1, 2, 3, 4, 5, 6};

			ILookup<string, string> lookup = ints.ToLookup (keySelector: it => it.ToString (), elementSelector: it => it.ToString (), comparer: null);

			Assert.That (lookup.Count, Is.EqualTo (ints.Length));
			foreach (int element in ints) {
				string key = element.ToString ();
				string value = element.ToString ();
				IEnumerable<string> enumerable = lookup [key];
				Assert.That (enumerable.Count (), Is.EqualTo (1));
				Assert.That (enumerable.ElementAt (0), Is.EqualTo (value));
			}
		}

		[Test]
		public void TestReferenceType_ValueKey_ValueElement_NullComparer ()
		{
			string[] strings = new [] {"0", "1", "2", "3", "4", "5", "6"};

			ILookup<int, int> lookup = strings.ToLookup (keySelector: it => int.Parse (it), elementSelector: it => int.Parse (it), comparer: null);

			Assert.That (lookup.Count, Is.EqualTo (strings.Length));
			foreach (string element in strings) {
				int key = int.Parse (element);
				int value = int.Parse (element);
				IEnumerable<int> enumerable = lookup [key];
				Assert.That (enumerable.Count (), Is.EqualTo (1));
				Assert.That (enumerable.ElementAt (0), Is.EqualTo (value));
			}
		}

		[Test]
		public void TestReferenceType_ValueKey_ReferenceElement_NullComparer ()
		{
			string[] strings = new [] {"0", "1", "2", "3", "4", "5", "6"};

			ILookup<int, string> lookup = strings.ToLookup (keySelector: it => int.Parse (it), elementSelector: it => it, comparer: null);

			Assert.That (lookup.Count, Is.EqualTo (strings.Length));
			foreach (string element in strings) {
				int key = int.Parse (element);
				IEnumerable<string> enumerable = lookup [key];
				Assert.That (enumerable.Count (), Is.EqualTo (1));
				Assert.That (enumerable.ElementAt (0), Is.EqualTo (element));
			}
		}

		[Test]
		public void TestReferenceType_ReferenceKey_ValueElement_NullComparer ()
		{
			string[] strings = new [] {"0", "1", "2", "3", "4", "5", "6"};

			ILookup<string, int> lookup = strings.ToLookup (keySelector: it => it, elementSelector: it => int.Parse (it), comparer: null);

			Assert.That (lookup.Count, Is.EqualTo (strings.Length));
			foreach (string element in strings) {
				int value = int.Parse (element);
				IEnumerable<int> enumerable = lookup [element];
				Assert.That (enumerable.Count (), Is.EqualTo (1));
				Assert.That (enumerable.ElementAt (0), Is.EqualTo (value));
			}
		}

		[Test]
		public void TestReferenceType_ReferenceKey_ReferenceElement_NullComparer ()
		{
			string[] strings = new [] {"0", "1", "2", "3", "4", "5", "6"};

			ILookup<string, string> lookup = strings.ToLookup (keySelector: it => it, elementSelector: it => it, comparer: null);

			Assert.That (lookup.Count, Is.EqualTo (strings.Length));
			foreach (string element in strings) {
				IEnumerable<string> enumerable = lookup [element];
				Assert.That (enumerable.Count (), Is.EqualTo (1));
				Assert.That (enumerable.ElementAt (0), Is.EqualTo (element));
			}
		}
		#endregion

		#region null_exception
		[Test]
		public void TestValueType_NullArgumentExceptions ()
		{
			int[] ints = new [] {0, 1, 2, 3, 4, 5, 6};
			IEqualityComparer<int> comparer = EqualityComparer<int>.Default;
			Func<int, int> func = it => it;

			Assert.Throws<ArgumentNullException> (() => ints.ToLookup<int, int> (keySelector: null));
			Assert.Throws<ArgumentNullException> (() => ints.ToLookup<int, int> (keySelector: null, comparer: comparer));

			Assert.Throws<ArgumentNullException> (() => ints.ToLookup<int, int, int> (keySelector: null, elementSelector: func));
			Assert.Throws<ArgumentNullException> (() => ints.ToLookup<int, int, int> (keySelector: null, elementSelector: func, comparer: comparer));

			Assert.Throws<ArgumentNullException> (() => ints.ToLookup<int, int, int> (keySelector: func, elementSelector: null));
			Assert.Throws<ArgumentNullException> (() => ints.ToLookup<int, int, int> (keySelector: func, elementSelector: null, comparer: comparer));

			Assert.Throws<ArgumentNullException> (() => ints.ToLookup<int, int, int> (keySelector: null, elementSelector: null));
			Assert.Throws<ArgumentNullException> (() => ints.ToLookup<int, int, int> (keySelector: null, elementSelector: null, comparer: comparer));
		}

		[Test]
		public void TestReferenceType_NullArgumentExceptions ()
		{
			string[] strings = new [] {"0", "1", "2", "3", "4", "5", "6"};
			IEqualityComparer<string> comparer = EqualityComparer<string>.Default;
			Func<string, string> func = it => it;

			Assert.Throws<ArgumentNullException> (() => strings.ToLookup<string, string> (keySelector: null));
			Assert.Throws<ArgumentNullException> (() => strings.ToLookup<string, string> (keySelector: null, comparer: comparer));

			Assert.Throws<ArgumentNullException> (() => strings.ToLookup<string, string, string> (keySelector: null, elementSelector: func));
			Assert.Throws<ArgumentNullException> (() => strings.ToLookup<string, string, string> (keySelector: null, elementSelector: func, comparer: comparer));

			Assert.Throws<ArgumentNullException> (() => strings.ToLookup<string, string, string> (keySelector: func, elementSelector: null));
			Assert.Throws<ArgumentNullException> (() => strings.ToLookup<string, string, string> (keySelector: func, elementSelector: null, comparer: comparer));

			Assert.Throws<ArgumentNullException> (() => strings.ToLookup<string, string, string> (keySelector: null, elementSelector: null));
			Assert.Throws<ArgumentNullException> (() => strings.ToLookup<string, string, string> (keySelector: null, elementSelector: null, comparer: comparer));
		}
		#endregion
	}
}