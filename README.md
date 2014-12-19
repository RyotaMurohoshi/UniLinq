# UniLinq (Beta)

Class library for LINQ to Objects on Unity GameEngine without Exceptions related AOT compile.

# What is UniLinq? Why UniLinq?

`UniLinq` is class library to use `Linq to Objects` on Unity GameEngine safely.

`LINQ` is one of the most powerful language features in C#. But on Unity + iOS, `LINQ to Objects` has a major problem. Under a particular set of conditions, some methods throw exceptions on Unity + iOS.

For example, next `Average` method 

```csharp
double average = new string[]{"Up", "Down", "Right", "Left"}.Average (it => it.Length);
```

returns average string length value accurately on Unity Editor and Android etc.

But on iOS, the example throws next Exception.

```
System.ExecutionEngineException : Attempting to JIT compile method 'System.Linq.Enumerable:Select<string, int> (System.Collections.Generic.IEnumerable`1<string>,System.Func`2<string, int>)' while running with --aot-only.
```

For iOS platform, Unity GameEnginge uses Ahead Of Time (AOT) compile. The exception is thrown only under the AOT compile situation.  More information for error condition and error log, please read `ErrorExampleAndErrorLog.md`.

This is so difficult problem.

* Exceptions are thrown only under the AOT compile situation (iOS).
* Conditions are so complex.

But we know that `LINQ to Objects` is so useful C# Language feature. So `UniLinq` aim is to provide the way to use `LINQ to Objects` without Exceptions related AOT compile.

# How to use

Import UniLinq.unitypackage and replace using directive from `System.Linq` to `UniLinq` where you use `Linq to Objects`.

So, change From

```
using System;
using System.Collections.Generic;

using System.Linq;
```

to

```
using System;
using System.Collections.Generic;

using UniLinq;
```

And you can write `LINQ to objects` codes that are equivalent to codes with System.Linq.

# Source codes from newer mono/mono

UniLinq is based on [mono/mono](https://github.com/mono/mono/tree/mono-3.10.0) (tag:mono-3.10.0) System.Linq namespace [source codes](https://github.com/mono/mono/tree/mono-3.10.0/mcs/class/System.Core/System.Linq). They are under the MIT License.

Many problesms related AOT compile has already fixed at original mono/mono. But Unity GameEngine is based on very old mono, so there are many problem related to AOT compile yet.

UniLinq is based on newer mono/mono System.Linq classes and interfaces source codes. Not only source codes but also compiler has enhanced on original newer mono/mono, some codes are changed from mono/mono to avoid problem related AOT compile additonaly.

# Author
Ryota Murohoshi is game Programmer in Japan.

* Posts:http://qiita.com/RyotaMurohoshi (JPN)
* Twitter:https://twitter.com/RyotaMurohoshi (JPN)

# License

This library is under MIT License.
