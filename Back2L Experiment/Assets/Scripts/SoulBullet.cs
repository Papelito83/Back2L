using System;

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

