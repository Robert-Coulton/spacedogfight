using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "SaveScriptableObject", menuName = "ScriptableObjects/SaveScriptableObject", order = 1)]
public class SaveScriptableObject : ScriptableObject
{
    public float coins;

    public int skinIndex;

    public bool[] owned;
}
