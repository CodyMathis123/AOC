namespace AOC2024.Day4
{
    internal class XmasLetter
    {
        public XmasLetter(int column, int row, char letter)
        {
            Column = column;
            Row = row;
            Letter = letter;
        }

        public int Column { get; set; }
        public int Row { get; set; }
        public char Letter { get; set; }
    }
}