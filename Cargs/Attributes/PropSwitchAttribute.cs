using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cargs.Attributes {

    [AttributeUsage( AttributeTargets.Property )]
    public class PropSwitchAttribute : CargsAttribute {

        /// <summary>
        /// プロパティの型情報
        /// </summary>
        public SwitchOptions Option { get; set; }
                        = SwitchOptions.None;

        #region Constructor

        public PropSwitchAttribute(char shortSwitch) : base( shortSwitch ) {
        }

        public PropSwitchAttribute(string longSwitch) : base( longSwitch ) {
        }

        public PropSwitchAttribute(char shortSwitch, string longSwitch) : base( shortSwitch, longSwitch ) {
        }

        #endregion

        }

}
