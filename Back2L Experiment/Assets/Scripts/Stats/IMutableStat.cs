using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shiva.Stats
{
    public interface IMutableStat : IStat
    {
        bool IsModified { get; }
        void AddModifier(StatModifier modifier);
        bool RemoveModifier(StatModifier modifier);
        bool RemoveAllModifierFromSource(object source);
    }
}
