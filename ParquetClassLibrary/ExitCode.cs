namespace ParquetRoller
{
    /// <summary>A value indicating success or the nature of the failure.</summary>
    /// <remarks>Returned when the application terminates to indicate results of the process.</remarks>
    /// <seealso href="https://docs.microsoft.com/en-us/windows/win32/debug/system-error-codes"/>
    public enum ExitCode : int
    {
        Success = 0,
        FileNotFound = 1,
        AccessDenied = 5,
        InvalidData = 13,
        NotSupported = 50,
        BadArguments = 160,
    }
}
