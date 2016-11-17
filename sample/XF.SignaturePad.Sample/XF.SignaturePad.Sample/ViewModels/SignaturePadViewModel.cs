using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace XF.SignaturePad.Sample.ViewModels
{
    class SignaturePadViewModel : INotifyPropertyChanged
    {
        #region INotifyPropertyChanged

        public event PropertyChangedEventHandler PropertyChanged;

        public virtual void NotifyPropertyChanged(string propertyName)
        {
            var changedEventHandler = this.PropertyChanged;
            changedEventHandler?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        #endregion

        public ICommand SaveCommand { get; private set; }

        public SignaturePadViewModel()
        {
            SaveCommand = new Command(async parameter => await OnSave(parameter));
        }

        #region methods

        private async Task OnSave(object parameter)
        {
            try
            {
                await SaveSignature(parameter);
            }
            catch (Exception e)
            {
                Debug.WriteLine(e);
            }
        }

        private async Task SaveSignature(object pad)
        {
            var view = pad as SignaturePadView;

            if (view != null)
            {
                if (view.IsBlank)
                {
                    await App.ShowAlert("Signature is empty");
                    return;
                }

                var signatureString = await SignatureToBase64(view);
                var result = await SignatureStringIsNotEmpty(signatureString);
                if (result)
                    await App.ShowAlert("Signature successfully converted to base64 string");
            }
        }

        private async Task<string> SignatureToBase64(SignaturePadView view)
        {
            if (view != null)
            {
                try
                {
                    return await view.GetImageStringBase64Async();
                }
                catch (Exception e)
                {
                    await App.ShowAlert(e.Message);
                    Debug.WriteLine(e);
                }
            }

            return null;
        }

        private async Task<bool> SignatureStringIsNotEmpty(string signatureString)
        {
            if (string.IsNullOrEmpty(signatureString))
            {
                await App.ShowAlert("Signature is empty");
                return false;
            }

            return true;
        }

        #endregion
    }
}
