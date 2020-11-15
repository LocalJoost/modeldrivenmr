using UniRx;

namespace ReactNativeDemo.State
{
    public class TwoButtonModel : ITwoButtonModel
    {
        public BoolReactiveProperty SelectOne { get; set; } = new BoolReactiveProperty();
        public BoolReactiveProperty SelectTwo { get; set; } = new BoolReactiveProperty();

    }
}
