using UnityEngine;
using System.Reflection;

namespace NUnitLiteForUnity
{
	public class TestRunnerBehaviour : MonoBehaviour
	{
		void Start ()
		{
			NUnitLiteForUnityTestRunner.RunTests ();
		}
	}
}