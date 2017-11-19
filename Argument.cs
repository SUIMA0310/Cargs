using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cargs.Util;

namespace Cargs {
    internal class Argument : IEquatable<Argument> {

        public static Argument[] GetArguments( IEnumerable<string> args ) {

            var list = new List<Argument>();
            foreach ( string arg in args ) {
                if ( arg.IsSwitch() ) {
                    list.Add( new Argument( arg.GetSwitch(), new List<string>() ) );
                } else {
                    (list.LastOrDefault()?.Options as List<string>)?.Add( arg );
                }
            }
            return list.ToArray();

        }

        public string Switch { get; }
        public bool HaveOption { get => Options?.Any() ?? false; }
        public IEnumerable<string> Options { get; }

        public Argument( IEnumerator<string> enu ) {

            string s = enu.Current;
            if ( !s.IsSwitch() ) {throw new ArgumentException( nameof(enu) );}
            Switch = s.GetSwitch();
            var list = new List<string>();
            while ( enu.MoveNext() ) {
                if ( enu.Current.IsSwitch() ) { break; }
                list.Add( enu.Current );
            }

        }

        internal Argument(string @switch, IEnumerable<string> options) {
            this.Switch = @switch ?? throw new ArgumentNullException( nameof( @switch ) );
            this.Options = options ?? throw new ArgumentNullException( nameof( options ) );
        }

        public override string ToString() {
            var builder = new StringBuilder();
            builder.Append( $"/{Switch}" );
            foreach ( string option in Options ) {
                builder.Append( $" {option}" );
            }
            return builder.ToString();
        }

        public override bool Equals(object obj) {
            return this.Equals( obj as Argument );
        }

        public bool Equals(Argument other) {
            return other != null &&
                     this.Switch == other.Switch &&
                    EqualityComparer<IEnumerable<string>>.Default.Equals( this.Options, other.Options );
        }

        public override int GetHashCode() {
            var hashCode = -961672578;
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode( this.Switch );
            hashCode = hashCode * -1521134295 + EqualityComparer<IEnumerable<string>>.Default.GetHashCode( this.Options );
            return hashCode;
        }
    }
}
