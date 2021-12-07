using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "HotSpotSO", menuName = "HotSpot/HotSpots")]
public class HotSpotSO : ScriptableObject
{
    public string Name;
    public string TextOnEnter;
    public string HoverText;
}
