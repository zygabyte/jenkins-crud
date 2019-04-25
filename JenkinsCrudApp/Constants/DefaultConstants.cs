namespace JenkinsCrudApp.Constants
{
    public static class DefaultConstants
    {
        public static string SuccessfullyCreated => "Successfully created {0}";
        public static string SuccessfullyDeleted => "Successfully deleted {0}";
        public static string SuccessfullyUpdated => "Successfully updated {0}";

        public static string FailedCreate => "Failure in creating {0}";
        public static string FailedDelete => "Failure in deleting {0}";
        public static string FailedUpdate => "Failure in updating {0}";

        public static string ErrorCreate => "Error in creating {0}";
        public static string ErrorDelete => "Error in deleting {0}";
        public static string ErrorUpdate => "Error in updating {0}";
        public static string ErrorRead => "Error in reading {0}";
        public static string ErrorReadSingle => "Error in reading {0} with Id {1}";

        public static string NullObject => "{0} is null";


    }
}