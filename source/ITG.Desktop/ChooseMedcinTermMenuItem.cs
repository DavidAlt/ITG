using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using ITG.Common;

namespace ITG.Desktop
{
    public class ChooseMedcinTermMenuItem : MenuItem
    {
        public ChooseMedcinTermMenuItem()
            : base()
        {
            SetupMenu();
            this.Click += ChooseMedcinTermMenuItem_Click;
        }

        private void ChooseMedcinTermMenuItem_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            Console.WriteLine("Clicked!");
            Console.WriteLine("Sender, Source, OriginalSource: {0}, {1}, {2}", sender, e.Source, e.OriginalSource);
        }

        private void SetupMenu()
        {
            // Tier 1: medcin term option
            this.Header = "Choose a Medcin term ...";

            // Tier 2: categories
            List<MenuItem> tier2 = new List<MenuItem>();
            foreach (Common.Category cat in Enum.GetValues(typeof(Common.Category)))
            {
                MenuItem item = new MenuItem();
                item.Header = cat.ToString();
                item.Tag = cat;
                tier2.Add(item);
            }

            // Tier 3: medcin terms
            foreach (var item in tier2)
            {
                IEnumerable<MedcinTerm> choices = MedcinData.ExtractBy((Category)item.Tag);
                item.ItemsSource = choices;
            }

            // Tie it all together
            this.ItemsSource = tier2;
        }


        
    }
}
