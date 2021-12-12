using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmmoUI : MonoBehaviour
{
    private GameObject _weapon;

    void Awake()
    {
        _weapon = GameObject.FindWithTag("Weapon");
    }
}
