using System.Runtime.Serialization;
using System.ServiceModel;

namespace FootballService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "ITeamService" in both code and config file together.
    [ServiceContract]
    public interface ITeamService
    {

        [OperationContract]
        string GetData(int value);
        
        [OperationContract]
        string GetTeamResults(string teamName);

        // TODO: Add your service operations here
    }


    // Use a data contract as illustrated in the sample below to add composite types to service operations.
    [DataContract]
    public class TeamResults
    {
        private string name = "";
        private string score = "";
        private int position = 0;

        [DataMember]
        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        [DataMember]
        public string Score
        {
            get { return score; }
            set { score = value; }
        }

        [DataMember]
        public int Position
        {
            get { return position; }
            set { position = value; }
        }
    }
}
