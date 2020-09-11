namespace MagusAppGateway.Services.Result
{
    public class ResultStatus
    {
        /// <summary>
        /// 状态
        /// </summary>
        public ResultCode code { get; set; }

        /// <summary>
        /// 信息
        /// </summary>
        private string _text;
        public string text
        {
            get
            {
                if (_text == null)
                    return string.Empty;
                return _text;
            }
            set
            {
                _text = value;
            }
        }
    }
}
