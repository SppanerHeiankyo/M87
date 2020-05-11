using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Goalbtn : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void GoNext()
    {
        int now = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(now + 1);
    }

    public void GoSelect()
    {
        SceneManager.LoadScene(10);
    }
}
