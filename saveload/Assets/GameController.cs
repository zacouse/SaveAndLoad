using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

public class GameController : MonoBehaviour
{

    public static GameController gameController;

    public int attack;
    public int defense;
    public int health;

    public List<Weapon> weapons = new List<Weapon>();
    public int activeWeapon;

    // Use this for initialization
    void Start()
    {
        if (gameController == null)
        {
            DontDestroyOnLoad(gameObject);
            gameController = this;
            SetDefaultValue();
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void SetDefaultValue()
    {
        attack = 1;
        defense = 1;
        health = 1;
        weapons.Add(new Weapon());
        activeWeapon = 0;
    }

    public void AddWeaponAttack()
    {
        weapons[activeWeapon].AddAttack();
    }

    public void AddWeapon()
    {
        weapons.Add(new Weapon());
        activeWeapon = weapons.Count - 1;
    }

    public void NextWeapon()
    {
        if(activeWeapon + 1 == weapons.Count)
        {
            activeWeapon = 0;
        }
        else
        {
            activeWeapon++;
        }
    }

    public void PreviousWeapon()
    {
        if (activeWeapon == 0)
        {
            activeWeapon = weapons.Count - 1;
        }
        else
        {
            activeWeapon--;
        }
    }

    public void AddAttack()
    {
        attack++;
    }

    public void AddDefense()
    {
        defense++;
    }

    public void AddHealth()
    {
        health++;
    }

    public void Load()
    {
        BinaryFormatter bf = new BinaryFormatter();
        if (!File.Exists(Application.persistentDataPath + "gameInfo.dat"))
        {
            throw new Exception("Game File Not Found");
        }

        FileStream file = File.Open(Application.persistentDataPath + "gameInfo.dat", FileMode.Open);
        PlayerData playerDataToLoad = new PlayerData();
        playerDataToLoad = (PlayerData)bf.Deserialize(file);
        attack = playerDataToLoad.attack;
        defense = playerDataToLoad.defense;
        health = playerDataToLoad.health;
        weapons = playerDataToLoad.weapons;
        activeWeapon = playerDataToLoad.activeWeapon;
        file.Close();
    }

    public void Save()
    {
        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Open(Application.persistentDataPath + "gameInfo.dat", FileMode.Create);
        PlayerData playerDataToSave = new PlayerData();
        playerDataToSave.attack = attack;
        playerDataToSave.defense = defense;
        playerDataToSave.health = health;
        playerDataToSave.weapons = weapons;
        playerDataToSave.activeWeapon = activeWeapon;
        bf.Serialize(file, playerDataToSave);
        file.Close();
    }

    private void OnGUI()
    {
        GUIStyle style = new GUIStyle();
        style.fontSize = 32;
        GUI.Label(new Rect(10, 60, 100, 100), "Attack : "+attack, style);
        GUI.Label(new Rect(10, 110, 100, 100), "Defense : " + defense, style);
        GUI.Label(new Rect(10, 160, 100, 100), "Health : " + health, style);
        GUI.Label(new Rect(10, 210, 100, 100), "Weapon : " + activeWeapon, style);
        GUI.Label(new Rect(10, 260, 100, 100), "Weapon attack : " + weapons[activeWeapon].attack, style);
    }

}
[Serializable]
class PlayerData
{
    public int attack;
    public int defense;
    public int health;
    public List<Weapon> weapons;
    public int activeWeapon;
};