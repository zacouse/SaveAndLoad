using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonWeapons : MonoBehaviour {

	public void AddWeapon()
    {
        GameController.gameController.AddWeapon();
    }

    public void AddWeaponAttack()
    {
        GameController.gameController.AddWeaponAttack();
    }

    public void Next()
    {
        GameController.gameController.NextWeapon();
    }
    public void Previous()
    {
        GameController.gameController.PreviousWeapon();
    }
}
