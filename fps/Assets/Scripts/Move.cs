using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    public float speed = 0.1f;
    public GameObject playerCamera;
    private Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();   
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Vector3 now = rb.position;            // 座標を取得
        Vector3 vec = new Vector3();
        //bool isNoneDownKey = true;
        if (Input.GetKey("w"))
        {
            vec += new Vector3(0.0f, 0.0f, speed);  // 前に少しずつ移動するように加算
            //isNoneDownKey = false;
        }
        if (Input.GetKey("a"))
        {
            vec += new Vector3(-speed, 0.0f, 0.0f);  // 前に少しずつ移動するように加算
            //isNoneDownKey = false;
        }
        if (Input.GetKey("s"))
        {
            vec += new Vector3(0.0f, 0.0f, -speed);  // 前に少しずつ移動するように加算
            //isNoneDownKey = false;
        }
        if (Input.GetKey("d"))
        {
            vec += new Vector3(speed, 0.0f, 0.0f);  // 前に少しずつ移動するように加算
            //isNoneDownKey = false;
        }

        //Debug.Log("vec:" + vec);
        if (vec != Vector3.zero)
        {
            // Calculate body position.
            rb.position += vec;
            // Set camera position.
            playerCamera.transform.position = rb.transform.position + new Vector3(0, 0.5f, 0);
        }

        //if (isNoneDownKey) {
        //    //Debug.Log("stop");
        //    rb.velocity = Vector3.zero;
        //    rb.angularVelocity = Vector3.zero;
        //}

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
