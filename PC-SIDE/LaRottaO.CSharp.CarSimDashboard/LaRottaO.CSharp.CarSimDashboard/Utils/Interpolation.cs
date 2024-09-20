using LRottaO.CSharp.SimDashboardCtrl;

namespace LaRottaO.CSharp.CarSimDashboard
{
    internal static class Interpolation
    {
        public static double interpolate(double valToFind, ValuePair[] pairs)
        {
            (ValuePair valuePairLower, ValuePair valuePairHigher) = BinarySearch.GetBoundingKeyPairs(valToFind, pairs);

            double x0 = valuePairLower.Key;
            double y0 = valuePairLower.Value;

            double x1 = valuePairHigher.Key;
            double y1 = valuePairHigher.Value;

            double ye = y0 + ((y1 - y0) * ((valToFind - x0) / (x1 - x0)));

            return ye;
        }
    }
}