using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WordManager : MonoBehaviour
{
    public Image hitbar;
    public Text prog;
    public Text letter;

    public string[] word;
    public string[] characters;

    public int letterProgress;
    public string currentLetter;

    public static WordManager wordManager;

    private void Start()
    {
        wordManager = this;
        

        ResetProgressBar(0);
    }

    public void ResetProgressBar(int level)
    {
        characters = new string[word[level].Length];
        for (int i = 0; i < word[level].Length; i++)
        {
            characters[i] = word[level][i].ToString();
            print(word[level][i]);
        }

        letterProgress = 0;
        prog.text = "0/" + characters.Length.ToString();

        currentLetter = characters[letterProgress];
        letter.text = currentLetter;
    }

    public void UpdateProgressBar()
    {

    }

    public void NextWord()
    {
        print("next word");
        ResetProgressBar(1);
    }

    public void NextLetter()
    {
        letterProgress++;
        prog.text = letterProgress + "/" + characters.Length.ToString();


        if (letterProgress == characters.Length)
        {
            NextWord();
            return;
        }

        currentLetter = characters[letterProgress];
        letter.text = currentLetter;

    }

}
