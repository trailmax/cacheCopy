using System;
namespace cacheCopy
{
    public interface IBrowserHelper
    {
        System.Collections.Generic.List<ProfilePath> getProfiles();
        bool isBrowserInstalled();
        string getBrowserVersion();
    }
}
