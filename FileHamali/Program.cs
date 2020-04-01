namespace FileHamali
{
    using System;
    using System.IO;

    public class Program
    {
        public static void Main(string[] args)
        {
            // Run GetAppInfo funtion to get the name and the version.
            GetAppInfo();
            Console.WriteLine();

            // Function for printing color messages.
            PrintColorMessage(ConsoleColor.Magenta, ">>> we are here to do the heavy copying, so you don't have to <<<".ToUpper());

            // Empty line used for better visual spacing in the console.
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();

            // Ask for the file extention.
            PrintColorMessage(ConsoleColor.Yellow, "Pease enter the file extention of the files you wish to copy. E.g., .pdf, .mp3, .txt, etc.");
            Console.WriteLine();
            PrintColorMessage(ConsoleColor.Cyan, "***If you wish to select all files with multiple extentions, please enter: . ");
            Console.WriteLine();
            Console.WriteLine();

            // Enter file extention - .mp3, .pdf, .txt or * for all files.
            string fileExtention = Console.ReadLine();

            Console.WriteLine();
            PrintColorMessage(ConsoleColor.Yellow, @"Pease enter the main folder path where the files are located. E.g., C:\Users\username\Desktop\SourceFilesFolder");
            Console.WriteLine();

            // Enter the path of the source files.
            string sourcePath = Console.ReadLine();

            Console.WriteLine();
            PrintColorMessage(ConsoleColor.Yellow, @"Pease enter the folder path where you wish to copy your files to. E.g., C:\Users\username\Desktop\DestinationFilesFolder");

            // Enter the destination folder to copy or move files to.
            string targetPath = Console.ReadLine();

            // Create a new target folder. 
            // If the directory already exists, this method does not create a new directory.
            Directory.CreateDirectory(targetPath);

            // Checking if the entered source directory is valid.
            if (Directory.Exists(sourcePath))
            {
                string[] files;

                if (fileExtention == ".")
                {
                    files = Directory.GetFiles(sourcePath, $"*{fileExtention}*", SearchOption.AllDirectories);
                }
                else
                {
                    files = Directory.GetFiles(sourcePath, $"*{fileExtention}", SearchOption.AllDirectories);
                }

                // Copy the files and overwrite destination files if they already exist.
                foreach (var file in files)
                {
                    // Use static Path methods to extract only the file name from the path.
                    string fileName = Path.GetFileName(file);
                    string destinationFile = Path.Combine(targetPath, fileName);
                    File.Copy(file, destinationFile, true);
                }

                Console.WriteLine();
                Console.WriteLine();
                PrintColorMessage(ConsoleColor.Green, "Thank you for using File Hamali ! Your files were successfully copied to their new location !".ToUpper());
                Console.WriteLine();
                Console.WriteLine("Press ENTER key to exit...");
                Console.ReadLine();
                return;
            }
            else
            {
                PrintColorMessage(ConsoleColor.Red, "Source files path does not exist!");
            }
        }

        public static void PrintColorMessage(ConsoleColor color, string message)
        {
            // Set console color.
            Console.ForegroundColor = color;

            // Write color message on the console.
            Console.WriteLine(message);

            // Reset console color back to default.
            Console.ResetColor();
        }

        public static void GetAppInfo()
        {
            // Set app variables.
            string appName = "File Hamali";
            string appVersion = "1.0";
            string appAuthor = "Nikolay Georgiev";

            // Print app info in color.
            PrintColorMessage(ConsoleColor.Green, $"*** {appName} *** (version {appVersion} by {appAuthor})");
            Console.WriteLine();
        }
    }
}
