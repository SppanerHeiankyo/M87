using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stage : MonoBehaviour
{
    private bool clear=false;
    private int i=0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (clear)
        {
            i++;
            this.transform.localRotation = Quaternion.Euler(new Vector3(0,0,i));
            foreach(Transform t in this.transform)
            {
                t.GetComponent<Rigidbody2D>().AddForce(-t.position);
            }
        }
    }

    public void Clear()
    {
        clear = true;
        foreach(Transform t in this.transform)
        {
            Rigidbody2D rb = t.gameObject.AddComponent<Rigidbody2D>();
            if(t.TryGetComponent(out Collider2D col))
            {
                col.isTrigger = true;
            }
            rb.gravityScale = 0;
            rb.simulated = true;
            rb.velocity = new Vector2(Random.Range(-1f, 1f), Random.Range(-1f, 1f)).normalized*3f;

        }
    }
}
