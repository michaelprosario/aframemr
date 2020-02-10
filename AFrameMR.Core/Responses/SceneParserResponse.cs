using AFrameMR.Core.Entities;
using System.Collections.Generic;

namespace AFrameMR.Core.Responses
{
    public class SceneParserResponse
    {
        public List<DocumentElement> DocumentElements;

        public SceneParserResponse()
        {
            DocumentElements = new List<DocumentElement>();
        }
    }
}
