using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cs_OnViewPort : MonoBehaviour
{
    //public GameObject requestcontent;
    //public GameObject inventorycontent;
    //public GameObject potionsellcontent;
    //public GameObject weaponsellcontent;
    //public GameObject ingredientsellcontent;

    public GameObject[] viewportcontents = new GameObject[5];

    // Start is called before the first frame update
    void Start()
    {
        for(int i = 0; i < 5; i++)
        {
            viewportcontents[i].SetActive(false);
        }
    }

    public void OnViewport(short n)
    {
        for (int i = 0; i < 5; i++)
        {
            viewportcontents[i].SetActive(false);
        }
        viewportcontents[n].SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
