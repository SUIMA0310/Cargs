using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cargs.Exceptions {

    /// <summary>
    /// Cargsに関する例外
    /// </summary>
    public class CargsException : Exception {
        public CargsException() { }
        public CargsException(string message) : base( message ) { }
        public CargsException(string message, Exception inner) : base( message, inner ) { }
        protected CargsException(
          System.Runtime.Serialization.SerializationInfo info,
          System.Runtime.Serialization.StreamingContext context) : base( info, context ) { }
    } 
    
}
