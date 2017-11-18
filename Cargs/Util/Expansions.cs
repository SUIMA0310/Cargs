using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cargs.SwitchTargets;

namespace Cargs.Util {
    internal static class Expansions {

        public static bool IsSwitch(this string str) {

            return str.StartsWith( "/" ) && str.Length > 1;

        }

        public static string GetSwitch(this string str) {

            return str.Substring( 1 ).ToUpper();

        }

        public static char ToUpper(this char c) {
            return char.ToUpper( c );
        }

        public static void AddTarget(this IDictionary<string, ISwitchTarget> dic, IEnumerable<ISwitchTarget> switchTargets  ) {

            foreach ( var switchTarget in switchTargets ) {

                var attr = switchTarget.Attribute;
                if ( attr.ShortSwitch != null ) {
                    dic.Add( attr.ShortSwitch.ToString(), switchTarget );
                }
                if ( attr.LongSwitch != null ) {
                    dic.Add( attr.LongSwitch, switchTarget );
                }

            }

        }

    }
}
