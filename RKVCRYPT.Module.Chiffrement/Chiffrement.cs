namespace RKVCRYPT.Module.Chiffrement
{
    public class Chiffrement
    {
        private string tempString;
        private List<Ensemble> tableDeChiffrement;
        private string key;
        public Chiffrement(string table)
        {
            tempString = "";
            tableDeChiffrement = new List<Ensemble>();
            GenerationTableDeChiffrement(table);
        }
        public void GenerationTableDeChiffrement(string table)
        {
            int j = 0;
            foreach (char c in table)
            {
                j++;
                tableDeChiffrement.Add(new Ensemble(c, j));
            }
        }
        public string Chiffrage(string message)
        {
            tempString = "";
            foreach(char c in message)
            {
                foreach (Ensemble e in tableDeChiffrement)
                {
                    if(c == e.CharI)
                    {
                        if (tableDeChiffrement.Count < 100)
                        {
                            if (e.IntJ < 10)
                            {
                                tempString += $"0{e.IntJ}";
                            }
                            else if (e.IntJ >= 10 && e.IntJ < 100)
                            {
                                tempString += $"{e.IntJ}";
                            }
                        }
                        else if (tableDeChiffrement.Count >= 100)
                        {
                            if (e.IntJ < 10)
                            {
                                tempString += $"00{e.IntJ}";
                            }
                            else if (e.IntJ >= 10 && e.IntJ < 100)
                            {
                                tempString += $"0{e.IntJ}";
                            }
                            else if (e.IntJ >= 100 && e.IntJ < 1000)
                            {
                                tempString += $"{e.IntJ}";
                            }
                        }
                        break;
                    }
                }
            }
            return tempString;
        }
        public string Dechiffrage(string message)
        {
            int count;
            tempString = "";
            if(tableDeChiffrement.Count < 100)
            {
                count = 3;
            }
            else
            {
                count = 4;
            }
            for (int i = count-1; i < message.Length; i+=count)
            {
                message = message.Insert(i," ");
            }

            string[] c = message.Split(' ');
            foreach (string s in c)
            {
                foreach (Ensemble e in tableDeChiffrement)
                {
                    if (Convert.ToInt32(s) == e.IntJ)
                    {
                        tempString += $"{e.CharI}";
                        break;
                    }
                }
            }
            return tempString;
        }
        public string AddKey(string key, string message)
        {
            int count = 4;
            key = Chiffrage(key);
            message = Chiffrage(message);
            while(key.Length != message.Length)
            {
                if (key.Length > message.Length)
                {
                   key = key.Remove(message.Length);
                }
                else if (key.Length < message.Length)
                {
                    key += key;
                }
            }
            for (int i = count - 1; i < key.Length; i += count)
            {
                key = key.Insert(i, " ");
            }
            for (int i = count - 1; i < message.Length; i += count)
            {
                message = message.Insert(i, " ");
            }
            string[] m = message.Split(' ');
            string[] k = key.Split(' ');
            for (int i = 0; i < m.Length; i++)
            {
                m[i] = Convert.ToString(Convert.ToInt32(m[i]) + Convert.ToInt32(k[i]));
                if (m[i].Length == 1)
                {
                    m[i] = "00"+m[i];
                }else if (m[i].Length == 2)
                {
                    m[i] = "0" + m[i];
                }
            }
            message = "";
            foreach(string s in m)
            {
                message += s;
            }
            return message;
        }
        public string RemoveKey(string key, string message)
        {
            int count = 4;
            key = Chiffrage(key);
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
            }
            for (int i = count - 1; i < key.Length; i += count)
            {
                key = key.Insert(i, " ");
            }
            for (int i = count - 1; i < message.Length; i += count)
            {
                message = message.Insert(i, " ");
            }
            string[] m = message.Split(' ');
            string[] k = key.Split(' ');
            for (int i = 0; i < m.Length; i++)
            {
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
            return Dechiffrage(message);
        }
    }
}