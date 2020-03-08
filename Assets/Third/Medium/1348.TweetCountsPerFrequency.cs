using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;


namespace Third
{

    public class TweetCountsPerFrequency : MonoBehaviour
    {
        // Start is called before the first frame update
        void Start()
        {
            
        }

        // Update is called once per frame
        void Update()
        {
            
        }

        public class TweetCounts {

            Dictionary<string, SortedSet<int>> dic;

            public TweetCounts() {
                dic = new Dictionary<string, SortedSet<int>>();
            }   
            
            public void RecordTweet(string tweetName, int time) {
                if (!dic.ContainsKey(tweetName))
                {
                    dic.Add(tweetName, new SortedSet<int>());
                }

                dic[tweetName].Add(time);
            }
            
            public IList<int> GetTweetCountsPerFrequency(string freq, string tweetName, int startTime, int endTime) {
                int interval = 60;
                if (freq == "hour")
                {
                    interval *= 60;
                }
                else if (freq == "day")
                {
                    interval = interval * 60 * 12;
                }

                SortedSet<int> set = dic[tweetName].GetViewBetween(startTime, endTime);
                IList<int> list = new List<int>();

                int count = (int)Math.Ceiling((float)(endTime - startTime + 1) / interval);

                for (int i = 0; i < count; i++){
                    list.Add(0);
                }

                int index = 0;
                foreach (int num in set)
                {
                    if (num >= startTime && num < startTime + interval)
                    {
                        list[index]++;
                    }
                    else
                    {
                        index++;
                        list[index]++;
                        startTime += interval;
                    }
                }

                return list;
            }
        }
    }

}