using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Telerik.Windows.Controls;
using System.Windows.Controls;
using System.Windows;

namespace Umetzu
{
    public class CustomFilterBehavior : ViewModelBase
    {
        private readonly RadGridView gridView = null;
        private readonly TextBox tb = null;

        private CustomFilterDescriptor _customFilterDescriptor;
        public CustomFilterDescriptor CustomFilterDescriptor
        {
            get
            {
                if (this._customFilterDescriptor == null)
                {
                    this._customFilterDescriptor = new CustomFilterDescriptor(this.gridView.Columns.OfType<Telerik.Windows.Controls.GridViewColumn>());
                    this.gridView.FilterDescriptors.Add(this._customFilterDescriptor);
                }
                return this._customFilterDescriptor;
            }
        }

        public static readonly DependencyProperty TextBoxProperty =
        DependencyProperty.RegisterAttached("TextBox", typeof(TextBox), typeof(CustomFilterBehavior),
            new PropertyMetadata(new PropertyChangedCallback(OnTextBoxPropertyChanged)));

        public static void SetTextBox(DependencyObject dependencyObject, TextBox tb)
        {
            dependencyObject.SetValue(TextBoxProperty, tb);
        }

        public static TextBox GetTextBox(DependencyObject dependencyObject)
        {
            return (TextBox)dependencyObject.GetValue(TextBoxProperty);
        }

        public static void OnTextBoxPropertyChanged(DependencyObject dependencyObject, DependencyPropertyChangedEventArgs e)
        {
            RadGridView grid = dependencyObject as RadGridView;
            TextBox tb = e.NewValue as TextBox;

            if (grid != null && tb != null)
            {
                CustomFilterBehavior behavior = new CustomFilterBehavior(grid, tb);
            }
        }

        public CustomFilterBehavior(RadGridView gridView, TextBox tb)
        {
            this.gridView = gridView;
            this.tb = tb;

            this.tb.TextChanged -= FilterValue_TextChanged;
            this.tb.TextChanged += FilterValue_TextChanged;
        }

        private void FilterValue_TextChanged(object sender, TextChangedEventArgs e)
        {
            this.CustomFilterDescriptor.FilterValue = tb.Text;
            tb.Focus();
        }
    }
}
