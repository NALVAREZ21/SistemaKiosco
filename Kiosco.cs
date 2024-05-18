using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sistema_Kiosco
{
    class Program
    {
        public static void cargar_arreglos_y_imprimir()
        {
            string[] productos = { "Azucar", "Yerba", "harina", "Cafe", "Aceite" };
            int[] cantidad = new int[5] { 6, 9, 8, 7, 11 };
            double[] precio = { 450.44, 500.23, 300.64, 370.32, 600.12 };

            for (int i = 0; i < productos.Length; i++)
            {
                for (i = 0; i < cantidad.Length; i++)
                {
                    for (i = 0; i < precio.Length; i++)
                    {
                        //Console.WriteLine($"En la posicion {i} se encuentra el producto {productos[i]} con {cantidad[i]} productos con un precio unitario de $ {precio[i]}");
                        Console.WriteLine($"Tenemos {cantidad[i]} {productos[i]} por un precio unitario de ${precio[i]}\n");
                    }
                }
            }
        }
        public static void forma_pago(ref double cantidad_final, ref double acumulacion_harina, ref double acumulacion_yerba,ref double acumulacion_azucar,double acumulacion_aceite,double acumulacion_cafe)
        {
            int op;
            double descuento = 0, compra_minima =1000;
            
            if (cantidad_final > compra_minima)
            {
                Console.WriteLine("--------------");
                Console.Write("Digite su forma de pago (1- Efectivo || 2- Tarjeta de credito || 3 -  Debito): ");
                op = Int32.Parse(Console.ReadLine());

                switch (op)
                {
                    case 1:
                        {
                            descuento = cantidad_final * 0.10; // HACE 10% DE DESCUENTO
                            double cantidad_descuento10 = cantidad_final - descuento;
                            Console.WriteLine($"Si abona en efectivo debe abonar ${cantidad_descuento10} de ${cantidad_final}");
                            break;
                        }
                    case 2:
                        {
                            double IVA = cantidad_final * 0.21;
                            double precio_con_IVA = cantidad_final + IVA; // EL PRECIO FINAL SE LE APLICA IVA
                            Console.WriteLine($"Si abona con tarjeta debe abonar ${precio_con_IVA} de ${cantidad_final} aplicandole IVA");
                            break;
                        }
                    case 3:
                        {
                            descuento = cantidad_final * 0.12; // HACE 12% DESCUENTO
                            double cantidad_descuento12 = cantidad_final - descuento;
                            Console.WriteLine($"Si abona con debito debe abonar ${cantidad_descuento12} de ${cantidad_final}");
                            break;
                        }
                }
            }
            else
            {
                cantidad_final = acumulacion_azucar + acumulacion_harina + acumulacion_yerba + acumulacion_cafe + acumulacion_aceite;
                Console.WriteLine($"Usted debe abonar ${cantidad_final} y no se aplico descuento ya que no alcanzo a la compra minima de ${compra_minima}");
                Console.WriteLine("---------");
                Console.WriteLine("Gracias por su visita, lo esperamos nuevamente");
            }
        }
        static void Main(string[] args)
        {
            string[] productos = { "Azucar", "Yerba", "harina", "Cafe", "Aceite" };
            int[] cantidad = new int[5] { 6, 9, 8, 7, 11 };
            double[] precio = { 450.44, 500.23, 300.64, 370.32, 600.12 };
            double cantidad_final = 0, acumulacion_harina = 0, acumulacion_yerba = 0, acumulacion_azucar = 0, acumulacion_aceite = 0, acumulacion_cafe=0;
            cargar_arreglos_y_imprimir();
            int opc = 0, opcion = 0, op = 0;
            double cantidad_parcial_azucar = 0, cantidad_parcial_yerba = 0, cantidad_parcial_harina = 0, cantidad_parcial_cafe = 0, cantidad_parcial_aceite = 0;
            double cantidad_descuento10 = 0, cantidad_descuento12 = 0, descuento;

            Console.Write("Desea visitar nuestra tienda (0 - N0 || 1 - Si): ");
            opcion = Int32.Parse(Console.ReadLine());
            while (opcion != 0)
            {
                while (opcion < 0 || opcion > 1)
                {
                    Console.Write("Reingrese una opcion valida (0 - N0 || 1 - Si): ");
                    opcion = Int32.Parse(Console.ReadLine());
                }
                Console.WriteLine("---BIENVENIDO AL KIOSCO FALOPITA---");
                Console.Write("Digite una opcion para comprar: 1 - Azucar || 2 - Yerba || 3 - Harina || 4 - Cafe || 5 - Aceite: ");
                opc = Int32.Parse(Console.ReadLine());
                switch (opc)
                {
                    case 1:
                        {
                            Console.Write("¿Cuanto paquetes de azucar desea llevar?: ");
                            int llevar = Int32.Parse(Console.ReadLine());
                            if (llevar > cantidad[0])
                            {
                                cantidad_parcial_azucar = cantidad[0];

                                Console.WriteLine($"Por el momento tenemos {cantidad_parcial_azucar} en stock");
                                Console.Write("¿Desea comprar a pesar que no tengamos la cantidad que necesita? (1-si || 2-no): ");
                                int respuesta = Int32.Parse(Console.ReadLine());

                                if (respuesta == 1)
                                {
                                    Console.Write("¿Cuantos paquetes desea llevar?: ");
                                    int cantidad_llevara = Int32.Parse(Console.ReadLine());
                                    cantidad_parcial_azucar = cantidad[0] - cantidad_llevara;
                                    Console.WriteLine($"Quedan {cantidad_parcial_azucar} paquetes de azucar en stock");

                                    for (int i = 0; i < precio.Length; i++)
                                    {
                                        acumulacion_azucar = cantidad_llevara * precio[0];
                                    }
                                    Console.WriteLine($"Lleva gastando ${acumulacion_azucar} en {cantidad_llevara} paquete/s de azucar por el momento");
                                }
                                else
                                {
                                    Console.WriteLine("Disculpe las molestias ocasionadas");
                                }
                            }
                            else
                            {
                                for (int i = 0; i < cantidad.Length; i++)
                                {
                                    cantidad_parcial_azucar = cantidad[0] - llevar;
                                }
                                Console.WriteLine($"Quedan {cantidad_parcial_azucar} paquete/s de azucar en stock");
                                for (int i = 0; i < precio.Length; i++)
                                {
                                    acumulacion_azucar = llevar * precio[0];
                                }
                                Console.WriteLine($"Lleva gastando ${acumulacion_azucar} en {llevar} paquete/s de azucar por el momento");
                            }
                            break;
                        }
                    case 2:
                        {
                            Console.Write("¿Cuantos paquetes de Yerba desea llevar?: ");
                            int llevar = Int32.Parse(Console.ReadLine());

                            if (llevar > cantidad[1])
                            {
                                cantidad_parcial_yerba = cantidad[1];

                                Console.WriteLine($"Por el momento tenemos {cantidad_parcial_yerba} paquetes de yerba en stock");
                                Console.Write("¿Desea comprar a pesar que no tengamos la cantidad que necesita? (1-si || 2-no): ");
                                int respuesta = Int32.Parse(Console.ReadLine());

                                if (respuesta == 1)
                                {
                                    Console.Write("¿Cuantos paquetes de yerba desea llevar?: ");
                                    int cantidad_llevara = Int32.Parse(Console.ReadLine());
                                    cantidad_parcial_yerba = cantidad[1] - cantidad_llevara;
                                    Console.WriteLine($"Quedan {cantidad_parcial_yerba} paquetes de yerba en stock");

                                    for (int i = 0; i < precio.Length; i++)
                                    {
                                        acumulacion_yerba = cantidad_llevara * precio[1];
                                    }
                                    Console.WriteLine($"Lleva gastando ${acumulacion_yerba} en {cantidad_llevara} paquete/s de yerba por el momento");
                                }
                                else
                                {
                                    Console.WriteLine("Disculpe las molestias ocasionadas");
                                }
                            }
                            else
                            {
                                for (int i = 0; i < cantidad.Length; i++)
                                {
                                    cantidad_parcial_yerba = cantidad[1] - llevar;
                                }
                                Console.WriteLine($"Quedan {cantidad_parcial_yerba} paquetes de yerba en stock");
                                for (int i = 0; i < precio.Length; i++)
                                {
                                    acumulacion_yerba = llevar * precio[1];
                                }
                                Console.WriteLine($"Lleva gastando ${acumulacion_yerba} en {llevar} paquete/s de yerba por el momento");
                            }
                            break;
                        }
                    case 3:
                        {
                            Console.Write("¿Cuantos paquetes de harina desea llevar?: ");
                            int llevar = Int32.Parse(Console.ReadLine());

                            if (llevar > cantidad[2])
                            {
                                cantidad_parcial_harina = cantidad[2];

                                Console.WriteLine($"Por el momento tenemos {cantidad_parcial_harina} paquetes de harina en stock");
                                Console.Write("¿Desea comprar a pesar que no tengamos la cantidad que necesita? (1-si || 2-no): ");
                                int respuesta = Int32.Parse(Console.ReadLine());

                                if (respuesta == 1)
                                {
                                    Console.Write("¿Cuantos paquetes de harina desea llevar?: ");
                                    int cantidad_llevara = Int32.Parse(Console.ReadLine());
                                    cantidad_parcial_harina = cantidad[2] - cantidad_llevara;
                                    Console.WriteLine($"¿Quedan {cantidad_parcial_harina} en stock");

                                    for (int i = 0; i < precio.Length; i++)
                                    {
                                        acumulacion_harina = cantidad_llevara * precio[2];
                                    }
                                    Console.WriteLine($"Lleva gastando ${acumulacion_harina} en {cantidad_llevara} paquete/s de harina por el momento");
                                }
                                else
                                {
                                    Console.WriteLine("Disculpe las molestias ocasionadas");
                                }
                            }
                            else
                            {
                                for (int i = 0; i < cantidad.Length; i++)
                                {
                                    cantidad_parcial_harina = cantidad[2] - llevar;
                                }
                                Console.WriteLine($"Quedan {cantidad_parcial_harina} paquetes de harina en stock");
                                for (int i = 0; i < precio.Length; i++)
                                {
                                    acumulacion_harina = llevar * precio[2];
                                }
                                Console.WriteLine($"Lleva gastando ${acumulacion_harina} en {llevar} paquete/s de harina por el momento");
                            }
                            break;
                        }

                    case 4:
                        {
                            Console.Write("¿Cuantos frascos de cafe desea llevar?: ");
                            int llevar = Int32.Parse(Console.ReadLine());

                            if (llevar > cantidad[3])
                            {
                                cantidad_parcial_cafe = cantidad[3];

                                Console.WriteLine($"Por el momento tenemos {cantidad_parcial_cafe} frascos de cafe en stock");
                                Console.Write("¿Desea comprar a pesar que no tengamos la cantidad que necesita? (1-si || 2-no): ");
                                int respuesta = Int32.Parse(Console.ReadLine());

                                if (respuesta == 1)
                                {
                                    Console.Write("¿Cuantos frascos de cafe desea llevar?: ");
                                    int cantidad_llevara = Int32.Parse(Console.ReadLine());
                                    cantidad_parcial_cafe = cantidad[3] - cantidad_llevara;
                                    Console.WriteLine($"Quedan {cantidad_parcial_cafe} en stock");

                                    for (int i = 0; i < precio.Length; i++)
                                    {
                                        acumulacion_cafe = cantidad_llevara * precio[3];
                                    }
                                    Console.WriteLine($"Lleva gastando ${acumulacion_cafe} en {cantidad_llevara} frasco/s de cafe por el momento");
                                }
                                else
                                {
                                    Console.WriteLine("Disculpe las molestias ocasionadas");
                                }
                            }
                            else
                            {
                                for (int i = 0; i < cantidad.Length; i++)
                                {
                                    cantidad_parcial_cafe = cantidad[3] - llevar;
                                }
                                Console.WriteLine($"Quedan {cantidad_parcial_cafe} frasco/s de cafe en stock");
                                for (int i = 0; i < precio.Length; i++)
                                {
                                    acumulacion_cafe = llevar * precio[3];
                                }
                                Console.WriteLine($"Lleva gastando ${acumulacion_cafe} en {llevar} frasco/s de cafe por el momento");
                            }
                            break;
                        }
                    case 5:
                        {
                            Console.Write("¿Cuantas botellas de aceite desea llevar?: ");
                            int llevar = Int32.Parse(Console.ReadLine());

                            if (llevar > cantidad[4])
                            {
                                cantidad_parcial_aceite = cantidad[4];
                                Console.WriteLine($"Por el momento tenemos {cantidad_parcial_aceite} botellas de aceite en stock");
                                Console.Write("¿Desea comprar a pesar que no tengamos la cantidad que necesita? (1-si || 2-no): ");
                                int respuesta = Int32.Parse(Console.ReadLine());

                                if (respuesta == 1)
                                {
                                    Console.Write("¿Cuantas botellas de aceite desea llevar?: ");
                                    int cantidad_llevara = Int32.Parse(Console.ReadLine());
                                    cantidad_parcial_aceite = cantidad[4] - cantidad_llevara;
                                    Console.WriteLine($"Quedan {cantidad_parcial_aceite} en stock");

                                    for (int i = 0; i < precio.Length; i++)
                                    {
                                        acumulacion_aceite = cantidad_llevara * precio[4];
                                    }
                                    Console.WriteLine($"Lleva gastando ${acumulacion_aceite} en {cantidad_llevara} botella/s de aceite por el momento");
                                }
                                else
                                {
                                    Console.WriteLine("Disculpe las molestias ocasionadas");
                                }
                            }
                            else
                            {
                                for (int i = 0; i < cantidad.Length; i++)
                                {
                                    cantidad_parcial_aceite = cantidad[4] - llevar;
                                }
                                Console.WriteLine($"Quedan {cantidad_parcial_aceite} botellas de aceite en stock");
                                for (int i = 0; i < precio.Length; i++)
                                {
                                    acumulacion_aceite = llevar * precio[4];
                                }
                                Console.WriteLine($"Lleva gastando ${acumulacion_aceite} en {llevar} botella/s de aceite por el momento");
                            }
                            break;
                        }
                    default:
                        {
                            Console.WriteLine("El producto momentaneamente no lo tenemos");
                            break;
                        }
                }
                Console.Write("Desea seguir comprando en nuestra tienda (0 - N0 || 1 - Si): ");
                opcion = Int32.Parse(Console.ReadLine());
            }
            cantidad_final = acumulacion_azucar + acumulacion_harina + acumulacion_yerba + acumulacion_cafe + acumulacion_aceite;

            forma_pago(ref cantidad_final, ref acumulacion_harina, ref acumulacion_yerba, ref acumulacion_azucar, acumulacion_aceite,acumulacion_cafe);
        }
    }
}