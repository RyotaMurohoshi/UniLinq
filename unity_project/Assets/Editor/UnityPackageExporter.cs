using UnityEditor;
using UnityEngine;

namespace UniLinq.Utility
{
	public class UnityPackageExporter
	{
		[MenuItem("Assets/Export UniLinq")]
		public static void ExportUnityPackage ()
		{
			Debug.Log ("Export UniLinq");
			AssetDatabase.ExportPackage ("Assets/UniLinq", "UniLinq.unitypackage", ExportPackageOptions.Recurse);
		}
	}
}