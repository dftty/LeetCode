using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class DesignALeaderboard : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Leaderboard l = new Leaderboard();

        l.AddScore(1, 73);
        l.AddScore(2, 56);
        l.AddScore(3, 39);
        l.AddScore(4, 51);
        l.AddScore(5, 4);
        l.Top(1);
        l.Reset(1);
        l.Reset(2);
        l.AddScore(2, 51);
        l.Top(3);
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public class Leaderboard {

        private Dictionary<int, int> playerDic;
        private SortedSet<KeyValuePair<int, int>> playerScore;

        public Leaderboard() {
            playerDic = new Dictionary<int, int>();
            playerScore = new SortedSet<KeyValuePair<int, int>>(
                new KeyValueCompare()
            );
        }
        
        public void AddScore(int playerId, int score) {
            if (playerDic.ContainsKey(playerId))
            {
                playerScore.Remove(new KeyValuePair<int, int>(playerDic[playerId], playerId));
                playerDic[playerId] += score;
            }else{
                playerDic.Add(playerId, score);
            }
            var a = playerScore.Add(new KeyValuePair<int, int>(playerDic[playerId], playerId));
        }
        
        public int Top(int K) {
            int res = 0;
            int count = 0;
            foreach (KeyValuePair<int, int> pair in playerScore)
            {
                res += pair.Key;
                count++;
                if (count == K) return res;
            }

            return res;
        }
        
        public void Reset(int playerId) {
            playerScore.Remove(new KeyValuePair<int, int>(playerDic[playerId], playerId));
            playerDic.Remove(playerId);
        }
    }

    
}

public class KeyValueCompare : IComparer<KeyValuePair<int, int>>
{
    public int Compare(KeyValuePair<int, int> a, KeyValuePair<int, int> b)
    {
        if (a.Key != b.Key)
        {
            return b.Key - a.Key;
        }
        return b.Value - a.Value;
    }
}
