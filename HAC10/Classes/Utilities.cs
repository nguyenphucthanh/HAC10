using System;
using System.Text.RegularExpressions;

namespace HAC10
{
    public enum ConnectionType
    {
        Wifi,
        MobileData,
        None
    }

    public class Utilities
    {
        public static string ByteToString(byte[] buff)
        {
            string sbinary = "";
            for (int i = 0; i < buff.Length; i++)
                sbinary += buff[i].ToString("x2"); /* hex format */
            return sbinary;
        }   
    }

    public static class StringExtention
    {
        public static string RemoveDiacritics(this String str)
        {
            str = str.ToLower();
	        str = Regex.Replace(str, "/à|á|ạ|ả|ã|â|ầ|ấ|ậ|ẩ|ẫ|ă|ằ|ắ|ặ|ẳ|ẵ/g","a");
	        str = Regex.Replace(str, "/è|é|ẹ|ẻ|ẽ|ê|ề|ế|ệ|ể|ễ/g","e");
	        str = Regex.Replace(str, "/ì|í|ị|ỉ|ĩ/g","i");
	        str = Regex.Replace(str, "/ò|ó|ọ|ỏ|õ|ô|ồ|ố|ộ|ổ|ỗ|ơ|ờ|ớ|ợ|ở|ỡ/g","o");
	        str = Regex.Replace(str, "/ù|ú|ụ|ủ|ũ|ư|ừ|ứ|ự|ử|ữ/g","u");
	        str = Regex.Replace(str, "/ỳ|ý|ỵ|ỷ|ỹ/g","y");
	        str = Regex.Replace(str, "/đ/g","d");
	        str = Regex.Replace(str, @"/!|@|\$|%|\^|\*|\(|\)|\+|\=|\<|\>|\?|\/|,|\.|\:|\'| |\""|\&|\#|\[|\]|~/g","-");
	        str = Regex.Replace(str, "/-+-/g","-"); //thay thế 2- thành 1-
	        str = Regex.Replace(str, @"/^\-+|\-+$/g"," ");//cắt bỏ ký tự - ở đầu và cuối chuỗi
	        str = Regex.Replace(str, "/-/g", " "); // Thay tất cả - thành dấu khoảng trắng

            return str;
        }

        public static string PrepareSQLiteString(this String inputString)
        {
            string pattern = "[ăâđêôơưàảãạáằẳẵặắầẩẫậấèẻẽẹéềểễệếìỉĩịíòỏõọóồổỗộốờởỡợớùủũụúừửữựứỳỷỹỵýĂÂĐÊÔƠƯÀẢÃẠÁẰẲẴẶẮẦẨẪẬẤÈẺẼẸÉỀỂỄỆẾÌỈĨỊÍÒỎÕỌÓỒỔỖỘỐỜỞỠỢỚÙỦŨỤÚỪỬỮỰỨỲỶỸỴÝ]";
            return Regex.Replace(inputString, pattern, "_");
        }

        public static string SQLTrickDCharacter(this String inputString)
        {
            string pattern = "[dđDĐ]";
            return Regex.Replace(inputString, pattern, "_");
        }
    }
}