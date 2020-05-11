using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class suutihyouzi : MonoBehaviour
{
    public GameObject cvs,txt;
    public int mit;
    bool hyouzi=true;
    // Start is called before the first frame update
    void Start()
    {
    }

    public void settxt(int i)
    {
        txt.GetComponent<Text>().text = i.ToString();
    }
    public void setfalse()
    {
        hyouzi = false;
    }

    // Update is called once per frame
    void Update()
    {
        cvs.SetActive(Input.GetKey(KeyCode.LeftShift)&&hyouzi);
    }
}
