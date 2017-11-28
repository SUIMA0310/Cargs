using System;
using System.Reflection;
using System.Linq;
using Cargs.Attributes;

namespace Cargs.SwitchTargets {
    internal class PropTarget : SwitchTarget<PropertyInfo, PropSwitchAttribute> {

        public static PropTarget[] GetPropTargets(object obj) {

            var info = obj.GetType().GetProperties();
            return info.AsParallel()
                       .Select( i => new { info = i, attr = i.GetCustomAttribute<PropSwitchAttribute>() } )
                       .Where( s => s.attr != null )
                       .Select( a => new PropTarget { Info = a.info, Attribute = a.attr, Instance = obj } )
                       .ToArray();

        }


        public override void OnSwitch(Argument arg) {
            switch ( Attribute.Option ) {
                case SwitchOptions.None: {
                    Info.SetValue( Instance, true );
                    break;
                }
                case SwitchOptions.String: {
                    Info.SetValue( Instance, arg.Options.First() );
                    break;
                }
                case SwitchOptions.Int: {
                    Info.SetValue( Instance, int.Parse( arg.Options.First() ) );
                    break;
                }
                case SwitchOptions.Double: {
                    Info.SetValue( Instance, double.Parse( arg.Options.First() ) );
                    break;
                }
                default: {
                    throw new ArgumentException( nameof( PropSwitchAttribute.Option ) );
                }
            }
        }

    }
}
