using CommunityToolkit.Mvvm.Messaging.Messages;


namespace L00177804_Project.Service.ThemeService
{
    public class ThemeAddMessage : ValueChangedMessage<string>
    {
        public ThemeAddMessage(string value) : base(value) {}
    }
}
