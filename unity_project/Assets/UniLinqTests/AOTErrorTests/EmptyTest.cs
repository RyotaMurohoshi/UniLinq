using System;
using System.Collections.Generic;
using UniLinq;
using NUnit.Framework;

namespace UniLinqTest
{
	[TestFixture]
	[Category("UniLinqTests")]
	class EmptyTest
	{
		[Test]
		public void TestValueType ()
		{
			IEnumerable<int> empty = Enumerable.Empty<int> ();
			Assert.That (empty.Count (), Is.EqualTo (0));
		}

		[Test]
		public void TestReferenceType ()
		{
			IEnumerable<string> empty = Enumerable.Empty<string> ();
			Assert.That (empty.Count (), Is.EqualTo (0));
		}
	}
}
