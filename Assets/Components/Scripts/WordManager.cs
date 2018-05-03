using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WordManager : MonoBehaviour
{
    public string word;
    public string[] characters;

    private void Start()
    {
        
        characters = new string[word.Length];
        for (int i = 0; i < word.Length; i++)
        {
            characters[i] = word[i].ToString();
            print(word[i]);
        }
    }

}
