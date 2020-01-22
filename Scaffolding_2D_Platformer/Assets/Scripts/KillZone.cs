using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillZone : MonoBehaviour
{
    //This code is attached to a prefab called killzone, when the player hits the killzone, he/she will be reset to the checkpoint created

    //references to checkpoint
    [SerializeField]
    public GameObject CheckPoint;

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            Vector3 temp = CheckPoint.transform.position;
            collision.transform.position = temp;
        }
    }
}
