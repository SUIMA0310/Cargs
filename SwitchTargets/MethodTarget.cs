using System;
using System.Reflection;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cargs.Attributes;

namespace Cargs.SwitchTargets {
    internal class MethodTarget : SwitchTarget<MethodInfo, MethodSwitchAttribute> {

        public static MethodTarget[] GetMethodTargets(object obj) {

            var info = obj.GetType().GetMethods();
            return info.AsParallel()
                       .Select( i => new { info = i, attr = i.GetCustomAttribute<MethodSwitchAttribute>() } )
                       .Where( s => s.attr != null )
                       .Select( a => new MethodTarget { Info = a.info, Attribute = a.attr, Instance = obj } )
                       .ToArray();

        }

        public override void OnSwitch(Argument arg) {

            Info.Invoke(Instance, GetObjects(Attribute.Args, arg.Options.ToArray() ) );

        }

        private object[] GetObjects( SwitchOptions[] optionTypes, string[] optionStrings ) {

            var list = new List<object>();

            foreach ( var item in optionTypes.Select( (option, index) => new { option, index } ) ) {

                switch ( item.option ) {
                    case SwitchOptions.String: {
                        list.Add( optionStrings[item.index] );
                        break;
                    }
                    case SwitchOptions.Int: {
                        list.Add( int.Parse( optionStrings[item.index] ) );
                        break;
                    }
                    case SwitchOptions.Double: {
                        list.Add( double.Parse( optionStrings[item.index] ) );
                        break;
                    }
                }

            }

            return list.ToArray();

        }

    }
}
