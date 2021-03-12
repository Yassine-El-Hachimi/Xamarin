using EnsaAbscence.ModelControllers;
using System;
using System.IO;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace EnsaAbscence
{
    public partial class App : Application
    {
        static UserRepository usr;
        public static UserRepository Usr
        {
            get
            {
                if (usr == null)
                {
                    usr = new UserRepository(Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal), "GestionAbsences.db3"));
                }

                return usr;

            }
        }

        public App()
        {
            InitializeComponent();

            MainPage = new NavigationPage(new MainPage());

        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
