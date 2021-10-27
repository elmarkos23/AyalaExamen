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
  public partial class Login : ContentPage
  {
    /// <summary>
    /// Nombre de usuario para login
    /// </summary>
    const string usuario = "estudiante2021";
    /// <summary>
    /// Contraseña para el login
    /// </summary>
    const string contrasenia = "uisrael2021";
    /// <summary>
    /// Constrcutor
    /// </summary>
    public Login()
    {
      InitializeComponent();
    }

    /// <summary>
    /// Evento para el boton ingresar
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private async void btnIngresar_Clicked(object sender, EventArgs e)
    {
      if (Validacion())
      {
        if (txtUsuario.Text.Equals(usuario) && txtContrasenia.Text.Equals(contrasenia))
        {
          App.Current.MainPage = new NavigationPage(new Registro(txtUsuario.Text));
        }
        else
        {
          await DisplayAlert("Error", "Los datos son incorrectos", "Aceptar");
        }
      }
    }
    /// <summary>
    /// Metodo que valida los textos
    /// </summary>
    /// <returns></returns>
    private bool Validacion()
    {
      bool resultado = true;
      if (String.IsNullOrEmpty(txtUsuario.Text))
      {
        resultado = false;
        DisplayAlert("Mensaje", "Ingrese el usuario", "Aceptar");
      }
      else if (String.IsNullOrEmpty(txtContrasenia.Text))
      {
        resultado = false;
        DisplayAlert("Mensaje", "Ingrese la clave", "Aceptar");
      }
      return resultado;
    }
  }
}