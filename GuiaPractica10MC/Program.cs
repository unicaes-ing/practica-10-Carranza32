using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace GuiaPractica10MC
{
    class Program
    {
        #region atributos
        private static bool isNumber;
        #endregion

        static void Main(string[] args)
        {
            int opc = 0;
            bool isNumber;
            do
            {
                do
                {
                    Console.Clear();
                    Console.WriteLine("Escoja una opcion");
                    Console.WriteLine("1 - Ejercicio 1");
                    Console.WriteLine("2 - Ejercicio 2");
                    Console.WriteLine("3 - Ejercicio 3");
                    Console.WriteLine("4 - Ejercicio 4");
                    Console.WriteLine("0 - Salir");
                    isNumber = int.TryParse(Console.ReadLine(), out opc);
                } while (isNumber == false || opc < 0);
                switch (opc)
                {
                    case 1:
                        Console.Clear();
                        Ejercicio1();
                        Console.ReadKey();
                        break;
                    case 2:
                        Console.Clear();
                        Ejercicio2();
                        Console.ReadKey();
                        break;
                    case 3:
                        Console.Clear();
                        Ejercicio3();
                        Console.ReadKey();
                        break;
                    case 4:
                        Console.Clear();
                        Ejercicio4();
                        Console.ReadKey();
                        break;
                    default:
                        break;
                }
            } while (opc != 0);
        }

        private static void Ejercicio1()
        {
            int opc = 0;
            string line;
            StreamReader reader;
            StreamWriter writer;


            do
            {
                do
                {
                    Console.Clear();
                    Console.WriteLine("Escoja una opcion");
                    Console.WriteLine("1 - Agregar pais");
                    Console.WriteLine("2 - Mostrar paises");
                    Console.WriteLine("3 - Buscar paises");
                    Console.WriteLine("4 - Salir");
                    isNumber = int.TryParse(Console.ReadLine(), out opc);
                } while (isNumber == false || opc < 0);
                switch (opc)
                {
                    case 1:
                        Console.Clear();
                        writer = new StreamWriter("Ejercicio1.txt", true);
                        Console.WriteLine("Escriba el nombre de un pais");
                        writer.WriteLine(Console.ReadLine());
                        writer.Close();
                        break;
                    case 2:
                        Console.Clear();
                        reader = new StreamReader("Ejercicio1.txt");
                        Console.WriteLine("Paises");
                        while ((line = reader.ReadLine()) != null)
                        {
                            Console.WriteLine(line);
                        }
                        reader.Close();
                        Console.ReadKey();
                        break;
                    case 3:
                        Console.Clear();
                        reader = new StreamReader("Ejercicio1.txt");
                        Console.WriteLine("Ingrese el pais que desea encontrar");
                        string pais = Console.ReadLine();
                        Console.WriteLine("Paises");
                        while ((line = reader.ReadLine()) != null)
                        {
                            if (line.ToLower().Equals(pais.ToLower()))
                            {
                                Console.ForegroundColor = ConsoleColor.DarkRed;
                            }
                            Console.WriteLine(line);
                            Console.ResetColor();
                        }
                        reader.Close();
                        Console.ReadKey();
                        break;
                    default:
                        break;
                }
            } while (opc != 4);
        }

        private static void Ejercicio2()
        {
            int opc = 0;
            string line;
            StreamReader reader;
            StreamWriter writer;
            string[] paises = new string[5];
            string texto;

            do
            {
                do
                {
                    Console.Clear();
                    Console.WriteLine("Escoja una opcion");
                    Console.WriteLine("1 - Agregar pais");
                    Console.WriteLine("2 - Mostrar paises");
                    Console.WriteLine("3 - Buscar paises");
                    Console.WriteLine("4 - Salir");
                    isNumber = int.TryParse(Console.ReadLine(), out opc);
                } while (isNumber == false || opc < 0);
                switch (opc)
                {
                    case 1:
                        Console.Clear();
                        writer = new StreamWriter("Ejercicio2.txt", true);
                        
                        for (int i = 0; i < paises.Length; i++)
                        {
                            Console.WriteLine("Escriba el nombre del pais " + i + " de 5");
                            paises[i] = Console.ReadLine();
                        }
                        texto = string.Join(",", paises);

                        writer.Write(texto);
                        writer.Close();
                        break;
                    case 2:
                        Console.Clear();
                        reader = new StreamReader("Ejercicio2.txt");
                        texto = reader.ReadToEnd();
                        paises = texto.Split(',');
                        Console.WriteLine("Paises");
                        foreach (var item in paises)
                        {
                            Console.WriteLine(item);
                        }
                        reader.Close();
                        Console.ReadKey();
                        break;
                    case 3:
                        Console.Clear();
                        reader = new StreamReader("Ejercicio2.txt");
                        texto = reader.ReadToEnd();
                        paises = texto.Split(',');
                        Console.WriteLine("Ingrese el pais que desea encontrar");
                        string pais = Console.ReadLine();
                        Console.WriteLine("Paises");
                        foreach (var item in paises)
                        {
                            if (item.ToLower().Equals(pais.ToLower()))
                            {
                                Console.ForegroundColor = ConsoleColor.DarkRed;
                            }
                            Console.WriteLine(item);
                            Console.ResetColor();
                        }
                        reader.Close();
                        Console.ReadKey();
                        break;
                    default:
                        break;
                }
            } while (opc != 4);
        }

        private static void Ejercicio3()
        {
            string pass;
            do
            {
                Console.WriteLine("Ingrese su contraseña: ");
                pass = Console.ReadLine();
            } while (pass.Length < 7 || pass.Length > 20);
            Console.WriteLine("\nEncriptacion: " + Encript(pass));
            Console.WriteLine("\npass: " + Desencript(pass));

            StreamWriter archivo = new StreamWriter("Ejercicio3.txt", true);
            archivo.WriteLine(Encript(pass));
            archivo.Close();
            Console.WriteLine("La pass ha sido ENCRIPTADA y ALMACENADA con exito.");
            Console.WriteLine("\nPresione <ENTER> para continuar");
            Console.ReadKey();
        }
        public static string Encript(string clave)
        {
            string encriptado = string.Empty;
            Byte[] encriptar = System.Text.Encoding.Unicode.GetBytes(clave);
            encriptado = Convert.ToBase64String(encriptar);
            return encriptado;
        }
        public static string Desencript(string clave)
        {
            string desencriptado = string.Empty;
            Byte[] desencriptar = Convert.FromBase64String(Encript(clave));
            desencriptado = System.Text.Encoding.Unicode.GetString(desencriptar);
            return desencriptado;
        }

        private static void Ejercicio4()
        {
            string pass;
            int intentos = 0;
            bool isValid = false;

            StreamReader archivo = new StreamReader("Ejercicio3.txt");
            var clave = Desencript(archivo.ReadLine());
            archivo.Close();
            
            do
            {
                Console.WriteLine("Ingrese su contraseña: ");
                pass = Encript(Console.ReadLine());

                if (pass == clave)
                {
                    isValid = true;
                }
                intentos++;
            } while (isValid == false && intentos < 3);

            if (intentos >= 3)
            {
                Console.WriteLine("Limite de intentos.");
                return;
            }

            Console.WriteLine("Accedio con exito");
        }
    }
}
