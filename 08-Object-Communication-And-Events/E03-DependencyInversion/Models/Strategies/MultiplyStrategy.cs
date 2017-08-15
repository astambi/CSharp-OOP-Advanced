using E03_DependencyInversion.Interfaces;

namespace E03_DependencyInversion.Models
{
    public class MultiplyStrategy : IStrategy
    {
        public int Calculate(int firstOperand, int secondOperand)
        {
            return firstOperand * secondOperand;
        }
    }
}
