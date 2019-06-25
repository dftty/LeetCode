using System.Collections;
using System.Collections.Generic;

namespace GameFramework{

    internal abstract class GameFrameWorkModule
    {
        
        /// <summary>
        ///
        /// </summary>
        internal virtual int Priority
        {
            get
            {
                return 0;
            }
        }

        internal abstract void Update(float elapseSeconds, float realElapseSeconds);

        internal abstract void Shutdown();

    }

}

