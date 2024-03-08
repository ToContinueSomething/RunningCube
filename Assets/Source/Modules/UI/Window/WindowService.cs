using Window.Source.Modules.UI.Window;

namespace Source.Modules.UI.Window
{
    public class WindowService
    {
        private readonly UIFactory _factory;

        public WindowService(UIFactory factory)
        {
            _factory = factory;
        }
        
        public TWindow Create<TWindow>() where TWindow : WindowBase
        {
           return _factory.CreateWindow<TWindow>();
        }
    }
}