namespace RKVCRYPT.Module.Chiffrement
{
    public partial class Chiffrement
    {
        internal int ProtocoleHexadecimal(int input)
        {

            return input;
        }
        internal string ProtocoleLectureBinarosk(string message, bool type)
        {
            if (type)
            {
                message = message.Replace("AAAAAA", "060").Replace("AAAAA", "050").Replace("AAAA", "040").Replace("AAA", "030").Replace("AA", "020").Replace("A", "010");
                message = message.Replace("BBBBBB", "061").Replace("BBBBB", "051").Replace("BBBB", "041").Replace("BBB", "031").Replace("BB", "021").Replace("B", "011");
            }
            else
            {
                int count = 4;
                for (int i = count - 1; i < message.Length; i += count)
                {
                    message = message.Insert(i, " ");
                }
                string[] m = message.Split(' ');
                message = "";
                for (int i = 0; i < m.Length; i++)
                {
                    switch (m[i])
                    {
                        case "010": m[i] = "A"; break;
                        case "020": m[i] = "AA"; break;
                        case "030": m[i] = "AAA"; break;
                        case "040": m[i] = "AAAA"; break;
                        case "050": m[i] = "AAAAA"; break;
                        case "060": m[i] = "AAAAAA"; break;
                        case "011": m[i] = "B"; break;
                        case "021": m[i] = "BB"; break;
                        case "031": m[i] = "BBB"; break;
                        case "041": m[i] = "BBBB"; break;
                        case "051": m[i] = "BBBBB"; break;
                        case "061": m[i] = "BBBBBB"; break;
                    }
                    message += m[i];
                }

            }
            return message;
        }
        internal string ProtocoleBinarosk(string message, bool type)
        {
            if (type)
            {
                return message.Replace("1", "BAAA").Replace("2","ABAA").Replace("3","AABA").Replace("4","AAAB").Replace("5", "BBAA").Replace("6", "AABB").Replace("7", "BABB").Replace("8", "BBAB").Replace("9","BAAB").Replace("0","ABBA");
            }
            else
            {
                int count = 5;
                for (int i = count - 1; i < message.Length; i += count)
                {
                    message = message.Insert(i, " ");
                }
                string[] m = message.Split(' ');
                message = "";
                for (int i = 0; i < m.Length; i++)
                {
                    switch (m[i])
                    {
                        case "BAAA": m[i] = "1"; break;
                        case "ABAA": m[i] = "2"; break;
                        case "AABA": m[i] = "3"; break;
                        case "AAAB": m[i] = "4"; break;
                        case "BBAA": m[i] = "5"; break;
                        case "AABB": m[i] = "6"; break;
                        case "BABB": m[i] = "7"; break;
                        case "BBAB": m[i] = "8"; break;
                        case "BAAB": m[i] = "9"; break;
                        case "ABBA": m[i] = "0"; break;
                    }
                    message += m[i];
                }
                return message.Replace("A", "0").Replace("B", "1");

            }
        }

    }
    
}
