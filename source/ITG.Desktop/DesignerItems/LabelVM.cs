
namespace ITG.Desktop.DesignerItems
{
    public class LabelVM : DesignerItemBaseVM
    {
        public LabelVM() : base()
        {
            SetControlDefaults("Label", 32769, "Label"); // left-aligned label
            SetSizeConstraints(100, 4, 1000, 20, 10, 60);
            D_Caption = "Caption";
        }
    }
}

