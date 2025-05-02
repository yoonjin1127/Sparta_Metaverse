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

    // �ʻ�ȭ�� ������ �迭
    public Sprite[] portraitArr;

    // �ʻ�ȭ
    public Image portraitImage;

    // Ű ��ȣ�� �޾ƿ� ������ ����Ѵ�
    Dictionary<int, string[]> dialogueData;

    // �ʻ�ȭ �����͸� �����Ѵ�
    Dictionary<int, Sprite> portraitData;

    // ���� ����ϰ� �ִ� ��ȭ�� �ε���
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

    // ������Ʈ �� NPC�� ������ �����Ѵ�
    void GenerateData()
    {
        dialogueData.Add(1000, new string[] { "���� ��ħ�Դϴ�.", "Į���ϰ� �ͽ��ϴ�." });
        dialogueData.Add(1001, new string[] { "���� ��ħ�Դϴ�.", "���� 9�ó׿�." });
        dialogueData.Add(1002, new string[] { "���� ��ħ�Դϴ�.", "���� 9��° TIL ������� �޾ҽ��ϴ�." });
        dialogueData.Add(1003, new string[] { "���� ��ħ�Դϴ�.", "�� ���� �� �ϰ� ���ڽ��ϴ�." });
        dialogueData.Add(100, new string[] { "������ �����̴�.", "���ź��� �Ͱ� �����."});
        dialogueData.Add(101, new string[] { "ū ���̴�.", "���ſ� �� ����.\n�� �� ������?"});

        dialogueData.Add(2000, new string[] { "��Ż�̴�. �̴ϰ����� �Ϸ� ����?" });

        portraitData.Add(1000, portraitArr[0]);
        portraitData.Add(1001, portraitArr[1]);
        portraitData.Add(1002, portraitArr[2]);
        portraitData.Add(1003, portraitArr[3]);
    }

    // id�� ������� �� ��° ��ȭ�� ������� ���Ѵ�
    public string GetDialogue(int id, int dialogueIndex)
    {
        // ��� ����� ���� ����
        if(dialogueIndex == dialogueData[id].Length)
        {
            return null;
        }
        else
        {
            // ������ �迭���� id�� ã��, �� �ȿ��� �ٽ� �� �� dialogueIndex ��ȣ�� ���� ��縦 ã�� ������.
            return dialogueData[id][dialogueIndex];
        }
    }

    void Dialogue(int id, bool isNpc)
    {
        string dialogueData = GetDialogue(id, dialogueIndex);

        if (dialogueData == null)
        {
            // �ε��� �ʱ�ȭ
            isAction = false;
            dialogueIndex = 0;
            return;
        }

        if (isNpc)
        {
            Sprite dialogueSprite = GetPortrait(id);
            dialogueText.text = dialogueData;
            portraitImage.sprite = dialogueSprite;
            // npc�� ���� �ʻ�ȭ ���
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

    // �ʻ�ȭ ��������Ʈ�� ��ȯ�ϴ� �Լ�
    public Sprite GetPortrait(int id)
    {
        return portraitData[id];
    }
}
