using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using MasterDetail.Core.Extensions;
using Xamarin.Forms;

namespace MasterDetail.Forms.Controls
{
    public abstract class LimitedItemsView : StackLayout
    {
        public static readonly BindableProperty ItemsProperty =
            BindableProperty.Create(nameof(Items),
                typeof(IEnumerable),
                typeof(LimitedItemsView),
                null,
                propertyChanged: OnItemsChanged);

        public static readonly BindableProperty ItemTemplateProperty =
            BindableProperty.Create(nameof(ItemTemplate),
                typeof(DataTemplate),
                typeof(LimitedItemsView),
                null,
                propertyChanged: OnItemTemplateChanged);

        public static readonly BindableProperty LimitProperty =
            BindableProperty.Create(nameof(Limit),
                typeof(int),
                typeof(LimitedItemsView),
                1,
                propertyChanged: OnLimitChanged);

        public static readonly BindableProperty ClickableProperty =
            BindableProperty.Create(nameof(Clickable),
                typeof(bool),
                typeof(LimitedItemsView),
                false,
                propertyChanged: OnClickableChanged);

        public static readonly BindableProperty SelectedItemProperty =
            BindableProperty.Create(nameof(SelectedItem),
                typeof(object),
                typeof(LimitedItemsView),
                null,
                BindingMode.OneWayToSource);

        private readonly Button _seeMoreButton;
        private List<ViewButton> _buttons;
        private bool _isExpanded;
        private INotifyCollectionChanged _observedItems;

        protected LimitedItemsView()
        {
            Padding = 0;
            _seeMoreButton = new Button
            {
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.End
            };
            _seeMoreButton.Clicked += SeeMoreButtonOnClicked;
        }

        public IEnumerable Items
        {
            get => (IEnumerable) GetValue(ItemsProperty);
            set => SetValue(ItemsProperty, value);
        }

        public DataTemplate ItemTemplate
        {
            get => (DataTemplate) GetValue(ItemTemplateProperty);
            set => SetValue(ItemTemplateProperty, value);
        }

        public int Limit
        {
            get => (int) GetValue(LimitProperty);
            set => SetValue(LimitProperty, value);
        }

        public bool Clickable
        {
            get => (bool) GetValue(ClickableProperty);
            set => SetValue(ClickableProperty, value);
        }

        public object SelectedItem
        {
            get => GetValue(SelectedItemProperty);
            set => SetValue(SelectedItemProperty, value);
        }

        public event EventHandler<EventArgs> ItemClicked;

        private static void OnItemsChanged(BindableObject bindable, object oldvalue, object newvalue)
        {
            var list = (LimitedItemsView) bindable;

            list.UpdateItems();
        }

        private static void OnItemTemplateChanged(BindableObject bindable, object oldvalue, object newvalue)
        {
            var list = (LimitedItemsView) bindable;
            list.LoadChildren();
        }

        private static void OnLimitChanged(BindableObject bindable, object oldvalue, object newvalue)
        {
            var list = (LimitedItemsView) bindable;
            list.LoadChildren();
        }

        private static void OnClickableChanged(BindableObject bindable, object oldvalue, object newvalue)
        {
            var list = (LimitedItemsView) bindable;
            list.LoadChildren();
        }

        protected internal virtual void LoadChildren()
        {
            Clear();
            var count = Items?.Count() ?? 0;

            if (!(count > 0 && ItemTemplate != null)) return;

            var i = 0;
            foreach (var item in Items)
            {
                if (!_isExpanded && Limit >= 0 && i >= Limit) break;

                AddItem(item);
                i++;
            }

            if (i < count)
            {
                _seeMoreButton.Text = $"See {count - i} more";
                Children.Add(_seeMoreButton);
            }
        }

        private void AddItem(object item, int index = -1)
        {
            if (Clickable) _buttons = _buttons ?? new List<ViewButton>();

            var itemView = (View) ItemTemplate.CreateContent();
            itemView.BindingContext = item;
            if (Clickable)
            {
                index = index >= 0 && index <= _buttons.Count ? index : _buttons.Count;
                var button = new ViewButton();
                button.Clicked += ButtonOnClicked;
                button.Content = itemView;
                _buttons.Insert(index, button);
                AddView(button, index);
            }
            else
            {
                AddView(itemView, index);
            }
        }

        private void RemoveItem(int aindex)
        {
            _buttons.RemoveAt(aindex);
            RemoveView(aindex);
        }

        protected abstract void AddView(View view, int index = -1);

        protected abstract void RemoveView(int index);

        protected virtual void Clear()
        {
            DisconnectButtonEvents();
            _buttons?.Clear();
            Children.Clear();
        }

        protected virtual void SeeMoreButtonOnClicked(object sender, EventArgs eventArgs)
        {
            _isExpanded = true;
            Children.RemoveAt(Children.Count - 1);
            for (var i = Limit; i < Items.Count(); i++)
            {
                var item = Items.GetElementAt(i);
                AddItem(item);
            }
        }

        private void DisconnectButtonEvents()
        {
            if (_buttons == null) return;

            foreach (var button in _buttons) button.Clicked -= ButtonOnClicked;
        }

        private void ButtonOnClicked(object sender, EventArgs eventArgs)
        {
            var button = (ViewButton) sender;
            var index = _buttons.IndexOf(button);
            SelectedItem = Items.GetElementAt(index);
            ItemClicked?.Invoke(SelectedItem, EventArgs.Empty);
        }

        private void UpdateItems()
        {
            DisconnectEvents();
            _observedItems = null;
            _isExpanded = false;
            Clear();

            _observedItems = Items as INotifyCollectionChanged;
            ConnectEvents();

            LoadChildren();
        }

        private void ConnectEvents()
        {
            if (_observedItems == null) return;
            _observedItems.CollectionChanged += OnItemsCollectionChanged;
        }

        private void DisconnectEvents()
        {
            if (_observedItems == null) return;
            _observedItems.CollectionChanged -= OnItemsCollectionChanged;
        }

        private void OnItemsCollectionChanged(object sender,
            NotifyCollectionChangedEventArgs notifyCollectionChangedEventArgs)
        {
            LoadChildren();
        }
    }
}