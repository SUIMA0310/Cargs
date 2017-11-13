using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cargs.Attributes {

    [AttributeUsage(AttributeTargets.Property)]
    public class PropSwitchAttribule : CargsAttribule {

        /// <summary>
        /// プロパティの型情報
        /// </summary>
        public SwitchOptions Option { get; set; } 
                        = SwitchOptions.None;

    }

}
