using System;
using UnityEngine;

namespace GameStatus
{
    [Serializable]
    public class InteractableInfo
    {
        [SerializeField] private string name;
        [SerializeField] private bool done;
        [SerializeField] private int score;

        public string Name { get => name; set => name = value; }
        public bool Done { get => done; 
            set { 
                done = value; 
                if(done)
                    ScoreManager.miss--; 
            } 
        }
        public int Score { get => score; set => score = value; }

        public InteractableInfo(string name)
        {
            this.name = name;

        }
    }
}
