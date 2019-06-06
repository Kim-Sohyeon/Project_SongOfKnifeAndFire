using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class cs_MoveScene : MonoBehaviour
{
    static public bool isSceneMoved;
    static public bool isSceneOpened;
    static public bool isAnimEnded;
    string nowscene, collidedobj;

    void Start()
    {
        isSceneMoved = false;
        isSceneOpened = false;
        isAnimEnded = false;
        nowscene = SceneManager.GetActiveScene().name;
    }

    void Update()
    {
        /*
        if(isSceneMoved == true && isAnimEnded == true)
        {
            SceneManager.LoadScene("SceneHouseFront");
        }*/

        if(isAnimEnded == true)
        {
            Debug.Log(collidedobj);
            if (nowscene.Equals("SceneHouseFront"))
            {
                if (collidedobj.Equals("toCookingCollider")) SceneManager.LoadScene("SceneCookingField");
                else if (collidedobj.Equals("toVillageCollider"))
                {
                    SceneManager.LoadScene("SceneVillage");
                    Debug.Log("Load Village");
                }
                else if (collidedobj.Equals("toDungeonCollider")) SceneManager.LoadScene("SceneSelectDungeon");
                else if (collidedobj.Equals("toInHouseCollider")) SceneManager.LoadScene("SceneInHouse");
            } else if (nowscene.Equals("SceneInHouse"))
            {
                SceneManager.LoadScene("SceneHouseFront");
            } else if (nowscene.Equals("SceneVillage"))
            {
                if (collidedobj.Equals("toHouseFrontCollider")) SceneManager.LoadScene("SceneHouseFront");
                else if (collidedobj.Equals("toHeadquarterFrontCollider"))
                {
                    SceneManager.LoadScene("SceneHeadquarterFront");
                    Debug.Log("Load Headquarter");
                }
                else if (collidedobj.Equals("toArtifactCollider")) SceneManager.LoadScene("SceneArtifact");
                else if (collidedobj.Equals("toMysteryCaveCollider")) SceneManager.LoadScene("SceneMysteryCaveFront");
            } else if(nowscene.Equals("SceneHeadquarterFront"))
            {
                if (collidedobj.Equals("toVillageCollider")) SceneManager.LoadScene("SceneVillage");
                else if (collidedobj.Equals("toInHeadquarterCollider")) SceneManager.LoadScene("SceneInHeadquarter");
                Debug.Log("collided31");
            } else if(nowscene.Equals("SceneInHeadquarter"))
            {
                SceneManager.LoadScene("SceneHeadquarterFront");
            } else if (nowscene.Equals("SceneArtifact"))
            {
                SceneManager.LoadScene("SceneVillage");
                //SceneManager.LoadScene("");
            } else if(nowscene.Equals("SceneCaveFront"))
            {
                SceneManager.LoadScene("SceneVillage");
            }
        }

    }


    void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("collided");
        isSceneMoved = true;
        cs_FadeOut.fadeImage.SetActive(true);
        collidedobj = this.gameObject.name;
        Debug.Log("씬움직임    :  " +  collidedobj);
    }
}