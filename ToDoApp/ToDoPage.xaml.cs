﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoApp.Models;
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
        protected override void OnAppearing()
        {
            var todo = (ToDo)BindingContext;
            if (todo != null && !string.IsNullOrEmpty(todo.FileName)) 
            { 
                ToDoText.Text = File.ReadAllText(todo.FileName);
            }
        }

        private void OnSaveButton_Clicked(object sender, EventArgs e)
        {
            var todo = (ToDo)BindingContext;
            todo.Text = ToDoText.Text;
            if (string.IsNullOrEmpty(todo.FileName)) 
            {
                todo.FileName = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), $"{Path.GetRandomFileName()}.notes.txt");
            }
            todo.Text = ToDoText.Text;
            todo.FileName = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), $"{Path.GetRandomFileName()}.notes.txt");

            File.WriteAllText(todo.FileName, todo.Text);
            Navigation.PopModalAsync();
        }

        private void OnDeleteButton_Clicked(object sender, EventArgs e)
        {
            var todo = (ToDo)BindingContext;
            if (File.Exists(todo.FileName)) 
            { 
                File.Delete(todo.FileName);
            }
            ToDoText.Text = String.Empty;
            Navigation.PopModalAsync();
        }
    }
}