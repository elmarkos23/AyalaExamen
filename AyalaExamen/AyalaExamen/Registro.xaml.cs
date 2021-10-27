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
    public double montoTotal { get; set; }
    public double montoInicial { get; set; }
    public double montoDiferencia { get; set; }
    public double valorCuota { get; set; }
    public double valorCuotaConInteres { get; set; }
    public double porcentajeInteresBase { get; set; }
    public double valorInteresBase { get; set; }
    public double totalPagar { get; set; }
    public Registro(string usuarioConectado)
    {
      InitializeComponent();
      montoTotal = 1800;
      porcentajeInteresBase = 5;
      valorInteresBase = ((montoTotal * porcentajeInteresBase) / 100);
      this.usuarioConectado = usuarioConectado;
      lblUsuarioConectado.Text = "Usuario conectado: " + this.usuarioConectado;

    }

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