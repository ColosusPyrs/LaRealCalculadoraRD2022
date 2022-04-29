using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LaRealCalculadoraRD2022
{
    public enum Operacion
    {
        NoDefinida = 0,
        Suma = 1,
        Resta = 2,
        Division = 3,
        Multiplicacion = 4,
        Modulo = 5
    }

    public partial class Form1 : Form
    {
        double valor1 = 0;
        double valor2 = 0;
        bool unNumero = false;
        Operacion operador = Operacion.NoDefinida;

        public Form1()
        {
            InitializeComponent();
        }

        private void LeerNumero(string numero)
        {
            unNumero = true;
            
            if (CajaResultado.Text == "0" && CajaResultado.Text != null)
            {
                CajaResultado.Text = numero;
            }
            else
            {
                CajaResultado.Text += numero;
            }
        }
        private double EjecutarOperacion()
        {
            double resultado = 0;

            switch (operador)
            {
                case Operacion.Suma:
                    resultado = valor1 + valor2;
                    break;
                case Operacion.Resta:
                    resultado = valor1 - valor2;
                    break;
                case Operacion.Division:
                    if(valor2 == 0)
                    {
                        lblHistorial.Text = ":v No se puede."; 
                        resultado = 0;
                    }
                    else
                    {
                        resultado = valor1 / valor2;
                    }
                    break;
                case Operacion.Multiplicacion:
                    resultado = valor1 * valor2;
                    break;
                case Operacion.Modulo:
                    resultado = valor1 % valor2;
                    break;
            }

            return resultado;
        }

        private void btn0_Click(object sender, EventArgs e)
        {
            unNumero = true;

            if(CajaResultado.Text == "0")
            {
                return;
            }
            else
            {
                CajaResultado.Text += "0";
            }
        }

        private void btn1_Click(object sender, EventArgs e)
        {
            LeerNumero("1");
        }

        private void btn2_Click(object sender, EventArgs e)
        {
            LeerNumero("2");
        }

        private void btn3_Click(object sender, EventArgs e)
        {
            LeerNumero("3");
        }

        private void btn4_Click(object sender, EventArgs e)
        {
            LeerNumero("4");
        }

        private void btn5_Click(object sender, EventArgs e)
        {
            LeerNumero("5");
        }

        private void btn6_Click(object sender, EventArgs e)
        {
            LeerNumero("6");
        }

        private void btn7_Click(object sender, EventArgs e)
        {
            LeerNumero("7");
        }

        private void btn8_Click(object sender, EventArgs e)
        {
            LeerNumero("8");
        }

        private void btn9_Click(object sender, EventArgs e)
        {
            LeerNumero("9");
        }

        private void ObtenerValor(string operador)
        {
            valor1 = Convert.ToDouble(CajaResultado.Text);
            lblHistorial.Text = CajaResultado.Text + operador;
            CajaResultado.Text = "0";
        }

        private void btnSumar_Click(object sender, EventArgs e)
        {
            operador = Operacion.Suma;
            ObtenerValor("+");
        }

        private void btnResultado_Click(object sender, EventArgs e)
        {
            if(valor2 == 0 && unNumero)
            {
                valor2 = Convert.ToDouble(CajaResultado.Text);
                lblHistorial.Text += valor2 + "=";
                double resultado = EjecutarOperacion();
                valor2 = valor1 = 0;
                unNumero = false;
                CajaResultado.Text = Convert.ToString(resultado);
            }
        }

        private void btnRestar_Click(object sender, EventArgs e)
        {
            operador = Operacion.Resta;
            ObtenerValor("-");
        }

        private void btnMultiplicar_Click(object sender, EventArgs e)
        {
            operador = Operacion.Multiplicacion;
            ObtenerValor("X");
        }

        private void btnDivision_Click(object sender, EventArgs e)
        {
            operador = Operacion.Division;
            ObtenerValor("/");
        }

        private void btnModulo_Click(object sender, EventArgs e)
        {
            operador = Operacion.Modulo;
            ObtenerValor("%");
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            CajaResultado.Text = "0";
            lblHistorial.Text = ":v";
        }

        private void btnBorrar_Click(object sender, EventArgs e)
        {
            if(CajaResultado.Text.Length > 1)
            {
                string txtResultado = CajaResultado.Text;
                txtResultado = txtResultado.Substring(0, txtResultado.Length - 1);

                if(txtResultado.Length == 1 && txtResultado.Contains("-"))
                {
                    CajaResultado.Text = "0";
                }
                else
                {
                    CajaResultado.Text = txtResultado;
                }
            }
            else
            {
                CajaResultado.Text = "0";
            }
        }

        private void btnPunto_Click(object sender, EventArgs e)
        {
            if (CajaResultado.Text.Contains("."))
            {
                return;
            }

            CajaResultado.Text += ".";
        }
    }
}
