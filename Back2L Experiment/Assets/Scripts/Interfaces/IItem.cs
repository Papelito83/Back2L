using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IItem
{
    int GetId();
    bool Stackable();
    int GetStackLimit();
}
