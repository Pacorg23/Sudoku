using System;
using System.ComponentModel.Design;
using System.Diagnostics;
using System.Globalization;
using System.Runtime.Loader;

namespace prueba_para_sudoku
{

    
    class Program
    {



        static void Main(string[] args)
        {
            Sudoku iokese = new Sudoku();
            Random generador = new Random();
            string eleccion;
            int elecciont=0;
            
            
            while (elecciont != 3)
            {
                Console.WriteLine("1)Crear un sudoku \n" +
                    "2) mostrar el sudoku \n" +
                    "3)cerrar \n");
                eleccion = Console.ReadLine();
                elecciont = Convert.ToInt32(eleccion);
                switch (elecciont)
                {
                    default:
                        Console.WriteLine("Error: valor no valido");
                        break;
                    case 1:
                        iokese = iokese.GenerarPanel(iokese, generador);
                        break;
                    case 2:
                        iokese.escribirPanelPrincipal(iokese.Panel_principal);
                        break;
                    case 3:
                        break;
            }
            }
            
            
            
           /* 
             
            
            
            //iokese.Panel_principal= new int[9,9] { { 0, 5, 0,0,0,4,0,0,0 }, {0,0,0,0,0,3,0,0,8 }, { 7, 0, 0, 0, 0, 0, 9, 0, 0 }, {0,3,0,0,9,1,0,0,0 }, {0,0,0,7,0,0,0,3,6 }, {0,0,2,0,0,0,8,0,0 }, {6,0,8,0,0,0,4,0,3 }, {0,0,0,0,2,0,0,6,0 }, {0,0,0,0,6,0,0,0,0 } };
            //iokese.Actualizar(iokese);
            //iokese.resolverSudoku(iokese, 0, 0, 0);
            iokese = iokese.GenerarPanel(iokese, generador);
            
             



            iokese.escribirPanelPrincipal(iokese.Panel_principal);*/
        }
    }
}
