﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ClinicaFrba.Login
{
    public partial class Cl_Login : Form
    {
        public Cl_Login()
        {
            InitializeComponent();
        }

        private void BtnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Btn_Aceptar_Click(object sender, EventArgs e)
        {
            Roles roles = new Roles();
            if (roles.rol_name.Equals("") == true)
            {
                roles.ShowDialog();
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        
    }
}