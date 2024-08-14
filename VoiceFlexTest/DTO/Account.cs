namespace VoiceFlexTest.DTO;

public class Account
{
    public Guid Id { get; set; }

    public string Description { get; set; }

    public int Status { get; set; }

    public List<PhoneNumber> PhoneNumbers { get; set; }
}
