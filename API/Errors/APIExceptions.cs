namespace API.Errors
{
    public class APIExceptions : APIResponse
    {
        public string Details{set;get;}
        public APIExceptions(int statuscode, string message = null,string details=null) : base(statuscode, message)
        {
            Details=details;
        }
    }
}