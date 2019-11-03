# overhead-view

overhead-view

# Requirement

 - 2019.xxx

# Dependencies

Need to put following assets to `Assets/ExternalAssets` directory.

> Standard Assets - Asset Store  
> https://assetstore.unity.com/packages/essentials/asset-packs/standard-assets-32351

# Human model

> www.makehumancommunity.org  
> http://www.makehumancommunity.org/

# Memo

## ThirdPersonUserControl

 - キャラがずっと空中に浮き続けてるみたいなアクションになった場合は
   - Capsule Colliderの形状をキャラと一致させて
   - ThirdPersonUserControlの`Ground check distance`を大きめの値にする
 

## FreeLookCameraRig

 - キャラがでかすぎたりしてカメラと近くなりすぎるとカメラがキャラに吸い込まれる現象が発生するので注意
 - 吸い込まれる現象は
   - `ProtectCameraFromWallClip.clipMoveTime`の値を大きくする
   - `ProtectCameraFromWallClip.closestDistance`（カメラとターゲットの最も近い距離）の値を大きくする（5とかにする）
   - とマシになる
 - カメラとキャラの距離は
   - `FreeLookCameraRig`の中にあるPivotの位置
   - `FreeLockCam.MoveSpeed`をはやくする
   - を調整すればOK
