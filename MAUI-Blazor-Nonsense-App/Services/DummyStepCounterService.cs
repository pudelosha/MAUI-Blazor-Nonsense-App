using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MAUI_Blazor_Nonsense_App.Services
{
    public class DummyStepCounterService : IStepCounterService
    {
        public event Action<int> OnStep;

        public void Start() { }
        public void Stop() { }
    }
}
