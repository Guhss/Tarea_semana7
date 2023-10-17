using System.Collections;
using System.Collections.Generic;
using System.Data;
using UnityEngine;

public class Player : MonoBehaviour
{
    public string playerName;
    public int strength;
    public int dexterity;
    public int health;

    public void UpdatePlayer(LogOption logOption)
    {
        strength -= logOption.requiredStrength;
        dexterity -= logOption.requiredDexterity;
        health += logOption.lifeImpact;
    }
}
