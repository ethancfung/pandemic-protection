using UnityEngine;

public class JumpPower : MonoBehaviour
{
    public float increase = 7f;
    public Player playerScript;

    public void getJumpPower()
    {
        playerScript = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
        playerScript.JumpForce = increase;
    }
}
