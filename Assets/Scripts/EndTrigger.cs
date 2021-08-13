using UnityEngine;

public class EndTrigger : MonoBehaviour
{

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            AllEventsScript.OnBallGoOut?.Invoke();
        }
    }

}
