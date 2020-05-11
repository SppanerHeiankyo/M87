using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public int Max=1;
    public bool debag_mode = false;
    public GameObject Player;
    public GameObject Canvas;
    private bool cleard=false;
    public int RisetCount = 0;
    private void Start()
    {
        Max = GameObject.Find("Goal").GetComponent<Block>().mit;
    }

    // Start is called before the first frame update
    private void FixedUpdate()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            reload();
        }
        if (Input.GetKeyDown(KeyCode.Backspace))
        {
            SceneManager.LoadScene(10);
        }
        if (debag_mode)
        {
            if (Input.GetKeyDown(KeyCode.Q))
            {
                Player.GetComponent<Player>().mit++;
            }
            if(Input.GetKeyDown(KeyCode.A))
            {
                Player.GetComponent<Player>().mit--;
            }
            if (Input.GetKeyDown(KeyCode.F))
            {
                Player.GetComponent<Player>().fry = !Player.GetComponent<Player>().fry;
            }
        }
        if (Input.GetKeyDown(KeyCode.Space) && cleard)
        {
            NextStage();
        }
        if (Input.GetKeyDown(KeyCode.LeftShift) || Input.GetKeyDown(KeyCode.RightShift))
        {
            if(cleard) goselect();
        }
        if (Input.GetKeyDown(KeyCode.N) && RisetCount > 5)
        {
            
        }
    }

    public void goselect()
    {
        SceneManager.LoadScene(10);
    }
    public void reload()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void clear()
    {
        int now = SceneManager.GetActiveScene().buildIndex;
        if (now > PlayerPrefs.GetInt("clear"))
        {
            Debug.Log(now);
            PlayerPrefs.SetInt("clear", now);
            PlayerPrefs.Save();
        }
        StartCoroutine("canvastrue");
    }

    IEnumerator canvastrue()
    {
        yield return new WaitForSeconds(2);
        Canvas.SetActive(true);
        cleard = true;
    }

    public void NextStage()
    {
        int now = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(now + 1);
    }

    
}
