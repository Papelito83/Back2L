using System;
using System.Collections.Generic;

public class Inventory
{
    private List<Item> items;
    private int storeSpace;

    public Action OnItemChanged;

    public Inventory(int storeSpace)
    {
        items = new List<Item>();
        this.storeSpace = storeSpace;
    }

    public bool Add(Item item)
    {
        if (items.Count < storeSpace)
        {
            items.Add(item);
            OnItemChanged();

            return true;
        }

        return false;

    }

    public void Remove(Item item)
    {
        items.Remove(item);
        OnItemChanged();
    }
}
