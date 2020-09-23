using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BluePrint : MonoBehaviour
{
    [SerializeField] GameObject Village;

    private Camera cam;

    private void Start()
    {
        cam = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonUp(0))
        {
            //Place village at current pos
            GameObject tempVillage = Instantiate(Village);
            tempVillage.transform.position = transform.position;

            //Destory this blueprint
            Destroy(gameObject);
        }

        //Move bluePrint to mouse pos
        Vector3 pos = cam.ScreenToWorldPoint(Input.mousePosition);
        pos = new Vector3(pos.x, pos.y, 0);
        transform.position = pos;
    }
}
