import itemPair = require('./itemPair');

class comboGroup {
    public label: string;
    public items: itemPair[];

    constructor(label: string, items: itemPair[]) {
        this.label = label;
        this.items = items;
    }
}

export = comboGroup;
