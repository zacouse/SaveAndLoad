using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonModifyPlayerData : MonoBehaviour {

    public void AddAttack()
    {
        GameController.gameController.AddAttack();
    }

    public void AddDefense()
    {
        GameController.gameController.AddDefense();
    }

    public void AddHealth()
    {
        GameController.gameController.AddHealth();
    }
}
