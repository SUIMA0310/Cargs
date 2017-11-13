using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cargs.TypeAnalyses {
    internal interface ITargetInfo {

        bool IsMethod { get; }
        bool IsField { get; }
        bool IsProperty { get; }

        void SetData();

    }
}
