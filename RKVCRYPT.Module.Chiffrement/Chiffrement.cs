using System.Text.RegularExpressions;

namespace RKVCRYPT.Module.Chiffrement
{
    public partial class Chiffrement
    {
        private string tempString;
        private List<Ensemble> tableDeChiffrement;
        private string BinaroskLastString;
        public Chiffrement(string table)
        {
            BinaroskLastString = "";
            tempString = "";
            tableDeChiffrement = new List<Ensemble>();
            GenerationTableDeChiffrement(table);
        }
        public string Chiffrage(string message)
        {
            double l = 0;
            tempString = "";
            foreach (char c in message)
            {
                l++;
                foreach (Ensemble e in tableDeChiffrement)
                {
                    if (c == e.CharI)
                    {
                        if (tableDeChiffrement.Count < 100)
                        {
                            if (e.IntJ < 10)
                            {
                                tempString += $" 0{e.IntJ}";
                            }
                            else if (e.IntJ >= 10 && e.IntJ < 100)
                            {
                                tempString += $" {e.IntJ}";
                            }
                        }
                        else if (tableDeChiffrement.Count >= 100)
                        {
                            if (e.IntJ < 10)
                            {
                                tempString += $" 00{e.IntJ}";
                            }
                            else if (e.IntJ >= 10 && e.IntJ < 100)
                            {
                                tempString += $" 0{e.IntJ}";
                            }
                            else if (e.IntJ >= 100 && e.IntJ < 1000)
                            {
                                tempString += $" {e.IntJ}";
                            }
                        }
                        break;
                    }
                    
                }
                if (tempString.Length == 4)
                {
                    tempString = tempString.Replace(" ", "");
                }
                Console.WriteLine(l + "/" + message.Length);
            }
            return tempString;
        }
        public string Dechiffrage(string message)
        {
            string pattern = @"^[0-9]*$";
            Regex regex = new Regex(pattern);
            if (regex.IsMatch(message))
            {
                int count;
                tempString = "";
                if (tableDeChiffrement.Count < 100)
                {
                    count = 3;
                }
                else
                {
                    count = 4;
                }
                message = Space(message, count);
                int l = 0;
                string[] c = message.Split(' ');
                foreach (string s in c)
                {
                    l++;
                    foreach (Ensemble e in tableDeChiffrement)
                    {
                        if (Convert.ToInt32(s) == e.IntJ)
                        {
                            tempString += $"{e.CharI}";
                            break;
                        }
                    }
                    Console.WriteLine(l + "/" + c.Length);
                }
                return tempString;
            }
            else
            {
                return message;
            }
        }
        public string AddKey(string key, string message)
        {
            int count = 4;
            double l = 0;
            key = Binarosk(key, true, false);
            message = Chiffrage(message);
            while (key.Length != message.Length)
            {
                if (key.Length > message.Length)
                {
                    key = key.Remove(message.Length);
                }
                else if (key.Length < message.Length)
                {
                    key += key;
                }
                Console.WriteLine(key.Length + "/" + message.Length);
            }
            for (int i = count - 1; i < key.Length; i += count)
            {
                l++;
                key = key.Insert(i, " ");
                message = message.Insert(i, " ");
                if (i * 1000 / message.Length != l)
                {
                    l = i * 1000 / message.Length;
                    Console.WriteLine(l + "/1000");
                }
            }
            l = 0;
            string[] m = message.Split(' ');
            string[] k = key.Split(' ');
            for (int i = 0; i < m.Length; i++)
            {
                l++;
                Console.WriteLine(l + "/" + message.Length);
                m[i] = Convert.ToString(Convert.ToInt32(m[i]) + Convert.ToInt32(k[i]));
                if (m[i].Length == 1)
                {
                    m[i] = "00" + m[i];
                }
                else if (m[i].Length == 2)
                {
                    m[i] = "0" + m[i];
                }
            }
            message = "";
            foreach (string s in m)
            {
                message += s;
            }
            return message;
        }
        public string RemoveKey(string key, string message)
        {
            string patternTrue = @"^[0-9]*$";
            Regex t = new Regex(patternTrue);
            if (t.IsMatch(message) && message.Length != 0)
            {
                double l = 0;
                int count = 4;
                key = Binarosk(key, true, false);
                while (key.Length != message.Length)
                {
                    if (key.Length > message.Length)
                    {
                        key = key.Remove(message.Length);
                    }
                    else if (key.Length < message.Length)
                    {
                        key += key;
                    }
                    Console.WriteLine(key.Length + "/" + message.Length);
                }
                message = Space(message, count);
                key = Space(key, count);
                string[] m = message.Split(' ');
                string[] k = key.Split(' ');
                l = 0;
                for (int i = 0; i < m.Length; i++)
                {
                    l++;
                    Console.WriteLine(l + "/" + m.Length);
                    if (Convert.ToInt32(m[i]) <= Convert.ToInt32(k[i]))
                    {
                        m[i] += 125;
                    }

                    m[i] = Convert.ToString(Convert.ToInt32(m[i]) - Convert.ToInt32(k[i]));
                    if (m[i].Length == 1)
                    {
                        m[i] = "00" + m[i];
                    }
                    else if (m[i].Length == 2)
                    {
                        m[i] = "0" + m[i];
                    }
                }
                message = "";
                foreach (string s in m)
                {
                    message += s;
                }
                message = Dechiffrage(message);
            }
            return message;
        }
        public string Binarosk(string message, bool type, bool user)
        {
            if (type)
            {
                if (!user || !IntValidation(message))
                {
                    message = Chiffrage(message);
                }
                message = ProtocoleBinarosk(message, type);
                message = ProtocoleLectureBinarosk(message, type);
            }
            else
            {
                string pattern = @"^[0-6]*$";
                Regex rg = new Regex(pattern);
                if (rg.IsMatch(message))
                {
                    message = ProtocoleLectureBinarosk(message, type);
                    message = ProtocoleBinarosk(message, type);
                    if (BinaroskLastString.EndsWith('f'))
                    {
                        message = Dechiffrage(message);
                    }
                    if (user)
                    {
                        BinaroskLastString = BinaroskLastString.Remove(BinaroskLastString.Length - 1);
                    }
                }
            }
            return message;
        }
    }
}