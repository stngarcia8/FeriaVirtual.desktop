namespace FeriaVirtual.Domain.Orders {

    public class OrderProcess {

        // Properties
        public int ProcessID { get; set; }
        public string ProcessDescription { get; set; }

        // Constructors.
        private OrderProcess() {
            ProcessID = 0;
            ProcessDescription = string.Empty;
        }

        private OrderProcess(int processID,string processDescription) {
            ProcessID= processID;
            ProcessDescription= processDescription;
        }

        // Named constructors.
        public static OrderProcess CreateProcess() {
            return new OrderProcess();
        }

        public static OrderProcess CreateProcess(int processID,string processDescription) {
            return new OrderProcess(processID,processDescription);
        }

        public override string ToString() {
            return ProcessDescription;
        }
    }
}
