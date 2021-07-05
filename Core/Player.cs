using System.Collections.Generic;

namespace Core
{
    public class Player
    {
        public int Lives { get; set; }
        
        public int Score { get; set; }
        
        public Platform Platform { get; set; }
        
        public List<Ball> Balls { get; set; }
        
        public List<Event> Effects { get; set; }
    }
}