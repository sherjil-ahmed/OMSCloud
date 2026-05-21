importScripts("https://www.gstatic.com/firebasejs/8.2.10/firebase-app.js")
const periodicSync = self.registration.periodicSync;
// The install handler takes care of precaching the resources we always need.
self.addEventListener('install', event => {
    console.log('install called', event, self)
    // event.waitUntil(
    //     caches.open(PRECACHE)
    //         .then(cache => cache.addAll(PRECACHE_URLS))
    //             .then(self.skipWaiting())
    // );
    //using firebase push
    var firebaseConfig = {
        apiKey: "AIzaSyCL_xHzcZTgn4qrbJVqLeQtr3H7VR7B3GM",
        authDomain: "testfcm-a6b5e.firebaseapp.com",
        databaseURL: "https://testfcm-a6b5e.firebaseio.com",
        projectId: "testfcm-a6b5e",
        storageBucket: "testfcm-a6b5e.appspot.com",
        messagingSenderId: "625122776125",
        appId: "1:625122776125:web:b9b53c153d8ee0a93ac654"
      };
      // Initialize Firebase
      self.firebase.initializeApp(firebaseConfig);
});

// The activate handler takes care of cleaning up old caches.
self.addEventListener('start', event => {
    console.log('I am started')
})

self.addEventListener('activate', event => {
    // const currentCaches = [PRECACHE, RUNTIME];
    // event.waitUntil(
    //     caches.keys().then(cacheNames => {
    //         return cacheNames.filter(cacheName => !currentCaches.includes(cacheName));
    //     }).then(cachesToDelete => {
    //         return Promise.all(cachesToDelete.map(cacheToDelete => {
    //             return caches.delete(cacheToDelete);
    //         }));
    //     }).then(() => self.clients.claim())
    // );

    // setInterval(() => {
    //     console.log('I am in interval')
    // }, 5000);
    
    // let profileID = '17'
    // let hubName = 'notificationhub'
    // fetch(`http://localhost:8749/signalr/negotiate?clientProtocol=1.5&ProfileID=${profileID}&connectionData=%5B%7B%22name%22%3A%22${hubName}%22%7D%5D`).then(data=> 
    //     data.json()
    // ).then((negotiations)=> {
    //     console.log(negotiations)
    //     let token = encodeURIComponent(negotiations.ConnectionToken);
    //     const socket = new WebSocket(`ws://localhost:8749/signalr/connect?transport=webSockets&clientProtocol=1.5&ProfileID=${profileID}&connectionToken=${token}&connectionData=%5B%7B%22name%22%3A%22${hubName}%22%7D%5D&tid=7`);

    //     // Connection opened
    //     socket.addEventListener('open', function (event) {
    //         socket.send('Hello Server!');
    //     });
    
    //     // Listen for messages
    //     socket.addEventListener('message', function (event) {
    //         console.log('Message from server ', event.data);
    //         let rawMessage = JSON.parse(event.data)
    //         if(rawMessage && rawMessage.M && rawMessage.M.length >0  && rawMessage.M[0].A && rawMessage.M[0].A.length >0 )
    //         {
    //             let jsonData = rawMessage.M[0].A[0]
    //             if (Notification.permission == 'granted') {
    //                 self.registration.showNotification(jsonData.Message)
    //                 // self.getRegistration().then((reg)=> {
    //                 //     //console.log("reg", reg)
    //                 //     //reg.Notification(jsonData.Message)
    //                 //     //reg.showNotification(jsonData.Message);
                        
    //                 // });
    //             }
    //         }
            
    //     });

    //     fetch(`http://localhost:8749/signalr/start?transport=webSockets&clientProtocol=1.5&ProfileID=${profileID}&connectionToken=${token}&connectionData=%5B%7B%22name%22%3A%22${hubName}%22%7D%5D`).then(data=>
    //         data.json()
    //     ).then(connect => console.log(connect))
    // })


    

});

// The fetch handler serves responses for same-origin resources from a cache.
// If no response is found, it populates the runtime cache with the response
// from the network before returning it to the page.
self.addEventListener('fetch', event => {
    console.log('fetch called',event, self)
    // Skip cross-origin requests, like those for Google Analytics.
    // if (event.request.url.startsWith(self.location.origin)) {
    //     event.respondWith(
    //         caches.match(event.request).then(cachedResponse => {
    //             if (cachedResponse) {
    //                 return cachedResponse;
    //             }

    //             return caches.open(RUNTIME).then(cache => {
    //                 return fetch(event.request).then(response => {
    //                     // Put a copy of the response in the runtime cache.
    //                     return cache.put(event.request, response.clone()).then(() => {
    //                         return response;
    //                     });
    //                 });
    //             });
    //         })
    //     );
    // }
});


self.addEventListener('push', function(event) {

    console.log("I am called ~ push",event)

})

// self.addEventListener('periodicsync', function(event){
//     console.log("I am called ~ periodicEvent",event)
// })

self.onperiodicsync = function (event) {
    console.log("periodicsync", event)
}