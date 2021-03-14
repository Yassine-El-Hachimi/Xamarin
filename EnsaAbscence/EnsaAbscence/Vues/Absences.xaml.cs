using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;
using Xamarin.Forms.Internals;
using Xamarin.Forms.Xaml;
using XLabs.Forms.Controls;

namespace EnsaAbscence
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class Absences : ContentPage
	{
            public Absences () 
		{
            
            InitializeComponent();
            Gender.SelectedIndexChanged += (object sender,EventArgs e) =>
              {
                  checkBoxContainer.Children.Clear();
                  for (var i = 0; i < 10; i++)
                {
                    checkBoxContainer.Children.Add(new CheckBox { DefaultText = Gender.SelectedItem.ToString() });
                }
            };
                
            
            
		}
        
        
    }
}