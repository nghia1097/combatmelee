using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : MonoBehaviour
{
    public Transform player;
    public bool isFlip = false;

    public void LookatPlayer()
    {
        Vector3 flipped = transform.localScale;
        flipped.x = flipped.x * -1;
        if(transform.position.x > player.position.x && isFlip)
        {
            transform.localScale = flipped;
            // transform.Rotate(0f, 100f, 0f);
            isFlip = false;
        }
        if(transform.position.x < player.position.x && !isFlip)
        {
            transform.localScale = flipped;
            // transform.Rotate(0f, 100f, 0f);
            isFlip = true;
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
