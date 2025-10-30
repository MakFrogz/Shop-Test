using System;

namespace VIP
{
    public class VIPWidgetController : IDisposable
    {
        private readonly VIPWidget _view;
        private readonly VIPProperty _model;

        public VIPWidgetController(VIPWidget view, VIPProperty model)
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
            _model.Modify(TimeSpan.FromSeconds(30d));
        }

        private void SetWidgetText()
        {
            _view.SetText($"{_model.Value.TotalSeconds} sec");
        }

        public void Dispose()
        {
            _view.Button.onClick.RemoveListener(OnCheatClick);
            _model.OnPropertyChanged -= SetWidgetText;
        }
    }
}