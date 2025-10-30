using System;

namespace Health
{
    public class HealthWidgetController : IDisposable
    {
        private readonly HealthWidget _view;
        private readonly HealthProperty _model;

        public HealthWidgetController(HealthWidget view, HealthProperty model)
        {
            _view = view;
            _model = model;
        }

        public void Initialize()
        {
            SetWidgetText();
            _view.Button.onClick.AddListener(OnCheatClick);
            _model.OnPropertyChanged += SetWidgetText;
        }
        
        private void OnCheatClick()
        {
            _model.Modify(100);
        }

        private void SetWidgetText()
        {
            _view.SetText($"{_model.Value}");
        }

        public void Dispose()
        {
            _view.Button.onClick.RemoveListener(OnCheatClick);
            _model.OnPropertyChanged -= SetWidgetText;
        }
    }
}