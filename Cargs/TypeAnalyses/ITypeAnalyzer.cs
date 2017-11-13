using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cargs.TypeAnalyses {

    internal interface ITypeAnalyzer {

        void TypeAnalysis( object obj );
        bool SwitchSearch( IEnumerator<string> enumerator, object obj ); 

    }

}
