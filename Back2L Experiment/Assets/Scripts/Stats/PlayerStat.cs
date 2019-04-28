using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shiva.Stats
{
    [Serializable]
    public class PlayerStat
    {
        private float baseValue;        
        private float value;
        private bool isDirty;

        private float lastBaseValue = float.MinValue;

        public bool IsModified { get { return Value > baseValue;  } }

        public float Value
        {
            get
            {
                if (isDirty || lastBaseValue != baseValue)
                {
                    lastBaseValue = baseValue;
                    isDirty = false;
                    value = CalculateFinalValue();

                }
                return value;
            }
        }

        private readonly List<StatModifier> statModifiers;
        private readonly ReadOnlyCollection<StatModifier> StatModifiers;

        public PlayerStat()
        {
            statModifiers = new List<StatModifier>();
            StatModifiers = statModifiers.AsReadOnly();
        }

        public PlayerStat(float statValue) : this()
        {
            baseValue = statValue;
        }

        public void AddModifier(StatModifier modifier)
        {
            isDirty = true;
            statModifiers.Add(modifier);
        }

        public bool RemoveModifier(StatModifier modifier)
        {
            if(statModifiers.Remove(modifier))
            {
                isDirty = true;
                return true;
            }
            return false;
        }

        public bool RemoveAllModifierFromSource(object source)
        {
            bool didRemove = false;

            for (int i = statModifiers.Count - 1; i >= 0; i--)
            {
                if (StatModifiers[i].Source == source)
                {
                    isDirty = true;
                    didRemove = true;
                    statModifiers.RemoveAt(i);
                }
            }
            return didRemove;
        }

        private float CalculateFinalValue()
        {
            float finalValue = baseValue;

            for(int i=0;i<statModifiers.Count; i++)
            {
                finalValue = StatModifiers[i].ModifyStatValue(finalValue);
            }

            return (int)Math.Round(finalValue, 4);
        }
    }
}
