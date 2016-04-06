using CraftyPucker.Data.UrlGenerators;
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

        public void StreamGame(Arguments args, MediaFeed mediaFeed)
        {
            try
            {
                StreamGame(args, CraftyPucker.Data.Stream.Parameters.CDN.Akami, mediaFeed);
            }
            catch (StreamException streamEx)
            {
                StreamGame(args, CraftyPucker.Data.Stream.Parameters.CDN.Level3, mediaFeed);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public void StreamGame(Arguments args, string CDN, MediaFeed mediaFeed)
        {
            var argumentBuilder = new ArgumentBuilder();
            var psi = new ProcessStartInfo();
            psi.FileName = @"C:\Program Files (x86)\Livestreamer\livestreamer.exe";
            
            psi.Arguments = argumentBuilder.Build(args, CDN, mediaFeed);
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
                    throw new StreamException(line);
                }
            }


        }

    }
}
