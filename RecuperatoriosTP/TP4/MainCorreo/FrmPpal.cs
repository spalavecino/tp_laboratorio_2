﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Entidades;

namespace MainCorreo
{
    public partial class FrmPpal : Form
    {
        private Correo correo;

        public FrmPpal()
        {
            InitializeComponent();
            correo = new Correo();
            lstEstadoEntregado.ContextMenuStrip = cmsListas;
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            
            Paquete paquete = new Paquete(txtDireccion.Text, maskedTextBox1.Text);
            paquete.InformaEstado += paq_InformaEstado;
            paquete.InformaExcepcion += paqInformaExcepcion;

            try
            {
                correo = correo + paquete;
            }catch(TrackingIdRepetidoException ex)
            {
                Console.WriteLine(ex.Message);
                MessageBox.Show(ex.Message, "Paquete repetido");
                // Ver que tiene que hacer, si mostrarlo en el form o solo imprimir por consola
            }

            ActualizarEstados();
        }

        /// <summary>
        /// Reinicia las listas de paquetes en cada estado y vuelve a reasignarlos
        /// </summary>
        private void ActualizarEstados()
        {
            lstEstadoEntregado.Items.Clear();
            lstEstadoEnViaje.Items.Clear();
            lstEstadoIngresado.Items.Clear();

            foreach(var paquete in correo.Paquetes)
            {
                switch (paquete.Estado)
                {
                    case Paquete.EEstado.Ingresado:
                        lstEstadoIngresado.Items.Add(paquete);
                        break;
                    case Paquete.EEstado.EnViaje:
                        lstEstadoEnViaje.Items.Add(paquete);
                        break;
                    case Paquete.EEstado.Entregado:
                        lstEstadoEntregado.Items.Add(paquete);
                        break;
                }
            }
        }

        /// <summary>
        /// Actualiza el estado de los paquetes
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void paq_InformaEstado(object sender, EventArgs e)
        {
            if (this.InvokeRequired)
            {
                Paquete.DelegadoEstado d = new Paquete.DelegadoEstado(paq_InformaEstado);
                this.Invoke(d, new object[] { sender, e });
            }
            else
            {
                ActualizarEstados();
            }                
        }

        /// <summary>
        /// Muestra un mensaje al capturar el evento de falla al ingresar datos en la base
        /// </summary>
        /// <param name="e"></param>
        private void paqInformaExcepcion(Exception e)
        {
            MessageBox.Show(e.Message, "Error al persistir datos");
            Console.WriteLine(e.Message + " -> Error que lo generó: " + e.InnerException.InnerException);
        }

        /// <summary>
        /// Muestra los datos del paquete seleccionado en estado "Entregado"
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="elemento"></param>
        private void MostrarInformacion<T>(IMostrar<T> elemento)
        {
            if(elemento != null)
            {
                rtbMostrar.Text = elemento.MostrarDatos(elemento);
                rtbMostrar.Text.Guardar("salida.txt");
            }
        }

        private void FrmPpal_FormClosing(object sender, FormClosingEventArgs e)
        {
            correo.FinEntregas();
        }

        private void btnMostrarTodos_Click(object sender, EventArgs e)
        {
            this.MostrarInformacion<List<Paquete>>((IMostrar<List<Paquete>>)correo);
        }

        private void mostrarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.MostrarInformacion<Paquete>((IMostrar<Paquete>)lstEstadoEntregado.SelectedItem);
        }
    }
}
