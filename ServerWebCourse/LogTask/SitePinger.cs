using System;
using System.Threading;
using NLog;
using System.Net.NetworkInformation;

namespace LogTask
{
    public class SitePinger
    {
        public static void Main(string[] args)
        {
            var logger = LogManager.GetCurrentClassLogger();
            var pinger = new Ping();
            const string serverName = "glavnoehvost.ru";
            const int pingsCount = 100;
            var i = 0;

            void Start()
            {
                ++i;
                while (i <= pingsCount)
                {
                    try
                    {
                        var reply = pinger.Send(serverName);
                        if (reply.Status != IPStatus.Success)
                        {
                            logger.Warn("Сервер недоступен.");
                        }
                        else
                        {
                            logger.Info($"Latency: {reply.RoundtripTime}");
                        }
                    }
                    catch (Exception e)
                    {
                        logger.Error(e, "Ошибка");
                    }

                    Thread.Sleep(3000);
                }
            }

            var pingJob = new Thread(Start);
            pingJob.Start();
        }
    }
}
