using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InstallCustomCulture
{
    class Program
    {
        static void Main(string[] args)
        {
            if (args.Length > 0)
            {
                if (args[0] == "install" && args.Length == 4)
                {
                    InstallCulture(args[1], args[2], args[3]);
                    return;
                }

                if (args[0] == "uninstall" && args.Length == 2)
                {
                    UninstallCulture(args[1]);
                    return;
                }
            }

            Console.WriteLine("Usage:");
            Console.WriteLine("  ");
            Console.WriteLine("  Installation:");
            Console.WriteLine("    ");
            Console.WriteLine("    InstallCustomCulture install [culture-id] [culture-name] [based-on]");
            Console.WriteLine("    ");
            Console.WriteLine("    Example:");
            Console.WriteLine("      InstallCustomCulture install en-HK \"English (Hong Kong)\" en-GB");
            Console.WriteLine("  ");
            Console.WriteLine("  Uninstallation:");
            Console.WriteLine("    ");
            Console.WriteLine("    InstallCustomCulture uninstall [culture-id]");
            Console.WriteLine("    ");
            Console.WriteLine("    Example:");
            Console.WriteLine("      InstallCustomCulture uninstall en-HK");
        }

        static void InstallCulture(string cultureId, string cultureName, string basedOn)
        {
            CultureInfo cultureInfo = new CultureInfo(basedOn);
            RegionInfo regionInfo = new RegionInfo(cultureInfo.Name);

            CultureAndRegionInfoBuilder cultureAndRegionInfoBuilder = new CultureAndRegionInfoBuilder(cultureId, CultureAndRegionModifiers.None);

            cultureAndRegionInfoBuilder.LoadDataFromCultureInfo(cultureInfo);
            cultureAndRegionInfoBuilder.LoadDataFromRegionInfo(regionInfo);

            cultureAndRegionInfoBuilder.CultureEnglishName = cultureName;
            cultureAndRegionInfoBuilder.CultureNativeName = cultureName;

            cultureAndRegionInfoBuilder.Register();
        }

        static void UninstallCulture(string cultureId)
        {
            CultureAndRegionInfoBuilder.Unregister(cultureId);
        }
    }
}
