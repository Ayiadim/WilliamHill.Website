
function RaceModel(data) {
    var self = this;

    self.Races = ko.observableArray();

    self.LoadData = function (data) {
        var items = [];
        for (var i = 0; i < data.length; i++) {
            items.push(new Race(data[i]));
        }

        self.Races.push.apply(self.Races, items);
    };

    self.LoadData(data);
}

function Race(raceData) {
    var self = this;

    self.ID = raceData.ID;
    self.Name = raceData.Name;
    self.Start = raceData.Start;
    self.Status = raceData.Status;
    self.TotalBets = raceData.TotalMoneyPlaced;
    self.Horses = raceData.Horses;

    self.InnerModel = new InnerModel(self.Horses);

    self.ToggleView = function () {
        var state = self.InnerModel.IsVisible();
        self.InnerModel.IsVisible(!state);
    };
}

function InnerModel(horseData) {
    var self = this;

    self.Horses = ko.observableArray();
    self.IsVisible = ko.observable(false);

    self.LoadData = function (data) {
        var items = [];
        for (var i = 0; i < data.length; i++) {
            items.push(new Horse(data[i]));
        }

        self.Horses.push.apply(self.Horses, items);
    };

    self.LoadData(horseData);
}

function Horse(horseData) {
    var self = this;

    self.ID = horseData.ID;
    self.Name = horseData.Name;
    self.Odds = horseData.Odds;
    self.TotalBets = horseData.TotalBets;
    self.Payout = horseData.Payout;
}