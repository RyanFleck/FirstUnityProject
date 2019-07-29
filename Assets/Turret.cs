using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret : MonoBehaviour
{

    [SerializeField]
    private GameObject emitter;

    [SerializeField]
    private GameObject bullet;

    [SerializeField]
    private GameObject parent;

    private readonly float bullet_speed = 10;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("space"))
        {
            GameObject bulletHandler;
            bulletHandler = Instantiate(bullet, emitter.transform.position, emitter.transform.rotation) as GameObject;
            //bulletHandler.transform.Rotate(Vector3.left * 90);

            Rigidbody bulletBody = bulletHandler.GetComponent<Rigidbody>();

            Vector3 basev = Vector3.zero;
            if (parent)
            {
                basev = parent.transform.root.GetComponent<Rigidbody>().velocity;
            }

            bulletBody.AddForce((bulletBody.transform.forward * 1000) + basev);
            Debug.Log("BASEV: " + Vec2String(basev) + " " + Vec2String(bulletBody.transform.forward));


            Destroy(bulletHandler, 5.0f);
        }
    }

    string Vec2String(Vector3 vec)
    {
        return "x:" + vec.x + " y:" + vec.y + " z:" + vec.z + " ";
    }
}
