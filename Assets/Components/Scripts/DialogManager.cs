using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogManager : MonoBehaviour
{
    public string name;


    public GameObject weapon;
    public GameObject namePanel;
    public Text characterName;
    public Text dialogueText;
    public int step;

    [TextArea(3,10)]
    public string[] sentences;
    bool dialog;

    public void Start()
    {
        characterName.text = name.ToString();
        //StartCoroutine(StartDialogTimer());
        StartDialog();
    }

    public void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            NextDialog();
        }
    }


    public void StartDialog()
    {
        dialog = true;
        
        StartCoroutine(TypeSentence(sentences[0]));
    }

    public void NextDialog()
    {
        if (!dialog) { return; }

        if (step == sentences.Length) { return; }

        StopAllCoroutines();

        if(step == 6)
        {
            weapon.SetActive(true);
        }

        if(step == 7)
        {
            weapon.SetActive(false);
        }

        if(step == 9)
        {
            namePanel.SetActive(true);
        }


        step++;
        StartCoroutine(TypeSentence(sentences[step]));

    }

    IEnumerator StartDialogTimer()
    {
        yield return new WaitForSeconds(3);
        StartDialog();
    }

    IEnumerator TypeSentence(string sentence)
    {
        dialogueText.text = "";

        foreach(char letter in sentence.ToCharArray())
        {
            dialogueText.text += letter;
            yield return null;
        }
    }

}
