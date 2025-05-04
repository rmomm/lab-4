using NUnit.Framework;

namespace MatrixSumTests
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void SumOf_3x3_Matrix()
        {
            int[,] matrix = {
                { 1, 2, 3 },
                { 4, 5, 6 },
                { 7, 8, 9 }
            };

            var sum = new MatrixSum(matrix);
            int total = sum.ComputeTotalSum();

            Assert.That(total, Is.EqualTo(45));
        }

        [Test]
        public void SumOf_EmptyMatrix()
        {
            int[,] matrix = new int[0, 0];

            var sum = new MatrixSum(matrix);
            int total = sum.ComputeTotalSum();

            Assert.That(total, Is.EqualTo(0));
        }

        [Test]
        public void SumOf_OneElementMatrix()
        {
            int[,] matrix = { { 42 } };

            var sum = new MatrixSum(matrix);
            int total = sum.ComputeTotalSum();

            Assert.That(total, Is.EqualTo(42));
        }

        [Test]
        public void SumOf_NegativeElementsMatrix()
        {
            int[,] matrix = {
                { -1, -2 },
                { -3, -4 }
            };

            var sum = new MatrixSum(matrix);
            int total = sum.ComputeTotalSum();

            Assert.That(total, Is.EqualTo(-10));
        }

        [Test]
        public void SumOf_MatrixWithZeros()
        {
            int[,] matrix = {
                { 0, 0 },
                { 0, 0 }
            };

            var sum = new MatrixSum(matrix);
            int total = sum.ComputeTotalSum();

            Assert.That(total, Is.EqualTo(0));
        }
    }
}