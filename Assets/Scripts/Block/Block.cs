using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour
{
    public int mit = 0;
    SpriteRenderer sprite;
    GameManager GM;
    
    float c;
    // Start is called before the first frame update
    GameObject Player;
    void Start()
    {
        Player = GameObject.Find("Player");
        sprite = this.GetComponent<SpriteRenderer>();
        GM = GameObject.Find("GameManager").GetComponent<GameManager>();
        c = 1f / GM.Max;
        if (this.GetComponent<suutihyouzi>())
        {
            this.GetComponent<suutihyouzi>().settxt(mit);
        }
    }

    public IEnumerator kyusyu()
    {
        Destroy(this.GetComponent<Collider2D>());
        this.sprite.sortingOrder = 100;
        for (int i = 60; i != 0; i--)
        {
            transform.localScale *= 0.95f;
            yield return new WaitForFixedUpdate();
        }
        Destroy(this.gameObject);
        yield return null;
    }

    // Update is called once per frame
    void Update()
    {
        sprite.color = new Color(1f - c * mit, 1f - c * mit, 1f - c * mit, 1f);
        if (TryGetComponent(out Collider2D col))
        {
            col.isTrigger =Player.GetComponent<Player>().mit >= mit;
        }
        else
        {
            Vector3 newpos = 0.2f*Player.transform.position+0.8f*transform.position;
            transform.position = newpos;
        }
    }
}
