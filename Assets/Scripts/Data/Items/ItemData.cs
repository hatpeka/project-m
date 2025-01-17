using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Item Data", menuName = "Item Data")]
public class ItemData : ScriptableObject
{
    [Header("Basic info")]
    [SerializeField] private string itemName;
    [SerializeField] private string description;
    [SerializeField] private Sprite icon;
    [SerializeField] private bool stackable;
    [SerializeField] private ItemType itemType;
    //The attribute 'int amount' may be declared here later

    public string GetName()
    {
        return itemName;
    }

    public string GetDesc()
    {
        return description;
    }

    public Sprite GetSprite()
    {
        return icon;
    }

    public bool IsStackable()
    {
        return stackable;
    }

    public ItemType GetItemType()
    {
        return itemType;
    }
}
