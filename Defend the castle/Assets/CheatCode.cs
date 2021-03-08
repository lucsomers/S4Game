using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheatCode : MonoBehaviour
{
    #if UNITY_EDITOR
    bool cheatMode = false;

    // Update is called once per frame
    void Update()
    {
        if (!cheatMode)
        {
            if (Input.GetKeyDown(KeyCode.Alpha0))
            {
                cheatMode = true;

                ModifierManager.instance.AddMoveSpeedModifier(100);
                ModifierManager.instance.AddCooldownModifier(100);
                ModifierManager.instance.AddAttackSpeedModifier(100);
                ModifierManager.instance.AddMaxHealthModifier(100);
                GetComponentInParent<PlayerController>().Invisible = true;
            }
        }
    }
    #endif
}
