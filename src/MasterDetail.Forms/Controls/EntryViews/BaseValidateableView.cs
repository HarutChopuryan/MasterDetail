using System.Collections;
using System.ComponentModel;
using MasterDetail.UI.Base;
using Xamarin.Forms;

namespace MasterDetail.Forms.Controls.EntryViews
{
    public class BaseValidateableView : ContentView
    {
        //Validator
        public static readonly BindableProperty ValidatorProperty =
            BindableProperty.Create(nameof(Validator),
                typeof(IViewModelValidator),
                typeof(BaseEntryView),
                null);

        //ValidationIds
        public static readonly BindableProperty ValidationIdProperty =
            BindableProperty.Create(nameof(ValidationId),
                typeof(string),
                typeof(BaseEntryView));

        private IList _errors;
        private IViewModelValidator _validationContext;

        public IViewModelValidator Validator
        {
            get => (IViewModelValidator) GetValue(ValidatorProperty);
            set => SetValue(ValidatorProperty, value);
        }

        public string ValidationId
        {
            get => (string) GetValue(ValidationIdProperty);
            set => SetValue(ValidationIdProperty, value);
        }

        public IList Errors
        {
            get => _errors;
            private set
            {
                if (!Equals(_errors, value))
                {
                    _errors = value;
                    OnPropertyChanged(nameof(Errors));
                }
            }
        }

        protected override void OnBindingContextChanged()
        {
            if (_validationContext != null) _validationContext.ErrorsChanged -= OnErrorsChanged;

            _validationContext = Validator ?? (BindingContext as IValidateableViewModel)?.Validator;
            if (_validationContext != null) _validationContext.ErrorsChanged += OnErrorsChanged;

            UpdateErrorsInternal();
            base.OnBindingContextChanged();
        }

        private void OnErrorsChanged(object sender, DataErrorsChangedEventArgs e)
        {
            if (ValidationId == null) return;
            if (string.IsNullOrEmpty(e.PropertyName) || ValidationId.Contains(e.PropertyName)) UpdateErrorsInternal();
        }

        protected virtual void UpdateErrors(bool hasErrors)
        {
        }

        private void UpdateErrorsInternal()
        {
            if (_validationContext != null)
            {
                Errors = _validationContext.GetAllErrors(ValidationId);
                var hasErrors = Errors != null && Errors.Count > 0;
                UpdateErrors(hasErrors);
            }
        }
    }
}