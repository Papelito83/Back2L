namespace Shiva.Stats
{ 
    public class StatModifier
    {
        public readonly float Value;
        public readonly object Source;

        public StatModifier(float value, object source)
        {
            Value = value;
            Source = source;
        }

        public float ModifyStatValue(float statValue)
        {
            return FlatModify(statValue);
        }

        private float FlatModify(float statValue)
        {
            statValue += Value;
            return statValue;
        }
    }
}
