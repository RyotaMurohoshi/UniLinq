using System.Reflection;

namespace NUnitLiteForUnity
{
	public class AssemblyGetter
	{
		public static Assembly Assembly { get { return typeof(NUnitLiteForUnity.AssemblyGetter).Assembly; } }
	}
}
