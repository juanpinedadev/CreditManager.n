﻿using System;
using System.Windows.Forms;

namespace Presentacion
{
    internal static class Program
    {
        /// <summary>
        /// Punto de entrada principal para la aplicación.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            //Application.Run(new Formularios.FormularioPrincipal(new Entidades.Usuario()));
            Application.Run(new Formularios.FormularioLogin());
        }
    }
}