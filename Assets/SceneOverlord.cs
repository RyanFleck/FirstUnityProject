using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneOverlord : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Cursor.visible = false;
    }

    private void OnGUI()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

    }



    // Update is called once per frame
    void Update()
    {
        
    }
}
