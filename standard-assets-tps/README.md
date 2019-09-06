# standard-assets-tps

standard-assets-tps

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
