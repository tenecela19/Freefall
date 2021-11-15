using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//CLASS
[System.Serializable]
public class Save
{
    public int level;
    public int oldlevel;
    public int BlockNum;
    public int Highscore;
    public int PlayerToPlay;
    public List<float> blockpositionx = new List<float>();
    public List<float> blockpositiony = new List<float>();
    public List<float> blockpositionz = new List<float>();
    public List<float> blockrotationy = new List<float>();
    public List<int> bloquesLevel = new List<int>();
    public float r, g, b, a;
    public float r1, g1, b1, a1;
}
