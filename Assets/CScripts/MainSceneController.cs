using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainSceneController : MonoBehaviour
{
    private Touch tempTouches;
    private Vector3 touchedPos; //터치 된 위치 정보 저장 변수
    private bool touchOn; // 터치 확인 변수

    public void Update()
    {
        touchOn = false;
        if(Input.touchCount > 0)
        {//터치 된 수 체크
            for (int i=0; i<Input.touchCount; i++)
            {
                tempTouches = Input.GetTouch(i);
                //현재 입력된 터치에 대한 정보
                if(tempTouches.phase == TouchPhase.Began)
                {
                    //touchedPos = Camera.main.ScreenToWorldPoint(tempTouches.position);//get world position
                    //현재 터치 된 위치의 메인 카메라 기준의 WorldPosition  값 얻어오는 코드
                    touchOn = true;
                    ChangeSceneWhenStartGame();
                    break;
                }
            }
        }
        if(Input.GetMouseButtonDown(0))//마우스 좌측 버튼 클릭
        {
            ChangeSceneWhenStartGame();
        }
    }

    public void ChangeSceneWhenStartGame()
    {
        SceneManager.LoadScene("TutorialDialog");
    }

}
