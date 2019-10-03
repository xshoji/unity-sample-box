using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddButtonController : MonoBehaviour
{

    public GameObject addingTarget;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AddContent()
    {
        // > 【Unity】スクリプトからPrefabのインスタンスを作る方法 - Qiita
        // > https://qiita.com/2dgames_jp/items/8a28fd9cf625681faf87
        // プレハブを取得
        GameObject contentObjectPrefab = (GameObject)Resources.Load("ContentObject");
        // プレハブからインスタンスを生成
        GameObject contentObjectObj = Instantiate(contentObjectPrefab) as GameObject;
        // あるオブジェクトの子として追加
        // > 【Unity】GameObjectをSetParentするとエラーになる件 - NinaLabo
        // > http://ninagreen.hatenablog.com/entry/2015/10/25/000444
        contentObjectObj.transform.SetParent(addingTarget.transform);
        // > Unity - Scripting API： Transform.localScale
        // > https://docs.unity3d.com/ScriptReference/Transform-localScale.html?_ga=2.65667310.1187445378.1569860193-888141676.1564340563
        contentObjectObj.transform.localScale = new Vector3(1, 1, 1);
    }
}
