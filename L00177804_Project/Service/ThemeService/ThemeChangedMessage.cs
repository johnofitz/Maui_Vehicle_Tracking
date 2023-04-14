using CommunityToolkit.Mvvm.Messaging.Messages;


namespace L00177804_Project.Service.ThemeService
{
    public class ThemeChangedMessage : ValueChangedMessage<string>
    {
        public ThemeChangedMessage(string value) : base(value)
        {
        }
    }
}
