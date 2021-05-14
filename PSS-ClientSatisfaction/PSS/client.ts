class client {
    public clientID: number;
    public display: string;
    public isIndividual: boolean;

    constructor(clientID: number, display: string, isIndividual: boolean) {
        this.clientID = clientID;
        this.display = display;
        this.isIndividual = isIndividual;
    }

    crossoversql(reportId: number): string {
        var firstHalf: string;

        if (this.isIndividual) {
            firstHalf = "BusinessClientFollowUp (BusinessClientID";
        } else {
            firstHalf = "IndividualClientFollowUp (IndividualClientID";
        }

        return "INSERT INTO " + firstHalf + ", ServiceRequestID) " +
               `VALUES (${this.clientID}, ${reportId})`
    }

}

export = client;
