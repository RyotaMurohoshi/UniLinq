# UniLinq (Obsolete)

Unity上でAOTコンパイル関連のエラーを回避し、LINQ to Objectsを使うためのクラスライブラリでした。
UnityはAOTコンパイラに不具合があります。
このバグにより、いくつかの条件を満たした場合LINQメソッドを用いると実行時例外が発生しました。

現在、iOSをはじめとしたいくつかのプラットホームではIL2CPPが使われています。
そのためAOTコンパイラのバグなしで、安全にLINQのメソッドを今では使うことができるようになりました。

UniLinqは現在非推奨です。

# 作者

室星亮太

* 投稿先:http://qiita.com/RyotaMurohoshi
* Twitter:https://twitter.com/RyotaMurohoshi

# ライセンス
MIT License です。