

using Microsoft.Extensions.DependencyInjection;

namespace Services.IServices
{
    [ServiceLifetime(ServiceLifetime.Scoped)]
    public interface ICalculatorService
    {
        int Sumar(int a, int b);
        int Restar(int a, int b);
        int Multiplicar(int a, int b);
        double Dividir(int a, int b);
    }
}
