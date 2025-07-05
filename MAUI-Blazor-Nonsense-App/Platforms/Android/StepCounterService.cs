#if ANDROID
using Android.Hardware;
using MAUI_Blazor_Nonsense_App.Services;

public class StepCounterService : Java.Lang.Object, ISensorEventListener, IStepCounterService
{
    SensorManager sensorManager;
    Sensor stepSensor;
    int steps;

    public event Action<int> OnStep;

    public void Start()
    {
        sensorManager = (SensorManager)Android.App.Application.Context.GetSystemService(Android.Content.Context.SensorService) as SensorManager;
        stepSensor = sensorManager?.GetDefaultSensor(SensorType.StepCounter);
        if (stepSensor != null)
            sensorManager.RegisterListener(this, stepSensor, SensorDelay.Ui);
    }

    public void Stop()
    {
        sensorManager?.UnregisterListener(this);
    }

    public void OnSensorChanged(SensorEvent e)
    {
        steps = (int)e.Values[0];
        OnStep?.Invoke(steps);
    }

    public void OnAccuracyChanged(Sensor sensor, SensorStatus accuracy) { }
}
#endif
