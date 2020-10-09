using System;
using System.Threading.Tasks;

public static void Run(string mySbMsg, Int32 deliveryCount, DateTime enqueuedTimeUtc, string messageId, TraceWriter log)
{
    log.Info($"C# {mySbMsg}");
    log.Info($"{enqueuedTimeUtc}");
    log.Info($"{deliveryCount}");
    log.Info($"{messageId}");
}
