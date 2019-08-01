using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using System.Xml;

public class DialogueManager : MonoBehaviour
{
    // Resources/XML/DialogueScript.XML 파일.
    string xmlFileName = "DialogueScript";

    public Text nameText;
    public Text dialogueText;
    public Text AnnouncerDialogueText;

    public Animator dialogue_animator;
    public Animator announcer_animator;

    public string dialogue_name;

    //private Queue<string> sentences;
    private Queue<Dictionary<string, object>> dialogues;
    Dictionary<string, object> dialogue;
    int sentenceCount;
    private Queue<string> sentences;
    string sentence;

    GameObject anoDiaBox;

    // Start is called before the first frame update
    void Start()
    {
        anoDiaBox = GameObject.Find("Announcer_DialogueBox");
        anoDiaBox.SetActive(false);
        sentenceCount = 0;
        dialogues = new Queue<Dictionary<string, object>>();
        sentences = new Queue<string>();
        StartDialogues(dialogue_name);
    }

    public void StartDialogues(string DialogueName)
    {
        dialogues.Clear();
        dialogues = LoadXML(xmlFileName, DialogueName);

        DisplayNextDiaglue();
    }
    public void DisplayNextDiaglue()
    {
        Debug.Log(dialogues.Count);
        if (dialogues.Count == 0)
        {
            EndDialogues();
            return;
        }
        dialogue = dialogues.Dequeue();

        if(!Convert.ToBoolean(dialogue["isAnnouncer"]))
        {
            anoDiaBox.SetActive(false);
            dialogue_animator.SetBool("isOpen", true);
            announcer_animator.SetBool("isOpen", false);
            nameText.text = dialogue["npcName"].ToString();
        }
        else
        {
            anoDiaBox.SetActive(true);
            dialogue_animator.SetBool("isOpen", false);
            announcer_animator.SetBool("isOpen", true);
        }

        sentences = (Queue<string>)dialogue["sentences"];

        DisplayNextSentence();
    }
    public void DisplayNextSentence ()
    {
        if (sentences.Count == 0)
        {
            EndSentences();
            DisplayNextDiaglue();
            return;
        }
        sentence = sentences.Dequeue();
        StopAllCoroutines();
        StartCoroutine(TypeSentence(sentence));
    }

    IEnumerator TypeSentence (string sentence)
    {
        if (!Convert.ToBoolean(dialogue["isAnnouncer"]))
        {
            dialogueText.text = "";
            foreach (char letter in sentence.ToCharArray())
            {
                dialogueText.text += letter;
                yield return null;
            }
        }
        else
        {
            AnnouncerDialogueText.text = "";
            foreach (char letter in sentence.ToCharArray())
            {
                AnnouncerDialogueText.text += letter;
                yield return null;
            }
        }
        
    }
    void EndSentences()
    {
        dialogue_animator.SetBool("isOpen", false);
        announcer_animator.SetBool("isOpen", false);
    }
    void EndDialogues()
    {
        
    }

    private Queue<Dictionary<string, object>> LoadXML(string _fileName, string dialogueName)
    {
        //리턴값을 담을 변수
        Queue<Dictionary<string, object>> dialogues = new Queue<Dictionary<string, object>>();
        //전체 xml 로드
        TextAsset txtAsset = (TextAsset)Resources.Load("XML/" + _fileName);
        XmlDocument dialogueDoc = new XmlDocument();
        dialogueDoc.LoadXml(txtAsset.text);
        //최상위 노드 선택
        XmlNodeList dialogueAreas = dialogueDoc.SelectNodes("DialogueCollection/DialogueArea");
        Debug.Log(txtAsset.text);
        //dialogueDoc.LoadXml(txtAsset.text);
        foreach (XmlNode dialogueArea in dialogueAreas)
        {
            Debug.Log("dialogueArea name Attr : "+dialogueArea.Attributes.GetNamedItem("name").Value);
            //DialogueArea의 name 속성 값이 dialogueName로 전달받은 값과 같은지, 자식이 있을때만 돌도록 설정
            if (dialogueArea.Attributes.GetNamedItem("name").Value.Equals(dialogueName) 
                && dialogueArea.HasChildNodes)
            {
                foreach (XmlNode dialogue in dialogueArea)
                {
                    //Dialogue 요소를 담기위한 Dictionary
                    /*
                     * 
                     */
                    Dictionary<string, object> dt = new Dictionary<string, object>();
                    dt["isAnnouncer"] = dialogue.SelectSingleNode("isAnnouncer").InnerText;
                    //Debug.Log("isAnnouncer : " + dt["isAnnouncer"]);
                    dt["npcName"] = dialogue.SelectSingleNode("npcName").InnerText;
                    //Debug.Log("npcName : " + dt["npcName"]);
                    //dt["sentenceSize"] = dialogue.SelectSingleNode("sentenceSize").InnerText;
                    //Debug.Log("sentenceSize : " + dt["sentenceSize"]);
                    Queue<string> sentences = new Queue<string>();
                    //Debug.Log("sentences : ");
                    foreach (XmlNode sentence in dialogue.SelectSingleNode("sentences"))
                    {
                        sentences.Enqueue(sentence.InnerText);
                        //Debug.Log(sentence.InnerText+", ");
                    }
                    dt["sentences"] = sentences;
                    dialogues.Enqueue(dt);
                }
                break;
            }
        }
        return dialogues;
    }
}
