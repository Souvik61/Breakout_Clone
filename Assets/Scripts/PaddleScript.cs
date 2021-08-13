using UnityEngine;

public class PaddleScript : MonoBehaviour
{
    [Range(1,20)]
    public float speed = 5f;

    public float rightLimit;
    public float leftLimit;

    public void Move(int dir)
    {
        float delta = speed * Time.deltaTime;
        //Move right
        if (dir > 0)
        {
            if (transform.position.x < rightLimit)
            {
                //Continuous detection
                if (transform.position.x + delta > rightLimit)
                {
                    transform.position = new Vector2(rightLimit, transform.position.y);
                }
                else
                {
                    transform.Translate(1 * delta, 0, 0);
                }
            }
        }
        //Move left
        else if (dir < 0)
        {
            if (transform.position.x > leftLimit)
            {
                //Continuous detection
                if (transform.position.x - delta < leftLimit)
                {
                    transform.position = new Vector2(leftLimit, transform.position.y);
                }
                else
                {
                    transform.Translate(-1 * delta, 0, 0);
                }
            }
        }
    }

    public void SetPositionDirect(Vector2 pos)
    {
        float inputX = pos.x;

        if (inputX < leftLimit)
        {
            transform.position = new Vector2(leftLimit, transform.position.y);
        }
        else if (inputX > rightLimit)
        {
            transform.position = new Vector2(rightLimit, transform.position.y);
        }
        else {
            transform.position = pos;
        }

    }

}
