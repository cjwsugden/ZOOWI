using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]

public class SaveProfile
{
    public float xPos;
    public float yPos;
    public float zPos;
    public bool TourQuestCompleted;
    public bool RegQuestCompleted;
    public bool FSTQuestCompleted;
    public bool NightQuestCompleted;
    public bool AstronomyQuestCompleted;
    public bool SportsQuestCompleted;
    
    public bool pbWin;
    public bool pbLose;
    public bool pbDraw;

    public bool astBronze;
    public bool astSilver;
    public bool astGold;
    
    
    public SaveProfile (MainManager mm)
    {
        xPos = mm.xPos;
        yPos = mm.yPos;
        zPos = mm.zPos;

        TourQuestCompleted = mm.TourQuestCompleted1;
        RegQuestCompleted = mm.RegQuestCompleted1;
        FSTQuestCompleted = mm.FSTQuestCompleted1;
        NightQuestCompleted = mm.NightQuestCompleted1;
        AstronomyQuestCompleted = mm.AstronomyQuestCompleted1;
        SportsQuestCompleted = mm.SportsQuestCompleted1;

        pbWin = mm.pbWin1;
        pbDraw = mm.pbDraw1;
        pbLose = mm.pbLose1;

        astBronze = mm.astBronze1;
        astSilver = mm.astSilver1;
        astGold = mm.astGold1;

    }

}
