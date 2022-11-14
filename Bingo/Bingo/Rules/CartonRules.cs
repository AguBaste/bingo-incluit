using Bingo.Models;

namespace Bingo.Rules
{
    public class CartonRules
    {
        public Carton Crear()
        {
            Carton  carton = new();
            Random genRandom = new Random();
            carton.Numeros = new int[9, 3];

            // lleno el carton de numeros
            for (int c = 0; c < 9; c++)
            {
                for (int f = 0; f < 3; f++)
                {
                    int nuevoNumero = 0;
                    bool esNuevo = false;
                    while (!esNuevo)
                    {
                        if (c == 0)
                        {
                            nuevoNumero = genRandom.Next(1, 10);
                        }
                        else if (c == 8)
                        {
                            nuevoNumero = genRandom.Next(80, 91);
                        }
                        else
                        {
                            nuevoNumero = genRandom.Next(c * 10, c * 10 + 10);
                        }


                        // busco los repetidos
                        esNuevo = true;
                        for (int j = 0; j < 3; j++)
                        {
                            if (carton.Numeros[c, j] == nuevoNumero)
                                esNuevo = false;
                            break;
                        }
                    }
                    carton.Numeros[c, f] = nuevoNumero;
                }

            }
            // ordeno los numeros del carton

            for (int c = 0; c < 9; c++)
            {
                for (int f = 0; f < 3; f++)
                {
                    for (int k = f + 1; k < 3; k++)
                    {
                        if (carton.Numeros[c, f] > carton.Numeros[c, k])
                        {
                            int aux = carton.Numeros[c, f];
                            carton.Numeros[c, f] = carton.Numeros[c, k];
                            carton.Numeros[c, k] = aux;
                        }
                    }
                }
            }

            //borro los numeros que me sobran
            var borrados = 0;

            while (borrados < 12)
            {
                int filaABorrar = genRandom.Next(0, 3);
                int colABorrar = genRandom.Next(0, 9);

                if (carton.Numeros[colABorrar, filaABorrar] == 0)
                {
                    continue;
                }

                //cuento los ceros por fila 
                var cerosFila = 0;
                for (int c = 0; c < 9; c++)
                {
                    if (carton.Numeros[c, filaABorrar] == 0)
                    {
                        cerosFila++;
                    }
                }

                //cuento los ceros por columna
                var cerosCol = 0;
                for (int f = 0; f < 3; f++)
                {
                    if (carton.Numeros[colABorrar, f] == 0)
                    {
                        cerosCol++;
                    }
                }

                //cuento cantidad de numeros por columna
                var itemsPorCol = new int[9];

                for (int c = 0; c < 9; c++)
                {
                    for (int f = 0; f < 3; f++)
                    {
                        if (carton.Numeros[c, f] != 0)
                        {
                            itemsPorCol[c]++;
                        }
                    }
                }


                //cuento cuantas columnas hay con un solo numero
                var colConUno = 0;
                for (int c = 0; c < 9; c++)
                {
                    if (itemsPorCol[c] == 1)
                    {
                        colConUno++;
                    }
                }

                if (cerosFila == 4 || cerosCol == 2)
                {
                    continue;
                }

                if (colConUno == 3 && itemsPorCol[colABorrar] != 3)
                {
                    continue;
                }
                carton.Numeros[colABorrar, filaABorrar] = 0;
                borrados++;
            }
            return carton;
        }
        public int Sortear()
        {
            Random random = new Random();
            int numero = random.Next(1, 91);
            return numero;
        }
    }
}
