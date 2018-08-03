using lBook.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace lBook.ViewModel
{
    class ViewModel : NotifyClass
    {
        public string Header { get; set; }
        RelayCommand _closeCommand;
        public ICommand CloseCommand
        {
            get
            {
                if (_closeCommand == null)
                {
                    _closeCommand = new RelayCommand(
                       param => Close()
                       );
                }
                return _closeCommand;
            }
        }

        public event Action RequestClose;

        public virtual void Close()
        {
            if (RequestClose != null)
            {
                RequestClose();
            }
        }

    }
}
