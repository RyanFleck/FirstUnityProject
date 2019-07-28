using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        float verMos = -Input.GetAxis("Mouse Y");
        Camera.current.transform.rotation = Quaternion.Euler(Camera.current.transform.rotation.eulerAngles + new Vector3(1f * verMos, 0f, 0f));
    }
}
