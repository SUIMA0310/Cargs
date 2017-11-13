using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cargs {

    public class Analyzer {

        #region Property

        /// <summary>
        /// 解析対象のオブジェクト
        /// </summary>
        protected object TargetObject { get; }

        /// <summary>
        /// 解析対象のオブジェクトのタイプ
        /// </summary>
        protected Type TargetType { get; }

        /// <summary>
        /// 解析する引数
        /// </summary>
        protected IEnumerable<string> Args { get; }

        #endregion

        #region Constructor

        /// <summary>
        /// コンストラクター
        /// </summary>
        /// <param name="targetObject">引数を解析する対象</param>
        /// <param name="args">解析する引数</param>
        public Analyzer(object targetObject, IEnumerable<string> args) {
            this.TargetObject = targetObject ?? throw new ArgumentNullException( nameof( targetObject ) );
            this.TargetType = this.TargetType.GetType();
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



    }

}
