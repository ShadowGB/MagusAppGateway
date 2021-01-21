namespace MagusAppGateway.UI.Result
{
    public class ResultModel<T>
    {
        /// <summary>
        /// 返回状态信息
        /// </summary>
        public ResultStatus status { get; set; }

        /// <summary>
        /// 业务数据
        /// </summary>
        private T _custom;
        public T custom
        {
            get
            {
                //if (_custom == null)
                //    return new Array[0];
                return _custom;
            }
            set
            {
                _custom = value;
            }
        }


        /// <summary>
        /// 构造函数-默认失败
        /// </summary>
        public ResultModel()
        {
            status = new ResultStatus();
            status.code = ResultCode.Fail;
        }

        /// <summary>
        /// 构造函数-返回错误信息
        /// </summary>
        /// <param name="text">错误信息</param>
        public ResultModel(string text)
        {
            status = new ResultStatus();
            status.code = ResultCode.Fail;
            status.text = text;
        }

        /// <summary>
        /// 构造函数-返回信息和数据
        /// </summary>
        /// <param name="statusCode">状态码</param>
        /// <param name="text">信息</param>
        /// <param name="data">数据</param>
        public ResultModel(ResultCode statusCode, string text, T data)
        {
            status = new ResultStatus();
            status.code = statusCode;
            status.text = text;
            custom = data;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="statusCode">状态码</param>
        /// <param name="data">数据（注意不要放string数据，会调用到上一个构造函数）</param>
        public ResultModel(ResultCode statusCode, T data)
        {
            status = new ResultStatus();
            status.code = statusCode;
            custom = data;
        }
    }
}
