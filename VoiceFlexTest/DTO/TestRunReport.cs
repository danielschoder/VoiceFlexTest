namespace VoiceFlexTest.DTO
{
    public class TestRunReport
    {
        public string VoiceFlexVersion { get; set; }
        public int NumberOfTestsPerformed { get; set; }
        public int NumberOfTestsPassed { get; set; }
        public int NumberOfTestsFailed => NumberOfTestsPerformed - NumberOfTestsPassed;
    }
}
