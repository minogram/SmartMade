using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ReactiveUI;
using ReactiveUI.Fody.Helpers;
using PropertyChanged;
namespace SmartMade.ViewModels
{
    [AddINotifyPropertyChangedInterface]
    public class SummaryViewModel 
    {
        public DateTime Start { get; set; }
        public DateTime End { get; set; }
        public TimeSpan Elapsed => End - Start;
    }
}
