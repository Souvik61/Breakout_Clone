using UnityEngine;

public class AltBallScript : MonoBehaviour
{
    public BallMoverScript moverScript;

    //Send collision event to Ball mover script
    private void OnCollisionEnter2D(Collision2D collision)
    {

        moverScript.OnCollisionEventFromBall(collision);

    }
}
