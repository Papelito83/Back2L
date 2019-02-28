using System;
using System.Collections;
using System.Collections.Generic;

public class Inventory
{
    private Dictionary<int, IItemStack> stacks;

    public Inventory()
    {
        stacks = new Dictionary<int, IItemStack>();
    }

    public bool FindItem(IItem item)
    {
        if (item != null)
        {
            if (stacks.ContainsKey(item.GetId()))
            {
                if (!stacks[item.GetId()].IsEmpty())
                    return true;               
            }
        }

        return false;
    }

    public void AddItem(IItem item)
    {
        if (item != null)
        { 
            if (stacks.ContainsKey(item.GetId()))
            {
                if (!stacks[item.GetId()].IsFull())
                    stacks[item.GetId()].AddItem(item);
            }
            else
            {
                if (item.Stackable())
                {
                    IItemStack stack = new IItemStack(item.GetStackLimit());
                    stack.AddItem(item);
                    stacks.Add(item.GetId(), stack);
                }            
            }
        }
    }  

    public void RemoveItem(IItem item)
    {
        if(item != null)
        {
            if(stacks.ContainsKey(item.GetId()))
            {
                stacks[item.GetId()].RemoveItem(item);

                if (stacks[item.GetId()].IsEmpty())
                    RemoveStack(item.GetId());
            }
        }
    }

    private void RemoveStack(int id)
    {
        stacks.Remove(id);
    }
    
}
