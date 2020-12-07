using Domain.Interfaces;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Olympics.Model
{
    public class WindowsClass : IOperatingSystemClass
    {
        public void ShowMessageBox(string header, string message)
        {
            MessageBox.Show(message, header, MessageBoxButton.OK, MessageBoxImage.Information);
        }
        public string GetImagePath(string imageName)
        {
            imageName = string.IsNullOrEmpty(imageName) ? string.Empty : imageName;

            var dialog = new OpenFileDialog();
           // dialog.Filter = "Image files (*.jpg, *.jpeg, *.jpe, *.jfif, *.png) | *.jpg; *.jpeg; *.jpe; *.jfif; *.png)";
            dialog.InitialDirectory = @"C:\Users\ibrah\source\repos\Olympics\Olympics\Images";
            dialog.Title = $"Browse {imageName} Image";

            if(dialog.ShowDialog() == true)
            {
                return dialog.FileName;
            }
            return string.Empty;
        }
    }
}
