using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Input;

namespace HangarEstimates.Infrastructure.Controls
{
    public class EditableComboBox : ComboBox
    {
        public static readonly DependencyProperty MaxLengthProperty = DependencyProperty.Register(
            "EditableTextBox", typeof(int), typeof(EditableComboBox), new UIPropertyMetadata(int.MaxValue));

        public EditableComboBox()
        {
            // Avoid non-intuitive behavior

            this.IsTextSearchEnabled = false;

            this.IsEditable = true;
        }

        /// <summary>
        /// Gets or sets the maximum length of the text in the EditableTextBox.
        /// </summary>
        /// <value>The maximum length of the text in the EditableTextBox.</value>
        [Description("Maximum length of the text in the EditableTextBox.")]
        [Category("Editable ComboBox")]
        [DefaultValue(int.MaxValue)]
        public int MaxLength
        {
            [System.Diagnostics.DebuggerStepThrough]
            get
            {
                return (int)this.GetValue(MaxLengthProperty);
            }

            [System.Diagnostics.DebuggerStepThrough]
            set
            {
                this.SetValue(MaxLengthProperty, value);

                this.ApplyMaxLength();
            }
        }

        /// <summary>
        /// Gets a reference to the internal editable textbox.
        /// </summary>
        /// <value>A reference to the internal editable textbox.</value>
        /// <remarks>
        /// We need this to get access to the real MaxLength.
        /// </remarks>
        protected TextBox EditableTextBox
        {
            get
            {
                return this.GetTemplateChild("PART_EditableTextBox") as TextBox;
            }
        }

        /// <summary>
        /// Makes sure that the design time settings are applied when the control 
        /// becomes operational. If the MaxLength setter is called too early, we miss
        /// the assignment.
        /// </summary>
        /// <remarks>
        /// This feels like a hack, but
        /// - OnInitialized is fired too early
        /// - OnRender in fired too often
        /// </remarks>
        public override void OnApplyTemplate()
        {
            base.OnApplyTemplate();

            this.ApplyMaxLength();
        }

        /// <summary>    
        /// Updates the Text property binding when the user presses the Enter key.  
        /// </summary>
        /// <remarks>
        /// KeyDown is not raised for Arrows, Tab and Enter keys.
        /// They are swallowed by the DropDown if it is open.
        /// So use the KeyUp instead.   
        /// </remarks>
        /// <param name="e">A Key EventArgs.</param>
        protected override void OnKeyUp(KeyEventArgs e)
        {
            base.OnKeyUp(e);

            if (e.Key == Key.Return || e.Key == Key.Enter)
            {
                this.UpdateDataSource();
            }
        }

        /// <summary>    
        /// Updates the Text property binding when the selection changes. 
        /// </summary>
        /// <param name="e">A SelectionChanged EventArgs.</param>
        protected override void OnSelectionChanged(SelectionChangedEventArgs e)
        {
            base.OnSelectionChanged(e);

            this.UpdateDataSource();
        }

        /// <summary>
        /// Applies the MaxLength value to the EditableTextBox.
        /// </summary>
        private void ApplyMaxLength()
        {
            if (this.EditableTextBox != null)
            {
                this.EditableTextBox.MaxLength = this.MaxLength;
            }
        }

        /// <summary>    
        /// Updates the data source.
        /// </summary>    
        private void UpdateDataSource()
        {
            BindingExpression expression = this.GetBindingExpression(ComboBox.TextProperty);

            if (expression != null)
            {
                expression.UpdateSource();
            }
        }
    }
}
