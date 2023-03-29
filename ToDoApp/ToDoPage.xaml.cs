using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ToDoApp
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ToDoPage : ContentPage
    {
        public ToDoPage()
        {
            InitializeComponent();
        }

        private void OnSaveButton_Clicked(object sender, EventArgs e)
        {
            var todo = new ToDo();
            todo.Text = ToDoText.Text;
        }

        private void OnDeleteButton_Clicked(object sender, EventArgs e)
        {

        }
    }
}