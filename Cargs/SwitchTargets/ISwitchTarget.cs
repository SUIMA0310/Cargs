using Cargs.Attributes;

namespace Cargs.SwitchTargets {
    internal interface ISwitchTarget {

        object Instance { get; set; }
        CargsAttribute Attribute { get; set; }
        object Info { get; set; }

        void OnSwitch(Argument arg);
    }

    internal interface ISwitchTarget<TInfo, TAttribute> : ISwitchTarget
        where TInfo : class
        where TAttribute : CargsAttribute {

        new object Instance { get; set; }
        new TAttribute Attribute { get; set; }
        new TInfo Info { get; set; }

    }
}