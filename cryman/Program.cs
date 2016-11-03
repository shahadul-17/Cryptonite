using System;
using System.Runtime.InteropServices;
using Microsoft.Win32;

namespace Cryptonite
{
    public static class Program
    {
        private static readonly string extension = ".cry", applicationName = "Cryptonite";
        private static string fullApplicationName;

        [DllImport("Shell32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        public static extern void SHChangeNotify(uint wEventId, uint uFlags, IntPtr dwItem1, IntPtr dwItem2);

        public static void Main(string[] args)
        {
            if (args.Length == 2)
            {
                fullApplicationName = args[0];
                int value = Convert.ToInt32(args[1]);

                switch (value)
                {
                    case 1:
                        RemoveFileAssociation();
                        AssociateFile();

                        break;
                    case 2:
                        RemoveFileAssociation();

                        break;
                    case 3:
                        AddToExplorerContextMenu();

                        break;
                    case 4:
                        RemoveFromExplorerContextMenu();

                        break;
                    case 5:
                        RemoveFileAssociation();
                        AssociateFile();
                        AddToExplorerContextMenu();

                        break;
                }
            }
        }

        private static void AssociateFile()
        {
            RegistryKey registryKey;

            try
            {
                registryKey = Registry.ClassesRoot.CreateSubKey(extension);

                if (registryKey != null)
                {
                    registryKey.SetValue("", "cryfile");
                }

                registryKey.Close();
            }
            catch
            {
                /*
                 * don't need to handle this exception...
                 */
            }

            try
            {
                registryKey = Registry.ClassesRoot.CreateSubKey("cryfile");

                if (registryKey != null)
                {
                    registryKey.SetValue("", "Cryptonited File");
                }

                registryKey.Close();
            }
            catch
            {
                /*
                 * don't need to handle this exception...
                 */
            }

            try
            {
                registryKey = Registry.ClassesRoot.CreateSubKey(@"cryfile\DefaultIcon");

                if (registryKey != null)
                {
                    registryKey.SetValue("", fullApplicationName);
                }

                registryKey.Close();
            }
            catch
            {
                /*
                 * don't need to handle this exception...
                 */
            }

            try
            {
                registryKey = Registry.ClassesRoot.CreateSubKey(@"cryfile\shell\open\command");

                if (registryKey != null)
                {
                    registryKey.SetValue("", fullApplicationName + " \"%1\"");
                }

                registryKey.Close();
            }
            catch
            {
                /*
                 * don't need to handle this exception...
                 */
            }

            SHChangeNotify(0x08000000, 0x0000, IntPtr.Zero, IntPtr.Zero);
        }

        private static void RemoveFileAssociation()
        {
            try
            {
                Registry.ClassesRoot.DeleteSubKeyTree(extension);
            }
            catch
            {
                /*
                 * don't need to handle this exception...
                 */
            }

            try
            {
                Registry.ClassesRoot.DeleteSubKeyTree("cryfile");
            }
            catch
            {
                /*
                 * don't need to handle this exception...
                 */
            }

            SHChangeNotify(0x08000000, 0x0000, IntPtr.Zero, IntPtr.Zero);
        }

        private static void AddToExplorerContextMenu()
        {
            RegistryKey registryKey;

            try
            {
                registryKey = Registry.ClassesRoot.CreateSubKey(@"*\shell\" + applicationName);

                if (registryKey != null)
                {
                    registryKey.SetValue("Icon", fullApplicationName, RegistryValueKind.String);
                }

                registryKey.Close();

                registryKey = Registry.ClassesRoot.CreateSubKey(@"*\shell\" + applicationName + @"\command");

                if (registryKey != null)
                {
                    registryKey.SetValue("", fullApplicationName + " \"%1\"");
                }

                registryKey.Close();
            }
            catch
            {
                /*
                 * don't need to handle this exception...
                 */
            }
        }

        private static void RemoveFromExplorerContextMenu()
        {
            try
            {
                Registry.ClassesRoot.DeleteSubKeyTree(@"*\shell\" + applicationName);
            }
            catch
            {
                /*
                 * don't need to handle this exception...
                 */
            }
        }
    }
}