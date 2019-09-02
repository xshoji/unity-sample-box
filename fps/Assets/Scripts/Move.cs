using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    public float speed = 0.1f;
    public GameObject playerCamera;
    private Rigidbody rb;
    //> unity - How to use Input.GetAxis("Mouse X/Y") to rotate the camera? - Game Development Stack Exchange  
    //> https://gamedev.stackexchange.com/questions/104693/how-to-use-input-getaxismouse-x-y-to-rotate-the-camera
    private float yaw;
    private float pitch;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        playerCamera.transform.position = rb.transform.position + new Vector3(0, 0.5f, 0);
        yaw = playerCamera.transform.rotation.x;
        pitch = playerCamera.transform.rotation.y;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        movePosition();
        rotateView();
    }

    private void rotateView()
    {
        yaw += Input.GetAxis("Mouse X") * 10f;
        pitch -= Input.GetAxis("Mouse Y") * 10f;
        playerCamera.transform.eulerAngles = new Vector3(pitch, yaw, 0.0f);
        rb.transform.eulerAngles = new Vector3(0.0f, yaw, 0.0f);
    }

    private void movePosition()
    {
        Vector3 now = rb.position;            // 座標を取得
        Vector3 vec = new Vector3();
        if (Input.GetKey("w"))
        {
            vec += new Vector3(0.0f, 0.0f, speed);  // 前に少しずつ移動するように加算
        }
        if (Input.GetKey("a"))
        {
            vec += new Vector3(-speed, 0.0f, 0.0f);  // 前に少しずつ移動するように加算
        }
        if (Input.GetKey("s"))
        {
            vec += new Vector3(0.0f, 0.0f, -speed);  // 前に少しずつ移動するように加算
        }
        if (Input.GetKey("d"))
        {
            vec += new Vector3(speed, 0.0f, 0.0f);  // 前に少しずつ移動するように加算
        }

        //Debug.Log("vec:" + vec);
        if (vec != Vector3.zero)
        {
            //> Unity初心者でも簡単に作れるFPSカメラの作り方 - あさちゅんのゲームブログ
            //> http://chungames.hateblo.jp/entry/2016/07/31/201807
            // Calculate body position.
            rb.position += playerCamera.transform.forward * vec.z + playerCamera.transform.right * vec.x;

            // Set camera position.
            playerCamera.transform.position = rb.transform.position + new Vector3(0, 0.5f, 0);
        }

        //Vector3 directionVector = playerCamera.transform.position - transform.position;
        //Debug.Log("direction:" + directionVector + ", vec:" + vec);
        //if (vec != Vector3.zero && directionVector != Vector3.zero) {
        //    var resultVector = Quaternion.LookRotation(directionVector) * vec;
        //    resultVector = new Vector3(resultVector.x, 0.0f, resultVector.y);
        //    Debug.Log("resultVector:" + resultVector);
        //    now += resultVector;
        //    rb.position = now; // 値を設定
        //}


    }
}
