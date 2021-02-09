using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PaginaDeSudoku.Models;
using PaginaDeSudoku.viewModel;

namespace PaginaDeSudoku.Controllers
{
    public class controlbaseController : Controller
    {
        public static Sudoku asdf = new Sudoku();
        public static Random random = new Random();

        // GET: controlbase
        [Route("paginadeprueba")]
        public ActionResult paginadeprueba()
        {
            var huehue = new huehue("puto el que lo lea");
            var juejue = new juejue("pendejo el que siga leyendo");

            var ViewModel = new PruebadeViewModel()
            {
                juejue = juejue,
                huehue = huehue
                };
            return View(ViewModel);
        }
        [Route("elbarto")]
        public ActionResult Index()
        {
            Random generador = new Random();
            return View("~/Views/Sudoku/PanelGrande.cshtml", asdf);
        }
        public ActionResult borrarPanel()
        {
            
            asdf = new Sudoku();
            
            return View("~/Views/Sudoku/PanelSudoku.cshtml", asdf);
        }
        public ActionResult aver()
        {
            asdf.veces++;
            return PartialView("~/Views/Sudoku/PanelSudoku.cshtml", asdf);
        }
        
        public ActionResult generarpanel(int eliminados)
        {
            //int eliminados = int.Parse(elimina2);
            asdf = new Sudoku();
            
            Random generador = new Random();
            
            int  x, y;
            asdf = asdf.GenerarPanel(asdf, generador);
            asdf.Panel_Parcial = asdf.CambiarAChar(asdf.Panel_principal);
            for (int i = 0; i < eliminados; i++)
            {
                x = generador.Next(0, 9);
                y = generador.Next(0, 9);
                if (asdf.Panel_Parcial[x, y] != Convert.ToChar(32))
                {
                    asdf.Panel_Parcial[x, y] = Convert.ToChar(32);
                }
                else
                {
                    i--;
                }
            }
            asdf.contador = asdf.contador - eliminados;
            
            return PartialView("~/Views/Sudoku/PanelSudoku.cshtml", asdf);
        }
        
        public ActionResult seleccionar(int casilla)
        {
            asdf.seleccion_j = casilla % 10;
            asdf.seleccion_i = (casilla - asdf.seleccion_j) / 10;
            
                
            
            
            //En caso de que ya este seleccionado
            if (asdf.color[asdf.seleccion_i, asdf.seleccion_j] == "wheat")
            {
                if(asdf.Panel_Parcial[asdf.seleccion_i, asdf.seleccion_j] == Convert.ToChar(32))
                {
                    asdf.color[asdf.seleccion_i,asdf.seleccion_j] = "white";
                }
                else{
                    for (int i = 0; i < 9; i++)
                    {
                        for (int j = 0; j < 9; j++)
                        {
                            if (asdf.Panel_Parcial[asdf.seleccion_i, asdf.seleccion_j] == asdf.Panel_Parcial[i, j] && asdf.Panel_Parcial[asdf.seleccion_i, asdf.seleccion_j] != Convert.ToChar(32))
                            {
                                asdf.color[i, j] = "white";
                            }
                            
                        }
                    }
                }

                return PartialView("~/Views/Sudoku/PanelSudoku.cshtml", asdf);
            }

            else
            {
                if (asdf.Panel_Parcial[asdf.seleccion_i, asdf.seleccion_j] != Convert.ToChar(32))
                {
                    for (int i = 0; i < 9; i++)
                    {
                        for (int j = 0; j < 9; j++)
                        {
                            if(asdf.Panel_Parcial[i,j]==asdf.Panel_Parcial[asdf.seleccion_i, asdf.seleccion_j])
                            {
                                asdf.color[i, j] = "wheat";
                            }
                            else
                            {
                                asdf.color[i, j] = "white";
                            }
                        }
                    }

                }
                else
                {
                    for (int i = 0; i < 9; i++)
                    {
                        for (int j = 0; j < 9; j++)
                        {
                            if (asdf.Panel_Parcial[i, j] == Convert.ToChar(32))
                            {
                                asdf.color[i, j] = "white";
                            }
                        }
                    }
                    asdf.color[asdf.seleccion_i, asdf.seleccion_j] = "wheat";
                }
                
            }
            return PartialView("~/Views/Sudoku/PanelSudoku.cshtml", asdf);
        }
        
        public ActionResult colocar(int casilla)
        {
            /*int i, j;
            i = random.Next(0, 9);
            j = random.Next(0, 9);
            asdf.Panel_Parcial[i, j] = '1';
            return PartialView("~/Views/Sudoku/PanelSudoku.cshtml", asdf);*/
            if (asdf.color[asdf.seleccion_i, asdf.seleccion_j] == "wheat"&& casilla >0)
            {
                asdf.Panel_Parcial[asdf.seleccion_i, asdf.seleccion_j] =Convert.ToChar( casilla+48);
                asdf.contador++;
                if (asdf.contador>81)
                {
                    if (asdf.victoria(asdf))
                    {
                        asdf.victoria_1 = true;
                    }
                }
                for (int i = 0; i < 9; i++)
                {
                    for (int j = 0; j < 9; j++)
                    {
                        if (asdf.Panel_Parcial[asdf.seleccion_i, asdf.seleccion_j] == asdf.Panel_Parcial[i, j] && asdf.Panel_Parcial[asdf.seleccion_i, asdf.seleccion_j] != Convert.ToChar(32))
                        {
                            asdf.color[i, j] = "wheat";
                        }
                        else
                        {
                            asdf.color[i, j] = "white";
                        }
                    }
                }
            }
            else if (casilla == 0)
            {
                asdf.Panel_Parcial[asdf.seleccion_i, asdf.seleccion_j] = Convert.ToChar(32);
                asdf.contador--;
                
            }
            else
            {
                return PartialView("~/Views/Sudoku/PanelSudoku.cshtml", asdf);
            }
            return PartialView("~/Views/Sudoku/PanelSudoku.cshtml", asdf);

        }
        
        public ActionResult recargarelpanel()
        {
            
            return PartialView("~/Views/Sudoku/PanelSudoku.cshtml", asdf);
        }

        
        public ActionResult elbarto()
        {
            return Content("elbarto");
        }
    }
}