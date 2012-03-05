using System;
namespace Homegrown.Updater
{
    public interface IMessagingGui
    {
        void setProgressLabel(string message);
        void showMessageBox(string message);
        bool showConfirmationDialog(string question, string title);
    }
}
