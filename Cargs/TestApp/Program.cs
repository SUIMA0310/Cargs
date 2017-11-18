using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cargs;
using Cargs.Attributes;

namespace TestApp {
    class Program {
        static void Main(string[] args) {

            var test = new TestClass();
            var analyzer = new Analyzer( test, new[] { "aaa", "/method", "125", "25", "/a", "/Help" } );

            analyzer.DoAnalyze();

        }
    }

    public class TestClass {

        [PropSwitch( 'a', "aaa" )]
        public bool BoolProp { get; set; }
        [PropSwitch( "bbb" )]
        public bool PublicBoolProp { get; set; }

        [PropSwitch( 'c' )]
        public static string StaticBoolProp { get; set; }
        [PropSwitch( 'd' )]
        public static bool PublicStaticBoolProp { get; set; }

        [MethodSwitch('?', "help")]
        public static void Help() {
            Console.WriteLine( "I am help." );
        }

        [MethodSwitch("method",SwitchOptions.Int, SwitchOptions.Int)]
        public void Method(int i, int l) {

            Console.WriteLine( $"{i} + {l} = {i+l};" );

        }

    }
}
