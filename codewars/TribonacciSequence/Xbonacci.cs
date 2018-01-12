namespace CodeWars.TribonacciSequence
{
    public class Xbonacci
    {
        private double[] _tribonacciArray;

        public double[] Tribonacci(double[] signature, int n)
        {
            _tribonacciArray = new double[1];
            // hackonacci me
            // if n==0, then return an array of length 1, containing only a 0
            if (n == 0)
                return new[] { CalculateNthTribonacci(signature, n) };
            for (var i = 0; i < n; i++)
            {
                if (_tribonacciArray.Length < i + 1)
                {
                    var newTribonacciArray = new double[_tribonacciArray.Length + 1];
                    _tribonacciArray.CopyTo(newTribonacciArray, 0);
                    _tribonacciArray = newTribonacciArray;
                }

                _tribonacciArray[i] = CalculateNthTribonacci(signature, i + 1);
            }
            return _tribonacciArray;
        }

        private double CalculateNthTribonacci(double[] signature, int n)
        {
            if (n == 0)
                return 0;
            if (n <= 3)
                return signature[n - 1];
            var t1 = CalculateNthTribonacci(n - 3) ?? CalculateNthTribonacci(signature, n - 3);
            var t2 = CalculateNthTribonacci(n - 2) ?? CalculateNthTribonacci(signature, n - 2);
            var t3 = CalculateNthTribonacci(n - 1) ?? CalculateNthTribonacci(signature, n - 1);
            return t1 + t2 + t3;
        }

        private double? CalculateNthTribonacci(int n)
        {
            return n < _tribonacciArray.Length ? (double?)_tribonacciArray[n - 1] : null;
        }
    }
}
