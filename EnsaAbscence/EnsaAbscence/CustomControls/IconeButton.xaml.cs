using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;


namespace EnsaAbscence.CustomControls
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class IconeButton : ContentView
    {
        public event EventHandler Clicked;
        public static readonly BindableProperty ButtonImage = BindableProperty.Create(nameof(Image), typeof(string), typeof(NavigationButton));
        public static readonly BindableProperty BgColor = BindableProperty.Create(nameof(FrameBackgroundColor), typeof(string), typeof(NavigationButton), "#fff");
        public static readonly BindableProperty CommandProperty = BindableProperty.Create(nameof(Command), typeof(ICommand), typeof(NavigationButton), null);
        public static readonly BindableProperty CommandPropertyParam = BindableProperty.Create(nameof(CommandParam), typeof(object), typeof(NavigationButton), null);

        

        public string Image
        {
            get => (string)GetValue(ButtonImage);
            set => SetValue(ButtonImage, value);
        }

        public string FrameBackgroundColor
        {
            get => (string)GetValue(BgColor);
            set => SetValue(BgColor, value);
        }

        public ICommand Command
        {
            get => (ICommand)GetValue(CommandProperty);
            set => SetValue(CommandProperty, value);
        }

        public object CommandParam
        {
            get => (object)GetValue(CommandPropertyParam);
            set => SetValue(CommandPropertyParam, value);
        }

        public IconeButton()
        {
            InitializeComponent();

            this.GestureRecognizers.Add(new TapGestureRecognizer
            {
                Command = new Command(() =>
                {
                    Clicked?.Invoke(this, EventArgs.Empty);
                    if (Command != null)
                    {
                        if (Command.CanExecute(CommandParam))
                            Command.Execute(CommandParam);
                    }
                })

            });
        }
        protected override void OnParentSet()
        {
            base.OnParentSet();
            btnIcon.Source = Image;
            myFrame.BackgroundColor = Color.FromHex(FrameBackgroundColor);
            

            stack.BackgroundColor = Color.FromHex(FrameBackgroundColor);
            btnIcon.BackgroundColor = Color.FromHex(FrameBackgroundColor);
        }
    }
}