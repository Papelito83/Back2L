using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Shiva.Stats;

public class DefenseBuffEffect : IBuffEffect
{
    private readonly float defenseBuff;

    public DefenseBuffEffect(int defenseBuff)
    {
        this.defenseBuff = defenseBuff;
    }

    public void ExecuteEffect(IMutableStat stat)
    {
        var modifier = new StatModifier(defenseBuff, this);

        if (!stat.IsModified)
        {
            stat.AddModifier(modifier);
        }
        else
        {
            stat.RemoveAllModifierFromSource(this);
            stat.AddModifier(modifier);
        }
    }
}

