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
            string key1 = "";
            int count = 4;
            this.key = key;
            key1 = Chiffrage(key);
            message = Chiffrage(message);
            while(key1.Length <= message.Length)
            {
                    key1 += $"{key1}";
            }
            key1 = key1.Insert(message.Length, "~");
            string[] key2 = key1.Split('~');
            key1 = key2[0];
            for (int i = count - 1; i < key1.Length; i += count)
            {
                key1 = key1.Insert(i, " ");
            }
            for (int i = count - 1; i < message.Length; i += count)
            {
                message = message.Insert(i, " ");
            }
            string[] m = message.Split(' ');
            string[] k = key1.Split(' ');
            for (int i = 0; i < m.Length; i++)
            {
                if(m.Length == k.Length)
                {
                    count = Convert.ToInt32(m[i]);
                    key1 = Convert.ToString($"{count + Convert.ToInt32(k[i])}");
                    if (key1.Length == 2)
                    {
                        key1 = $"0{key1}";
                    }
                    m[i] = key1;
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
            string key1 = "";
            int count = 4;
            this.key = key;
            key1 = Chiffrage(key);
            while (key1.Length <= message.Length)
            {
                key1 += $"{key1}";
            }
            key1 = key1.Insert(message.Length, "~");
            string[] key2 = key1.Split('~');
            key1 = key2[0];
            for (int i = count - 1; i < key1.Length; i += count)
            {
                key1 = key1.Insert(i, " ");
            }
            for (int i = count - 1; i < message.Length; i += count)
            {
                message = message.Insert(i, " ");
            }
            string[] m = message.Split(' ');
            string[] k = key1.Split(' ');
            for (int i = 0; i < m.Length; i++)
            {
                if (m.Length == k.Length)
                {
                    count = Convert.ToInt32(m[i]);
                    key1 = Convert.ToString($"{count - Convert.ToInt32(k[i])}");
                    if(key1.Length == 1)
                    {
                        key1 = $"00{key1}";
                    }
                    else if (key1.Length == 2)
                    {
                        key1 = $"0{key1}";
                    }
                    m[i] = key1;
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