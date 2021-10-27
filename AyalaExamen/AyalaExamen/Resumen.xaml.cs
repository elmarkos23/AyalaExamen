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
  public partial class Resumen : ContentPage
  {
    /// <summary>
    /// Varianle del usuario conectado
    /// </summary>
    public string usuarioConectado { get; set; }
    /// <summary>
    /// Constructor
    /// </summary>
    /// <param name="usuarioConectado"></param>
    /// <param name="nombre"></param>
    /// <param name="totalPagar"></param>
    public Resumen(string usuarioConectado, string nombre, double totalPagar)
    {
      InitializeComponent();
      this.usuarioConectado = usuarioConectado;
      lblUsuarioConectado.Text = usuarioConectado;
      lblNombre.Text = nombre;
      lblTotalPagar.Text = totalPagar.ToString("F2");
    }
  }
}