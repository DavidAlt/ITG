using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DALT.Utility;
using ITG.Desktop.Models;

namespace ITG.Desktop.BaseClasses
{
    public abstract class TemplateItemBase : MovableCanvasItemBase
    {

        #region PUBLIC ACCESS

        public ItemDataOptionContainer ItemData
        {
            get { return _itemData; }
        }

        #endregion

        #region INHERITED ACCESS

        protected ItemDataOptionContainer _itemData = new ItemDataOptionContainer();

        protected TemplateItemBase() : base() { }

        #endregion
    }
}
