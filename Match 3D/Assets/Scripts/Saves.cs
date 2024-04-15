using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Saves", menuName = "Saves")]

public class Saves : ScriptableObject
{
    public Material[] skyboxes;
    public int skyboxIndex;
    public float volume;
    public int qualityIndex;
    public bool isFullscreen;
    public int resolutionIndex;

    public long HighScore;
}
