using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IItemStack
{
    private int capacity;
    private List<IItem> items;

    public IItemStack(int capacity)
    {
        items = new List<IItem>();
        this.capacity = capacity;
    }

    public bool IsFull()
    {
        return !(items.Count < capacity);
    }

    public bool IsEmpty()
    {
        return items.Count == 0;
    }

    public void AddItem(IItem item)
    {
        items.Add(item);
    }

    public void RemoveItem(IItem item)
    {
        items.Remove(item);
    }
}
