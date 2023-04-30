﻿# WorldQuakeViwer - Setting
設定についての解説です。

## 情報
バージョン情報、情報取得元などの情報一覧です。

## 表示・ログ
メイン画面の表示・動作ログなどの設定です。

## 更新検知
更新検知の対象となる情報を選択できます。

## 音声
情報受信時に音声を流します。音声はSoundフォルダに入っています。

## 読み上げ
棒読みちゃんにSocket通信で読み上げ指令を送信します。ホスト、ポートは特に変更する必要はありません。

内容はログに保存されるものと同じになります。

詳しくは棒読みちゃんに付属されている**SampleSrc\Socket通信で読み上げ指示を送る(ネット経由可・.NET版)\Src\BouyomiChanSample\Program.cs**などを参考にしてください。

---
**以下は高度な設定となります。**

## 自動ツイート
※Twitter APIの申請が必要です。tokenは暗号化しないので心配な場合Socket通信で別ソフトに送信して処理してください。

内容はログに保存されるものと同じになります。

## Socket通信
Socket通信で送信します。置き換えは対応を増やす予定です。

---

# その他

## 稼働状況
起動時間・アクセス回数を表示します。

- 設定は**UserSetting.xml**,**AppData\Local\Ichihai1415\WorldQuakeViewer.exe_Url_{ハッシュ値}\{バージョン}\user.config**に保存されます。

- 設定はUserSetting.xmlからAppDataにコピーされソフトに読み込まれるという流れです。保存は逆にAppDataに保存され、UserSetting.xmlにコピーされます。(バージョンが変わっても読み込みできるようにしています)

- 設定ウィンドウを閉じると設定が再読み込みされます。

---
---

# 更新履歴

## v1.1.0α2
2023/03/12

動作ログ・更新検知の説明を追加。

## v1.0.0
2022/12/24

v1.0.0の設定画面の説明を追加。