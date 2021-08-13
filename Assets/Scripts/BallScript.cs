using UnityEngine;

namespace Breakout_Game
{
    public class BallScript : MonoBehaviour
    {
        [SerializeField]
        public Vector2 velocityVec;

        [Range(0, 20)]
        public float speed;

        private Rigidbody2D selfBody;

        // Awake is called when the script instance is being loaded
        private void Awake()
        {
            selfBody = GetComponent<Rigidbody2D>();
        }

        // This function is called every fixed framerate frame, if the MonoBehaviour is enabled
        private void FixedUpdate()
        {
            if (velocityVec.magnitude < 1.2f)
            {
                selfBody.MovePosition(selfBody.position + (velocityVec * (0.02f * speed)));
            }
        }

        private void OnCollisionEnter2D(Collision2D collision)
        {
            //If collision with brick response is different
            if (collision.gameObject.CompareTag("brick"))
            {
                GameObject brick = collision.gameObject;
                //Collision in world point
                var collInWorld = collision.contacts[0].point;
                var collInLocal=brick.transform.InverseTransformPoint(collInWorld);
                float posXnor = collInLocal.x * 2;
                velocityVec = new Vector2(posXnor, -velocityVec.y).normalized;
                
            }
            //Else normal collision
            else
            {
                //Calculate reflect vector
                Vector2 v = velocityVec;
                Vector2 n = collision.contacts[0].normal;

                Vector2 u = (Vector2.Dot(v, n) / Vector2.Dot(n, n)) * n;
                Vector2 w = v - u;
                Vector2 v1 = w - u;
                velocityVec = v1;
            }
        }

        private Vector2 GetRandomVector()
        {
            Vector2 vec = new Vector2(Random.Range(-1.0f, 1.0f), Random.Range(-1.0f, 1.0f));
            return vec.normalized;
        }
    }
}