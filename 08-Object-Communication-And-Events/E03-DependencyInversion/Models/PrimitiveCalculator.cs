using E03_DependencyInversion.Interfaces;
using E03_DependencyInversion.Models;

namespace E03_DependencyInversion
{
    class PrimitiveCalculator
    {
        private IStrategy strategy;

        public PrimitiveCalculator()
        {
            this.strategy = new AdditionStrategy();
        }

        public void ChangeStrategy(char @operator)
        {
            switch (@operator)
            {
                case '+': this.strategy = new AdditionStrategy(); break;
                case '-': this.strategy = new SubtractionStrategy(); break;
                case '*': this.strategy = new MultiplyStrategy(); break;
                case '/': this.strategy = new DivideStrategy(); break;
            }
        }

        public int PerformCalculation(int firstOperand, int secondOperand)
        {
            return this.strategy.Calculate(firstOperand, secondOperand);
        }
    }
}
