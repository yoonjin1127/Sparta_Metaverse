using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{
    public static DialogueManager instance;

    public GameObject dialoguePanel;
    public  TextMeshProUGUI dialogueText;
    public GameObject scanObject;
    public bool isAction = false;

    // 초상화를 저장할 배열
    public Sprite[] portraitArr;

    // 초상화
    public Image portraitImage;

    // 키 번호를 받아와 정보를 출력한다
    Dictionary<int, string[]> dialogueData;

    // 초상화 데이터를 저장한다
    Dictionary<int, Sprite> portraitData;

    // 현재 출력하고 있는 대화의 인덱스
    int dialogueIndex = 0;

    private void Awake()
    {
        instance = this;
        dialogueData = new Dictionary<int, string[]>();
        portraitData = new Dictionary<int, Sprite>();
        GenerateData();
    }

    public void Action(GameObject scanObj)
    {
        scanObject = scanObj;
        ObjectData objectData = scanObject.GetComponent<ObjectData>();
        Dialogue(objectData.id, objectData.isNpc);
            
        dialoguePanel.SetActive(isAction);
    }

    // 오브젝트 및 NPC의 정보를 생성한다
    void GenerateData()
    {
        dialogueData.Add(1000, new string[] { "좋은 아침입니다.", "칼퇴하고 싶습니다." });
        dialogueData.Add(1001, new string[] { "좋은 아침입니다.", "벌써 9시네요." });
        dialogueData.Add(1002, new string[] { "좋은 아침입니다.", "제가 9번째 TIL 우수상을 받았습니다." });
        dialogueData.Add(1003, new string[] { "좋은 아침입니다.", "저 질문 좀 하고 오겠습니다." });
        dialogueData.Add(100, new string[] { "빨간색 포션이다.", "마셔보고 싶게 생겼다."});
        dialogueData.Add(101, new string[] { "큰 검이다.", "무거울 것 같다.\n들 수 있을까?"});

        dialogueData.Add(2000, new string[] { "포탈이다. 미니게임을 하러 갈까?" });

        portraitData.Add(1000, portraitArr[0]);
        portraitData.Add(1001, portraitArr[1]);
        portraitData.Add(1002, portraitArr[2]);
        portraitData.Add(1003, portraitArr[3]);
    }

    // id를 기반으로 몇 번째 대화를 출력할지 정한다
    public string GetDialogue(int id, int dialogueIndex)
    {
        // 대사 출력이 끝난 상태
        if(dialogueIndex == dialogueData[id].Length)
        {
            return null;
        }
        else
        {
            // 데이터 배열에서 id를 찾고, 그 안에서 다시 한 번 dialogueIndex 번호를 가진 대사를 찾아 꺼낸다.
            return dialogueData[id][dialogueIndex];
        }
    }

    void Dialogue(int id, bool isNpc)
    {
        string dialogueData = GetDialogue(id, dialogueIndex);

        if (dialogueData == null)
        {
            // 인덱스 초기화
            isAction = false;
            dialogueIndex = 0;
            return;
        }

        if (isNpc)
        {
            Sprite dialogueSprite = GetPortrait(id);
            dialogueText.text = dialogueData;
            portraitImage.sprite = dialogueSprite;
            // npc일 때만 초상화 출력
            portraitImage.color = new Color(1, 1, 1, 1);
        }
        else
        {
            dialogueText.text = dialogueData;
            portraitImage.color = new Color(1, 1, 1, 0);
        }

        isAction = true;
        dialogueIndex++;
    }

    // 초상화 스프라이트를 반환하는 함수
    public Sprite GetPortrait(int id)
    {
        return portraitData[id];
    }
}
