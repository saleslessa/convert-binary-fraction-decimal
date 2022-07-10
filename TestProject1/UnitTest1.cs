using System;
using NUnit.Framework;

namespace TestProject1
{
    [TestFixture]
    public class UnitTest1
    {
        [Test]
        public void TestMethod1()
        {
            var decimalValue = 0.1156f;
            var bytes = BitConverter.GetBytes(decimalValue);
            //if (BitConverter.IsLittleEndian) Array.Reverse(bytes);

            var converted = BitConverter.ToSingle(bytes, 0);
            Assert.AreEqual(decimalValue, converted);
        }

        [Test]
        public void TestMethod2()
        {
            var b = "0000000000000000.0001110110110110";
            var decimalValue = 0.116058349609375;

            var converted = BinaryToDecimal(b);

            Assert.AreEqual(decimalValue, converted);

        }

        private static double BinaryToDecimal(string binary)
        {
            var len = binary.Length;
            // Fetch the radix point
            int point = binary.IndexOf('.');

            // Update point if not found
            if (point == -1)
                point = len;

            double intDecimal = 0,
                fracDecimal = 0,
                twos = 1;

            // Convert integral part of binary to decimal
            // equivalent
            for (int i = point - 1; i >= 0; i--)
            {
                intDecimal += (binary[i] - '0') * twos;
                twos *= 2;
            }

            // Convert fractional part of binary to
            // decimal equivalent
            twos = 2;
            for (int i = point + 1; i < len; i++)
            {
                fracDecimal += (binary[i] - '0') / twos;
                twos *= 2.0;
            }

            // Add both integral and fractional part
            return intDecimal + fracDecimal;
        }

    }
}