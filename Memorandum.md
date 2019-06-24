# 覚書 ～Memorandum～


## クラスごとの覚書

### Initialize.cs
	- 参照の追加でSystem.Windows.Formsを追加する
	- Docs参照
	(https://docs.microsoft.com/ja-jp/dotnet/api/system.windows.forms.screen.primaryscreen?view=netframework-4.8#System_Windows_Forms_Screen_PrimaryScreen)

## 設計に関する覚書
### Mainwindow
	- 被験者情報(名前・学部・学年)を入力する欄
	- 次へ
	- 新しいWindow(SelectWindow)で作成した実験用Windowを選択してもらう
	- 実験用Windowを開く

### 実験用Window(ResearchWindowN)
	- ユーザのマウスカーソルの軌跡を取れるようにする
	(ログとして操作の時間と座標を取得していく やり方は後で考える)
	- ユーザのマウスカーソルの軌跡を再現できる機能を実装する

## 雑多な覚書
	- 標準出力
	```C#
	Console.WriteLine("Hello World!");
	```
## 