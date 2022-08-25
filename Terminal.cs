using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace proyecto
{
    class Terminal
    {
        public Empresa emp { get; set; }
        public Buses[] buses { get; set; }

        public Terminal()
        {
            this.buses = new Buses[5];
            this.emp = new Empresa();
        }    
        
        public void ingresarEmpresa()
        {            
            Console.WriteLine("------------------- Ingresar Datos de la Empresa -------------------");
            Console.Write("NIT de la empresa: ");
            emp.Nit = Console.ReadLine();
            Console.Write("Nombre de la empresa: ");
            emp.NombreEmp = Console.ReadLine();
            Console.Write("Direccion de la empresa: ");
            emp.DireccionEmp = Console.ReadLine();
            Console.Write("Telefono de la empresa: ");
            emp.TelefonoEmp = Console.ReadLine();
            Console.WriteLine("--------------------------------------------------------------------\n");
            Console.Clear();
        }
        public void mostrarEpresa()
        {
            var datosEmp = "Empresa:" + emp.NombreEmp + " - NIT:" + emp.Nit + " - Direccion:" + emp.DireccionEmp + " - Tel:" + emp.TelefonoEmp;           
            Console.WriteLine(datosEmp);            
        }

        public void realizarVenta()
        {
            for (int i = 0; i < buses.Length; i++)
            {
                if (buses[i] != null)
                    Console.WriteLine((i + 1) + ". " + buses[i].placa);
            }

            Console.Write("Seleccione el bus: ");
            var posBus = int.Parse(Console.ReadLine()) - 1;

            Boolean aux = false;
            int cont = 1;

            mostrarBus();

            Console.Write("Digite el numero del asiento: ");
            int numAsiento = int.Parse(Console.ReadLine());

            for (int i = 0; i < buses[posBus].distribucion.GetLength(0); i++)
            {
                for (int j = 0; j < buses[posBus].distribucion.GetLength(1); j++, cont++)
                {
                    if (numAsiento == cont && validarAsiento(numAsiento, posBus))
                    {
                        ingresarCliente(i, j, posBus);
                        aux = true;
                    }
                    else if (validarAsiento(numAsiento, posBus) == false)
                    {
                        Console.WriteLine("Este asiento ya esta ocupado\n");
                        aux = true;
                    }

                    if (aux)
                        break;
                }
                if (aux)
                    break;
            }

        }
        public void ingresarCliente(int x, int y, int posBus)
        {
            var asiento = new Cliente();
            Console.WriteLine();
            Console.Write("Cedula cliente: ");
            asiento.Cedula = Console.ReadLine();
            Console.Write("Nombre cliente: ");
            asiento.Nombre = Console.ReadLine();
            Console.Write("fecha de compra: ");
            asiento.fechaCompra = DateTime.Parse(Console.ReadLine());
            asiento.confirmacion = 0;

            buses[posBus].distribucion[x,y] = asiento;
            Console.WriteLine("--------------venta exitosa--------------\n");
        }
              
        public Boolean validarAsiento(int numAsiento, int posBus)
        {
            Boolean aux = false;
            int cont = 1;
            
            for (int i = 0; i < buses[posBus].distribucion.GetLength(0); i++)
            {
                for (int j = 0; j < buses[posBus].distribucion.GetLength(1); j++, cont++)
                {
                    if (numAsiento == cont && buses[posBus].distribucion[i,j] == null) {
                        aux = true;                         
                    }
                    
                    if (aux)
                        break;
                }
                if (aux)
                    break;
            }
            return aux;
        }
            
        public void confirmarReserva()
        {
            Console.WriteLine("---------------- Modulo de Confirmacion --------------------");
            Boolean aux = false;
            
            Console.Write("Digite el numero de cedula: ");
            string cedBuscar = Console.ReadLine();

            Console.WriteLine("---------------- Informacion del Cliente -------------------");
            for (int i = 0; i < buses.Length; i++)
            {
                for (int j = 0; j < buses[i].distribucion.GetLength(0); j++)
                {
                    for (int k = 0; k < buses[i].distribucion.GetLength(1); k++)
                    {
                        if (buses[i].distribucion[j,k] != null && buses[i].distribucion[j, k].Cedula == cedBuscar)
                        {
                            Console.WriteLine("Cedula: " + buses[i].distribucion[j, k].Cedula);
                            Console.WriteLine("Nombre: " + buses[i].distribucion[j, k].Nombre);
                            Console.WriteLine("Fecha de Compra: " + buses[i].distribucion[j, k].fechaCompra);
                            Console.WriteLine("Bus: " + buses[i].placa);
                            Console.WriteLine("N° Asiento: " + ((k + 1) + buses[i].distribucion.GetLength(1) * j));

                            Console.Write("\nDesea confirmar la reserva (s/n): ");
                            var resp = Console.ReadLine();

                            if (resp == "s") {
                                buses[i].distribucion[j, k].confirmacion = 1;
                                Console.WriteLine("Confirma realizada");
                            }
                            else if (resp == "n")
                                Console.WriteLine("Recuerde la confirmacion nos permite brindarle un mejor servicio.");

                            aux = true;
                        }
                        if (aux)
                            break;
                    }
                    if (aux)
                        break;
                }
                if (aux)
                    break;
            }
            if (aux == false) 
                Console.WriteLine("No se encontro ninguna reserva para el documento: " + cedBuscar);
            
            Console.WriteLine("------------------------------------------------------------\n");
        }
        public void buscarReserva()
        {
            Console.WriteLine("---------------- Modulo de Busqueda --------------------");
            Boolean aux = false;

            Console.Write("Digite el numero de cedula: ");
            string cedBuscar = Console.ReadLine();

            Console.WriteLine("---------------- Informacion del Cliente -------------------");
            for (int i = 0; i < buses.Length; i++)
            {
                for (int j = 0; j < buses[i].distribucion.GetLength(0); j++)
                {
                    for (int k = 0; k < buses[i].distribucion.GetLength(1); k++)
                    {
                        if (buses[i].distribucion[j, k] != null && buses[i].distribucion[j, k].Cedula == cedBuscar)
                        {
                            Console.WriteLine("Cedula: " + buses[i].distribucion[j, k].Cedula);
                            Console.WriteLine("Nombre: " + buses[i].distribucion[j, k].Nombre);
                            Console.WriteLine("Fecha de Compra: " + buses[i].distribucion[j, k].fechaCompra);
                            Console.WriteLine("Bus: " + buses[i].placa);
                            Console.WriteLine("N° Asiento: " + ((k + 1) + buses[i].distribucion.GetLength(1) * j));

                            aux = true;
                        }
                        if (aux)
                            break;
                    }
                    if (aux)
                        break;
                }
                if (aux)
                    break;
            }
            if (aux == false)
                Console.WriteLine("No se encontro ninguna reserva para el documento: " + cedBuscar);

            Console.WriteLine("------------------------------------------------------------\n");
        }
        public void cancelar()
        {
            Console.WriteLine("---------------- Modulo de Cancelacion --------------------");
            Boolean aux = false;
            Console.Write("Digite el numero de cedula: ");
            string cedBuscar = Console.ReadLine();

            Console.WriteLine("---------------- Informacion del Cliente -------------------");
            for (int i = 0; i < buses.Length; i++)
            {
                for (int j = 0; j < buses[i].distribucion.GetLength(0); j++)
                {
                    for (int k = 0; k < buses[i].distribucion.GetLength(1); k++)
                    {
                        if (buses[i].distribucion[j, k] != null && buses[i].distribucion[j, k].Cedula == cedBuscar)
                        {
                            Console.WriteLine("Cedula: " + buses[i].distribucion[j, k].Cedula);
                            Console.WriteLine("Nombre: " + buses[i].distribucion[j, k].Nombre);
                            Console.WriteLine("Fecha de Compra: " + buses[i].distribucion[j, k].fechaCompra);
                            Console.WriteLine("Bus: " + buses[i].placa);
                            Console.WriteLine("N° Asiento: " + ((k + 1) + buses[i].distribucion.GetLength(1) * j));

                            Console.Write("\nDesea cancelar la reserva (s/n): ");
                            var resp = Console.ReadLine();

                            if (resp == "s")
                            {
                                buses[i].distribucion[j, k] = null;
                                Console.WriteLine("Cancelacion Exitosa");
                            }
                            else if (resp == "n")
                                Console.WriteLine("Recuerde la confirmacion nos permite brindarle un mejor servicio.");

                            aux = true;
                        }
                        if (aux)
                            break;
                    }
                    if (aux)
                        break;
                }
                if (aux)
                    break;
            }
            if (aux == false)
                Console.WriteLine("No se encontro ninguna reserva para el documento: " + cedBuscar);

            Console.WriteLine("------------------------------------------------------------\n");
        }
    
        public void nuevoBus()
        {
            Console.WriteLine("--------------------- Agregar bus ------------------------");

            Buses micro = new Buses();
            
            Console.Write("placa: ");
            micro.placa = Console.ReadLine();

            Console.Write("numero columnas: ");
            int col = int.Parse(Console.ReadLine());
            Console.Write("numero filas: ");
            int fila = int.Parse(Console.ReadLine());
            
            micro.distribucion = new Cliente [fila,col];
            Boolean aux = true;
            
            if (buses[0] == null)
            {
                buses[0] = micro;
                aux = false;
            }
            
            while (aux) {      
                for (int i = 0; i < buses.Length; i++)
                {
                    if (buses[i] == null) 
                    {
                        buses[i] = micro;
                        aux = false;
                    }
                    if (aux == false)
                        break;
                }
            }
            Console.WriteLine("----------------------------------------------------------\n");
        }
        public void mostrarBus()
        {
            Console.WriteLine("--------------------- Lista de Buses ------------------------");
            for (int i = 0; i < buses.Length; i++)
            {
                if (buses[i] != null)
                    Console.WriteLine((i + 1) + ". " + buses[i].placa);
            }

            Console.Write("Seleccione el bus: ");
            var posBus = int.Parse(Console.ReadLine()) - 1;

            var pasillo = buses[posBus].distribucion.GetLength(1) / 2;

            Console.WriteLine("\tPuestos Reservados (X)\tPuestos con Confirmacion (C)\n");
            for (int i = 0; i < buses[posBus].distribucion.GetLength(0); i++)
            {
                for (int j = 0; j < buses[posBus].distribucion.GetLength(1); j++)
                {
                    if (j == pasillo)
                        Console.Write("\t");
                    
                    if (buses[posBus].distribucion[i, j] != null) {
                        
                        if (buses[posBus].distribucion[i, j].confirmacion == 0)
                            Console.Write("X \t");
                        else if (buses[posBus].distribucion[i, j].confirmacion == 1)
                            Console.Write("C \t");
                        //else if (buses[posBus].distribucion[i, j].confirmacion == 2)
                        //    Console.Write("/ \t");
                    }
                    else
                        Console.Write(((j +1) + buses[posBus].distribucion.GetLength(1) * i) + " \t");

                    //if (i == 0)
                    //    Console.Write("/ \t");
                    //else if (i == (buses[posBus].distribucion.GetLength(0) - 1) && j == (buses[posBus].distribucion.GetLength(1) - 1))
                    //    Console.Write("/ \t");
                    //else if (i == (buses[posBus].distribucion.GetLength(0) - 1) && j == 0)
                    //    Console.Write("/ \t");
                    //else
                    //    Console.Write(((j - (buses[posBus].distribucion.GetLength(1)-1)) + buses[posBus].distribucion.GetLength(1) * i) + " \t");
                }
                Console.WriteLine("\n");
            }
            Console.WriteLine("--------------------------------------------");
        }

        public void agregarConductor()
        {

        }
    }
}
