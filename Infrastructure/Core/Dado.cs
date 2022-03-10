
namespace Infrastructure.Core
{
    public class Dado
    {
        public static int Lanzar()
        {
            return new Random().Next(1, 6);
        }
    }
}
