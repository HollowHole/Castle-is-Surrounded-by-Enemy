using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "MagicSO", menuName = "SO/MagicSO", order = 1)]
public class MagicSO : ScriptableObject
{
    public string magicName;
    public float lastTime;
    public float triggerRate;
    public int damage;
}
