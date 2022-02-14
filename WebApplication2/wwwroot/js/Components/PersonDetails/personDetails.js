define(['knockout', 'personservice', 'bookmarkService', 'postman'], function (ko, ps, bs, postman) {
    return function (params) {
        let nameOtherview = ko.observable();
        let findingCoPlayers = ko.observableArray([]);
        let status = ko.observable();

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

        let BookmarkPeople = () => {
            const bookmarkPeople = { u_id: localStorage.getItem("u_id"), personId: nameOtherview().personId, name: nameOtherview().name };
            status("Bookmarked")

            bs.createBookmarkPeople(bookmarkPeople, data => {
                console.log(data);
            });

        }

        return {
            nameOtherview,
            findingCoPlayers,
            Back,
            BookmarkPeople,
            status
        };
    };
});