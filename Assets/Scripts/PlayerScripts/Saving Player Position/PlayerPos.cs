using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]

public class PlayerPos
{
    public Vector3 _pos ;
    public Quaternion _rot;
    
    public PlayerPos (AdvisingDialogue p)
    {
        _pos = p.pos;
        _rot = p.rot;
    }
}
