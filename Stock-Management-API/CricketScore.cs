namespace Stock_Management_API
{
    public class CricketScore
    {
        public DateTime Date { get; set; }
        public int Score { get; set; }
        public int Wickets { get; set; }
        public Decimal Overs { get; set; }
        public int Hours { get; set; }

        //TODO: Create a DB call to get the list of data.
    }
}
