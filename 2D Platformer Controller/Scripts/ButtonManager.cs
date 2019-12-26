using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ButtonManager : MonoBehaviour
{ 

    // Use this for initialization
    public void Repeat()
    {
        ScoreTrackering.scoreNum = 0;
        Application.LoadLevel(0);
    }
    public void Continue()
    {
        Application.OpenURL("http://www.dddragon.cn/endgame.php");
    }
}
