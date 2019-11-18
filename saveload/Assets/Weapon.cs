using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

[Serializable]
public class Weapon {

    public int attack;

    public Weapon()
    {
        attack = 0;
    }

    public void AddAttack()
    {
        attack++;
    }
}
