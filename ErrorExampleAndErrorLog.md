# Error method example and its error log

Some LINQ methods may throw System.ExecutionEngineException or System.TypeInitializationException in Unity + iOS.

Next listed methods have possibilities to throw the exceptions.

* Average
* Max
* Min
* Sum
* FirstOrDefault
* Last
* LastOrDefault
* Single
* SingleOrDefault
* ToDictionary
* ToLookup
* Join
* GroupJoin
* OrderBy
* OrderByDescending
* ThenBy
* ThenByDescending

This document has 

* Example code that throws exceptions at Unity + iOS.
* Log when exceptions are thrown.

# Average1

When next code is executed,

```
public void ExampleAverage1 ()
{
	new []{0, 1, 2}.Average (it => 2 * it);
}
```

log like next one will be shown.

```
Failed:Error
ExampleAverage1 (UniLinq.LinqErrorExample.LinqErrorExample.ExampleAverage1)
System.ExecutionEngineException : Attempting to JIT compile method 'System.Linq.Enumerable:<Average`1>m__28<int> (long,int)' while running with --aot-only.

  at System.Linq.Enumerable.Average[Int32,Int64,Double] (IEnumerable`1 source, System.Func`3 func, System.Func`3 result) [0x00000] in <filename unknown>:0 
  at System.Linq.Enumerable.Average[Int32] (IEnumerable`1 source, System.Func`2 selector) [0x00000] in <filename unknown>:0 
  at UniLinq.LinqErrorExample.LinqErrorExample.ExampleAverage1 () [0x00000] in <filename unknown>:0 
  at System.Reflection.MonoMethod.Invoke (System.Object obj, BindingFlags invokeAttr, System.Reflection.Binder binder, System.Object[] parameters, System.Globalization.CultureInfo culture) [0x00000] in <filename unknown>:0 
```

Conditions are 

* Average method with Delegate.
* TSource of `IEnumerable<TSource>` is reference type.




# Average2

When next code is executed,

```
public void ExampleAverage2 ()
{
	new []{"Up", "Down", "Right", "Left"}.Average (it => it.Length);
}
```

log like next one will be shown.


```
Failed:Error
ExampleAverage2 (UniLinq.LinqErrorExample.LinqErrorExample.ExampleAverage2)
System.ExecutionEngineException : Attempting to JIT compile method 'System.Linq.Enumerable:Select<string, int> (System.Collections.Generic.IEnumerable`1<string>,System.Func`2<string, int>)' while running with --aot-only.

  at System.Linq.Enumerable.Average[String] (IEnumerable`1 source, System.Func`2 selector) [0x00000] in <filename unknown>:0 
  at UniLinq.LinqErrorExample.LinqErrorExample.ExampleAverage2 () [0x00000] in <filename unknown>:0 
  at System.Reflection.MonoMethod.Invoke (System.Object obj, BindingFlags invokeAttr, System.Reflection.Binder binder, System.Object[] parameters, System.Globalization.CultureInfo culture) [0x00000] in <filename unknown>:0 
```

Conditions are 

* Average method with Delegate.
* TSource of `IEnumerable<TSource>` is reference type.


# Max, Min and Sum

When next codes are executed,

```
public void ExampleMax ()
{
	new []{"Up", "Down", "Right", "Left"}.Max (it => it.Length);
}

public void ExampleMin ()
{
	new []{"Up", "Down", "Right", "Left"}.Min (it => it.Length);
}

public void ExampleSum ()
{
	new []{"Up", "Down", "Right", "Left"}.Sum (it => it.Length);
}
```

log like next one will be shown.

```
Failed:Error
ExampleMax (UniLinq.LinqErrorExample.LinqErrorExample.ExampleMax)
System.ExecutionEngineException : Attempting to JIT compile method 'System.Linq.Enumerable:Iterate<string, int> (System.Collections.Generic.IEnumerable`1<string>,int,System.Func`3<string, int, int>)' while running with --aot-only.

  at System.Linq.Enumerable.Max[String] (IEnumerable`1 source, System.Func`2 selector) [0x00000] in <filename unknown>:0 
  at UniLinq.LinqErrorExample.LinqErrorExample.ExampleMax () [0x00000] in <filename unknown>:0 
  at System.Reflection.MonoMethod.Invoke (System.Object obj, BindingFlags invokeAttr, System.Reflection.Binder binder, System.Object[] parameters, System.Globalization.CultureInfo culture) [0x00000] in <filename unknown>:0 
```

Conditions are 

* Max, Min or Sum method with Delegate.
* TSource of `IEnumerable<TSource>` is reference type.


# FirstOrDefualt, Last, LastOrDefault, Single or SingleOrDefault

When next codes are executed,

```
public void ExampleFirstOrDefualt ()
{
	new []{0, 1, 2}.FirstOrDefault ();
}

public void ExampleLast ()
{
	new []{0, 1, 2}.Last ();
}

public void ExampleLastOrDefault ()
{
	new []{0, 1, 2}.LastOrDefault ();
}

public void ExampleSingle ()
{
	new []{0}.Single ();
}

public void ExampleSingleOrDefault ()
{
	new []{0}.SingleOrDefault ();
}
```

log like next one will be shown.

```
Failed:Error
ExampleFirstOrDefualt (UniLinq.LinqErrorExample.LinqErrorExample.ExampleFirstOrDefualt)
System.TypeInitializationException : An exception was thrown by the type initializer for PredicateOf`1
  ----> System.ExecutionEngineException : Attempting to JIT compile method 'System.Linq.Enumerable/PredicateOf`1<int>:.cctor ()' while running with --aot-only.

  at UniLinq.LinqErrorExample.LinqErrorExample.ExampleFirstOrDefualt () [0x00000] in <filename unknown>:0 
  at System.Reflection.MonoMethod.Invoke (System.Object obj, BindingFlags invokeAttr, System.Reflection.Binder binder, System.Object[] parameters, System.Globalization.CultureInfo culture) [0x00000] in <filename unknown>:0 
--ExecutionEngineException
```

Conditions are 

* FirstOrDefualt, Last, LastOrDefault, Single or SingleOrDefault with no Delegate
* TSource of `IEnumerable<TSource>` is value type.


# ToDictionary

When next code is executed,

```

public void ExampleToDictionary1 ()
{
	new []{0, 1, 2}.ToDictionary (it => it);
}

public void ExampleToDictionary2 ()
{
        IEqualityComparer<int> comparer = EqualityComparer<int>.Default;
        new []{0, 1, 2}.ToDictionary (it => it, comparer);
}
```

log like next one will be shown.

```
Failed:Error
ExampleToDictionary1 (UniLinq.LinqErrorExample.LinqErrorExample.ExampleToDictionary1)
System.TypeInitializationException : An exception was thrown by the type initializer for Function`1
  ----> System.ExecutionEngineException : Attempting to JIT compile method 'System.Linq.Enumerable/Function`1<int>:.cctor ()' while running with --aot-only.

  at System.Linq.Enumerable.ToDictionary[Int32,Int32] (IEnumerable`1 source, System.Func`2 keySelector) [0x00000] in <filename unknown>:0 
  at UniLinq.LinqErrorExample.LinqErrorExample.ExampleToDictionary1 () [0x00000] in <filename unknown>:0 
  at System.Reflection.MonoMethod.Invoke (System.Object obj, BindingFlags invokeAttr, System.Reflection.Binder binder, System.Object[] parameters, System.Globalization.CultureInfo culture) [0x00000] in <filename unknown>:0 
--ExecutionEngineException
```

Conditions are

* ToDictionary method with no elementSelector argument.
* TSource of `IEnumerable<TSource>` is value type.

# ToLookup1

When next code is executed,

```
public void ExampleToLookup1 ()
{
	new []{0, 1, 2}.ToLookup (it => it);
}
```

log like next one will be shown.

```
Failed:Error
ExampleToLookup1 (UniLinq.LinqErrorExample.LinqErrorExample.ExampleToLookup1)
System.TypeInitializationException : An exception was thrown by the type initializer for Function`1
  ----> System.ExecutionEngineException : Attempting to JIT compile method 'System.Linq.Enumerable/Function`1<int>:.cctor ()' while running with --aot-only.

  at System.Linq.Enumerable.ToDictionary[Int32,Int32] (IEnumerable`1 source, System.Func`2 keySelector) [0x00000] in <filename unknown>:0 
  at UniLinq.LinqErrorExample.LinqErrorExample.ExampleToDictionary1 () [0x00000] in <filename unknown>:0 
  at System.Reflection.MonoMethod.Invoke (System.Object obj, BindingFlags invokeAttr, System.Reflection.Binder binder, System.Object[] parameters, System.Globalization.CultureInfo culture) [0x00000] in <filename unknown>:0 
--ExecutionEngineException
```

Conditions are

* ToLookup method with only keySelector.
* TSource of `IEnumerable<TSource>` is value type.


# ToLookpup2

When next codes are executed,

```
public void ExampleToLookup2 ()
{
	IEqualityComparer<int> comparer = EqualityComparer<int>.Default;
	new []{0, 1, 2}.ToLookup (it => it, comparer);
}

public void ExampleToLookup3 ()
{
	IEqualityComparer<int> comparer = EqualityComparer<int>.Default;
	new []{"Up", "Down", "Right", "Left"}.ToLookup (it => it.Length, comparer);
}
```

log like next one will be shown.

```
Failed:Error
ExampleToLookup2 (UniLinq.LinqErrorExample.LinqErrorExample.ExampleToLookup2)
System.ExecutionEngineException : Attempting to JIT compile method 'System.Linq.Enumerable:<ToLookup`2>m__7A<int, int> (int)' while running with --aot-only.

  at System.Linq.Enumerable.ToLookup[Int32,Int32,Int32] (IEnumerable`1 source, System.Func`2 keySelector, System.Func`2 elementSelector, IEqualityComparer`1 comparer) [0x00000] in <filename unknown>:0 
  at System.Linq.Enumerable.ToLookup[Int32,Int32] (IEnumerable`1 source, System.Func`2 keySelector, IEqualityComparer`1 comparer) [0x00000] in <filename unknown>:0 
  at UniLinq.LinqErrorExample.LinqErrorExample.ExampleToLookup2 () [0x00000] in <filename unknown>:0 
  at System.Reflection.MonoMethod.Invoke (System.Object obj, BindingFlags invokeAttr, System.Reflection.Binder binder, System.Object[] parameters, System.Globalization.CultureInfo culture) [0x00000] in <filename unknown>:0 
```

Conditions are

* ToLookup method with argument keySelector and comparer (no element selector)

# Join and GroupJoin


When next code are executed,

```
public void ExampleJoin1 ()
{
	IEnumerable<int> result = Enumerable.Join (
		outer: new []{0, 1, 2},
		inner: new []{0, 1, 2},
		outerKeySelector: it => it,
		innerKeySelector: it => it,
		resultSelector: (outer, inner) => outer);

	Evaluate (result);
}

public void ExampleJoin2 ()
{
	IEnumerable<string> result = Enumerable.Join (
		outer: new []{"0", "1", "2"},
		inner: new []{"0", "1", "2"},
		outerKeySelector: it => int.Parse (it),
		innerKeySelector: it => int.Parse (it),
		resultSelector: (outer, inner) => outer);

	Evaluate (result);
}

public void ExampleJoin3 ()
{
	IEnumerable<int> result = Enumerable.Join (
		outer: new []{0, 1, 2},
		inner: new []{0, 1, 2},
		outerKeySelector: it => it.ToString (),
		innerKeySelector: it => it.ToString (),
		resultSelector: (outer, inner) => outer);

	Evaluate (result);
}

public void ExampleGroupJoin1 ()
{
	IEnumerable<int> result = Enumerable.GroupJoin (
		outer: new []{0, 1, 2},
		inner: new []{0, 1, 2},
		outerKeySelector: it => it,
		innerKeySelector: it => it,
		resultSelector: (outer, inners) => outer);

	Evaluate (result);
}

public void ExampleGroupJoin2 ()
{
	IEnumerable<string> result = Enumerable.GroupJoin (
		outer: new []{"0", "1", "2"},
		inner: new []{"0", "1", "2"},
		outerKeySelector: it => int.Parse (it),
		innerKeySelector: it => int.Parse (it),
		resultSelector: (outer, inners) => outer);

	Evaluate (result);
}

public void ExampleGroupJoin3 ()
{
	IEnumerable<int> result = Enumerable.GroupJoin (
		outer: new []{0, 1, 2},
		inner: new []{0, 1, 2},
		outerKeySelector: it => it.ToString (),
		innerKeySelector: it => it.ToString (),
		resultSelector: (outer, inners) => outer);

	Evaluate (result);
}
```

log like next one will be shown.

```
Failed:Error
ExampleJoin1 (UniLinq.LinqErrorExample.LinqErrorExample.ExampleJoin1)
System.ExecutionEngineException : Attempting to JIT compile method 'System.Linq.Enumerable:<ToLookup`2>m__7A<int, int> (int)' while running with --aot-only.

  at System.Linq.Enumerable.ToLookup[Int32,Int32,Int32] (IEnumerable`1 source, System.Func`2 keySelector, System.Func`2 elementSelector, IEqualityComparer`1 comparer) [0x00000] in <filename unknown>:0 
  at System.Linq.Enumerable.ToLookup[Int32,Int32] (IEnumerable`1 source, System.Func`2 keySelector, IEqualityComparer`1 comparer) [0x00000] in <filename unknown>:0 
  at System.Linq.Enumerable+<CreateJoinIterator>c__IteratorB`4[System.Int32,System.Int32,System.Int32,System.Int32].MoveNext () [0x00000] in <filename unknown>:0 
  at System.Linq.Enumerable.Count[Int32] (IEnumerable`1 source) [0x00000] in <filename unknown>:0 
  at UniLinq.LinqErrorExample.LinqErrorExample.ExampleJoin1 () [0x00000] in <filename unknown>:0 
  at System.Reflection.MonoMethod.Invoke (System.Object obj, BindingFlags invokeAttr, System.Reflection.Binder binder, System.Object[] parameters, System.Globalization.CultureInfo culture) [0x00000] in <filename unknown>:0 
``` 

This relates to ToLookup method exception because Join and GroupJoin uses ToLookup in its implementation.

Condition A

* Join or GroupJoin.
* TOuter of `IEnumerable<TOuter> outer` is value type.

Condition B

* Join or GroupJoin.
* TOuter of `IEnumerable<TOuter> outer` is reference type.
* TKey of `Function<TOuter, TKey> outerKeySelector` is value type.



# OrderBy or OrderByDescending

When next code is executed,

```
public void ExampleOrderBy ()
{
	foreach (int elment in new []{2, 1, 0}.OrderBy (it => it)) {
		;
	}
}

public void Example OrderByDescending ()
{
	foreach (int elment in new []{0, 1, 2}. OrderByDescending (it => it)) {
		;
	}
}
```

log like next one will be shown.

```
Failed:Error
ExampleOrderBy (UniLinq.LinqErrorExample.LinqErrorExample.ExampleOrderBy)
System.ExecutionEngineException : Attempting to JIT compile method 'System.Linq.OrderedEnumerable`1<int>:GetEnumerator ()' while running with --aot-only.

  at System.Linq.Enumerable.Count[Int32] (IEnumerable`1 source) [0x00000] in <filename unknown>:0 
  at UniLinq.LinqErrorExample.LinqErrorExample.ExampleOrderBy () [0x00000] in <filename unknown>:0 
  at System.Reflection.MonoMethod.Invoke (System.Object obj, BindingFlags invokeAttr, System.Reflection.Binder binder, System.Object[] parameters, System.Globalization.CultureInfo culture) [0x00000] in <filename unknown>:0 
```

Conditions are

* OrderBy method
* TSource of `IEnumerable<TSource>` is value type.

# ThenBy or ThenByDescending

When next codes are executed,

```
public void ExampleThenBy ()
{
	foreach(string element in new []{"Up", "Down", "Right", "Left"}
			.OrderBy (it => it [0])
			.ThenBy (it => it.Length)){
		;
	}
}

public void ExampleThenByDescending ()
{
	foreach(string element in new []{"Up", "Down", "Right", "Left"}
			.OrderBy (it => it [0])
			.ThenByDescending (it => it.Length)){
		;
	}
}
```

log like next one will be shown.

```
Failed:Error
ExampleThenBy (UniLinq.LinqErrorExample.LinqErrorExample.ExampleThenBy)
System.ExecutionEngineException : Attempting to JIT compile method 'System.Linq.OrderedEnumerable`1<string>:CreateOrderedEnumerable<int> (System.Func`2<string, int>,System.Collections.Generic.IComparer`1<int>,bool)' while running with --aot-only.

  at System.Linq.Enumerable.ThenBy[String,Int32] (IOrderedEnumerable`1 source, System.Func`2 keySelector, IComparer`1 comparer) [0x00000] in <filename unknown>:0 
  at System.Linq.Enumerable.ThenBy[String,Int32] (IOrderedEnumerable`1 source, System.Func`2 keySelector) [0x00000] in <filename unknown>:0 
  at UniLinq.LinqErrorExample.LinqErrorExample.ExampleThenBy () [0x00000] in <filename unknown>:0 
  at System.Reflection.MonoMethod.Invoke (System.Object obj, BindingFlags invokeAttr, System.Reflection.Binder binder, System.Object[] parameters, System.Globalization.CultureInfo culture) [0x00000] in <filename unknown>:0 
```

Conditions are

* ThenBy or ThenByDescending method with keySelecotor
* TKey of `Func<TSource, TKey> keySelector` is value type.

