using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AyalaExamen
{
  [XamlCompilation(XamlCompilationOptions.Compile)]
  public partial class Registro : ContentPage
  {
    /// <summary>
    /// Nombre del usuario
    /// </summary>
    public string usuarioConectado { get; set; }
    /// <summary>
    /// Monto total del curso
    /// </summary>
    public double montoTotal { get; set; }
    /// <summary>
    /// Monto inicial que debe pagar el usuario
    /// </summary>
    public double montoInicial { get; set; }
    /// <summary>
    /// Monto que restara monto total y monto inicial
    /// </summary>
    public double montoDiferencia { get; set; }
    /// <summary>
    /// Valor de la cuota es la division entre 3 de la diferencia 
    /// </summary>
    public double valorCuota { get; set; }
    /// <summary>
    /// Valor de la cuota con el interes aplicado del 5 5%
    /// </summary>
    public double valorCuotaConInteres { get; set; }
    /// <summary>
    /// Valor del 5 porciento
    /// </summary>
    public double porcentajeInteresBase { get; set; }
    /// <summary>
    /// Valor de la cuota con interes base
    /// </summary>
    public double valorInteresBase { get; set; }
    /// <summary>
    /// total a pagar es el monto inicial con cuota con interes por 3 cuotas
    /// </summary>
    public double totalPagar { get; set; }
    /// <summary>
    /// Constructor
    /// </summary>
    /// <param name="usuarioConectado"></param>
    public Registro(string usuarioConectado)
    {
      InitializeComponent();
      montoTotal = 1800;
      porcentajeInteresBase = 5;
      valorInteresBase = ((montoTotal * porcentajeInteresBase) / 100);
      this.usuarioConectado = usuarioConectado;
      lblUsuarioConectado.Text = "Usuario conectado: " + this.usuarioConectado;

    }

    /// <summary>
    /// Evento para calcular
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private async void btnCalcular_Clicked(object sender, EventArgs e)
    {
      if (Valida())
      {
        montoInicial = Convert.ToDouble(txtMontoInicial.Text);
        //resto la diferencia del valor inicial sobre monto total
        montoDiferencia = montoTotal - montoInicial;
        //calculo la cuota base
        valorCuota = montoDiferencia / 3;
        //calculo el valor de cada cuota mas el interes
        valorCuotaConInteres = valorCuota + valorInteresBase;
        //aqui sumo la diferencia mas 3 veces la cuota con su interes
        totalPagar = montoDiferencia + (valorCuotaConInteres + valorCuotaConInteres + valorCuotaConInteres);
        await Navigation.PushAsync(new Resumen(usuarioConectado, txtNombre.Text, totalPagar));
      }
    }
    /// <summary>
    /// Metodo para validar campos
    /// </summary>
    /// <returns></returns>
    public bool Valida()
    {
      bool resultado = true;
      if (String.IsNullOrEmpty(txtMontoInicial.Text))
      {
        resultado = false;
        DisplayAlert("Error", "El valor inicial no puede ser vacio", "Aceptar");
      }
      else if (Convert.ToDouble(txtMontoInicial.Text) < 0)
      {
        resultado = false;
        DisplayAlert("Error", "El valor inicial no puede ser cero", "Aceptar");
      }
      return resultado;
    }
  }
}