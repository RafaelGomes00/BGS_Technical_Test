using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Initializer : MonoBehaviour
{
    void OnEnable()
    {
        Character_Inventory.OnEnable();
    }

    void OnDisable()
    {
        Character_Inventory.OnDisable();
    }
}
