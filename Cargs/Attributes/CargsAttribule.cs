using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cargs.Attributes {

    public abstract class CargsAttribule : Attribute {

        /// <summary>
        /// 引数スイッチの短い名前
        /// </summary>
        public char? ShortSwitch { get; set; } = null;

        /// <summary>
        /// 引数スイッチの長い名前
        /// </summary>
        public string LongSwitch { get; set; } = null;

    }

}
