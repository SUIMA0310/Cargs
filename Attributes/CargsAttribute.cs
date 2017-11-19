using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cargs.Util;

namespace Cargs.Attributes {

    public abstract class CargsAttribute : Attribute {

        /// <summary>
        /// 引数スイッチの短い名前
        /// </summary>
        public char? ShortSwitch { get; set; } = null;

        /// <summary>
        /// 引数スイッチの長い名前
        /// </summary>
        public string LongSwitch { get; set; } = null;

        #region Constructor

        public CargsAttribute(char? shortSwitch) {
            this.ShortSwitch = shortSwitch?.ToUpper()
                ?? throw new ArgumentNullException( nameof( shortSwitch ) );
        }

        public CargsAttribute(string longSwitch) {
            this.LongSwitch = longSwitch?.ToUpper() 
                ?? throw new ArgumentNullException( nameof( longSwitch ) );
        }

        public CargsAttribute(char? shortSwitch, string longSwitch) : this( shortSwitch ) {
            this.LongSwitch = longSwitch?.ToUpper()
                ?? throw new ArgumentNullException( nameof( longSwitch ) );
        }

        #endregion

    }

}
