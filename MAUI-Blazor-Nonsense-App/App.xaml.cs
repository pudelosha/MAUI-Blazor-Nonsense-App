namespace MAUI_Blazor_Nonsense_App
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
        }

        protected override Window CreateWindow(IActivationState? activationState)
        {
            return new Window(new MainPage()) { Title = "MAUI-Blazor-Nonsense-App" };
        }
    }
}
