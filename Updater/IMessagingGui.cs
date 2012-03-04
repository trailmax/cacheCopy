using System;
namespace Homegrown.Updater
{
    public interface IMessagingGui
    {
        void setProgressLabel(string message);
        void showMessageBox(string message);
    }
}
