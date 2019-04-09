//$(function () {
//    var chat = $.connection.chatHub;
//    var username;
//    do {
//        username = document.getElementById("nombre").innerHTML;
//    } while (username == null || username == "");

//    chat.client.updateUsers = function (userCount, userList) {
//        $('#onlineUsersCount').text('Online users: ' + userCount);
//        $('#userList').empty();
//        userList.forEach(function (username) {
//            $('#userList').append('<li>' + username + '</li>');
//        });
//    }

//    chat.client.broadcastMessage = function (username, message) {
//        $('#messagesArea').append('<li><strong>' + username + '</strong>: ' + message);
//    }

//    $.connection.hub.start().done(function () {
//        chat.server.connect(username);
//    });

//    $('#btnSendMessage').click(function () {
//        var message = $('#userMessage').val();
//        chat.server.send(message);
//        $('#userMessage').val("");
//    });

//});
"use strict";

var connection = new signalR.HubConnectionBuilder().withUrl("/chatHub").build();

//Disable send button until connection is established
document.getElementById("sendButton").disabled = true;

connection.on("ReceiveMessage", function (user, message) {
    var msg = message.replace(/&/g, "&amp;").replace(/</g, "&lt;").replace(/>/g, "&gt;");
    var encodedMsg = user + " says " + msg;
    var li = document.createElement("li");
    li.textContent = encodedMsg;
    document.getElementById("messagesList").appendChild(li);
});

connection.start().then(function () {
    document.getElementById("sendButton").disabled = false;
}).catch(function (err) {
    return console.error(err.toString());
});

document.getElementById("sendButton").addEventListener("click", function (event) {
    var user = document.getElementById("userInput").value;
    var message = document.getElementById("messageInput").value;
    connection.invoke("SendMessage", user, message).catch(function (err) {
        return console.error(err.toString());
    });
    event.preventDefault();
});