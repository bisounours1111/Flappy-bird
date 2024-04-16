using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeletePipe : MonoBehaviour
{

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("Collision");
        if (collision.gameObject.tag == "Pipe")
        {
            Destroy(collision.gameObject.transform.parent.gameObject);
        }
    }
}
