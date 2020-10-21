using Microsoft.VisualBasic.CompilerServices;
using System;
using System.Collections.Generic;
using System.Text;

namespace prueba_para_sudoku
{
    class Sudoku
    {
        public bool terminado = false;
        public int[,] Panel_principal = new int[9, 9] { { 0, 0, 0, 0, 0, 0, 0, 0, 0 }, { 0, 0, 0, 0, 0, 0, 0, 0, 0 }, { 0, 0, 0, 0, 0, 0, 0, 0, 0 },
            { 0, 0, 0, 0, 0, 0, 0, 0, 0 }, { 0, 0, 0, 0, 0, 0, 0, 0, 0 }, { 0, 0, 0, 0, 0, 0, 0, 0, 0 },
            { 0, 0, 0, 0, 0, 0, 0, 0, 0 }, { 0, 0, 0, 0, 0, 0, 0, 0, 0 }, { 0, 0, 0, 0, 0, 0, 0, 0, 0 } };
        public bool[,] ocupabilidad_horizontal = new bool[9, 9]{ {false, false, false, false, false, false, false, false, false},
            {false, false, false, false, false, false, false, false, false},{false, false, false, false, false, false, false, false, false},
            {false, false, false, false, false, false, false, false, false},{false, false, false, false, false, false, false, false, false},
            {false, false, false, false, false, false, false, false, false},{false, false, false, false, false, false, false, false, false},
            {false, false, false, false, false, false, false, false, false},{false, false, false, false, false, false, false, false, false} };
        public bool[,] ocupabilidad_vertical = new bool[9, 9]{ {false, false, false, false, false, false, false, false, false},
            {false, false, false, false, false, false, false, false, false},{false, false, false, false, false, false, false, false, false},
            {false, false, false, false, false, false, false, false, false},{false, false, false, false, false, false, false, false, false},
            {false, false, false, false, false, false, false, false, false},{false, false, false, false, false, false, false, false, false},
            {false, false, false, false, false, false, false, false, false},{false, false, false, false, false, false, false, false, false} };
        public bool[,] ocupabilidad_cuadrantil = new bool[9, 9] { {false, false, false, false, false, false, false, false, false},
            {false, false, false, false, false, false, false, false, false},{false, false, false, false, false, false, false, false, false},
            {false, false, false, false, false, false, false, false, false},{false, false, false, false, false, false, false, false, false},
            {false, false, false, false, false, false, false, false, false},{false, false, false, false, false, false, false, false, false},
            {false, false, false, false, false, false, false, false, false},{false, false, false, false, false, false, false, false, false} };    
        public bool viable(int lugar_x, int lugar_y, int valor, bool[,] sudoku_vertical, bool[,] sudoku_horizontal, bool[,] sudoku_cuadrantil)
        {
            int recuadro;
            int cuadrante_x, cuadrante_y;
            cuadrante_x = lugar_x / 3;
            cuadrante_y = lugar_y / 3;

            recuadro = cuadrante_x + (3 * cuadrante_y);

            
            if (!sudoku_cuadrantil[valor, recuadro] && !sudoku_horizontal[valor, lugar_x] && !sudoku_vertical[valor, lugar_y] && Panel_principal[lugar_x, lugar_y] == 0)
            {
                return true;
            }
            
            
            return false;   
        }
        
        
        public void escribirPanelPrincipal(int [,] Panel_principal)
        {
            bool aux = false;
            for (int i = 0; i < 9; i++)
            {
                for (int k = 0; k < 9; k++)
                {
                    if (i % 3 == 0 && !aux)
                    {
                        Console.WriteLine("-------+------+-----+");
                        aux = true;

                    }
                    if ((k) % 3 == 0)
                    {
                        Console.Write("|");
                    }

                    Console.Write(Panel_principal[i, k] + " ");

                }
                Console.Write("|");
                aux = false;
                Console.WriteLine();
            }
            Console.WriteLine();
        }
        public Sudoku generarUnNumero(Sudoku objeto, Random generador,  int n)
        {
            
            int contador=0;
            int recuadro;
            int cuadrante_x, cuadrante_y;
            int i = generador.Next(0, 9);
            int j = generador.Next(0, 9);
            cuadrante_x = i / 3;
            cuadrante_y = j / 3;
            recuadro = cuadrante_y + (3 * cuadrante_x);
            while(objeto.Panel_principal[i,j]!=0|| objeto.ocupabilidad_cuadrantil[n, recuadro] || objeto.ocupabilidad_horizontal[n, j] || objeto.ocupabilidad_vertical[n, i])
                {
                    if (contador > 100)
                    {
                        break;
                    }
                    i = generador.Next(0, 9);
                    j = generador.Next(0, 9);
                    cuadrante_x = i / 3;
                    cuadrante_y = j / 3;
                    recuadro = cuadrante_y + (3 * cuadrante_x);
                
                contador++;
                }
                if((contador < 100)&& !objeto.ocupabilidad_cuadrantil[n, recuadro] && !objeto.ocupabilidad_horizontal[n, j] && !objeto.ocupabilidad_vertical[n, i] && objeto.Panel_principal[i, j] == 0)
                {
                    
                    objeto.Panel_principal[i, j] = n + 1;
                    objeto.ocupabilidad_vertical[n, i] = true;
                    objeto.ocupabilidad_horizontal[n, j] = true;
                    objeto.ocupabilidad_cuadrantil[n, recuadro] = true;

                }
            
            return objeto;
            
        }
        public void escribirPanel(bool[,] Panel_principal)
        {
            bool aux = false;
            for (int i = 0; i < 9; i++)
            {
                for (int k = 0; k < 9; k++)
                {
                    
                    

                    Console.Write(Panel_principal[i, k] + " ");

                }
                Console.Write("|");
                aux = false;
                Console.WriteLine();
            }
            Console.WriteLine("_________________");
        }
        public int rastreoDeNumeros(int[,] Panel_principal)
        {
            int contador=0;
            for(int i = 0; i < 9; i++)
            {
                for(int j=0; j < 9; j++)
                {
                    if (Panel_principal[i, j] != 0)
                    {
                        contador++;
                    }
                }
            }
            return contador;
        }
        public Sudoku Asignar(int X, int Y, int V, Sudoku iokese)
        {
            Console.WriteLine(V);
                int cuadrante;
                cuadrante = (X / 3) + (3 * (Y / 3));
                iokese.Panel_principal[Y, X] = V + 1;
                iokese.ocupabilidad_vertical[V, X] = true;
                iokese.ocupabilidad_horizontal[V, Y] = true;
                iokese.ocupabilidad_cuadrantil[V, cuadrante] = true;
            Console.WriteLine(iokese.Panel_principal[X, Y]);
            return iokese;
            
            
        }
        public Sudoku Borrar(int X, int Y, int V, Sudoku iokese)
        {
            int cuadrante;
            cuadrante = (X / 3) + (3 * (Y / 3));
            iokese.Panel_principal[Y, X] = 0;
            iokese.ocupabilidad_vertical[V, X] = false;
            iokese.ocupabilidad_horizontal[V, Y] = false;
            iokese.ocupabilidad_cuadrantil[V, cuadrante] = false;
            return iokese;
        }
        public Sudoku resolverSudoku( Sudoku objeto, int i2, int j2, int n2)
        {
            
            int recuadro;
            int cuadrante_x, cuadrante_y;
            for(int i=0; i < 9; i++)
            {
                
                for (int j = 0; j < 9; j++)
                {
                    
                    if (objeto.Panel_principal[i, j] == 0)
                    {
                       
                        for (int n = 0; n < 9; n++)
                        {
                            
                            cuadrante_x = i / 3;
                            cuadrante_y = j / 3;
                            recuadro = cuadrante_y + (3 * cuadrante_x);                            
                            if (!objeto.ocupabilidad_cuadrantil[n, recuadro] && !objeto.ocupabilidad_horizontal[n, j] && !objeto.ocupabilidad_vertical[n, i])
                            {
                                objeto.Panel_principal[i, j] = n + 1;
                                objeto.ocupabilidad_vertical[n, i] = true;
                                objeto.ocupabilidad_horizontal[n, j] = true;
                                objeto.ocupabilidad_cuadrantil[n, recuadro] = true;
                                objeto=objeto.resolverSudoku(objeto, i,j,n);
                                
                                if (!objeto.terminado)
                                {
                                    objeto.Panel_principal[i, j] = 0;
                                    objeto.ocupabilidad_vertical[n, i] = false;
                                    objeto.ocupabilidad_horizontal[n, j] = false;
                                    objeto.ocupabilidad_cuadrantil[n, recuadro] = false;
                                }
                            }                            
                        }
                        return objeto;
                    }
                }
            }            
            /*objeto.escribirPanelPrincipal(objeto.Panel_principal);
            objeto.Comprobar(objeto);*/
            objeto.terminado = true;
            return objeto;
        }
        public Sudoku Actualizar(Sudoku iokese)
        {
            for(int i = 0; i < 9; i++)
            {
                for (int j=0; j<9; j++)
                {
                    if (iokese.Panel_principal[i, j] != 0)
                    {
                        int n;
                        n = iokese.Panel_principal[i, j]-1;
                        int cuadrante;
                        cuadrante = (j / 3) + (3 * (i / 3));
                        iokese.ocupabilidad_vertical[n, i] = true;
                        iokese.ocupabilidad_horizontal[n, j] = true;
                        iokese.ocupabilidad_cuadrantil[n, cuadrante] = true;

                    }
                }
            }
            return iokese;
        }
        public Sudoku Comprobar(Sudoku objeto)
        {
            for(int i=0; i<9; i++)
            {
                for(int j=0; j < 9; j++)
                {
                    if (!objeto.ocupabilidad_cuadrantil[i, j] || !objeto.ocupabilidad_horizontal[i, j] || !objeto.ocupabilidad_vertical[i, j])
                    {
                        return objeto;
                    }
                }
            }
            Console.WriteLine("Perfecto");
            objeto.terminado = true;
            return objeto;
        }
        public Sudoku GenerarPanel(Sudoku iokese, Random generador)
        {
            int n;
            while (!iokese.terminado)
            {
                iokese.Panel_principal = new int[9, 9] { { 0, 0, 0, 0, 0, 0, 0, 0, 0 }, { 0, 0, 0, 0, 0, 0, 0, 0, 0 }, { 0, 0, 0, 0, 0, 0, 0, 0, 0 },
            { 0, 0, 0, 0, 0, 0, 0, 0, 0 }, { 0, 0, 0, 0, 0, 0, 0, 0, 0 }, { 0, 0, 0, 0, 0, 0, 0, 0, 0 },
            { 0, 0, 0, 0, 0, 0, 0, 0, 0 }, { 0, 0, 0, 0, 0, 0, 0, 0, 0 }, { 0, 0, 0, 0, 0, 0, 0, 0, 0 } };
                iokese.ocupabilidad_cuadrantil = new bool[9, 9] { {false, false, false, false, false, false, false, false, false},
            {false, false, false, false, false, false, false, false, false},{false, false, false, false, false, false, false, false, false},
            {false, false, false, false, false, false, false, false, false},{false, false, false, false, false, false, false, false, false},
            {false, false, false, false, false, false, false, false, false},{false, false, false, false, false, false, false, false, false},
            {false, false, false, false, false, false, false, false, false},{false, false, false, false, false, false, false, false, false} };
                iokese.ocupabilidad_horizontal = new bool[9, 9]{ {false, false, false, false, false, false, false, false, false},
            {false, false, false, false, false, false, false, false, false},{false, false, false, false, false, false, false, false, false},
            {false, false, false, false, false, false, false, false, false},{false, false, false, false, false, false, false, false, false},
            {false, false, false, false, false, false, false, false, false},{false, false, false, false, false, false, false, false, false},
            {false, false, false, false, false, false, false, false, false},{false, false, false, false, false, false, false, false, false} };
                iokese.ocupabilidad_vertical = new bool[9, 9]{ {false, false, false, false, false, false, false, false, false},
            {false, false, false, false, false, false, false, false, false},{false, false, false, false, false, false, false, false, false},
            {false, false, false, false, false, false, false, false, false},{false, false, false, false, false, false, false, false, false},
            {false, false, false, false, false, false, false, false, false},{false, false, false, false, false, false, false, false, false},
            {false, false, false, false, false, false, false, false, false},{false, false, false, false, false, false, false, false, false} };
                iokese.terminado = false;
                for (int I = 0; I < 23; I++)
                {
                    n = generador.Next(0, 9);
                    iokese = iokese.generarUnNumero(iokese, generador, n);
                }
                iokese = iokese.resolverSudoku(iokese, 0, 0, 0);
            }
            return iokese;
        }
    }   
    
    
}
