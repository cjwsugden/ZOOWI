using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]

public class FacultyChoice
{
    public int _choice;
    
    public FacultyChoice (AdvisingDialogue p)
    {
        _choice = p.choice;
    }
}
