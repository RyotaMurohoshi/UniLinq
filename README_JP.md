# UniLinq (Beta)

Unity上でAOTコンパイル関連のエラーを回避し、LINQ to Objectsを使うためのクラスライブラリです。

# UniLinqとは？なぜUniLinq?

`UniLinq`は、Unity上で安全に`Linq to Objects`を使うためのクラスライブラリです。

`LINQ`は、プログラミング言語C#で、最も強力な言語機能の一つです。しかしUnity+iOSでは、`LINQ to Objects`は大きな問題を持っています。特定の条件下で、Unity + iOS上ではいくつかのメソッドで例外が発生するのです。

例えば、次の`Average`メソッドは、

```csharp
double average = new string[]{"Up", "Down", "Right", "Left"}.Average (it => it.Length);
```

UnityエディタやAndroidなどでは、文字列の長さの平均値を正確に計算します。

しかしiOSでは、先ほどのコードは次のように例外を投げます。

```
System.ExecutionEngineException : Attempting to JIT compile method 'System.Linq.Enumerable:Select<string, int> (System.Collections.Generic.IEnumerable`1<string>,System.Func`2<string, int>)' while running with --aot-only.
```

Unty、iOS用のビルドではAhead Of Time (AOT)コンパイルをします。さきほどの例外は、AOTコンパイルをする状況下のみで発生します。エラーの条件やエラーログについての更に詳しい情報は、`ErrorExampleAndErrorLog.md`を見てください。

これは非常に難しい問題です。

* iOSなど、AOTコンパイルの元でしか、例外が発生しないこと
* 条件が複雑であること(特定オーバーロードと型パラメータが参照型か値型かで違うなど)

だからです。

このようにUnity + iOSでは問題がありますが、LINQは非常に強力な言語機能です。

UniLinqの目標は、AOTコンパイル関連の例外が発生すること無く、LINQ to Objectsを使う方法を提供することです。

# 使い方

UniLinq.unitypackageをインポートしてください。
そしてLINQを使っている箇所で、`System.Linq`を`UniLinq`に変更してください。

つまり、これを

```
using System;
using System.Collections.Generic;

using System.Linq;
```

次のように変更してください。

```
using System;
using System.Collections.Generic;

using UniLinq;
```

後は通常の`LINQ to Objects`のコードを書いて下さい。

# mono/monoベースのクラスライブラリ

UniLinqは、[mono/mono](https://github.com/mono/mono/tree/mono-3.10.0) (tag:mono-3.10.0)の System.Linq 名前空間の[コード](https://github.com/mono/mono/tree/mono-3.10.0/mcs/class/System.Core/System.Linq)をベースにしています。それらは、MITライセンスで提供されています。

オリジナルのmono/monoは、AOTコンパイルに関連する問題の多くが解決されています。しかし、Unity GameEngineは非常に古いmonoをベースにしていて、まだAOTコンパイルに関連するエラーは解決されていません。

UniLinqは、新しいmono/monoのSystem.Linqクラスとインターフェースのコードをベースにしています。新しいmono/monoでは、ソースコードだけでなくコンパイラも改善されています。そのため、元のmono/monoのソースコードをそのまま使っても例外が発生します。そこで、UniLinqでは、いくつか修正を加えています。

# 作者

室星亮太

* 投稿先:http://qiita.com/RyotaMurohoshi
* Twitter:https://twitter.com/RyotaMurohoshi

# ライセンス
MIT License です。