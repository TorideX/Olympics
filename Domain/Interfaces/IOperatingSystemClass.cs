using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public interface IOperatingSystemClass
    {
        void ShowMessageBox(string header, string message);
        string GetImagePath(string imageName);
    }
}
