using System;

namespace Gold
{
    public class GoldWidgetController : IDisposable
    {
        private readonly GoldWidget _widget;
        private readonly GoldProperty _model;

        public GoldWidgetController(GoldWidget widget, GoldProperty model)
        {
            _widget = widget;
            _model = model;
        }

        public void Initialize()
        {
            SetWidgetText();
            _widget.Button.onClick.AddListener(OnCheatClick);
            _model.OnPropertyChanged += SetWidgetText;
        }

        private void OnCheatClick()
        {
            _model.Modify(100);
        }

        private void SetWidgetText()
        {
            _widget.SetText($"{_model.Value}");
        }

        public void Dispose()
        {
            _widget.Button.onClick.RemoveListener(OnCheatClick);
            _model.OnPropertyChanged -= SetWidgetText;
        }
    }
}