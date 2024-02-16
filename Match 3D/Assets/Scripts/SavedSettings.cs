using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Saved Settings", menuName = "Saves/SavedSettings")]

public class SavedSettings : ScriptableObject
{
    public Material[] skyboxes;
    public int skyboxIndex;
    public float volume;
    public int qualityIndex;
    public bool isFullscreen;
    public int resolutionIndex;
}
