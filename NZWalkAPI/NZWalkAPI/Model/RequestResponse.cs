namespace NZWalkAPI.Model
{
    public class RequestResponse
    {
        public int Code { get; set; }
        public Boolean Status { get; set; }
        public string Message { get; set; }
        public object Data { get; set; }
    }
}
