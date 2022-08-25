using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace proyecto
{
    class Program
    {
        static void Main(string[] args)
        {
            Terminal ter = new Terminal();
            var Opcion = 0;
            
            do
            {
                ter.mostrarEpresa();
                Console.WriteLine("------------ Bienvenido -------------");
                Console.Write("1 - Ingresar venta\n" +
                    "2 - Mostrar Asientos\n" +
                    "3 - Confirmar reserva\n" +
                    "4 - Nuevo bus\n" +
                    "5 - Datos Empresa\n" +
                    "6 - Buscar Reserva\n" +
                    "7 - Cancelar Reserva\n" +
                    "0 - Salir\n\n");
                Opcion = int.Parse(Console.ReadLine());

                switch (Opcion)
                {
                    case 1:
                        ter.realizarVenta();
                        break;
                    case 2:
                        ter.mostrarBus();
                        break;
                    case 3:
                        ter.confirmarReserva();
                        break;
                    case 4:
                        ter.nuevoBus();
                        break;
                    case 5:
                        ter.ingresarEmpresa();
                        break;
                    case 6:
                        ter.buscarReserva();
                        break;
                    case 7:
                        ter.cancelar();
                        break;
                }
            } while (Opcion != 0);
        }
    }
}
