﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CRUDEmpresa.EntityFramework;
using CRUDEmpresa.DAO;

namespace CRUDEmpresa
{
    /// <summary>
    /// Formulario de login
    /// </summary>
    public partial class login : Form
    {
        private dbempresaEntities context;
        private admin admin;

        public login()
        {
            InitializeComponent();
        }

        private void login_Load(object sender, EventArgs e)
        {
           this.context = new dbempresaEntities();
           this.admin =  this.context.admin.FirstOrDefault();
          
        }

        /// <summary>
        /// comprueba que el usuario y password son correctos en caso contrario 
        /// los textbox se pondran en modo warning.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)
        {
            var username = textBox1.Text;
            var password = textBox2.Text;

            if (username == admin.user && password == admin.pass) {
                menu m = new menu();
                // m.MdiParent = this;
                m.Show();
                this.Hide();
            }
            else
            {
                textBox1.ForeColor = Color.Red;
                textBox2.ForeColor = Color.Red;
            }
        }

        private void textBox1_Click(object sender, EventArgs e)
        {
            textBox1.ForeColor = Color.Black;
            textBox2.ForeColor = Color.Black;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            menu m = new menu();
            // m.MdiParent = this;
            m.Show();
            this.Hide();
        }
    }
}
