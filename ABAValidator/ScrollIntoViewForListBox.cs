using System;
using System.Windows.Controls;
using System.Windows.Interactivity;

public class ScrollIntoViewForListBox : Behavior<ListBox>
{
    /// <summary>
    ///     When Beahvior is attached
    /// </summary>
    protected override void OnAttached()
    {
        base.OnAttached();
        AssociatedObject.SelectionChanged += AssociatedObject_SelectionChanged;
    }

    /// <summary>
    ///     On Selection Changed
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void AssociatedObject_SelectionChanged(object sender,
        SelectionChangedEventArgs e)
    {
        if (sender is ListBox)
        {
            var listBox = (sender as ListBox);
            if (listBox.SelectedItem != null)
            {
                listBox.Dispatcher.BeginInvoke(
                    (Action) (() =>
                    {
                        listBox.UpdateLayout();
                        if (listBox.SelectedItem !=
                            null)
                            listBox.ScrollIntoView(
                                listBox.SelectedItem);
                    }));
            }
        }
    }

    /// <summary>
    ///     When behavior is detached
    /// </summary>
    protected override void OnDetaching()
    {
        base.OnDetaching();
        AssociatedObject.SelectionChanged -=
            AssociatedObject_SelectionChanged;
    }
}