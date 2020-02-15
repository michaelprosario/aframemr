using System.Collections.Generic;

namespace AFrameMR.Core.Entities
{
    public class AFrameScene
    {
        public List<DocumentElement> DocumentElements;

        public AFrameScene()
        {
            DocumentElements = new List<DocumentElement>();
        }
    }
}