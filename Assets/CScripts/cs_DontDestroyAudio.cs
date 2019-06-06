using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class cs_DontDestroyAudio : MonoBehaviour
{
    static public bool isPlayingVillageBgm;
    static public bool isInHeadquarter;
    // Start is called before the first frame update
    void Start()
    {
        isPlayingVillageBgm = true;
        isInHeadquarter = false;

        if(isPlayingVillageBgm == true)
        {
            DontDestroyOnLoad(transform.gameObject);
        } else
        {
            GetComponent<AudioSource>().Stop();
        }
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log("in headquarter");
        if(SceneManager.GetActiveScene().name.Equals("SceneInHeadquarter"))
        {
            isInHeadquarter = true;
            GetComponent<AudioSource>().Stop();
        }
    }
}
