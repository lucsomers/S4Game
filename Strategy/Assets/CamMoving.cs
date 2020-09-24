using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamMoving : MonoBehaviour
{
    [SerializeField] private Camera cam;
    [SerializeField] private float speed;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.W))
        {
            //UP
            cam.transform.position = new Vector3(cam.transform.position.x ,cam.transform.position.y + speed * Time.deltaTime, cam.transform.position.z);
        }
        if (Input.GetKey(KeyCode.S))
        {
            //DOWN
            cam.transform.position = new Vector3(cam.transform.position.x, cam.transform.position.y - speed * Time.deltaTime, cam.transform.position.z);
        }
        if (Input.GetKey(KeyCode.D))
        {
            //RIGHT
            cam.transform.position = new Vector3(cam.transform.position.x + speed * Time.deltaTime, cam.transform.position.y, cam.transform.position.z);
        }
        if (Input.GetKey(KeyCode.A))
        {
            //LEFT
            cam.transform.position = new Vector3(cam.transform.position.x - speed * Time.deltaTime, cam.transform.position.y, cam.transform.position.z);
        }
    }
}
