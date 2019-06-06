using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cs_BtnA : MonoBehaviour
{
    public static bool isAClicked;

    // Start is called before the first frame update
    void Start()
    {
        isAClicked = false;
    }

    public void AClicked()
    {
        isAClicked = true;
    }
}
