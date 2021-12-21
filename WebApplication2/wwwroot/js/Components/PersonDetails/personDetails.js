define(['knockout', 'personservice', 'postman'], function (ko, ps, postman) {
    return function (params) {
        let nameOtherview = ko.observableArray([]);
        let findingCoPlayers = ko.observableArray([]);

        let getPerson = (personId) => {
            ps.getSpecificPerson(personId, data => {
                console.log(data);
                nameOtherview(data);
            });
        }

        /*CoPlayers*/
        let getCoPlayers = (personId) => {
            ps.getCoPlayers(personId, data => {
                console.log(data);
                findingCoPlayers(data);
            });
        }

        postman.subscribe("showperson", personId => {
            getPerson(personId)
            getCoPlayers(personId)
            console.log(personId)
        })

        let Back = () => postman.publish("changeView", "Search-for-persons");

        return {
            nameOtherview,
            findingCoPlayers,
            Back          
        };
    };
});