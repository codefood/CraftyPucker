using CraftyPucker.Data.Stream.Locators;
using CraftyPucker.Data.UrlGenerators;
using NLog;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CraftyPucker.Data.Stream
{
    public class Streamer
    {
        private static Logger logger = LogManager.GetCurrentClassLogger();

        public static class CDN
        {
            public const string Level3 = "l3c";
            public const string Akami = "akc";
        }

        public void StreamGame(Arguments args, MediaFeed mediaFeed)
        {
            try
            {
                StreamGame(args, CDN.Akami, mediaFeed);
            }
            catch (StreamException)
            {
                logger.Warn("Akami cache failed, trying Level3 instead");
                StreamGame(args, CDN.Level3, mediaFeed);
            }
            catch (Exception ex)
            {
                logger.Error(ex);
                throw;
            }
        }

        public void StreamGame(Arguments args, string CDN, MediaFeed mediaFeed)
        {
            var argumentBuilder = new ArgumentBuilder();
            var psi = new ProcessStartInfo();
            psi.FileName = LiveStreamerLocator.Locate();

            logger.Warn(string.Format("Found LiveStreamer at {0}", psi.FileName));
            
            psi.Arguments = argumentBuilder.Build(args, CDN, mediaFeed);

            logger.Warn(string.Format("ARGS: {0}", psi.Arguments));

            psi.UseShellExecute = false;
            psi.RedirectStandardOutput = true;
            psi.CreateNoWindow = true;

            var process = new Process();
            process.StartInfo = psi;

            process.EnableRaisingEvents = true;

            process.Start();

            while (!process.StandardOutput.EndOfStream)
            {
                var line = process.StandardOutput.ReadLine();
                Console.WriteLine(line);
                if (line.StartsWith("error:"))
                {
                    logger.Error(line);
                    throw new StreamException(line);
                }
                else
                {
                    logger.Debug(line);
                }
            }


        }

    }
}
