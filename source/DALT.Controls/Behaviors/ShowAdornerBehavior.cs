using System.Windows;
using System.Linq;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Interactivity;
using System.Windows.Media;
using System.Windows.Data;
using System;

// ItemsControlAdorner
namespace DALT.Controls.Behaviors
{
    public class ShowAdornerBehavior : Behavior<Button>
    {
        public DataTemplate DataTemplate { get; set; }

        protected override void OnAttached()
        {
            this.AssociatedObject.Click += AssociatedObject_Click;
            base.OnAttached();
        }

        void AssociatedObject_Click(object sender, RoutedEventArgs e)
        {
            var adornerLayer = AdornerLayer.GetAdornerLayer(this.AssociatedObject);
            var contactAdorner = new ItemsControlAdorner(this.AssociatedObject, adornerLayer, this.AssociatedObject.DataContext, this.DataTemplate);
        }
    }


    
}