using System;
namespace Homegrown.Updater
{
    public interface IMessagingGui
    {
        void setProgressLabel(string message);
        void ShowMessageBox(string message);
        bool ShowConfirmationDialog(string question, string title);
    }
}
