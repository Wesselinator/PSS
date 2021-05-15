class client {
    public clientID: number;
    public isIndividual: boolean;

    constructor(clientID: number, isIndividual: boolean) {
        this.clientID = clientID;
        this.isIndividual = isIndividual;
    }

    //never able to use.
    //public crossoversql(reportId: number): string {
    //    var firstHalf: string;

    //    if (this.isIndividual) {
    //        firstHalf = "BusinessClientFollowUp (BusinessClientID";
    //    } else {
    //        firstHalf = "IndividualClientFollowUp (IndividualClientID";
    //    };

    //    return "INSERT INTO " + firstHalf + ", FollowUpReportID) " +
    //           `VALUES (${this.clientID}, ${reportId})`;
    //};

}

export = client;
