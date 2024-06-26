using System;
namespace CRS.Models
{
	public class MyException : Exception
	{
		public int Code { get; set; }
        public string Msg { get; set; }

		public MyException(int code, string msg)
		{
			Code = code;
            Msg = msg;
		}
    }
}

