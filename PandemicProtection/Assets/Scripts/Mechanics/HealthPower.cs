using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthPower : MonoBehaviour
{
    public Health playerHealth;
    
    public void getHealthPower()
    {
        playerHealth.HealPlayer(10);
    }
}
