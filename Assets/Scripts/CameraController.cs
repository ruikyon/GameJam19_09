using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public static CameraController instance;

    void Awake()
    {
        instance = this;
        Cursor.visible = false;

    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Player.instance.transform.position;

        //Vector3でX,Y方向の回転の度合いを定義
        Vector3 angle = new Vector3(0, Input.GetAxis("Mouse X")*10,  0);

        transform.Rotate(angle);

    }
}
