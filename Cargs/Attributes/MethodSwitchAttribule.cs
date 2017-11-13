using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cargs.Attributes {

    public class MethodSwitchAttribule : CargsAttribule {

        public SwitchOptions[] Args { get; set; }
                        = new[] { SwitchOptions.None };

        public MethodSwitchAttribule() {
        }

        public MethodSwitchAttribule(params SwitchOptions[] args) {
            this.Args = args ?? throw new ArgumentNullException( nameof( args ) );
        }
    }

}
