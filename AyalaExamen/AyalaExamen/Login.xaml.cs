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
    const string usuario = "estudiante2021";
    const string contrasenia = "uisrael2021";
    public Login()
    {
      InitializeComponent();
    }

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