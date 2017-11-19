using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cargs.Util;
using Cargs.Exceptions;
using Cargs.SwitchTargets;

namespace Cargs {

    public class Analyzer {

        /// <summary>
        /// 引数の解析を行います
        /// </summary>
        /// <param name="targetObject">アクションを起こすインスタンス</param>
        /// <param name="args">コマンドライン引数</param>
        public static void Analyze(object targetObject, IEnumerable<string> args) {

            new Analyzer( targetObject, args ).DoAnalyze();

        }

        #region Property

        /// <summary>
        /// 解析対象のオブジェクト
        /// </summary>
        public object TargetObject { get; }

        /// <summary>
        /// 解析対象のオブジェクトのタイプ
        /// </summary>
        public Type TargetType { get; }

        /// <summary>
        /// 解析する引数
        /// </summary>
        public IEnumerable<string> Args { get; }

        /// <summary>
        /// 解析できなかった引数
        /// </summary>
        public IEnumerable<string> UnknowSwitchs { get; } = new List<string>();

        #endregion

        #region Constructor

        /// <summary>
        /// コンストラクター
        /// </summary>
        /// <param name="targetObject">引数を解析する対象</param>
        /// <param name="args">解析する引数</param>
        public Analyzer(object targetObject, IEnumerable<string> args) {
            this.TargetObject = targetObject ?? throw new ArgumentNullException( nameof( targetObject ) );
            this.TargetType = this.TargetObject.GetType();
            this.Args = args ?? throw new ArgumentNullException( nameof( args ) );
        }

        /// <summary>
        /// コンストラクター
        /// </summary>
        /// <param name="targetType">引数解析する型情報</param>
        /// <param name="args">解析する引数</param>
        public Analyzer(Type targetType, IEnumerable<string> args) {
            this.TargetType = targetType ?? throw new ArgumentNullException( nameof( targetType ) );
            this.TargetObject = Activator.CreateInstance( this.TargetType );
            this.Args = args ?? throw new ArgumentNullException( nameof( args ) );
        }



        #endregion

        public void DoAnalyze() {

            var Dic = new Dictionary<string, ISwitchTarget>();

            try {

                Dic.AddTarget( PropTarget.GetPropTargets( TargetObject ) );
                Dic.AddTarget( MethodTarget.GetMethodTargets( TargetObject ) );

            } catch( Exception ex ) {

                throw new CargsException( "属性指定が不正です", ex );

            }

            foreach ( var arg in Argument.GetArguments( Args ) ) {

                if ( Dic.ContainsKey(arg.Switch) ) {

                    Dic[arg.Switch].OnSwitch( arg );

                } else {

                    ( (List<string>)UnknowSwitchs ).Add( arg.ToString() );

                }

            }

        }

    }

}
