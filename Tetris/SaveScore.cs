using System;

namespace Tetris
{
    [Serializable]
    public class SaveScore
    {
      public int Score { get; set;}
      public DateTime date { get; set;}
      public SaveScore() { }
    }
    
}
