using UnityEngine;

/// <summary>
/// This class moves the ball
/// </summary>
public class BallMoverScript : MonoBehaviour
{
    //Editor
    public GameObject paddle;
    public GameObject ballObj;
    public Transform ballSpawnPoint;
    
    //Others
    public enum ControlTypes { SELF, PADDLE };
    public ControlTypes currCtrlType;

    [SerializeField]
    public Vector2 ballVelocityVec;

    [Range(0, 20)]
    public float speed;

    private Rigidbody2D ballBody;

    // Awake is called when the script instance is being loaded
    private void Awake()
    {
        ballBody = ballObj.GetComponent<Rigidbody2D>();
        currCtrlType = ControlTypes.SELF;
    }

    // This function is called every fixed framerate frame, if the MonoBehaviour is enabled
    private void FixedUpdate()
    {
        if (currCtrlType == ControlTypes.SELF)
        {
            /*
            if (ballVelocityVec.magnitude < 1.2f)
            {
                ballBody.MovePosition(ballBody.position + (ballVelocityVec * (0.02f * speed)));
            }
            */
        }
        else if (currCtrlType == ControlTypes.PADDLE)
        {
            ballBody.MovePosition(ballSpawnPoint.position);
        }
    }

    //Other funcs

    //Call this from ball script
    public void OnCollisionEventFromBall(Collision2D collision)
    {
        //If collision with brick response is different
        if (collision.gameObject.CompareTag("brick"))
        {
            GameObject brick = collision.gameObject;
            //Collision in world point
            var collInWorld = collision.contacts[0].point;
            var collInLocal = brick.transform.InverseTransformPoint(collInWorld);
            float posXnormal = collInLocal.x * 2;
            ballBody.velocity = (new Vector2(posXnormal, 1)).normalized*10;
            //Debug.Log((new Vector2(posXnormal, -ballBody.velocity.y)).normalized*10);
        }
        //Else normal collision
        else
        {
            /*
            //Calculate reflect vector
            Vector2 v = ballVelocityVec;
            Vector2 n = collision.contacts[0].normal;

            Vector2 u = (Vector2.Dot(v, n) / Vector2.Dot(n, n)) * n;
            Vector2 w = v - u;
            Vector2 v1 = w - u;
            ballVelocityVec = v1;
            */
        }
    }

    public void SetBall(GameObject ball)
    {
        ballObj = ball;
    }

    public void SetState(ControlTypes type)
    {
        ballBody.velocity = Vector2.zero;
        ballBody.angularVelocity = 0;

        currCtrlType = type;
    }

    public void LaunchBall()
    {
        SetState(BallMoverScript.ControlTypes.SELF);
        ballObj.GetComponent<Rigidbody2D>().velocity = (new Vector2(Random.Range(-1, 1), 1)).normalized * 10;
    }

    public void ResetBall()
    {
        ballObj.transform.position = ballSpawnPoint.position;
        ballVelocityVec = Vector2.zero;
        ballBody.velocity = Vector2.zero;
        ballBody.angularVelocity = 0;
        currCtrlType = ControlTypes.PADDLE;
    }
}