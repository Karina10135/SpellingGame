using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WordManager : MonoBehaviour
{





    public Image hitbar;
    public Text progressNum;
    public Text letter;


    public GameObject letterPrefab;
    public GameObject wordHolder;


    public string[] word;
    public string[] characters;
    public GameObject[] letters;

    public int letterProgress;
    public string currentLetter;
    public int currentWord;

    public float currentProg;
    

    public static WordManager wordManager;

    private void Start()
    {
        wordManager = this;


        UpdateWord(0);
        UpdateProgressBar();
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
        letter.text = currentLetter;
    }

    public void ResetProgressBar(int level)
    {
        characters = new string[word[level].Length];
        for (int i = 0; i < word[level].Length; i++)
        {
            characters[i] = word[level][i].ToString();
        }

        letterProgress = 0;
        progressNum.text = "0/" + characters.Length.ToString();

        currentLetter = characters[letterProgress];
        letter.text = currentLetter;
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
        if(currentWord == word.Length)
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
        letter.text = currentLetter;


    }

    public void GameOver()
    {
        print("Finished!!!");

    }

}
