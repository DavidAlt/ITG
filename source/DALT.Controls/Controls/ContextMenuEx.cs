// Copied from ...
/*************************************************************************************

   Extended WPF Toolkit

   Copyright (C) 2007-2013 Xceed Software Inc.

   This program is provided to you under the terms of the Microsoft Public
   License (Ms-PL) as published at http://wpftoolkit.codeplex.com/license 

   For more features, controls, and fast professional support,
   pick up the Plus Edition at http://xceed.com/wpf_toolkit

   Stay informed: follow @datagrid on Twitter or Like http://facebook.com/datagrids

  ***********************************************************************************/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows;

namespace DALT.Controls.Controls
{
    public class ContextMenuEx : ContextMenu
    {
        static ContextMenuEx()
        {
        }

        public ContextMenuEx()
        {

        }

        protected override System.Windows.DependencyObject GetContainerForItemOverride()
        {
            return new MenuItemEx();
        }

        protected override void OnOpened(System.Windows.RoutedEventArgs e)
        {
            BindingOperations.GetBindingExpression(this, ItemsSourceProperty).UpdateTarget();

            base.OnOpened(e);
        }


    }
}

/* EXAMPLE OF USE:

<SomeControl x:Name="MyControlWithContextMenuEx">
    <SomeControl.ContextMenu>
        <dalt:ContextMenuEx ItemsSource="{Binding boundListOfMenuItemEx, RelativeSource={RelativeSource TemplatedParent}}">
            <dalt:ContextMenuEx.ItemContainerStyle>
                <Style TargetType="{x:Type dalt:MenuItemEx}" BasedOn="{StaticResource {x:Type MenuItem}}">
                    <Setter Property="HeaderTemplate" Value="{Binding Path=Root.Manager.DocumentPaneMenuItemHeaderTemplate}"/>
                    <Setter Property="HeaderTemplateSelector" Value="{Binding Path=Root.Manager.DocumentPaneMenuItemHeaderTemplateSelector}"/>
                    <Setter Property="IconTemplate" Value="{Binding Path=Root.Manager.IconContentTemplate}"/>
                    <Setter Property="IconTemplateSelector" Value="{Binding Path=Root.Manager.IconContentTemplateSelector}"/>
                    <Setter Property="Command" Value="{Binding Path=., Converter={StaticResource ActivateCommandLayoutItemFromLayoutModelConverter}}"/>
                </Style>
        </dalt:ContextMenuEx.ItemContainerStyle>
        </dalt:ContextMenuEx>
    </SomeControl.ContextMenu>
</SomeControl>
*/