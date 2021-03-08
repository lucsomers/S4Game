using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSpriteFlipper : MonoBehaviour
{
    private PlayerController playerController;
    private SpriteRenderer spriteRenderer;

    // Start is called before the first frame update
    void Start()
    {
        playerController = GetComponentInParent<PlayerController>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        float x_axis = playerController.transform.position.x - playerController.PlayerInput.MousePos.x;

        if (x_axis > 0 && !spriteRenderer.flipX)
        {
            spriteRenderer.flipX = true;
        }

        if (x_axis < 0 && spriteRenderer.flipX)
        {
            spriteRenderer.flipX = false;
        }
    }
}
