using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LimitMove : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // Amount to move
        // Input.GetAxis MAKES MOOVEMENT LEFT TO RIGHT WITH SMOOTHING
        // float amountToMove = Input.GetAxis("Horizontal") * PlayerSpeed * Time.deltaTime;
        // Move the Player
        // transform.Translate(Vector3.right * amountToMove);

        //When Players reaches desired (L/R)possition make him stop
        if (transform.position.x <= -8.5f)
            transform.position = new Vector3(-8.5f, transform.position.y, transform.position.z);
        else if (transform.position.x >= 8.5f)
            transform.position = new Vector3(8.5f, transform.position.y, transform.position.z);
    }
}
