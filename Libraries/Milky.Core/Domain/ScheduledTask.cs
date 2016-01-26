using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Blogger.Core.Domain
{
    public class ScheduledTask
    {
        
        DateTime LastRun;
    }

    //Get the biggest lastrun...
    //Compare month of last run, if last run month and year is same or larger, then quit and do not continue
}