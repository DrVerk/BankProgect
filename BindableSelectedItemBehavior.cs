using System.Windows;
using System.Windows.Controls;
using Microsoft.Xaml.Behaviors;

namespace BankProgect.BankClass.Base
{
    internal class BindableSelectedItemBehavior : Behavior<TreeView>
    {
        public object SelectedItem
        {
            get { return (object)GetValue(SelectedItemProperty); }
            set { SetValue(SelectedItemProperty, value); }
        }
        public static readonly DependencyProperty SelectedItemProperty =
            DependencyProperty.Register("SelectedItem", typeof(object),
            typeof(BindableSelectedItemBehavior), new UIPropertyMetadata(null, OnSelectedItemChanged));
        public static void OnSelectedItemChanged(DependencyObject sender, DependencyPropertyChangedEventArgs e)
        {
            var item = e.NewValue as TreeViewItem;
            if (item != null)
                item.SetValue(TreeViewItem.IsSelectedProperty, true);
        }
        protected override void OnAttached()
        {
            base.OnAttached();
            this.AssociatedObject.SelectedItemChanged += OnTreeViewSelectedItemChanged;
        }
        protected override void OnDetaching()
        {
            base.OnDetaching();
            this.AssociatedObject.SelectedItemChanged -= OnTreeViewSelectedItemChanged;
        }
        protected void OnTreeViewSelectedItemChanged(object sender, RoutedPropertyChangedEventArgs<object> e)
        {
            this.SelectedItem = e.NewValue;
        }
    }
}
