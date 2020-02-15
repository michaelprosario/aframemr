using AFrameMR.Core.Entities;
using System.Collections.Generic;

namespace AFrameMR.Core.Responses
{
    public class SceneParserResponse
    {
        public SceneParserResponse()
        {
            Scene = new AFrameScene();
        }

        public AFrameScene Scene {
            get;
            set;
        }
    }
}
