using System;
namespace Homegrown.Updater
{
    public interface IApplicationUpdaterBridge
    {
        Version GetApplicationVersion();
        DateTime GetLastCheckedForUpdateDate();
        void SetLastCheckedForUpdateDate(DateTime date);
    }
}
