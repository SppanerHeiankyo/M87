using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetSPD : MonoBehaviour
{
    Rigidbody2D rbody;
    KeyConfigClass kc = new KeyConfigClass();
    float maxv;
    enum direction
    {
        Left,Right,Stop
    }
    direction mae;
    // Start is called before the first frame update
    void Start()
    {
        rbody=GetComponent<Rigidbody2D>();
        mae = direction.Stop;
        maxv = 5 * transform.localScale.x;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public Vector2 GetVelocity(bool setti)
    {
        direction now;
        Vector2 v=rbody.velocity;
        if (kc.GetAxis().x < 0)
        {
            now = direction.Left;
        }
        else if (kc.GetAxis().x == 0)
        {
            now = direction.Stop;
        }
        else
        {
            now = direction.Right;
        }
        Debug.Log(now.ToString());
        switch (now)
        {
            case direction.Left:
                if ((now != mae) && setti) v.x = -0.5f * maxv;
                v.x -= maxv / 20f;
                break;
            case direction.Right:
                if ((now != mae) && setti) v.x = 0.5f * maxv;
                v.x += maxv / 20f;
                break;
            case direction.Stop:
                if (setti)
                {
                    v.x = 0f;
                    break;
                }
                break;
        }
        if (Mathf.Abs(v.x) > maxv)
        {
            v.x = Mathf.Sign(v.x) * maxv;
        }
        mae = now;
        return v;
    }
}
