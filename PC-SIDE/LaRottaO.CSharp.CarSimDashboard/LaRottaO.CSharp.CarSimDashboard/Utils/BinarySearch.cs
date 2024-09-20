namespace LRottaO.CSharp.SimDashboardCtrl
{
    public static class BinarySearch
    {
        public static (ValuePair lower, ValuePair higher) GetBoundingKeyPairs(double input, ValuePair[] RpmPairs)
        {
            int left = 0;
            int right = RpmPairs.Length - 1;

            while (left <= right)
            {
                int mid = (left + right) / 2;
                if (RpmPairs[mid].Key.Equals(input))
                {
                    // Exact match found, both lower and higher are the same
                    return (RpmPairs[mid], RpmPairs[mid]);
                }
                else if (RpmPairs[mid].Key < input)
                {
                    left = mid + 1;
                }
                else
                {
                    right = mid - 1;
                }
            }

            // If no exact match, return the closest lower and higher pairs
            ValuePair lower = (right >= 0) ? RpmPairs[right] : RpmPairs[0];
            ValuePair higher = (left < RpmPairs.Length) ? RpmPairs[left] : RpmPairs[RpmPairs.Length - 1];

            return (lower, higher);
        }
    }
}