﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LetterManager : MonoBehaviour
{
    public string letter;

    public void CheckLetter()
    {

    }
	
    public void DestroyLetter()
    {
        Destroy(gameObject);
    }

}
