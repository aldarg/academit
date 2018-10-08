using Academits.DargeevAleksandr;
using NUnit.Framework;

namespace VectorTest
{
    [TestFixture]
    public class VectorTest
    {
        private const double Epsilon = 1.0e-10;

        // тестируем скалярное произведение
        [Test]
        public void SameDimensionsVectorsMultiply()
        {
            var vector1 = new Vector(new double[] { 1, 2, 3, 4 });
            var vector2 = new Vector(new double[] { 2, 3, 4, 5 });

            Assert.That(Vector.GetScalarProduct(vector1, vector2), Is.InRange(40 - Epsilon, 40 + Epsilon));
        }

        [Test]
        public void VariousDimensionsVectorsMultiply()
        {
            var vector1 = new Vector(new double[] { 1, 2, 3, 4 });
            var vector2 = new Vector(new double[] { 2, 3 });

            Assert.That(Vector.GetScalarProduct(vector1, vector2), Is.InRange(8 - Epsilon, 8 + Epsilon));
        }

        // тестируем Equals
        [Test]
        public void TrueEquals()
        {
            var vector1 = new Vector(new double[] { 1, 2, 3, 4 });
            var vector2 = new Vector(new double[] { 1, 2, 3, 4 });

            Assert.That(vector1, Is.EqualTo(vector2));
        }

        [Test]
        public void FalseEquals()
        {
            var vector1 = new Vector(new double[] { 1, 2, 3, 4 });
            var vector2 = new Vector(new double[] { 1, 2 });

            Assert.That(vector1, Is.Not.EqualTo(vector2));
        }

        // тестируем нестатическое сложение

        [Test]
        public void SimpleAdd()
        {
            var vector1 = new Vector(new double[] { 1, 2, 3, 4 });
            var vector2 = new Vector(new double[] { 2, 3, 4, 5 });

            vector1.Add(vector2);

            var expected = new Vector(new double[] { 3, 5, 7, 9 });

            Assert.That(vector1, Is.EqualTo(expected));
        }

        [Test]
        public void LessDimensionsVectorsAdd()
        {
            var vector1 = new Vector(new double[] { 1, 2, 3, 4 });
            var vector2 = new Vector(new double[] { 2, 3 });

            vector1.Add(vector2);

            var expected = new Vector(new double[] { 3, 5, 3, 4 });

            Assert.That(vector1, Is.EqualTo(expected));
        }

        [Test]
        public void MoreDimensionsVectorsAdd()
        {
            var vector1 = new Vector(new double[] { 1, 2 });
            var vector2 = new Vector(new double[] { 2, 3, 3, 4 });

            vector1.Add(vector2);

            var expected = new Vector(new double[] { 3, 5, 3, 4 });

            Assert.That(vector1, Is.EqualTo(expected));
        }
    }
}
