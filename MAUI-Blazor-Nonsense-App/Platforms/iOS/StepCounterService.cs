#if IOS
using CoreMotion;
using Foundation;
using MAUI_Blazor_Nonsense_App.Services;

public class StepCounterService : IStepCounterService
{
    readonly CMPedometer pedometer = new();
    int steps;

    public event Action<int> OnStep;

    public void Start()
    {
        if (CMPedometer.IsStepCountingAvailable)
        {
            pedometer.StartPedometerUpdates(NSDate.Now, (data, error) =>
            {
                if (data != null)
                {
                    steps = data.NumberOfSteps.Int32Value;
                    OnStep?.Invoke(steps);
                }
            });
        }
    }

    public void Stop()
    {
        pedometer.StopPedometerUpdates();
    }
}
#endif
