using System;
using Xunit;
using CustomStackProject;

namespace TestCustomStackProj
{
    public class UnitTestCustomStack
    {
        private CustomStack<int> stack;

        [Theory]
        [InlineData(1, 8, 10, 2)]
        [InlineData(-5, 4, 1, 2)]
        [InlineData(6, 0, 9, 2)]
        public void TestPut_shouldWork(int num1, int num2, int num3, int size)
        {
            stack = new CustomStack<int>(size);

            stack.Put(num1);
            stack.Put(num2);
            stack.Put(num3);

            Assert.DoesNotContain(num1, stack);
            Assert.Equal(size, stack.Count);
        }

        [Theory]
        [InlineData(1)]
        [InlineData(2)]
        [InlineData(3)]
        public void TestPeek_shouldWork(int num1)
        {
            stack = new CustomStack<int>(3);
            stack.Put(num1);

            int expected = num1;

            Assert.Equal(expected, stack.Peek());
        }

        [Fact]
        public void TestPeek_shouldWorkException()
        {
            stack = new CustomStack<int>(2);
            Action act = () => stack.Peek();
            Assert.Throws<NullReferenceException>(act);
        }

        [Fact]
        public void TestTake_shouldWorkException()
        {
            stack = new CustomStack<int>(1);
            Action action = () => stack.Take();
            Assert.Throws<NullReferenceException>(action);
        }

        [Theory]
        [InlineData(1, 8, 10)]
        [InlineData(-5, 4, 4)]
        [InlineData(6, 0, 0)]
        public void TestTake_shouldWork(int num1, int num2, int num3)
        {
            stack = new CustomStack<int>(3);
            stack.Put(num1);
            stack.Put(num2);
            stack.Put(num3);

            int expected = num3;
            int countExpected = 2;
            
            Assert.Equal(expected, stack.Take());
            Assert.Equal(countExpected, stack.Count);
        }
    }
}
