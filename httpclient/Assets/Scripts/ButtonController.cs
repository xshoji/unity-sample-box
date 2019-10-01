using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class ButtonController : MonoBehaviour
{

    public UnityEngine.UI.InputField inputField;

    // > UnityでHTTPに接続する - Qiita  
    // > https://qiita.com/ponchan/items/65aeb43e8fea8da0bcac
    public void OnClick() {
        Debug.Log("inputField.text: " + inputField.text);
        Debug.Log("call ApiClient.Get!!");
        // コルーチンを実行  
        StartCoroutine("DoGet", inputField.text);
    }

    IEnumerator DoGet(string query)
    {
        string url = "https://itunes.apple.com/search?term=" + query + "&media=music";
        Debug.Log("query: " + query);
        Debug.Log("url: " + url);

        UnityWebRequest request = UnityWebRequest.Get(url);

        yield return request.SendWebRequest();
        Debug.Log("get response!!");

        if (request.isHttpError || request.isNetworkError)
        {
            Debug.Log("Error!");
            Debug.Log(request.error);
        }

        Debug.Log("OK!");
        Debug.Log(request.downloadHandler.text);

    }
}
