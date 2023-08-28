using System;

namespace FractionCalculator
{
    // Clase para representar fracciones
    class Fraction
    {
        public int Numerator { get; set; }
        public int Denominator { get; set; }

        public Fraction(int numerator, int denominator)
        {
            Numerator = numerator;
            Denominator = denominator;
        }

        // Método para simplificar la fracción
        public void Simplify()
        {
            int gcd = GCD(Numerator, Denominator);
            Numerator /= gcd;
            Denominator /= gcd;
        }

        private int GCD(int a, int b)
        {
            while (b != 0)
            {
                int temp = b;
                b = a % b;
                a = temp;
            }
            return a;
        }

        public override string ToString()
        {
            return $"{Numerator}/{Denominator}";
        }
    }

    class Program
    {
        static void Main(string[] args)
        {

            Console.Write("Ingrese el numero del ejercicio a consultar: ");
            int op = int.Parse(Console.ReadLine());

            if (op == 1)
            {
                Console.WriteLine("Calculadora de Fracciones");
                Console.WriteLine("---------------------------------------------");

                Console.Write("Ingrese el numerador de la primera fracción: ");
                int num1 = int.Parse(Console.ReadLine());
                Console.Write("Ingrese el denominador de la primera fracción: ");
                int den1 = int.Parse(Console.ReadLine());

                Console.Write("Ingrese el numerador de la segunda fracción: ");
                int num2 = int.Parse(Console.ReadLine());
                Console.Write("Ingrese el denominador de la segunda fracción: ");
                int den2 = int.Parse(Console.ReadLine());

                Console.Write("Ingrese el operador (+, -, *, /): ");
                char operation = char.Parse(Console.ReadLine());

                Fraction fraction1 = new Fraction(num1, den1);
                Fraction fraction2 = new Fraction(num2, den2);
                Fraction result = new Fraction(0, 0);

                switch (operation)
                {
                    case '+':
                        result.Numerator = fraction1.Numerator * fraction2.Denominator + fraction2.Numerator * fraction1.Denominator;
                        result.Denominator = fraction1.Denominator * fraction2.Denominator;
                        break;
                    case '-':
                        result.Numerator = fraction1.Numerator * fraction2.Denominator - fraction2.Numerator * fraction1.Denominator;
                        result.Denominator = fraction1.Denominator * fraction2.Denominator;
                        break;
                    case '*':
                        result.Numerator = fraction1.Numerator * fraction2.Numerator;
                        result.Denominator = fraction1.Denominator * fraction2.Denominator;
                        break;
                    case '/':
                        if (fraction2.Numerator == 0)
                        {
                            Console.WriteLine("Error: No se puede dividir entre cero.");
                            return;
                        }
                        result.Numerator = fraction1.Numerator * fraction2.Denominator;
                        result.Denominator = fraction1.Denominator * fraction2.Numerator;
                        break;
                    default:
                        Console.WriteLine("Operador no válido.");
                        return;
                }

                result.Simplify();
                Console.WriteLine($"Resultado: {result}");
            }

            else if (op == 2)
            {
                Console.WriteLine("Generador de Tablas de Multiplicar con un Giro");
                Console.WriteLine("---------------------------------------------");

                Console.Write("Ingrese el valor inicial del rango: ");
                int start = int.Parse(Console.ReadLine());

                Console.Write("Ingrese el valor final del rango: ");
                int end = int.Parse(Console.ReadLine());

                if (start > end)
                {
                    Console.WriteLine("El valor inicial debe ser menor o igual al valor final.");
                    return;
                }

                Random random = new Random();

                for (int number = start; number <= end; number++)
                {
                    int missingFactor = random.Next(1, 11); // Generar un factor aleatorio para ocultar
                    int product = number * missingFactor;

                    Console.WriteLine($"Resuelve: {number} x ? = {product}");
                    Console.Write("Tu respuesta: ");
                    int userAnswer = int.Parse(Console.ReadLine());

                    if (userAnswer == missingFactor)
                    {
                        Console.WriteLine("¡Correcto! ¡Buen trabajo!\n");
                    }
                    else
                    {
                        Console.WriteLine($"Incorrecto. La respuesta correcta era: {missingFactor}\n");
                    }
                }
            }

            else if (op == 3)
            {
                static int CalculateSumOfDigits(int numero)
                {
                    int sum = 0;
                    while (numero != 0)
                    {
                        sum += numero % 10;
                        numero /= 10;
                    }
                    return sum;
                }
                Console.WriteLine("Verificador de Números Especiales");
                Console.WriteLine("--------------------------------");

                Console.Write("Ingrese un número: ");
                int numero = int.Parse(Console.ReadLine());

                bool Divisible5 = numero % 5 == 0;
                bool NoDivisible2y3 = numero % 2 != 0 && numero % 3 != 0;
                int SumaDigitos = CalculateSumOfDigits(numero);

                bool especial = Divisible5 && NoDivisible2y3 && SumaDigitos > 10;

                if (especial)
                {
                    Console.WriteLine($"{numero} es un número especial.");
                }
                else
                {
                    Console.WriteLine($"{numero} no es un número especial.");
                }
            }

            else if (op == 4)
            {
                string originalPhrase = "El gato juega en el jardín";
                string hiddenPhrase = "El _____ juega _____ el _____";

                string[] hiddenWords = { "gato", "en", "jardín" };
                bool[] guessedWords = { false, false, false };

                int remainingAttempts = 10;

                Console.WriteLine("Adivinanza de Frase Oculta");
                Console.WriteLine("--------------------------");
                Console.WriteLine(hiddenPhrase);
                Console.WriteLine($"Tienes {remainingAttempts} intentos para adivinar las palabras ocultas.\n");

                while (remainingAttempts > 0)
                {
                    Console.Write("Ingresa una palabra: ");
                    string userGuess = Console.ReadLine().ToLower();

                    int foundIndex = Array.IndexOf(hiddenWords, userGuess);

                    if (foundIndex != -1 && !guessedWords[foundIndex])
                    {
                        guessedWords[foundIndex] = true;
                        Console.WriteLine("¡Has adivinado una palabra!\n");
                    }
                    else
                    {
                        Console.WriteLine("Respuesta incorrecta. Pierdes un intento.\n");
                        remainingAttempts--;
                    }

                    bool allWordsGuessed = true;
                    foreach (bool guessed in guessedWords)
                    {
                        if (!guessed)
                        {
                            allWordsGuessed = false;
                            break;
                        }
                    }

                    if (allWordsGuessed)
                    {
                        Console.WriteLine("¡Felicidades! Has adivinado todas las palabras ocultas.");
                        Console.WriteLine($"La frase original es: \"{originalPhrase}\"");
                        break;
                    }

                    Console.WriteLine(hiddenPhrase);
                    Console.WriteLine($"Tienes {remainingAttempts} intentos restantes.\n");
                }

                if (remainingAttempts == 0)
                {
                    Console.WriteLine("Has agotado tus intentos. ¡El juego ha terminado!");
                    Console.WriteLine($"La frase original era: \"{originalPhrase}\"");
                }
            }

        }
    }
}
