using System;
using System.Collections.Generic;
using System.Text;

namespace dystopia_sharp.Types
{
    public enum ForceTypes
    {
        Normal = 0,
        Include,
        Exclude
    }

    public class NoteData
    {
        // public NoteData Next { get; set; }
        public string Sender { get; set; }
        public string Date { get; set; }
        public string ToList { get; set; }
        public string Subject { get; set; }
        public string Text { get; set; }
        public DateTime DateStamp { get; set; }
        public DateTime Expire { get; set; }
    }

    public class BoardData
    {
        public string ShortName { get; set; }
        public string LongName { get; set; }
        public int ReadLevel { get; set; }
        public int WriteLevel { get; set; }
        public string Names { get; set; }
        public ForceTypes ForceType { get; set; }
        public NoteData[] Notes { get; set; }
        public bool Changed { get; set; }

        static readonly List<BoardData> boards = new List<BoardData>();

        public static int Lookup(string name)
        {
            for (int i = 0, count = boards.Count; i < count; ++i)
            {
                var board = boards[i];
                if (board.ShortName == name) return i;
            }
            return -1;
        }
    }
}
