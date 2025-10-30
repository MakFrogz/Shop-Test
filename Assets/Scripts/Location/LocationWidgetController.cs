using System;

namespace Location
{
    public class LocationWidgetController : IDisposable
    {
        private readonly LocationWidget _view;
        private readonly LocationProperty _model;

        public LocationWidgetController(LocationWidget view, LocationProperty model)
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
            _model.Modify("Forest");
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