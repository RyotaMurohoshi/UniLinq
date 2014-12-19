# NUnitLiteForUnity - Run tests on any platform -

# What is NUnitLiteForUnity?

NUnitLiteForUnity is test framework to test on each platforms containing iOS, AOT compile situation.

Unity is game engine and able to build games for multi platforms. PC, mobile platforms and video game console platforms. Without platform-dependent feature, we can use common codes to develop games for multi platforms.

But under AOT compile situation like iOS platform, Unity has a particular problem. For exameple, a error related to AOT compile happens when some LINQ methods are called. This error does't happen on UnityEditor or Android platform. 


When run next code on iOS,

```csharp
using UnityEngine;
using System.Linq;

public class Sample : MonoBehaviour
{
	void Start ()
	{
		int first = new []{0, 1, 2, 3}.FirstOrDefault ();
		Debug.Log (first);
	}
}
```

error happens.  Xcode shows next error log.

```
ExecutionEngineException: Attempting to JIT compile method 'System.Linq.Enumerable/PredicateOf`1<int>:.cctor ()' while running with --aot-only.


Rethrow as TypeInitializationException: An exception was thrown by the type initializer for PredicateOf`1
  at Sample.Start () [0x00000] in <filename unknown>:0 
```

Testing on each platform is so important because some error happens only on iOS platform but not on others.

NUnitLiteForUnity provides customized NUnitLite to use under AOT compile situation and its wrapper for Unity. We can test on each platform with NUnitLiteForUnity.

# How to use

## Define Test class

Please create test class for NUnitLite i.e. NUnit.

1. Add TestFixture attribute to test class.
2. Add Test attribute to test method.
3. Use Assert class in test method.

Next code is simple sample test class.


```csharp
using NUnit.Framework;

namespace NUnitLiteForUnity.Sample
{
	[TestFixture]
	public class SampleTest
	{
		[Test]
		public void TestSample ()
		{
			Assert.That (1 + 1, Is.EqualTo (2));
		}
	}
}
```

Do not put test class under Editor directory. NUnitLiteForUnity executes all tests in Assembly-CSharp assembly. If you put test class under Editor directory, test is not contained in Assembly-CSharp.

For more info about createing test, please read [here](http://nunit.org/index.php?p=quickStart&r=3.0).

## Define Test scene

Define test scene to execute on each platform.

1. Create new empty scene.
2. Create new GameObject.
3. Added TestRunnerBehaviour component to created GameObject.
4. (optional) Rename created GameObject to TestRunner.

Plese see Assets/NUnitLiteForUnity/Scenes/test_scene.unity.

## Executing Test
Set test scene to initial launch scene at BuildSettings. Build and run to test on each platform.

# Project Contents
## Assets/Editor/UnityPackageExporter.cs

Editor script to export NUnitLiteForUnity unitypackage.

## Assets/NUnitLiteForUnity/NUnitLite/nunitlite.dll

Customized NUnitLite DLL for NUnitLiteForUnity.

## Assets/NUnitLiteForUnity/Sample/SampleTest.cs

Sample test class.

## Assets/NUnitLiteForUnity/Scenes/test_scene.unity

When this scene is executed, tests are executed.

## Assets/NUnitLiteForUnity/Scripts/NUnitLiteForUnityTestRunner.cs

When NUnitLiteForUnityTestRunner class's RunTests method is called, all tests in Assembly-CSharp assembly are extecuted and results are shown via Debug.Log.

## Assets/NUnitLiteForUnity/Scripts/TestRunnerBehaviour.cs

TestRunnerBehaviour extends MonoBehaviour. This class calls NUnitLiteForUnityTestRunner's RunTests method at Start.

## Assets/NUnitLiteForUnity/LICENSE.txt

Liscense of NUnitLiteForUnity.

## Assets/NUnitLiteForUnity/CHANGES.md

NUnitLiteForUnity change log.

# What's NUnitLite? Why NUnitLite?

NUnitLite is a lightweight testing framework for .NET, based on the ideas in NUnit. NUnitLite is an open source project, available under the MIT License

[Unity Test Tools](https://www.assetstore.unity3d.com/jp/#!/content/13802) created by Unity Technologies uses NUnit. When tests are executed with NUnit on iOS device, an error related AOT compile happens. But with NUnitLite, no error happens.


NUnitLiteForUnity uses NUnitLite to execute tests on multi platforms containing iOS.

More information about NUnitLite, Please read [here](http://nunitlite.org/).

# NUnitLite Customize
To test on iOS Devices, I edited NUnitLite.

Original source code is on the [nunit/nunitlite](https://github.com/nunit/nunitlite)'s [this commit](3808d7fe49f8c24771ae804701adce0c21583d37).

The DLL in NUnitLiteForUnity was build with Xamarin for .NET 2.0, and added some changed.

## Deleted TcpWriter

NUnitLite.Runner.TcpWriter class uses  System.Net.Sockets namespace classes.


To use System.Net.Sockets namespace classes on iOS platform, Unity iOS Pro liscense is needed.

If there is no Unity iOS Pro liscense, console shows next message at the build time.

```
Error building Player: SystemException: System.Net.Sockets are supported only on Unity iOS Pro. Referenced from assembly 'nunitlite'.
```

To run tests without Unity iOS Pro liscense, NUnitLite.Runner.TcpWriter was deleted.

## Edited WorkItems class's Completed event

NUnit.Framework.Internal.WorkItems class has `Completed` event. Under the AOT compile situation, a error happens when external DLL class's event is raised.

```
ExecutionEngineException: Attempting to JIT compile method '(wrapper managed-to-native) System.Threading.Interlocked:CompareExchange (System.EventHandler&,System.EventHandler,System.EventHandler)' while running with --aot-only.

  at NUnit.Framework.Internal.WorkItems.WorkItem.add_Completed (System.EventHandler value) [0x00000] in <filename unknown>:0 
  at NUnit.Framework.Internal.WorkItems.CompositeWorkItem.RunChildren () [0x00000] in <filename unknown>:0 
  at NUnit.Framework.Internal.WorkItems.CompositeWorkItem.PerformWork () [0x00000] in <filename unknown>:0 
  at NUnit.Framework.Internal.WorkItems.WorkItem.RunTest () [0x00000] in <filename unknown>:0 
  at NUnit.Framework.Internal.WorkItems.WorkItem.Execute (NUnit.Framework.Internal.TestExecutionContext context) [0x00000] in <filename unknown>:0 
  at NUnit.Framework.Internal.NUnitLiteTestAssemblyRunner.Run (ITestListener listener, ITestFilter filter) [0x00000] in <filename unknown>:0 
  at NUnitLiteForUnity.NUnitLiteForUnityTestRunner.RunTests () [0x00000] in <filename unknown>:0 
  at NUnitLiteForUnity.TestRunnerBehaviour.Start () [0x00000] in <filename unknown>:0 
```

To avoid this error, added next change.

```csharp
// original code
// public event EventHandler Completed;

public event EventHandler Completed { add { completed += value; } remove { completed -= value; } }
EventHandler completed;
```

```csharp
// original code
// if (Completed != null)
//		 Completed(this, EventArgs.Empty);

if (completed != null)
	completed(this, EventArgs.Empty);
```

# Author
Ryota Murohoshi is game Programmer in Japan.

* Posts:http://qiita.com/RyotaMurohoshi (JPN)
* Twitter:https://twitter.com/RyotaMurohoshi (JPN)

# License

This library is under MIT License.