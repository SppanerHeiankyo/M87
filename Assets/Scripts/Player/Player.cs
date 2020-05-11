using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;

public class Player : MonoBehaviour
{
    Rigidbody2D rbody;
    GameManager GM;
    public int mit = 0;
    SpriteRenderer sprite;
    KeyConfigClass kc = new KeyConfigClass();
    float c;//密度の係数
    bool clear = false;
    bool canjump = false;
    string[] destroytag = new string[] { "Block" };
    public GameObject kouseiyouso;
    public bool fry = false;
    bool takeoff = true;
    public AudioClip tyakuti;
    private AudioSource AS;
    private GetSPD gsp;
    // Start is called before the first frame update
    void Start()
    {
        TryGetComponent<GetSPD>(out gsp);
        sprite = this.GetComponent<SpriteRenderer>();
        rbody = this.GetComponent<Rigidbody2D>();
        GM = GameObject.Find("GameManager").GetComponent<GameManager>();
        c = 1f / GM.Max;
        AS = GetComponentInChildren<AudioSource>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        sprite.color = new Color(1f - c * mit, 1f - c * mit, 1f - c * mit, 1f);
        Vector2 v = rbody.velocity;
        
        RaycastHit2D hit = Physics2D.Linecast(
            transform.position-transform.up*0.7f*transform.localScale.x-transform.right*0.2f, 
            transform.position - transform.up * 0.7f * transform.localScale.x+ transform.right * 0.2f,
            1 << 8);
        if (gsp)
        {
            v = gsp.GetVelocity(hit);
        }
        else
        {
            if (kc.GetAxis().x < 0)
            {
                v.x = -5f * transform.localScale.x;
            }
            else if (kc.GetAxis().x == 0)
            {
                v.x = 0;
            }
            else
            {
                v.x = 5f * transform.localScale.x;
            }
        }

        if (!canjump && hit&&!clear)
        {
            AS.clip = tyakuti;
            AS.time = 0.175f;
            AS.Play();
        }

        canjump = hit&&takeoff;
        if (canjump && destroytag.Contains(hit.transform.tag) && hit.collider.isTrigger)
        {
            canjump = false;
            AS.Stop();
        }
        if (canjump && hit.collider.isTrigger)
        {
            canjump = false;
            AS.Stop();
        }
        if (Input.GetKey(KeyCode.Space) && canjump)
        {
            takeoff = false;
            Invoke("cantakeoff", 0.1f);

            v.y = 11f * transform.localScale.x;
            if (destroytag.Contains(hit.transform.tag))
            {
                IsBlock(hit.transform.gameObject);
            }
        }

        if (clear)
        {
            v = new Vector2();
            rbody.gravityScale = 0;
            transform.position = transform.position * 0.9f;
        }

        if (fry)
        {
            rbody.gravityScale = 0;
            v = new Vector2();
            if (Input.GetKey(KeyCode.RightArrow))
            {
                v.x += 7f * transform.localScale.x;
            }
            if (Input.GetKey(KeyCode.LeftArrow))
            {
                v.x -= 7f * transform.localScale.x;
            }
            if (Input.GetKey(KeyCode.UpArrow))
            {
                v.y += 7f * transform.localScale.x;
            }
            if (Input.GetKey(KeyCode.DownArrow))
            {
                v.y -= 7f * transform.localScale.x;
            }

        }

        rbody.velocity = v;
        this.GetComponent<suutihyouzi>().settxt(mit);

    }

    void cantakeoff()
    {
        takeoff = true;
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        switch (collision.transform.tag)
        {
            case "Block":
                IsBlock(collision.gameObject);
                if (collision.GetComponent<Block>().mit == mit) mit++;
                return;
            case "Goal":
                Destroy(collision.gameObject);
                Clear();
                return;
            case "floar":
                if (clear)
                {
                    Destroy(collision.gameObject);
                    transform.localScale += new Vector3(1, 1, 0);
                }
                return;
            case "Up":
                IsBlock(collision.gameObject);
                mit++;
                return;
            case "Down":
                IsBlock(collision.gameObject);
                if(!clear)mit--;
                if (mit < 0) mit = 0;
                return;
            case "desu":
                if (!clear)
                {
                    GM.reload();
                }
                return;
        }
    }

    private void IsBlock(GameObject g)
    {
        if (g.GetComponent<Collider2D>().isTrigger)
        {
            StartCoroutine(g.GetComponent<Block>().kyusyu());
        }
    }

    private void Clear()
    {
        this.GetComponent<suutihyouzi>().setfalse();
        clear = true;
        foreach (Transform t in kouseiyouso.transform)
        {
            t.gameObject.GetComponent<Stage>().Clear();
        }

        foreach (Transform t in this.transform)
        {
            t.gameObject.SetActive(false);
        }
        GM.clear();
    }
}
