using UnityEngine;
using System.Collections.Generic;
using UniLinq;
using SL = System.Linq;
using NUnit.Framework;

namespace UniLinqTest
{
	[TestFixture]
	[Category ("UniLinqTests")]
	public class OrderByGenericTest
	{
		[Test]
		public void TestEmptyCalling ()
		{
			var arrayDepth = GetComponentsTopDown<Transform> (new GameObject (), true).ToArray ();
			Assert.AreEqual (1, arrayDepth.Length);
		}

		public static IEnumerable<T> GetComponentsTopDown<T> (GameObject gameObject, bool includeInactive) where T : Component
		{
			return gameObject
				.GetComponentsInChildren<T> (includeInactive)
				.OrderBy (x => x == null ? int.MinValue : GetDepthLevel (x.transform));
		}

		static int GetDepthLevel (Transform transform)
		{
			if (transform == null) {
				return 0;
			}else {
				return 1 + GetDepthLevel (transform.parent);
			}
		}
	}
}
