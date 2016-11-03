using System;
using System.IO;
using System.Reflection;
using System.Text;

namespace Cryptonite
{
    public static class Cryptography
    {
        public static volatile bool run = true, encrypt = false;
        private static byte[] byteArrayPassword = new byte[20], byteArrayFile = new byte[524288];     // 512 KB...
        private static byte[,] database = new byte[2, byte.MaxValue + 1];
        private static int bytesRead;
        private static long totalBytesRead, fileLength;
        private static decimal decimalFileSize = 0M;
        private static readonly decimal oneKilobyte = 1024M, oneMegabyte = oneKilobyte * 1024M,
            oneGigabyte = oneMegabyte * 1024M, oneTerabyte = oneGigabyte * 1024M;
        public static readonly string extension = ".cry";

        private static FileStream fileInputStream, fileOutputStream;

        public static void LoadDatabase()
        {
            byte _byte = 0;

            try
            {
                using (Stream stream = Assembly.GetExecutingAssembly().GetManifestResourceStream("Cryptonite.Resources.cryptonite.db"))
                {
                    using (StreamReader streamReader = new StreamReader(stream))
                    {
                        for (int i = 0; i < database.GetLength(1); i++)
                        {
                            _byte = Convert.ToByte(streamReader.ReadLine());
                            database[0, i] = _byte;
                            database[1, _byte] = (byte)i;
                        }
                    }
                }
            }
            catch
            {
                throw new Exception();
            }
        }

        private static void AddPasswordToByteArray(string password)
        {
            byte[] byteArrayPassword = Encoding.ASCII.GetBytes(password);

            for (int i = 0; i < Cryptography.byteArrayPassword.Length; i++)
            {
                if (i < byteArrayPassword.Length)
                {
                    Cryptography.byteArrayPassword[i] = byteArrayPassword[i];
                }
                else
                {
                    Cryptography.byteArrayPassword[i] = 0;
                }
            }

            CryptoniteBytes(Cryptography.byteArrayPassword.Length, Cryptography.byteArrayPassword, true);
        }

        private static string GetPasswordFromByteArray()
        {
            int i = 0;

            CryptoniteBytes(Cryptography.byteArrayPassword.Length, Cryptography.byteArrayPassword, false);

            for (i = 0; i < Cryptography.byteArrayPassword.Length && Cryptography.byteArrayPassword[i] != 0; i++)
            {
                /*
                 * just counting...
                 */
            }

            byte[] byteArrayPassword = new byte[i];

            for (i = 0; i < byteArrayPassword.Length; i++)
            {
                byteArrayPassword[i] = Cryptography.byteArrayPassword[i];
            }

            return Encoding.Default.GetString(byteArrayPassword);
        }

        public static string FormatFileSize(long fileSize)
        {
            if (fileSize == 0)
            {
                return "0 Bytes";
            }

            string unit = "Bytes";

            try
            {
                decimalFileSize = Convert.ToDecimal(fileSize);
            }
            catch
            {
                /*
                 * don't need to handle this exception...
                 */
            }

            if (decimalFileSize > oneTerabyte)
            {
                decimalFileSize /= oneTerabyte;
                unit = "TB";
            }
            else if (decimalFileSize > oneGigabyte)
            {
                decimalFileSize /= oneGigabyte;
                unit = "GB";
            }
            else if (decimalFileSize > oneMegabyte)
            {
                decimalFileSize /= oneMegabyte;
                unit = "MB";
            }
            else if (decimalFileSize > oneKilobyte)
            {
                decimalFileSize /= oneKilobyte;
                unit = "KB";
            }

            return string.Format("{0:.##}", decimalFileSize) + " " + unit;
        }

        public static void CryptoniteBytes(int bytesRead, byte[] byteArray, bool encrypt)
        {
            for (int i = 0; i < bytesRead; i++)
            {
                if (encrypt)
                {
                    byteArray[i] = database[0, byteArray[i]];
                }
                else
                {
                    byteArray[i] = database[1, byteArray[i]];
                }
            }
        }

        public static void CryptoniteFile(string fileName, string password)
        {
            totalBytesRead = 0;
            run = true;
            string outputFileName;

            if (encrypt)
            {
                outputFileName = fileName + extension;
            }
            else
            {
                outputFileName = fileName.Substring(0, fileName.LastIndexOf('.'));
            }

            try
            {
                using (fileInputStream = new FileStream(fileName, FileMode.Open, FileAccess.Read))
                {
                    fileLength = fileInputStream.Length;

                    if (!encrypt)
                    {
                        totalBytesRead += fileInputStream.Read(byteArrayPassword, 0, byteArrayPassword.Length);

                        if (!GetPasswordFromByteArray().Equals(password))
                        {
                            run = false;

                            Program.form.ShowErrorMessage("The password you entered is incorrect.\nPlease enter the correct password.");
                        }
                    }

                    if (run)
                    {
                        if (File.Exists(outputFileName))
                        {
                            try
                            {
                                File.Delete(outputFileName);
                            }
                            catch
                            {
                                /*
                                 * don't need to handle this exception...
                                 */
                            }
                        }

                        using (fileOutputStream = new FileStream(outputFileName, FileMode.Append, FileAccess.Write))
                        {
                            if (encrypt)
                            {
                                AddPasswordToByteArray(password);
                                fileOutputStream.Write(byteArrayPassword, 0, byteArrayPassword.Length);
                                fileOutputStream.Flush();
                            }

                            while (run && (bytesRead = fileInputStream.Read(byteArrayFile, 0, byteArrayFile.Length)) != 0)
                            {
                                totalBytesRead += bytesRead;

                                CryptoniteBytes(bytesRead, byteArrayFile, encrypt);

                                fileOutputStream.Write(byteArrayFile, 0, bytesRead);
                                fileOutputStream.Flush();

                                Program.form.UpdateProgress(Convert.ToInt32((totalBytesRead * 100) / fileLength));
                            }

                            if (!run)
                            {
                                Program.form.UpdateProgress(0);
                            }
                        }
                    }
                }
            }
            catch (Exception exc)
            {
                Program.form.ShowErrorMessage(exc.Message);
            }
        }
    }
}