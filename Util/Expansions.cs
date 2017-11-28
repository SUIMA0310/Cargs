using System;
using System.Collections.Generic;
using Cargs.SwitchTargets;

namespace Cargs.Util {
    internal static class Expansions {

        /// <summary>
        /// 文字列がSwitchかどうか判定します
        /// </summary>
        /// <returns>TRUE = Switchである / FALSE = Switchでない</returns>
        public static bool IsSwitch(this string str) {

            return str.StartsWith( "/" ) && str.Length > 1;
            
        }

        /// <summary>
        /// Switch名を取得します
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static string GetSwitch(this string str) {

            if (!str.IsSwitch()) {
                throw new ArgumentException($"{nameof( str )} is not switch.");
            }
            return str.Substring( 1 ).ToUpper();

        }

        /// <summary>
        /// 大文字に変換します
        /// </summary>
        public static char ToUpper(this char c) {
            return char.ToUpper( c );
        }

        /// <summary>
        /// DictionaryにTargetを追加します
        /// </summary>
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
