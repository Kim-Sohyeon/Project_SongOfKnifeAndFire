using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// 대사마다 불러올 텍스트와 스프라이트이미지
[System.Serializable]
public class Dialog
{
    [TextArea]
    public string dialog;
    public Sprite cg;
    public Sprite dialog_box;
    public bool isReverse;
}

public class DialogController : MonoBehaviour
{
    // 기존 캔버스에 있던 스프라이트 이미지와 텍스트, 대화 박스를 드롭다운으로 선택
    [SerializeField] private SpriteRenderer sprite_StandCG_o;
    [SerializeField] private SpriteRenderer sprite_StandCG_r;
    [SerializeField] private SpriteRenderer sprite_DialogBox;
    [SerializeField] private Text txt_dialog;

    // 현재 대화중인가 확인 트리거
    private bool isDialog = false;
    // 한 대화 장면에 들어갈 대화 목록 수
    private int count = 0;

    [SerializeField] private Dialog[] dialogs;

    // 대화 창을 화면에 출력할 것인지 설정
    private void OnOffDialog(bool _flag)
    {
        sprite_DialogBox.gameObject.SetActive(_flag);

        sprite_StandCG_r.gameObject.SetActive(_flag);
        sprite_StandCG_o.gameObject.SetActive(_flag);
        
        txt_dialog.gameObject.SetActive(_flag);
        isDialog = _flag;
    }

    public void ShowDialog()
    {
        OnOffDialog(true);
        count = 0;
        NextDialog();
    }

    private void HideDialog()
    {
        OnOffDialog(false);
    }

    private void NextDialog()
    {
        txt_dialog.text = dialogs[count].dialog;
        Debug.Log(dialogs[count].isReverse);
        if(dialogs[count].isReverse)
        {
            sprite_StandCG_r.sprite = dialogs[count].cg;
            sprite_StandCG_o.gameObject.SetActive(false);
            sprite_StandCG_r.gameObject.SetActive(true);
        } else {
            sprite_StandCG_o.sprite = dialogs[count].cg;
            sprite_StandCG_r.gameObject.SetActive(false);
            sprite_StandCG_o.gameObject.SetActive(true);
        }
        sprite_DialogBox.sprite = dialogs[count].dialog_box;
        count++;
    }

    // Update is called once per frame
    void Update()
    {
        if(isDialog)
        {
            // 스페이스를 누르면 다음 대화로 넘어감
            if(Input.GetKeyDown(KeyCode.Space))
            {
                if (count < dialogs.Length)
                    NextDialog();
                else
                    OnOffDialog(false);
            }
        }

       
    }
}
