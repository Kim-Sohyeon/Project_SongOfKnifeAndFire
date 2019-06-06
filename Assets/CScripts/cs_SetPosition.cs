using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class cs_SetPosition : MonoBehaviour
{
    static public string lastscene;
    string nowscene;


    // Start is called before the first frame update
    void Start()
    {
        nowscene = SceneManager.GetActiveScene().name;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
