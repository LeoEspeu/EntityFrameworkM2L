// <copyright file="Program.cs" company="Maison des Ligues de Lorraine">
// Copyright (c) Maison des Ligues de Lorraine. All rights reserved.
// </copyright>

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EntityFrameworkM2L
{
    /// <summary>
    /// Classe Program.
    /// Contient le point d'entrée de l'application.
    /// </summary>
    static class Program
    {
        /// <summary>
        /// Point d'entrée principal de l'application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new FrmPrincipale());
        }
    }
}