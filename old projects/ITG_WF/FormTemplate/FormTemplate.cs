using System;
using System.Collections.Generic;
using TextOps = ITG.Utilities.TextOps;

namespace ITG.DataLayer
{
    public class FormTemplate
    {

        #region FormTemplate Properties
        public string Name { get; set; }
        public string Signature { get; set; }
        public string Environment { get; set; }
        public string Author { get; set; }

        public int Width { get; set; }
        public int Height { get; set; }
        
        public int TabCount { get; set; }
        public string TabNames { get; set; }
        
        public string Options1 { get; set; }
        public string Options2 { get; set; }
#endregion

        public FormTemplate()
        {
            // Setup default properties
            Name = TextOps.QuoteWrap("New Template");
            Signature = TextOps.QuoteWrap("MedcinForm-v1.1");
            Environment = TextOps.QuoteWrap("AHLTA");
            Author = TextOps.QuoteWrap("Anonymous");
            Width = 1000;
            Height = 1000;
            TabCount = 1;
            TabNames = "Tab 1";
            Options1 = "";
            Options2 = "";
        }



    }
}
