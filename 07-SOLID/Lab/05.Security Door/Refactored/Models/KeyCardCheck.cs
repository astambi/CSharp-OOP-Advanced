namespace _05.Security_Door.Refactored
{
    public class KeyCardCheck : SecurityCheck
    {
        private IKeyCardUI securityUI;

        public KeyCardCheck(IKeyCardUI securityUI)
        {
            this.securityUI = securityUI;
        }

        private bool IsValid(string code)
        {
            return true;
        }

        public override bool ValidateUser()
        {
            string code = this.securityUI.RequestKeyCard();
            if (IsValid(code))
            {
                return true;
            }

            return false;
        }
    }
}