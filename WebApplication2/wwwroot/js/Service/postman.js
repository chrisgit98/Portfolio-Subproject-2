﻿define([], () => {
    let subscribers = [];
    let lastevent = {}

    let subscribe = (event, callback, target) => {
        let subscriber = { event, callback, target };

        if (!subscribers.find(x => x.target === target && x.event === event))
            subscribers.push(subscriber);

        if (lastevent[event]) {
            callback(lastevent[event])
        }

    };

    let publish = (event, data) => {

        subscribers.forEach(x => {
            if (x.event === event) x.callback(data);

        });
        lastevent[event] = data;
    };

    return {
        subscribe,
        publish
    }

});