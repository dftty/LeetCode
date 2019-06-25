using System;
using System.Collections.Generic;

namespace GameFramework{

    public abstract class GameFrameworkEntry{

        private static readonly LinkedList<GameFrameWorkModule> s_GameFrameworkModules = new LinkedList<GameFrameWorkModule>();

        public static void Update(float elaspseSeconds, float realElapseSeconds)
        {
            foreach(GameFrameWorkModule module in s_GameFrameworkModules){
                module.Update(elaspseSeconds, realElapseSeconds);
            }
        }

        public static void Shutdown()
        {
            for(LinkedListNode<GameFrameWorkModule> current = s_GameFrameworkModules.Last; current != null; current = current.Previous){
                current.Value.Shutdown();
            }

            s_GameFrameworkModules.Clear();
        }

    }

}