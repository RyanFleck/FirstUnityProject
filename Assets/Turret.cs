using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret : MonoBehaviour
{

    [SerializeField]
    private GameObject emitter;

    [SerializeField]
    private GameObject bullet;

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
            bulletBody.AddForce(transform.forward * 1000);

            Destroy(bulletHandler, 5.0f);
        }
    }
}
