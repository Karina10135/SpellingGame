using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class WordManager : MonoBehaviour
{
    public Image hitbar;
    public Text progressNum;

    public GameObject letterPrefab;
    public GameObject wordHolder;

    public string[] word;
    public string[] characters;
    public GameObject[] letters;

    public int letterProgress;
    public string currentLetter;

    public int currentWord;
    int half;

    public GameObject DialogBox;
    public Text dialogueText;
    [TextArea(3, 10)]
    public string[] log;
    public AudioClip[] dialogClip;
    public static WordManager wordManager;

    private bool isTalking;
    private bool gameComplete;

    private void Start()
    {
        wordManager = this;
        
        SetNameWord();
        UpdateWord(0);
        UpdateProgressBar();
    }

    private void Update()
    {
        if(isTalking)
        {
            if(Input.GetMouseButtonDown(0))
            {
                DialogBox.SetActive(false);
                isTalking = false;
                if (gameComplete)
                {
                    //SCENE YOU WANT AT THE END
                    SceneManager.LoadScene(0);
                }
            }

        }
    }

    public void CheckHalfway()
    {
        half = word.Length / 2;

        if(currentWord == half)
        {
            print("half way");
            StartCoroutine(Dialog(1));
            SoundManager.instance.PlaySound(PickupManager.instance.source, dialogClip[1]);
        }
    }

    
    public void UpdateWord(int level)
    {
        characters = new string[word[level].Length];
        letters = new GameObject[characters.Length];
        for (int i = 0; i < word[level].Length; i++)
        {
            characters[i] = word[level][i].ToString();
            var letter = Instantiate(letterPrefab);
            letter.transform.SetParent(wordHolder.transform);
            Text r = letter.GetComponentInChildren<Text>();
            r.text = characters[i];
            letters[i] = letter;
        }

        letterProgress = 0;

        progressNum.text = "0/" + characters.Length.ToString();
        currentLetter = characters[letterProgress];
    }

    public void UpdateProgressBar()
    {
        float length = characters.Length;
        float ratio = letterProgress/length;
        hitbar.rectTransform.localScale = new Vector3(1, ratio, 1);
    }

    public void NextWord()
    {
        print("next word");
        foreach(GameObject letterPre in letters)
        {
            Destroy(letterPre);
        }
        letters = new GameObject[0];
        currentWord++;

        CheckHalfway();

        if (currentWord == word.Length)
        {
            GameOver();
        }
        else
        {
            UpdateWord(currentWord);
            UpdateProgressBar();
        }
    }

    public void NextLetter()
    {
        letters[letterProgress].GetComponent<Image>().color = Color.white;
        letterProgress++;
        progressNum.text = letterProgress + "/" + characters.Length.ToString();
        UpdateProgressBar();

        if (letterProgress == characters.Length)
        {
            NextWord();
            return;
        }

        currentLetter = characters[letterProgress];


    }

    IEnumerator Dialog(int sentence)
    {
        yield return StartCoroutine(TypeSentence(log[sentence]));
    }

    public void GameOver()
    {
        print("Finished!!!");
        StartCoroutine(TypeSentence(log[2]));
        SoundManager.instance.PlaySound(PickupManager.instance.source, dialogClip[2]);
        gameComplete = true;
    }

    public void SetNameWord()
    {
        word[0] = GameManager.GM.playerName;
        for (int i = 1; i < word.Length; i++)
        {
            if (i != 1)
            {
                if (word[i - 2] != GameManager.GM.playerName && word[i - 1] != GameManager.GM.playerName)
                {
                    word[i] = GameManager.GM.playerName;
                }
            }
        }
    }

    IEnumerator TypeSentence(string sentence)
    {
        DialogBox.SetActive(true);
        dialogueText.text = "";
        foreach (char letter in sentence.ToCharArray())
        {
            dialogueText.text += letter;
            yield return null;
        }
        isTalking = true;
    }

    IEnumerator WaitTimer(int secs)
    {
        yield return new WaitForSeconds(secs);
    }

}
