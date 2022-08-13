namespace RKVCRYPT.Module.Chiffrement
{
    public class Chiffrement
    {
        private string tempString;
        private List<Ensemble> tableDeChiffrement;
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
    }
}