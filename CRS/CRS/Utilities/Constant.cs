using System;
using System.Collections.Generic;
using System.Text;

namespace CRS.Utilities
{
    public class Constant
    {
        public static class ApiUrl
        {
            public static readonly string Login = "login/check";
        }

        public static class RatingPoint
        {
            public static readonly int Happy = 3; //Rất hài lòng
            public static readonly int Smile = 2; //Hài lòng
            public static readonly int Neutral = 1; //Bình thường
            public static readonly int Sad = 0; //Không hài lòng
        }
    }
}
