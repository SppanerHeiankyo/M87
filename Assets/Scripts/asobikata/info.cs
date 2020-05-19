using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class info : MonoBehaviour
{
    public GameObject yazirusi;
    GameObject[] yazirusis;
    // Start is called before the first frame update
    void Start()
    {
        yazirusis = new GameObject[transform.childCount];
        int i = 0;
        foreach(Transform t in transform)
        {
            GameObject a = Instantiate(yazirusi, t);
            yazirusis[i] = a;
            i++;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
