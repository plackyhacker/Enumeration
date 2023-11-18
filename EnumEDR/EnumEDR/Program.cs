using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;

namespace EnumEDR
{
    public static class Program
    {
        public static void Main(string[] args)
        {
            string hostName = System.Net.Dns.GetHostName();

            // if a remote host is specified overwrite the default 
            if (args.Length > 0)
                hostName = args[0];

            string driverPath = "";
            
            // get a list of EDRs and signature files
            Dictionary<string, string[]> edrList = GetEDRList();
            bool edrFound = false;

            // determine which folder we need to search
            if (Environment.Is64BitOperatingSystem)
                driverPath = "\\\\" + hostName + "\\C$\\windows\\system32\\drivers";
            else
                driverPath = "\\\\" + hostName + "\\C$\\windows\\sysnative\\drivers";

            // search for EDR driver files
            foreach(KeyValuePair<string, string[]> kvp in edrList)
            {
                for(int i = 0; i <  kvp.Value.Length; i++)
                {
                    try
                    {
                        if (Directory.GetFiles(driverPath, kvp.Value[i], SearchOption.TopDirectoryOnly).Length != 0)
                        {
                            // if we find an EDR we can stop looking
                            Console.WriteLine("{0} is on the host.", kvp.Key);
                            edrFound = true;
                            break;
                        }
                    }
                    // in case we don't have permission
                    catch {  }
                }
                if (edrFound)
                    break;
            }

            // none were found
            if(!edrFound)
                Console.WriteLine("No EDR products were found.");
        }

        private static Dictionary<string, string[]> GetEDRList()
        {
            Dictionary<string, string[]> dict = new Dictionary<string, string[]>();

            dict.Add("Absolute", new string[] { "psepfilter.sys", "cve.sys", "cbfsfilter2017.sys" });
            dict.Add("Altiris (Symantec)", new string[] { "atrsdfw.sys" });
            dict.Add("Avast", new string[] { "aswSP.sys", "naswSP.sys" });
            dict.Add("AVG Technologies", new string[] { "avgtpx86.sys", "avgtpx64.sys" });
            dict.Add("BitDefender", new string[] { "edrsensor.sys", "hbflt.sys", "bdsvm.sys", "gzflt.sys", "bddevflt.sys", "AVCKF.SYS", "Atc.sys", "AVC3.SYS", "TRUFOS.SYS", "BDSandBox.sys" });
            dict.Add("Bromium", new string[] { "brfilter.sys", "BrCow_x_x_x_x.sys", "bemk.sys" });
            dict.Add("Carbon Black", new string[] { "CarbonBlackK.sys", "carbonblackk.sys", "Parity.sys", "cbk7.sys", "cbstream.sys", "ctifile.sys" });
            dict.Add("Check Point Software Technologies", new string[] { "epregflt.sys", "medlpflt.sys", "dsfa.sys", "cposfw.sys", "epklib.sys" });
            dict.Add("Cisco AMP", new string[] { "CiscoAMPCEFWDriver.sys", "CiscoAMPHeurDriver.sys" });
            dict.Add("Cisco Secure Endpoint", new string[] { "csacentr.sys", "csaenh.sys", "csareg.sys", "csascr.sys", "csaav.sys", "csaam.sys" });
            dict.Add("CJSC Returnil Software", new string[] { "rvsavd.sys" });
            dict.Add("Comodo Security Solutions", new string[] { "cfrmd.sys", "cmdccav.sys", "cmdguard.sys", "CmdMnEfs.sys", "MyDLPMF.sys" });
            dict.Add("CrowdStrike", new string[] { "im.sys", "CSAgent.sys", "CSBoot.sys", "CSDeviceControl.sys", "cspcm2.sys" });
            dict.Add("CyberArk", new string[] { "CybKernelTracker.sys", "vfdrv.sys", "vfnet.sys", "vfpd.sys" });
            dict.Add("Cybereason", new string[] { "CRExecPrev.sys" });
            dict.Add("Cylance Inc.", new string[] { "CyOptics.sys", "CyProtectDrv32.sys", "CyProtectDrv64.sys" });
            dict.Add("Dell Secureworks", new string[] { "groundling32.sys", "groundling64.sys" });
            dict.Add("Elastic Security for Endpoint", new string[] { "ElasticEndpoint.sys", "ElasticEndpointDriver.sys" });
            dict.Add("Endgame", new string[] { "esensor.sys" });
            dict.Add("ESET", new string[] { "edevmon.sys", "ehdrv.sys", "eamonm.sys", "ekbdflt.sys" });
            dict.Add("FireEye", new string[] { "FeKern.sys", "WFP_MRT.sys" });
            dict.Add("F-Secure", new string[] { "xfsgk.sys", "fsgk.sys", "fsatp.sys", "fshs.sys" });
            dict.Add("Heix Cyber Solutions", new string[] { "HexisFSMonitor.sys" });
            dict.Add("Kaspersky", new string[] { "klifks.sys", "klifaa.sys", "Klifsm.sys" });
            dict.Add("LogRhythm", new string[] { "LRAgentMF.sys" });
            dict.Add("Malwarebytes", new string[] { "mbamwatchdog.sys" });
            dict.Add("McAfee", new string[] { "mfeaskm.sys", "mfencfilter.sys", "epdrv.sys", "mfencoas.sys", "mfehidk.sys", "swin.sys", "hdlpflt.sys", "mfprom.sys", "MfeEEFF.sys" });
            dict.Add("OPSWAT Inc", new string[] { "libwamf.sys" });
            dict.Add("Palo Alto", new string[] { "telam.sys" });
            dict.Add("Panda Security", new string[] { "PSINPROC.SYS", "PSINFILE.SYS", "amfsm.sys", "amm8660.sys", "amm6460.sys" });
            dict.Add("Raytheon Cyber Solutions", new string[] { "eaw.sys" });
            dict.Add("SAFE-Cyberdefense", new string[] { "SAFE-Agent.sys" });
            dict.Add("SentinelOne", new string[] { "SentinelMonitor.sys" });
            dict.Add("Sophos", new string[] { "SAVOnAccess.sys", "savonaccess.sys", "sld.sys", "SophosED.sys", "sntp.sys", "swi_callout.sys", "hmpalert.sys", "sdcfilter.sys", "SophosBootDriver.sys" });
            dict.Add("Symantec", new string[] { "pgpwdefs.sys", "GEProtection.sys", "diflt.sys", "sysMon.sys", "ssrfsf.sys", "emxdrv2.sys", "reghook.sys", "spbbcdrv.sys", "bhdrvx86.sys", "bhdrvx64.sys", "SISIPSFileFilter.sys", "symevent.sys", "vxfsrep.sys", "VirtFile.sys", "SymAFR.sys", "symefasi.sys", "symefa.sys", "symefa64.sys", "SymHsm.sys", "evmf.sys", "GEFCMP.sys", "VFSEnc.sys", "pgpfs.sys", "fencry.sys", "symrg.sys" });
            dict.Add("Trend Micro", new string[] { "TMUMS.sys", "hfileflt.sys", "TMUMH.sys", "AcDriver.sys", "SakFile.sys", "SakMFile.sys", "fileflt.sys", "TmEsFlt.sys", "tmevtmgr.sys", "TmFileEncDmk.sys" });
            dict.Add("Verdasys", new string[] { "dgdmk.sys", "ndgdmk.sys" });
            dict.Add("Webroot", new string[] { "ssfmonm.sys" });

            return dict;
        }
    }
}
