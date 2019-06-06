using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class cs_FadeOut : MonoBehaviour
{
    public float animTime = 1f;
    static public GameObject fadeImage;
    static public Image fadeImage2;

    private float start = 0f;
    private float end = 1f;
    private float time = 0f;

    private bool isPlaying = false;

    // Start is called before the first frame update
    void Start()
    {
        fadeImage = GameObject.Find("BlackScreen");
        fadeImage2 = fadeImage.GetComponent<Image>();
        fadeImage.SetActive(false);

        Debug.Log("왜안돼~~~~~~~~~");

        //StartCoroutine("PlayFadeOut");
    }

    // Update is called once per frame
    void Update()
    {
        if (cs_MoveScene.isSceneMoved == true)    StartFadeAnim();
        
    }

    public void StartFadeAnim()
    {
        // 애니메이션 재생중 -> 중복 재생 X
        if (isPlaying == true) return;

        Debug.Log("랄랄ㄹ라랄");
        StartCoroutine("PlayFadeOut");
    }

    IEnumerator PlayFadeOut()
    {
        isPlaying = true;

        Debug.Log("Fade Out 재생");

        // Image 컴포넌트 색상 값 읽어오기
        Color color = fadeImage2.color;
        time = 0f;
        color.a = Mathf.Lerp(start, end, time);

        while (color.a < 1f)
        {
            // animTime 동안 재생
            time += Time.deltaTime / animTime;

            color.a = Mathf.Lerp(start, end, time);
            fadeImage2.color = color;

            yield return null;
        }

        isPlaying = false;
        cs_MoveScene.isAnimEnded = true;
    }
}
