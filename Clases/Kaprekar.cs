using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Retos.Clases
{
    public class Kaprekar
    {
        const int numeroKaprekar = 6174;

        public void Calcular()
        {
            Console.WriteLine("Introduce un número de 4 dígitos");
            string numeroString = Console.ReadLine();

            if (numeroString.Length != 4)
            {
                Console.WriteLine("Este número no tiene 4 dígitos");
            }
            else
            {
                //La primera vez transformo el número a entero fuera del while
                Int32.TryParse(numeroString, out int numeroExterior);

                int[] digitos = new int[4];
                int resultadoResta = 0;
                int contador = 0;

                while (resultadoResta != numeroKaprekar)
                {
                    if (numeroExterior != 0)
                    {
                        digitos = DescomponerNum(numeroExterior);

                        if (NumeroCorrecto(digitos[0], digitos[1], digitos[2], digitos[3]))
                        {
                            var minuendoArray = (int[])OrdenarNum(digitos, true).Clone();
                            var sustraendoArray = (int[])OrdenarNum(digitos, false).Clone();

                            int minuendo = Recomponer(minuendoArray);
                            int sustraendo = Recomponer(sustraendoArray);

                            Console.WriteLine($"Vuelta {contador} -> Minuendo: {minuendo}");
                            Console.WriteLine($"Vuelta {contador} -> Sustraendo: {sustraendo}");

                            resultadoResta = minuendo - sustraendo;

                            Console.WriteLine($"Vuelta {contador} -> Resultado de la resta: {resultadoResta}");

                            //asignamos al número a descomponer el resultado de la resta
                            numeroExterior = resultadoResta;

                            contador++;
                        }
                        else
                        {
                            Console.WriteLine("Número incorrecto");
                        }
                    }

                }
            }
        }

        public static int[] OrdenarNum(int[] digitos, bool desc)
        {
            int temp;

            if (desc)
            {
                for (int i = 0; i < digitos.Length - 1; i++)
                {
                    for (int x = i + 1; x < digitos.Length; x++)
                    {
                        if (digitos[i] < digitos[x])
                        {
                            temp = digitos[i];
                            digitos[i] = digitos[x];
                            digitos[x] = temp;
                        }
                    }
                }
            }
            else
            {
                for (int i = digitos.Length - 1; i >= 0; i--)
                {
                    for (int x = i - 1; x >= 0; x--)
                    {
                        if (digitos[x] > digitos[i])
                        {
                            temp = digitos[x];
                            digitos[x] = digitos[i];
                            digitos[i] = temp;
                        }
                    }
                }
            }

            return digitos;
        }

        public static int[] DescomponerNum(int numeroExterior)
        {
            int[] digitos = new int[4];

            int numeroExteriorInt = Int32.Parse(numeroExterior.ToString());

            //Descomposición matemática
            digitos[0] = numeroExteriorInt / 1000;
            digitos[1] = (numeroExteriorInt / 100) % 10;
            digitos[2] = (numeroExteriorInt % 100) / 10;
            digitos[3] = (numeroExteriorInt % 100) % 10;
            return digitos;
        }

        public static int Recomponer(int[] digitos)
        {
            var numeroString = digitos[0].ToString() + digitos[1].ToString() + digitos[2].ToString() + digitos[3].ToString();

            return Int32.Parse(numeroString);
        }

        public static bool NumeroCorrecto(int miles, int centenas, int decenas, int unidades)
        {
            bool reponse = true;

            if (miles == centenas && miles == decenas)
            {
                return false;
            }

            if (miles == centenas && miles == unidades)
            {
                return false;
            }

            if (miles == decenas && miles == unidades)
            {
                return false;
            }

            if (centenas == decenas && centenas == unidades)
            {
                return false;
            }

            return reponse;
        }
    }
}
