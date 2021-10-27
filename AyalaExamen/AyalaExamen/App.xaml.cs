using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AyalaExamen
{
  public partial class App : Application
  {
    public App()
    {
      InitializeComponent();

      //Ingeso a la pantalla inicial
      MainPage = new NavigationPage(new Login());
    }

    protected override void OnStart()
    {
    }

    protected override void OnSleep()
    {
    }

    protected override void OnResume()
    {
    }
  }
}
