using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NPCSO", menuName = "NPC/NPCs")]
public class NPCSO : ScriptableObject
{
    public string DialogTextNPC;
    public float OffsetTextFrame;
    public string[] PlayerAnsers;
}
