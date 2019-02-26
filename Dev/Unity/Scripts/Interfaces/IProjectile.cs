using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


public interface IProjectile
{
    void OnUse();
    void OnHit();
    void OnDrop();
}

