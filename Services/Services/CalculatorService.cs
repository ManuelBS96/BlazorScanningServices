
using Services.IServices;

namespace Services.Services
{
    public class CalculatorService : ICalculatorService
    {
        public double Dividir(int a, int b)
        {
            return a / b;
        }

        public int Multiplicar(int a, int b)
        {
            return a * b;
        }

        public int Restar(int a, int b)
        {
            return a - b;
        }

        public int Sumar(int a, int b)
        {
            return a + b;
        }
    }
}
