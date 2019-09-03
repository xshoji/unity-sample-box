using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    public float speed = 0.25f;
    public float cameraHeight = 0.5f;
    public GameObject playerCamera;
    public VariableJoystick variableJoystick;
    public DynamicJoystick dynamicJoystick;
    private Rigidbody rb;
    //> unity - How to use Input.GetAxis("Mouse X/Y") to rotate the camera? - Game Development Stack Exchange  
    //> https://gamedev.stackexchange.com/questions/104693/how-to-use-input-getaxismouse-x-y-to-rotate-the-camera
    private float yaw;
    private float pitch;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        playerCamera.transform.position = rb.transform.position + new Vector3(0, cameraHeight, 0);
        yaw = playerCamera.transform.rotation.x;
        pitch = playerCamera.transform.rotation.y;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        rotateView();
        movePosition();
    }

    private void rotateView()
    {
        yaw += dynamicJoystick.Horizontal * 10f;
        pitch -= dynamicJoystick.Vertical * 10f;
        playerCamera.transform.eulerAngles = new Vector3(pitch, yaw, 0.0f);
        rb.transform.eulerAngles = new Vector3(0.0f, yaw, 0.0f);
    }

    private void movePosition()
    {
        Vector3 directionVector = Vector3.forward * variableJoystick.Vertical + Vector3.right * variableJoystick.Horizontal;

        //Debug.Log("directionVector:" + directionVector);
        if (directionVector != Vector3.zero)
        {
            //> Unity初心者でも簡単に作れるFPSカメラの作り方 - あさちゅんのゲームブログ
            //> http://chungames.hateblo.jp/entry/2016/07/31/201807
            // Calculate body position.
            rb.position += playerCamera.transform.forward * directionVector.z * speed + playerCamera.transform.right * directionVector.x * speed;
        }

        // Set camera position.
        playerCamera.transform.position = rb.transform.position + new Vector3(0, cameraHeight, 0);
    }
}
