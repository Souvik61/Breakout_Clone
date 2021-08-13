using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseInputPaddle : MonoBehaviour
{
    [SerializeField]
    private Camera mainCam;
    private PaddleScript paddle;

    // Start is called before the first frame update
    void Awake()
    {
        paddle = GetComponent<PaddleScript>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 mouseToWorldPos = mainCam.ScreenToWorldPoint(Input.mousePosition);
        paddle.SetPositionDirect(new Vector2(mouseToWorldPos.x, paddle.transform.position.y));

    }
}
