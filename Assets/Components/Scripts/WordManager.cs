using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WordManager : MonoBehaviour
{
    public Image hitbar;
    public Text prog;
    public Text letter;

    public string word;
    public string[] characters;

    public int letterProgress;
    public string currentLetter;

    public static WordManager wordManager;

    private void Start()
    {
        wordManager = this;
        characters = new string[word.Length];
        for (int i = 0; i < word.Length; i++)
        {
            characters[i] = word[i].ToString();
            print(word[i]);
        }

        ResetProgressBar();
    }

    public void ResetProgressBar()
    {
        letterProgress = 0;
        prog.text = "0/" + characters.Length.ToString();

        currentLetter = characters[letterProgress];
        letter.text = currentLetter;
    }

    public void UpdateProgressBar()
    {

    }

    public void NextLetter()
    {
        letterProgress++;
        prog.text = "0/" + characters.Length.ToString();
        currentLetter = characters[letterProgress];
        letter.text = currentLetter;

    }

}
