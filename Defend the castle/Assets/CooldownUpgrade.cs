﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CooldownUpgrade : Upgrade
{
    public override void OnTriggerEnter2D(Collider2D collision)
    {
        base.OnTriggerEnter2D(collision);

        if (PlayerController != null)
        {

        }
    }
}
