using System;
using System.Collections.Generic;
using System.Text;

namespace Case03.ViewModels
{
    internal class MainViewModel
    {
        private string _outputString = "Hello world!!!!!";
        /// <summary>
        /// すべて大文字に変換した文字列を取得します。
        /// </summary>
        public string OutputString
        {
            get { return _outputString; }
            private set
            {
                if (_outputString != value)
                {
                    _outputString = value;
                }
            }
        }

    }
}
