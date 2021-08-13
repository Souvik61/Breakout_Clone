using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyboardInput : MonoBehaviour
{

    private PaddleScript paddleScript;

    // Awake is called when the script instance is being loaded
    private void Awake()
    {
        paddleScript = GetComponent<PaddleScript>();
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.D))
        {
            paddleScript.Move(1);
        }
        else if (Input.GetKey(KeyCode.A))
        {
            paddleScript.Move(-1);
        }

    }
}