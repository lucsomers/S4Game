using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamMoving : MonoBehaviour
{
    [SerializeField] private Camera cam;
    [SerializeField] private float moveSpeed;
    [SerializeField] private float zoomSpeed;

    private float maxZoom = 17.6f;
    private float minZoom = 3.3f;

    private float maxLeft = -18.54287f;
    private float maxUp = 8.101268f;
    private float maxRight = 18.01953f;
    private float maxDown = -9.984203f;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.W) && cam.transform.position.y < maxUp)
        {
            //UP
            cam.transform.position = new Vector3(cam.transform.position.x ,cam.transform.position.y + moveSpeed * Time.deltaTime, cam.transform.position.z);
        }
        if (Input.GetKey(KeyCode.S) && cam.transform.position.y > maxDown)
        {
            //DOWN
            cam.transform.position = new Vector3(cam.transform.position.x, cam.transform.position.y - moveSpeed * Time.deltaTime, cam.transform.position.z);
        }
        if (Input.GetKey(KeyCode.D) && cam.transform.position.x < maxRight)
        {
            //RIGHT
            cam.transform.position = new Vector3(cam.transform.position.x + moveSpeed * Time.deltaTime, cam.transform.position.y, cam.transform.position.z);
        }
        if (Input.GetKey(KeyCode.A) && cam.transform.position.x > maxLeft)
        {
            //LEFT
            cam.transform.position = new Vector3(cam.transform.position.x - moveSpeed * Time.deltaTime, cam.transform.position.y, cam.transform.position.z);
        }

        if (Input.GetAxis("Mouse ScrollWheel") < 0 && cam.orthographicSize < maxZoom)
        {
            cam.orthographicSize += zoomSpeed;
        }
        else if (Input.GetAxis("Mouse ScrollWheel") > 0 && cam.orthographicSize > minZoom)
        {
            cam.orthographicSize -= zoomSpeed;
        }
    }
}
