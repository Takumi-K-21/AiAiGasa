【ダウンロード時の注意点】</br>
「Open with Github Desktop」からダウンロードするようにしてください。</br>
「Download ZIP」だとScriptableObjectのデータが動作しない可能性があります。</br>
</br>

【本ゲームの紹介動画】</br>
本ゲームの紹介動画のURL：https://www.youtube.com/watch?v=7kSCafligiA</br>
</br>

【unityroom】</br>
unityroomに投稿したゲームのURL：https://unityroom.com/games/aiaigasa</br>
</br>

【タイトル】</br>
相合い傘</br>
</br>

【ジャンル】</br>
2Dアクションゲーム</br>
</br>

【コンセプト】</br>
主人公が相合い傘で彼女を守るゲームです。</br>
</br>

【あらすじ】</br>
彼女とデートをしていた帰り道、急に雨が降ってきてしまった。</br>
あいにく彼女は傘を持っておらず、相合い傘で距離を縮めるチャンスかと思ったら・・・？</br>
</br>

【開発期間】</br>
約1週間</br>
</br>

【開発メンバー】</br>
サウンドクリエイター、プログラマーの2人</br>
</br>

【担当】</br>
プログラマーとして、企画、プログラム、Unityを用いた機能の実装を担当しました。</br>
プログラム、Unityを用いた機能の実装は1人で取り組みました。</br>
書いたプログラムは「Assets/Scripts」と「Assets/MyGameLib/Scripts」にあります。</br>
</br>

【動作環境】</br>
OS：Windows11（Windows10/Macで動作確認をしていません）</br>
Unity：2022.3.61f1</br>
</br>

【ゲームプレイ時の注意点】</br>
ゲームをプレイするには、「Assets/Scenes」から「Title」を読み込んで、Playボタンを押してください。</br>
</br>

【操作方法】</br>
キーボードとマウスを使います。</br>
Aキーで左に移動、Dキーで右に移動します。</br>
マウスのカーソルで傘を操作します。</br>
</br>

【ルール】</br>
彼氏と傘を操作して彼女が雨に濡れないようにしてください。</br>
彼女は雨に濡れると好感度ゲージが低下します。</br>
好感度ゲージが0になるか、彼女が画面外にいくとゲームオーバーです。</br>
3つのラウンドを突破するとゲームクリアです。</br>
</br>

【プレイ時間】</br>
約3分</br>
 </br>
 
【概要】</br>
このゲームは「Unity1週間ゲームジャム」で開発しました。「Unity1週間ゲームジャム」とは、提示されたお題から1週間でゲームを完成させる企画で、今回のお題は「あい」でした。そこで、「相合い傘」をテーマにしたゲームを開発しました。</br>
</br>

【工夫した点】</br>
工夫した点は、再利用性や保守性を意識した設計・実装を行い、チームで扱いやすく、今後の開発にも応用できるプログラムを書いたことです。</br>
BGMやSEの再生・停止はシングルトンを用いて一行で実行できるようにし、ボタンの入力やアニメーション制御などの共通処理には、継承やインターフェースを活用して、ライブラリ化しました。特に、サウンド関連の処理は、ScriptableObjectを用いて設定できるようにしたことで、非プログラマーでも簡単にBGMやSEの管理を行えるようにしました。また、大量に生成・破棄されるオブジェクトには、オブジェクトプールのデザインパターンを導入し、パフォーマンスの最適化も図りました。</br>
</br>

【苦労した点】</br>
苦労した点は、テーマを決める際、ゲーム性やインパクトを実装にどう落とし込むかでメンバーと意見が衝突したことです。</br>
候補として、「藍色」か「相合い傘」を検討していました。藍色は、タイトルやサムネイルのインパクトはあるが、48種類ある藍色の中からランダムに提示された色を、スライダーでRGBを操作して当てるのは難易度が高く、正解したときの達成感を味わうことができないため、ゲーム性に課題がありました。一方、相合い傘は、主人公と傘を操作して彼女を雨から守るという明確なゲーム性はあるが、プレイしたときのインパクトがないという課題がありました。そこで、それぞれプロトタイプを開発し、動作を確認することにしました。</br>
その結果、傘を360度振り回せるように実装することで、インパクトを与えられると判断し、テーマを相合い傘に決定しました。</br>
 </br>
 
【使用したアセット】</br>
DOTween (HOTween v2)</br>
説明：UIのアニメーション（拡大、縮小など）に使用しました。</br>
URL：https://assetstore.unity.com/packages/tools/animation/dotween-hotween-v2-27676?locale=ja-JP&srsltid=AfmBOorrUta5t7d3RT0o7JvhQdkvy2inB5To__yaDNWTuhnepgCz4Rgg</br>
</br>
Kenney Input Prompts</br>
説明：操作方法のUIに使用しました。</br>
URL：https://kenney.nl/assets/input-prompts</br>
</br>
UniTask</br>
説明：カウントダウンに使用しました。</br>
URL：https://github.com/Cysharp/UniTask</br>
</br>
Unity-FadeManager</br>
説明：フェードイン、フェードアウトに使用しました。</br>
URL：https://github.com/Cysharp/UniTask</br>
</br>
unityroom-tweet</br>
説明：Xのポスト機能に使用しました。</br>
URL：https://github.com/Cysharp/UniTask</br>
</br>
やさしさゴシックボールドV2</br>
説明：ゲームのフォントに使用しました。</br>
URL：https://flopdesign.booth.pm/items/1833993</br>
</br>

【参考にしたサイト】</br>
オブジェクトプール（Object Pool）</br>
説明：オブジェクトプールのプログラムを使用しました。</br>
URL：https://zenn.dev/twugo/books/21cb3a6515e7b8/viewer/c6b6a1</br>
