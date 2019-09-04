using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightState : MonoBehaviour
{
    private Light mylight;

    // Start is called before the first frame update
    void Start()
    {
        mylight = GetComponent<Light>();
    }

    // Update is called once per frame
    void Update()
    {
        //> スクリプトでライトをコントロールする - まゆたまガジェット開発逆引き辞典
        //> http://prince9.hatenablog.com/entry/2018/11/19/184813
        Debug.Log("GlobalLightState.getLightState() : " + GlobalLightState.getLightState());
        if (!GlobalLightState.getLightState())
        {
            mylight.intensity = 0.0f;
        }
        else
        {
            mylight.intensity = 3.0f;
        }
    }
}
