using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Debugger : MonoBehaviour
{
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            PlayerController.Instance.TakeDamage(1);
        }
        
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            PlayerController.Instance.HealHealth(1);
        }
    }
}
