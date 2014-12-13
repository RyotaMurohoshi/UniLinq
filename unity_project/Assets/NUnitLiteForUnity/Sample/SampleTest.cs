using NUnit.Framework;

namespace NUnitLiteForUnity.Sample
{
	[TestFixture]
	public class SampleTest
	{
		[Test]
		public void TestPass ()
		{
			Assert.That (1 + 1, Is.EqualTo (2));
		}

		[Test]
		public void TestFailure ()
		{
			Assert.That (1 + 1, Is.EqualTo (1));
		}

		[Test]
		public void TestError ()
		{
			throw new System.Exception ("Invalid!");
		}

		[Test]
		[Ignore]
		public void TestIgnore ()
		{

		}
	}
}