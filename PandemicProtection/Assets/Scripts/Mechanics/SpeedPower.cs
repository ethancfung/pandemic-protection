using UnityEngine;

public class SpeedPower : MonoBehaviour {

    public float increase = 4f;
    public Player playerScript;

    public void getSpeedPower()
    {
        playerScript = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
        playerScript.MovementSpeed = increase;
    }
}
