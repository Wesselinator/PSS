class feedbackReport {
    public title: string;
    public type: string;
    public description: string;
    public followupdate: Date;
    public isIssueResolved: boolean;
    public satisfactionLevel: number;

    constructor(title: string, type: string, description: string, followupdate: Date, isIssueResolved: boolean, satisfactionLevel: number) {
        this.title = title;
        this.type = type;
        this.description = description;
        this.followupdate = followupdate;
        this.isIssueResolved = isIssueResolved;
        this.satisfactionLevel = satisfactionLevel;
    }
}

export = feedbackReport;
