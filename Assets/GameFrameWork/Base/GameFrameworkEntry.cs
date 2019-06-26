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
            ReferencePool.ClearAll();

            // TODO GameFrameworkLog
        }

        /// <summary>
        /// 获取游戏框架模块
        /// </summary>
        /// <typeparam name="T"></typeparam>
        public static T GetModule<T>() where T : class
        {
            Type interfaceType = typeof(T);
            if(!interfaceType.IsInterface)
            {
                throw new GameFrameworkException(Utility.Text.Format("You must get module by interface, but '{0}' is not.", interfaceType.FullName));
            }

            if(!interfaceType.FullName.StartsWith("GameFramework."))
            {
                throw new GameFrameworkException(Utility.Text.Format("You must get a Game Framework module, but '{0}' is not.", interfaceType.FullName));
            }

            string moduleName = Utility.Text.Format("{0}.{1}", interfaceType.Namespace, interfaceType.Name.Substring(1));
            Type moduleType = Type.GetType(moduleName);
            if(moduleType == null)
            {   
                throw new GameFrameworkException(Utility.Text.Format("Can not find Game Framework module type '{0}'.", moduleName));
            }

            return GetModule(moduleType) as T;
        }

        /// <summary>
        /// 获取游戏框架模块
        /// </summary>
        /// <param name="moduleType"></param>
        /// <returns></returns>
        private static GameFrameWorkModule GetModule(Type moduleType)
        {
            foreach(GameFrameWorkModule module in s_GameFrameworkModules)
            {
                if(module.GetType() == moduleType)
                {
                    return module;
                }
            }

            return CreateModule(moduleType);
        }

        private static GameFrameWorkModule CreateModule(Type moduleType)
        {
            GameFrameWorkModule module = (GameFrameWorkModule)Activator.CreateInstance(moduleType);

            if(module == null)
            {
                throw new GameFrameworkException(Utility.Text.Format("Can not create module '{0}'. ", moduleType.FullName));
            }

            LinkedListNode<GameFrameWorkModule> current = s_GameFrameworkModules.First;
            while(current != null)
            {
                if(module.Priority > current.Value.Priority)
                {
                    break;
                }

                current = current.Next;
            }

            if(current != null)
            {
                s_GameFrameworkModules.AddBefore(current, module);
            }else{
                s_GameFrameworkModules.AddLast(current);
            }

            return module;
        }

    }

}