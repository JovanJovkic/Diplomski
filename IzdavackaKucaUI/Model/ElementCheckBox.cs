using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IzdavackaKucaUI.Model
{
    public class ElementCheckBox:BindableBase
    {
        private long id;
        private string text;
        private bool isSelected;

        public long Id { get => id; set { id = value; OnPropertyChanged("Id"); } }
        public string Text { get => text; set { text = value; OnPropertyChanged("Text"); } }
        public bool IsSelected { get => isSelected; set { isSelected = value; OnPropertyChanged("IsSelected"); } }

        public ElementCheckBox(long id, string text, bool isSelected)
        {
            Id = id;
            Text = text;
            IsSelected = isSelected;
        }
    }
}
