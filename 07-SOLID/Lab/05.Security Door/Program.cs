namespace _05.Security_Door
{
    public class Program
    {
        public static void Main()
        {
            // Interface Segregation

            OriginalImplementation();

            RefactoredImplementation();
        }

        private static void RefactoredImplementation()
        {
            var scannerUi = new Refactored.ScannerUI();
            var keyCardCheck = new Refactored.KeyCardCheck(scannerUi);
            var pinCodeCheck = new Refactored.PinCodeCheck(scannerUi);
            var manager = new Refactored.SecurityManager(keyCardCheck, pinCodeCheck);
            manager.Check();
        }

        private static void OriginalImplementation()
        {
            ScannerUI scannerUi = new ScannerUI();
            KeyCardCheck keyCardCheck = new KeyCardCheck(scannerUi);
            PinCodeCheck pinCodeCheck = new PinCodeCheck(scannerUi);
            SecurityManager manager = new SecurityManager(keyCardCheck, pinCodeCheck);
            manager.Check();
        }
    }
}
