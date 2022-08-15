using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace App_Samuel
{
    #region Enumeration
    public enum Estado
    {
        Bajo = 1,
        Normal = 2,
        Sobrepeso = 3,
        Obesidad = 4
    }
    #endregion
    class Program
    {
        static void Main(string[] args)
        {
            double[,] IMC = new double[2, 4];
            string[,] usuarios = new string[4, 4];
            string user = "";
            string password = "";
            bool validacion = false;
            int contador = 3;
            int op = 0;

            BaseDatos(usuarios);

            Console.WriteLine("Bienvenido/a a esta aplicacion de muestra, presione enter para continuar");
            while (contador != 0 && validacion == false)
            {
                Console.WriteLine("Ingrese su nombre de usuario: ");
                user = Console.ReadLine();
                Console.Clear();

                Console.WriteLine("Ingrese su contraseña: ");
                password = Console.ReadLine();
                Console.Clear();

                validacion = Validacion(usuarios, validacion, user, password);

                if (validacion)
                {
                    Console.WriteLine($"Bienvenido/a nuevamente! {user}");
                    validacion = true;
                }
                else
                {
                    Console.WriteLine("Usuario y/o contraseña incorrectos");
                    validacion = false;
                    contador--;
                    Console.Write($"Intentos restantes: {contador}");
                    Console.ReadKey();
                    Console.Clear();
                }
            }
            if (contador == 0 && validacion == false)
            {
                Console.WriteLine("Cantidad maxima de intentos alcanzada.");
                Console.WriteLine("Cerrando sesion");

                for (int i = 0; i < 10; i++)
                {
                    Console.Write("-");
                    System.Threading.Thread.Sleep(200);
                }
            }
            Console.ReadKey();
            Console.Clear();

            while (op != 2)
            {
                Console.WriteLine("|----- Calculora de IMC -----|");
                Console.WriteLine("|1)--- Iniciar un calculo ---|");
                Console.WriteLine("|2)---------- Salir ---------|");

                op = Convert.ToInt32(Console.ReadLine());
                Console.Clear();

                switch (op)
                {
                    case 1:

                        IngresoDatos(IMC);

                        for (int i = 0; i < IMC.GetLength(0); i++)
                        {
                            IMC[i, 2] = Math.Round(CalculoIMC(IMC[i, 0], IMC[i, 1]), 2);
                            IMC[i, 3] = CalculoEstado(IMC[i, 2]);
                        }

                        Console.WriteLine($"{user}, tu calculo de IMC es:{System.Environment.NewLine}");
                        for (int i = 0; i < IMC.GetLength(0); i++)
                        {
                            for (int j = 0; j < IMC.GetLength(1); j++)
                            {
                                if (i == 0)
                                {
                                    switch (j)
                                    {
                                        case 0:
                                            Console.Write("|PESO|");
                                            break;
                                        case 1:
                                            Console.Write("|ESTATURA|");
                                            break;
                                        case 2:
                                            Console.Write("|IMC|");
                                            break;
                                        case 3:
                                            Console.WriteLine("|RESULTADO|");
                                            break;
                                    }
                                }
                                else
                                {
                                    if (j <= 2)
                                    {
                                        Console.Write($"|{IMC[i, j]}|");
                                    }
                                    if (j == 3)
                                    {
                                        Console.WriteLine($"|{(Estado)IMC[i, j]}|{System.Environment.NewLine}");
                                    }
                                }
                            }
                        }
                        Console.WriteLine("Enter para volver al menu principal");
                        Console.ReadKey();
                        Console.Clear();
                        break;

                    case 2:
                        Console.Write("Cerrando sesión");
                        for (int i = 0; i < 3; i++)
                        {
                            Console.Write(".");
                            System.Threading.Thread.Sleep(300);
                        }
                        break;
                }
            }
        }
        #region BaseDatos
        static void BaseDatos(string[,] usuarios)
        {
            for (int i = 0; i < usuarios.GetLength(0); i++)
            {
                for (int j = 0; j < usuarios.GetLength(1); j++)
                {
                    switch (i)
                    {
                        case 0:
                            usuarios[i, 0] = "samuel";
                            usuarios[i, 1] = "1234";
                            usuarios[i, 2] = "gabriel";
                            usuarios[i, 3] = "12332";
                            break;
                        case 1:
                            usuarios[i, 0] = "naty";
                            usuarios[i, 1] = "2012";
                            usuarios[i, 2] = "gio";
                            usuarios[i, 3] = "123";
                            break;
                        case 2:
                            usuarios[i, 0] = "dugle";
                            usuarios[i, 1] = "1901";
                            usuarios[i, 2] = "zuly";
                            usuarios[i, 3] = "0410";
                            break;
                        case 3:
                            usuarios[i, 0] = "ligia";
                            usuarios[i, 1] = "0312";
                            usuarios[i, 2] = "ali";
                            usuarios[i, 3] = "0412";
                            break;
                    }
                }
            }
        }
        #endregion
        #region Validacion
        static bool Validacion(string[,] usuarios, bool validacion, string user, string password)
        {
            for (int i = 0; i < usuarios.GetLength(1); i++)
            {
                if (usuarios[i, 0] == user && usuarios[i, 1] == password || usuarios[i, 2] == user && usuarios[i, 3] == password)
                {
                    validacion = true;
                }
            }
            return validacion;
        }
        #endregion
        #region IngresoDatos
        static void IngresoDatos(double[,] IMC)
        {
            Console.WriteLine("Ingrese su peso: ");
            IMC[1, 0] = Convert.ToDouble(Console.ReadLine());
            Console.Clear();

            Console.WriteLine("Ingrese su estatura (Con decimales): ");
            IMC[1, 1] = Convert.ToDouble(Console.ReadLine());
            Console.Clear();
        }
        #endregion
        #region CalculoIMC  
        static double CalculoIMC(double peso, double estatura)
        {
            return peso / Math.Pow(estatura, 2);
        }
        #endregion
        #region CalculoEstado
        static int CalculoEstado(double status)
        {

            if (status < 18.5)
            {
                return 1;
            }
            if (status >= 18.5 && status <= 24.99)
            {
                return 2;
            }
            if (status >= 25 && status <= 29.9)
            {
                return 3;
            }
            if (status >= 30)
            {
                return 4;
            }
            return 0;
        }
        #endregion  
    }
}