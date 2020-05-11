using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartGamen : MonoBehaviour
{
    public int i;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void Startbutton()
    {
        SceneManager.LoadScene(10);
    }

    public void asobikata()
    {
        SceneManager.LoadScene(11);
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.R)&& 
           Input.GetKey(KeyCode.I)&& 
           Input.GetKey(KeyCode.S)&&
           Input.GetKey(KeyCode.E)&&
           Input.GetKey(KeyCode.T))
        {
            PlayerPrefs.DeleteAll();
            PlayerPrefs.Save();
            Debug.Log("delete_data");
        }
    }
}
