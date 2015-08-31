サイボウズの共有にある各メンバの写真を下記に置きます．
/Assets/Photo
(meta fileはpushしてますので，そのまま使えるはずです）

﻿TODO
オブジェクトの追加
カメラワークの決定
カメラの移動の調整

ベースは MinaDeBon_1_00_03
プロジェクトの開き方
	ASS.zipを展開(パスワードはサイボウズにて)してMoCapとSoundをAssetsに入れる
		(Unity上ですることを推奨)

	キャラクタへの追加方法
		(1)	ReplaySceneを開き，シーン内のReplay -> modelListにキャラを追加
				位置は[0,0,0]，回転[0,0,0]，スケール(おそらく)を合わせる
				モデルの非アクティブにする(インスペクタでチェックを外す)
		(2) ReplaySceneのmodelListをコピーし，PlaySceneへ移動シーンに張り付け
				modelListをReplayの下へ入れる．

				modelListをさらにコピーし，playerListに名前を変える．
				playerListをSKinectFullの下へ．
				playerListの各モデルに plugin/kinect/KinectModelControllerV2を設定
					SWにKiect_Prefab，RootにモデルのRootを設定
		(3) modelListをコピーし，CharaSelectSceneへ移動，modelListを貼り付け．
				modelListをTurnTableの下へ．
				modelListのサイズがなぜか [0.1, 0.1, 0.1]になっているので，
				すべて0.2にしてサイズを合わせる．




