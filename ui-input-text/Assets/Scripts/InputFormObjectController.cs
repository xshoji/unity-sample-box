using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InputFormObjectController : MonoBehaviour
{

    public GameObject addingTarget;
    public InputField inputField;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AddText()
    {
        // > 【Unity】スクリプトからPrefabのインスタンスを作る方法 - Qiita
        // > https://qiita.com/2dgames_jp/items/8a28fd9cf625681faf87
        // プレハブを取得
        GameObject textPrefab = (GameObject)Resources.Load("Text");
        // プレハブからインスタンスを生成
        GameObject textObject = Instantiate(textPrefab) as GameObject;

        // formのtextをtextObjectに設定
        // > unity3d - C# Unity - How can I clear an InputField - Stack Overflow  
        // > https://stackoverflow.com/questions/37754617/c-sharp-unity-how-can-i-clear-an-inputfield
        // > UnityでGetComponent<Text>()でのエラー - conf t
        // > https://monaski.hatenablog.com/entry/2015/11/03/125957
        textObject.GetComponent<Text>().text = inputField.text;
        inputField.Select();
        inputField.text = null;

        // あるオブジェクトの子として追加
        // > 【Unity】GameObjectをSetParentするとエラーになる件 - NinaLabo
        // > http://ninagreen.hatenablog.com/entry/2015/10/25/000444
        textObject.transform.SetParent(addingTarget.transform);
        // > Unity - Scripting API： Transform.localScale
        // > https://docs.unity3d.com/ScriptReference/Transform-localScale.html?_ga=2.65667310.1187445378.1569860193-888141676.1564340563
        textObject.transform.localScale = new Vector3(1, 1, 1);
    }
}
