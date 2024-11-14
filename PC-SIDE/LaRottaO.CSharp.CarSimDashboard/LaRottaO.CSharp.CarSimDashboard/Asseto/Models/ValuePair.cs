namespace LRottaO.CSharp.SimDashboardCtrl
{
    public class ValuePair
    {
        public int Key { get; }
        public double Value { get; }

        public ValuePair(int key, double value)
        {
            Key = key;
            Value = value;
        }
    }
}