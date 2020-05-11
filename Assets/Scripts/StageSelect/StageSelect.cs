using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class StageSelect : MonoBehaviour
{
    Transform btn_canvas;
    public Sprite[] stage_images = new Sprite[9];
    // Start is called before the first frame update
    void Start()
    {
        btn_canvas = GameObject.Find("btn_canvas").transform;
        if (!PlayerPrefs.HasKey("clear"))
        {
            PlayerPrefs.SetInt("clear", 0);
            PlayerPrefs.Save();
        }
        if (PlayerPrefs.GetInt("clear") == 9) PlayerPrefs.SetInt("clear", 8);
        for(int i=0; i <= PlayerPrefs.GetInt("clear");i++)
        {
            btn_canvas.GetChild(i).GetComponent<Image>().sprite = stage_images[i];
            btn_canvas.GetChild(i).GetComponent<Outline>().enabled = true;
        }
    }

    public void selected(int stage_num)
    {
        if(PlayerPrefs.GetInt("clear")>=stage_num)loadStage(stage_num);
    }

    private void loadStage(int stage_num)
    {
        SceneManager.LoadScene(stage_num+1);
    }

    public void GoRight(bool right)
    {
        StartCoroutine("kirikae", right);
    }

    IEnumerator kirikae(bool right)
    {
        for(int i = 0; i < 10; i++)
        {
            foreach(Transform t in btn_canvas)
            {
                t.position -= new Vector3(right?Screen.width / 10:-Screen.width/10, 0, 0);
            }
            yield return null;
        }
    }
    public void OnClick()
    {
        Debug.Log("Clicked");
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Backspace)) SceneManager.LoadScene(0);
    }
}
