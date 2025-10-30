using Core;

namespace Shop
{
    public class BundleProperty : IProperty<BundleData>
    {
        public BundleData Value { get; private set; }
        
        public void SetValue(BundleData value)
        {
            Value = value;
        }

        public bool CanModify(BundleData value)
        {
            return true;
        }

        public void Modify(BundleData value)
        {
            SetValue(value);
        }
    }
}