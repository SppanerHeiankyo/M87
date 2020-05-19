using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class tutorial : MonoBehaviour
{
    GameManager GM;
    public GameObject Up, Down;
    public GameObject[] info;
    // Start is called before the first frame update
    void Start()
    {
        GM = GameObject.Find("GameManager").GetComponent<GameManager>();
        StartCoroutine(syori());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator Fadein(GameObject text)
    {
        Debug.Log("Fadeout:" + text.name);
        text.SetActive(true);
        Color c = text.GetComponent<Text>().color;
        for(int i = 0; i < 15; i++)
        {
            c.a = (float)i / 15f;
            text.GetComponent<Text>().color = c;
            yield return new WaitForFixedUpdate();
        }
    }

    IEnumerator Fadeout(GameObject text)
    {
        Debug.Log("Fadein:" + text.name);
        Color c = text.GetComponent<Text>().color;
        for (int i = 14; i != 0; i--)
        {
            c.a =(float)i / 15f;
            text.GetComponent<Text>().color = c;
            yield return new WaitForFixedUpdate();
        }
        text.SetActive(false);
    }

    IEnumerator syori()
    {
        StartCoroutine(Fadein(transform.GetChild(0).gameObject));
        info[0].SetActive(true);
        while(GM.Player.transform.position.x<-12.5f)
        {
            yield return null;
        }
        StartCoroutine(Fadeout(transform.GetChild(0).gameObject));
        info[0].SetActive(false);
        info[1].SetActive(true);
        yield return new WaitForSeconds(15f / 60f);

        StartCoroutine(Fadein(transform.GetChild(1).gameObject));
        while (GM.Player.GetComponent<Player>().mit==0)
        {
            yield return null;
        }
        StartCoroutine(Fadeout(transform.GetChild(1).gameObject));
        info[1].SetActive(false);
        info[2].SetActive(true);
        yield return new WaitForSeconds(15f / 60f);

        StartCoroutine(Fadein(transform.GetChild(2).gameObject));
        while (GM.Player.transform.position.x<info[2].transform.position.x)
        {
            yield return null;
        }
        StartCoroutine(Fadeout(transform.GetChild(2).gameObject));
        info[2].SetActive(false);
        info[3].SetActive(true);
        yield return new WaitForSeconds(15f / 60f);

        StartCoroutine(Fadein(transform.GetChild(3).gameObject));
        while (GM.Player.transform.position.x<info[3].transform.position.x)
        {
            yield return null;
        }
        StartCoroutine(Fadeout(transform.GetChild(3).gameObject));
        info[3].SetActive(false);
        yield return new WaitForSeconds(15f / 60f);

        StartCoroutine(Fadein(transform.GetChild(4).gameObject));
        while (!Input.GetKeyDown(KeyCode.LeftShift))
        {
            yield return null;
        }
        StartCoroutine(Fadeout(transform.GetChild(4).gameObject));
        yield return new WaitForSeconds(15f / 60f);

        StartCoroutine(Fadein(transform.GetChild(5).gameObject));
        //while (false)
        //{
        //    yield return null;
        //}
        //StartCoroutine(Fadeout(transform.GetChild(5).gameObject));
        //yield return new WaitForSeconds(15f / 60f);

        //StartCoroutine(Fadein(transform.GetChild(6).gameObject));
        //yield return new WaitForSeconds(3f);

        //StartCoroutine(Fadeout(transform.GetChild(6).gameObject));
        //yield return new WaitForSeconds(15f / 60f);

        //StartCoroutine(Fadein(transform.GetChild(7).gameObject));
        //yield return new WaitForSeconds(3f);

        //StartCoroutine(Fadeout(transform.GetChild(7).gameObject));
        //yield return new WaitForSeconds(15f / 60f);
        //StartCoroutine(Fadein(transform.GetChild(8).gameObject));
        //yield return new WaitForSeconds(3f);
        //StartCoroutine(Fadeout(transform.GetChild(8).gameObject));


    }
}
