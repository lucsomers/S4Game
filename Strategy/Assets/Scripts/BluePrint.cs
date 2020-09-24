using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BluePrint : MonoBehaviour
{
    [SerializeField] GameObject building;

    private Camera cam;

    private bool canSpawn = true;

    private void Start()
    {
        cam = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonUp(0) && canSpawn)
        {
            //Place building at current pos
            GameObject tempBuilding = Instantiate(building);
            tempBuilding.transform.position = transform.position;

            //Destory this blueprint
            Destroy(gameObject);
        }

        //Move bluePrint to mouse pos
        Vector3 pos = cam.ScreenToWorldPoint(Input.mousePosition);
        pos = new Vector3(pos.x, pos.y, 0);
        transform.position = pos;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer>();

        spriteRenderer.color = Color.red;

        canSpawn = false;
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer>();

        spriteRenderer.color = Color.red;

        canSpawn = false;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer>();

        spriteRenderer.color = Color.white;

        canSpawn = true;
    }
}
