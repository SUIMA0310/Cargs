using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cargs.Attributes {

    [AttributeUsage(AttributeTargets.Method)]
    public class MethodSwitchAttribute : CargsAttribute {

        public SwitchOptions[] Args { get; set; }
                        = new[] { SwitchOptions.None };

        #region Constructor

        public MethodSwitchAttribute(char shortSwitch) : base(shortSwitch){
        }

        public MethodSwitchAttribute(string longSwitch) : base( longSwitch ) {
        }

        public MethodSwitchAttribute(char shortSwitch, string longSwitch) : base( shortSwitch, longSwitch ) {
        }

        public MethodSwitchAttribute(string longSwitch, params SwitchOptions[] args) : base( longSwitch ) {
            this.Args = args 
                ?? throw new ArgumentNullException( nameof( args ) );
        }

        public MethodSwitchAttribute(char shortSwitch, params SwitchOptions[] args) : base( shortSwitch ) {
            this.Args = args 
                ?? throw new ArgumentNullException( nameof( args ) );
        }

        public MethodSwitchAttribute(char shortSwitch, string longSwitch, params SwitchOptions[] args) : base( shortSwitch, longSwitch ) {
            this.Args = args 
                ?? throw new ArgumentNullException( nameof( args ) );
        }

        #endregion

    }

}
