using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MAUI_Blazor_Nonsense_App.Services
{
    public interface IStepCounterService
    {
        event Action<int> OnStep;
        void Start();
        void Stop();
    }
}
