using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Security.Principal;

using static Enumeration.Native;

namespace Enumeration
{
    public static class Processes
    {
        public static void EnumerateProcesses()
        {
            Process[] processes = Process.GetProcesses();
            Process[] sortedProcesses = SortProcesses(processes);

            Console.WriteLine("{0} {1} {2} {3}", "PID".ToString().PadRight(6), "Process".PadRight(40), "Session   ", "User");
            Console.WriteLine("{0} {1} {2} {3}", "---".ToString().PadRight(6), "-------".PadRight(40), "-------   ", "----");

            foreach (Process process in sortedProcesses)
            {
                Console.WriteLine("{0} {1} {2} {3}", 
                    process.Id.ToString().PadRight(6), 
                    process.ProcessName.PadRight(40), 
                    process.SessionId.ToString().PadRight(10),
                    GetProcessUser(process));
            }
        }

        // https://stackoverflow.com/questions/777548/how-do-i-determine-the-owner-of-a-process-in-c
        private static string GetProcessUser(Process process)
        {
            IntPtr processHandle = IntPtr.Zero;
            try
            {
                Native.OpenProcessToken(process.Handle, 8, out processHandle);
                WindowsIdentity wi = new WindowsIdentity(processHandle);
                string user = wi.Name;
                return user.Contains(@"\") ? user.Substring(user.IndexOf(@"\") + 1) : user;
            }
            catch
            {
                return null;
            }
            finally
            {
                if (processHandle != IntPtr.Zero)
                {
                    Native.CloseHandle(processHandle);
                }
            }
        }

        private static Process[] SortProcesses(Process[] processes)
        {
            int[] sortedPIDs = new int[processes.Length];
            int index = 0;

            foreach (Process process in processes)
            {
                sortedPIDs[index] = process.Id; 
                index++;
            }

            Array.Sort(sortedPIDs);

            Process[] sortedProcesses = new Process[sortedPIDs.Length];

            for(int i = 0;i < sortedPIDs.Length;i++)
            {
                foreach(Process p in processes)
                {
                    if(p.Id == sortedPIDs[i])
                    {
                        sortedProcesses[i] = p;
                        continue;
                    }
                }
            }

            return sortedProcesses;

        }
    }
}
