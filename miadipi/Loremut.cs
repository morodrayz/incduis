private static async Task ProcessPythonScriptAsync()
{
    // Define the path to the Python script
    string scriptPath = @"path\to\your\script.py";

    // Start the Python process with the script
    using (Process process = new Process())
    {
        process.StartInfo.FileName = "python";
        process.StartInfo.Arguments = scriptPath;
        process.StartInfo.UseShellExecute = false;
        process.StartInfo.RedirectStandardOutput = true;
        process.StartInfo.RedirectStandardError = true;
        process.StartInfo.CreateNoWindow = true;

        try
        {
            process.Start();

            // Asynchronously read the standard output and standard error of the process
            string output = await process.StandardOutput.ReadToEndAsync();
            string error = await process.StandardError.ReadToEndAsync();

            // Wait for the process to exit asynchronously
            await process.WaitForExitAsync();

            if (process.ExitCode == 0)
            {
                Console.WriteLine("Python script executed successfully.");
                Console.WriteLine(output);
            }
            else
            {
                Console.WriteLine("Python script failed to execute.");
                Console.WriteLine(error);
            }
        }
        catch (Exception ex)
        {
            // Log or handle the exception as needed
            Console.WriteLine($"An error occurred: {ex.Message}");
        }
    }
}
