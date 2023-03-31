using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Scriptable/Item")]
public class ScriptableItem : ScriptableObject
{
    public Sprite icon;
    public string title;
    public string description;
    public float price;
}
