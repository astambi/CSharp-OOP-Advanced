using E03_DependencyInversion.Interfaces;

namespace E03_DependencyInversion.Models
{
    class SubtractionStrategy : IStrategy
    {
        public int Calculate(int firstOperand, int secondOperand)
        {
            return firstOperand - secondOperand;
        }
    }
}
