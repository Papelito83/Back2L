using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class SoulBullet : IItem, IProjectile
{
    public int GetId()
    {
        return 1;
    }

    public bool Stackable()
    {
        return true;
    }

    public int GetStackLimit()
    {
        return 6;
    }

    public void OnUse()
    {
        throw new NotImplementedException();
    }

    public void OnHit()
    {
        throw new NotImplementedException();
    }

    public void OnDrop()
    {
        throw new NotImplementedException();
    }
}

