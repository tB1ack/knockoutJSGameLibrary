/// <reference path="jquery-3.3.1.min.js" />
/// <reference path="knockout-3.4.2.js" />

function game(id, name, genre, console) {
    var self = this;

    self.Id = id;
    self.Name = name;
    self.Genre = genre;
    self.Console = console;

    self.addGame = function () {
        $.ajax({
            url: "/api/Game/",
            type: 'post',
            data: ko.toJSON(this),
            contentType: 'application/json',
            success: function (result) {
            }
        });
    };
}

function gameVM() {
    var self = this;
    self.games = ko.observableArray([]);
    self.getGames = function () {
        self.games.removeAll();
        $.getJSON("/api/Game/", function (data) {
            $.each(data, function (key, val) {
                self.games.push(new game(val.Id, val.Name, val.Genre, val.Console));
            });
        });
    };
}

$(document).ready(function () {
    ko.applyBindings(new gameVM(), document.getElementById('displayNode'));
    ko.applyBindings(new game(), document.getElementById('createNode'));
});