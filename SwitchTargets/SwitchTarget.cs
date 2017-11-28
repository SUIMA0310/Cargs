using Cargs.Attributes;

namespace Cargs.SwitchTargets {
    internal abstract class SwitchTarget<TInfo,TAttribute> : ISwitchTarget<TInfo, TAttribute>
                where TInfo : class 
                where TAttribute : CargsAttribute  {

        public TInfo Info { get; set; }
        public TAttribute Attribute { get; set; }
        public object Instance { get; set; }
        CargsAttribute ISwitchTarget.Attribute {
            get => Attribute;
            set => Attribute = value as TAttribute;
        }
        object ISwitchTarget.Info {
            get => Info;
            set => Info = value as TInfo;
        }

        public abstract void OnSwitch(Argument arg );

    }
}
