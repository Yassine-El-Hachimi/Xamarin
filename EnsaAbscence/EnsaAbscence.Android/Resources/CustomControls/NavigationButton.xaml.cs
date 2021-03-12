using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;


namespace EnsaAbscence.Droid.Resources.CustomControls
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class NavigationButton : ContentView
    {
        public event EventHandler Clicked;
        public static readonly BindableProperty ButtonText = BindableProperty.Create(nameof(Text), typeof(string), typeof(NavigationButton));
        public static readonly BindableProperty ButtonImage = BindableProperty.Create(nameof(Image), typeof(string), typeof(NavigationButton));
        public static readonly BindableProperty BgColor = BindableProperty.Create(nameof(FrameBackgroundColor), typeof(string), typeof(NavigationButton), "#fff");
        public static readonly BindableProperty TxtColor = BindableProperty.Create(nameof(TextColor), typeof(string), typeof(NavigationButton), "#000");
        public static readonly BindableProperty CommandProperty = BindableProperty.Create(nameof(Command), typeof(ICommand), typeof(NavigationButton), null);
        public static readonly BindableProperty CommandPropertyParam = BindableProperty.Create(nameof(CommandParam), typeof(object), typeof(NavigationButton), null);

        public string Text
        {
            get => (string)GetValue(ButtonText);
            set => SetValue(ButtonText, value);
        }

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

        public string TextColor
        {
            get => (string)GetValue(TxtColor);
            set => SetValue(TxtColor, value);
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

        public NavigationButton()
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
            btnText.Text = Text;
            myFrame.BackgroundColor = Color.FromHex(FrameBackgroundColor);
            btnText.TextColor = Color.FromHex(TextColor);

            stack.BackgroundColor = Color.FromHex(FrameBackgroundColor);
            btnText.BackgroundColor = Color.FromHex(FrameBackgroundColor);
            btnIcon.BackgroundColor = Color.FromHex(FrameBackgroundColor);
        }
    }
}