namespace RKVCRYPT.Module.Chiffrement
{
    internal class Ensemble
    {
        private char i;
        private int j;
        internal Ensemble(char i, int j)
        {
            this.i = i;
            this.j = j;
        }
        public char CharI
        {
            get { return i; }
        }
        public int IntJ
        {
            get { return j; }
        }
    }
}
