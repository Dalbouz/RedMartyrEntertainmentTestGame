using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "ITEMSO", menuName = "Item/Items")]
public class ItemSO : ScriptableObject
{
    public string Name;
    public string Description;
    public Sprite ImageOfItem;
}
