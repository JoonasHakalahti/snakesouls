using System;
using UnityEngine;

namespace Assets.scripts 
{
    class Highscores
    {
        public Highscore[] scores;
        public int status;
        public string message;
    }

    [Serializable]
    class Highscore
    {
        public int id = 0;
        public string playername = "";
        public float score = 0.0f;
    }
}
