# WorldQuakeViewer

<!--更新時CtrlForm.csのversionと_versionとアセンブリのバージョンとこれを変更-->
<!--画像開始-->
![GitHub last commit](https://img.shields.io/github/last-commit/Ichihai1415/WorldQuakeViewer)
![GitHub issues](https://img.shields.io/github/issues/Ichihai1415/WorldQuakeViewer)
![GitHub all releases](https://img.shields.io/github/downloads/Ichihai1415/WorldQuakeViewer/total)
![GitHub all releases](https://img.shields.io/github/downloads-pre/Ichihai1415/WorldQuakeViewer/latest/total)

![GitHub release (latest by date)](https://img.shields.io/github/v/release/Ichihai1415/WorldQuakeViewer)
![GitHub Release Date](https://img.shields.io/github/release-date/Ichihai1415/WorldQuakeViewer)
<!--古いから消しとく
<div display="flex">
  <img alt="v1.0.0" src="https://github.com/Ichihai1415/WorldQuakeViewer/blob/main/image/WQV_20221224_v1.0.0.png" width="49%" />
  <img alt="v1.0.4" src="https://github.com/Ichihai1415/WorldQuakeViewer/blob/main/image/WQV_20230206_v1.0.4.png" width="49%" />
</div>-->
<!--画像終了-->

世界の地震情報を表示します。

[詳細(Wiki)](https://github.com/Ichihai1415/WorldQuakeViewer/wiki)

[バグ、予定等(Issue)](https://github.com/Ichihai1415/WorldQuakeViewer/issues)

# 更新履歴
## v1.2.0
2023/12/29

大規模な改修を行いました。流れは[43bb7e1...6c8f967](https://github.com/Ichihai1415/WorldQuakeViewer/compare/43bb7e1...6c8f967)などで確認できます。

<details><summary>過去のバージョン</summary><div>

# v1.1.1
2023/11/29

**v1.1.0と同じく、まだ完全ではありません。(臨時対応版です)**

EMSCからの取得をGFZに変更

EMSCの更新

検知対象が変わらなかった?問題を修正(GFZ対応済み)

## v1.1.0

2023/10/08

**まだ完全ではないですが、ここから大規模な改修を行うためここでv1.1.0とします。問題が発生した場合過去のバージョンを使ってください。**

**コードを大きく変更したため不具合が起きる可能性があります。**

処理・表示等調整

自動ツイート機能廃止

## v1.1.0α6(内部バージョン1.0.10)
2023/07/05

**一部の設定名が変更されているため再設定が必要です。**

**コードを大きく変更したため不具合が起きる可能性があります。**

EMSCの表示に対応

画像を描画し表示するように 地図を更新(プレート境界追加)

WebHook送信仮追加(WebHookURL.txtを作成し送信するURLを入力してください)

その他各処理調整等

## v1.1.0α5(内部バージョン1.0.9)
2023/04/30

処理量更新直後初回判定になる問題を修正

表示調整

## v1.1.0α4(内部バージョン1.0.8)
2023/04/30

震源コード取得処理変更

処理数調整可能に

小規模コード修正

## v1.1.0α3(内部バージョン1.0.7)
2023/03/14

※一部の機能を先行公開します。不完全なところもあるためご注意ください。

最新の情報のMMIに()がつく問題を修正

## v1.1.0α2(内部バージョン1.0.6)
2023/03/12

※一部の機能を先行公開します。不完全なところもあるためご注意ください。

更新検知の対象を分割

地震履歴保存方法調整

その他コード修正(中規模、一部の動作がおかしくなる可能性あり)

## v1.1.0α1(内部バージョン1.0.5)
2023/03/11

※一部の機能を先行公開します。不完全なところもあるためご注意ください。

feedの取得先をweekに(インデックスが範囲を超えていますエラーの対処)

改正メルカリ震度階級・最大速度・気象庁震度階級の相互変換機能追加

動作ログ出力追加(内部に保存され1時間ごとに削除されます。保存しない場合"nolog.txt"を実行ファイルと同じフォルダに入れてください。(仮処置))

震源ログの自動削除を無効化(長期間起動しているとメモリ使用率が大きくなる可能性があります。右クリックメニューで削除できます。)

その他コード修正(中規模、一部の動作がおかしくなる可能性あり)

## v1.0.4
2023/01/02

更新確認処理を修正

画面表示タイミングを変更

## v1.0.3
2022/12/25

新規情報追加時履歴の表示が変わらない問題を修正

Y座標がはみ出す場合収まるように

## v1.0.2
2022/12/24

初回起動時エラーになる問題を修正

## v1.0.1
2022/12/24

履歴更新処理・棒読みちゃん送信テキスト修正

その他一部修正

## v1.0.0
2022/12/24

履歴表示機能等追加

設定画面追加

更新処理を履歴すべて(7件)で行います。

などなど

</div></details>
<details><summary>ベータバージョン</summary><div>
https://github.com/Ichihai1415/WorldQuakeViewer_Beta にあります。

## v0.2.6
7/16

メッセージ表示機能追加

アップデータミス修正

## v0.2.5
7/12

情報が更新しても表示されない問題を修正

ログの保存フォルダをさらに細かく

ログ出力、ツイートでのエラー時の動作を調整

## v0.2.4
7/9

表示、ログ、ツイート文微修正

## v0.2.3
7/2

アップデータ実装(ダウンロードと解凍のみ)

表示、ログ、ツイート文微修正

## v0.2.2
5/18

表示微修正

ログ出力機能追加

## v0.2.1
4/30

地図描画ミス修正(完全)

地図に赤道・本初子午線がわかりやすく

## v0.2.0
4/29

震源印対応

ツイート文調整(緯度経度、「更新」←直前と比較しているためつかない場合あり)

地図描画ミス修正(まだ南緯の時描画が正常ではない)

一部処理変更

## v0.1.1
4/21

地図描画ミス修正(まだ南緯の時描画が正常ではない)

## v0.1.0
4/21

震源名日本語対応

震源を中心としたマップ表示

</div></details>