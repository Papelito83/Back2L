using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

[CreateAssetMenu(fileName = "Default Item", menuName = "Items/Item")]
public class Item : ScriptableObject
{
    public string itemName;
    public Sprite itemSprite;
}
  
