using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goal : MonoBehaviour
{
    SpriteRenderer sprite;
    GameManager GM;

    // Start is called before the first frame update
    void Start()
    {
        sprite = this.GetComponent<SpriteRenderer>();
        GM = GameObject.Find("GameManager").GetComponent<GameManager>();
        sprite.color = new Color(0,0 ,0 , 1);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
