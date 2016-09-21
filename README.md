# 【Unity】描いた絵をクラウドで共有しましょ！
### 簡単な絵を描く、クラウドに保存・取得するのアプリ「Blackboard」
<img src="readme-img/illustration.png" width="800px"/>

## 概要
* [ニフティクラウドmobile backend](http://mb.cloud.nifty.com/)の『ファイルストア機能』を利用してUnityのサンプルプゲームプロジェクトです
* 簡単な操作ですぐに [ニフティクラウドmobile backend](http://mb.cloud.nifty.com/)の機能を体験いただけます★☆

## ニフティクラウドmobile backendって何？？
スマートフォンアプリのバックエンド機能（プッシュ通知・データストア・会員管理・ファイルストア・SNS連携・位置情報検索・スクリプト）が**開発不要**、しかも基本**無料**(注1)で使えるクラウドサービス！今回はデータストアを体験します

注1：詳しくは[こちら](http://mb.cloud.nifty.com/price.htm)をご覧ください

![画像2](https://github.com/natsumo/SwiftLoginApp/blob/master/readme-img/002.png)

## 動作環境
* windows7以上、或いはOS X
* Unity5.3.5以上

※上記内容で動作確認をしています。


## 手順
###『STEP 1』アカウントせ作成 ⇒ アプリ起動
### 1. [ニフティクラウドmobile backend](http://mb.cloud.nifty.com/)の会員登録とログイン→アプリ作成

* 上記リンクから会員登録（無料）をします。登録ができたらログインをすると下図のように「アプリの新規作成」画面が出るのでアプリを作成します

![画像3](readme-img/register.png)

* アプリ作成されると下図のような画面になります
* この２種類のAPIキー（アプリケーションキーとクライアントキー）はXcodeで作成するiOSアプリに[ニフティクラウドmobile backend](http://mb.cloud.nifty.com/)を紐付けるために使用します

![画像4](https://github.com/natsumo/SwiftLoginApp/blob/master/readme-img/004.png)

### 2. [GitHub](https://github.com/hounenhounen/UnityLoginApp)からサンプルプロジェクトの<a href="https://github.com/ellentby/Blackboard/archive/master.zip">ダウンロード</a>

### 3. Unityでアプリを起動

* ダウンロードしたフォルダを解凍し、Unityから開いてください。その後、loginシーンを開いてください。


### 4. APIキーの設定

* loginシーンの`NCMBSettings`を編集します
* 先程[ニフティクラウドmobile backend](http://mb.cloud.nifty.com/)のダッシュボード上で確認したAPIキーを貼り付けます

![画像07](https://github.com/hounenhounen/UnityLoginApp/blob/master/readme-img/ApiKey.png)

* それぞれ`YOUR_NCMB_APPLICATION_KEY`と`YOUR_NCMB_CLIENT_KEY`の部分を書き換えます
 * このとき、ダブルクォーテーション（`"`）を消さないように注意してください！
* 書き換え終わったら、シーンを保存して下さい。

### 5. アプリ再生
* Unity画面で上部真ん中の実行ボタン（さんかくの再生マーク）をクリックしして、次の画面が出たら、成功になります！

<img src="readme-img/blackboard-empty.png" width=600px>

<br/>
###『STEP 2』アプリ操作　＆　動作確認
* ブラックボードに適当な絵をか描いて下さい。そして、「Save」ボタンをクリックして下さい。
<img src="readme-img/01draw.png" width="700px"/>
* セーブが完了したら、ブラックボードは初期化にされます。そして、「Gallery」をクリックすると、先ほどか描いた絵を確認できます。
<img src="readme-img/02check.png" width="900px"/>

---------
* ダッシュボードで動作確認しましょう！
  1. ニフティクラウドmobile backendの<a href="https://console.mb.cloud.nifty.com">ダッシュボード</a>で、左の「ファイルストア」をクリックして下さい。
  2. 先ほど描いた絵のファイルを確認しましょう。
![画像14](readme-img/03filestore.png)

##機能解説
プロジェクトのコードファイルは以下の五つになります。これから、`「SaveImage.cs」`と`「LoadImage.cs」`について解説します。
`````````
`````Asset/script
``````````ButtonController.cs     ボタンのclickeventの処理
``````````DrawLine.cs             絵を描く機能の処理
``````````ScreenAdapter.cs        シーン「gallery」に展示する四枚の画像の位置・サイズ調整
``````````SaveImage.cs            描いた絵をスクリーンショットで取得し、クラウドに保存する
``````````LoadImage.cs            クラウドで保存された最新の四枚の画像を取得し、展示する
`````````
###「SaveImage.cs」画像を取得し、クラウドに保存
* <a href="https://docs.unity3d.com/ScriptReference/Texture2D.ReadPixels.html">Texture2D.ReadPixels()</a>関数にとうして、変量「camera」が撮った画面をbyte[]のタイプでれ
``````cs
public Camera camera;
RenderTexture renderTexture;

public void saveImage () {
		float width = Screen.width;
		float height = Screen.height;
	
		renderTexture = new RenderTexture (Screen.width, Screen.height, 0);
		camera.targetTexture = renderTexture;
		camera.Render ();

		RenderTexture.active = renderTexture;
		Texture2D virtualPhoto =
			new Texture2D((int)width, (int)height, TextureFormat.RGB24, false);
		// false, meaning no need for mipmaps
		virtualPhoto.ReadPixels( new Rect(0, 0, width, height), 0, 0);

		RenderTexture.active = null; //can help avoid errors 
		camera.targetTexture = null;

		byte[] bytes;
		bytes = virtualPhoto.EncodeToPNG();
		saveToCloud (bytes,getName());
	}
``````


## 参考
* ニフティクラウドmobile backend の[ドキュメント（会員管理）](http://mb.cloud.nifty.com/doc/current/user/basic_usage_unity.html)
* ニフティクラウドmobile backend の[ドキュメント（ファイルストア）](http://mb.cloud.nifty.com/doc/current/filestore/basic_usage_unity.html)
* ニフティクラウドmobile backend の[ドキュメント（データストア）](http://mb.cloud.nifty.com/doc/current/datastore/basic_usage_unity.html)
* このアプリの[機能解説ドキュメント](https://github.com/ellentby/Doodle-DrawTogether/blob/master/%E6%A9%9F%E8%83%BD%E8%A7%A3%E8%AA%AC.md)
