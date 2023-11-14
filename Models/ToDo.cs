using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

namespace MVVM_API_SampleProject.Models
{
    public class ToDo : INotifyPropertyChanged
    {
        private bool _completed;
        public int UserId { get; set; }
        public int Id { get; set; }
        public string Title { get; set; }
        public bool Completed{  get => _completed; set
            {
                if (_completed != value)
                {
                    _completed = value;
                    OnPropertyChanged(); // reports this property
                }
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged([CallerMemberName] string name = "") =>
       PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
    }


}
