<!--GitHub用開始-->
![GitHub](https://img.shields.io/github/license/Ichihai1415/WorldQuakeViewer)
![GitHub Release Date](https://img.shields.io/github/release-date/Ichihai1415/WorldQuakeViewer)
![GitHub tag (latest by date)](https://img.shields.io/github/v/tag/Ichihai1415/WorldQuakeViewer)
![GitHub commit activity](https://img.shields.io/github/commit-activity/m/Ichihai1415/WorldQuakeViewer)
![GitHub commits since latest release (by date)](https://img.shields.io/github/commits-since/Ichihai1415/WorldQuakeViewer/latest)
<div display="flex">
  <img alt="v1.0.0" src="https://github.com/Ichihai1415/WorldQuakeViewer/blob/main/image/WQV_20221224_v1.0.0.png" width="49%" />
  <img alt="v1.0.4" src="https://github.com/Ichihai1415/WorldQuakeViewer/blob/main/image/WQV_20230206_v1.0.4.png" width="49%" />
</div>
<!--GitHub用終了-->

世界の地震情報を表示します。

[MITライセンス](https://opensource.org/licenses/mit-license.php)で公開しています。確認してください。

バグ、予定等は[Issue](https://github.com/Ichihai1415/WorldQuakeViewer/issues)を確認してください。

[詳細(現在制作中)](https://Ichihai1415.github.io/programs/released/wqv/)

---
---
# 更新履歴
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

---
#### 以下は[ここ](https://github.com/Ichihai1415/WorldQuakeViewer_Beta)にあります。
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