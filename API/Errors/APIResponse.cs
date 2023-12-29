namespace API.Errors
{
    public class APIResponse
    { 
        public int StatusCode{set;get;}
        public string Message{set;get;}
        public APIResponse(int statuscode,string message=null)
        {
            StatusCode = statuscode;
            Message = message ?? GetDefaultMessageForStatusCode(statuscode);
        }
        private string GetDefaultMessageForStatusCode(int statuscode)
        {
            return statuscode switch 
            {
             400=> "A bad request you have made ",
             401=> "Authorized ,you are not",
             404=> "resource found, it was not",
             500=> "Errors are the path to the dark side,errors lead to anger,"
             +"anger lead to hate, hate leads to career shift",   
               _=>""
            };
        }
    }
}