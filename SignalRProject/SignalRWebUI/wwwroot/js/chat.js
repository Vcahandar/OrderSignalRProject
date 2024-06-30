
var connection = new signalR.HubConnectionBuilder().withUrl("https://localhost:7172/SignalRHub").build();

document.getElementById("sendbutton").disaabled = true;
connection.on("ReceiveMessage", function (user, message) {
    var currentTime = new Date();

    var currentHour = currentTime.getHours();
    var currentMinute = currentTime.getMinutes();

    var li = document.createElement("li");
    var span = document.createElement("span");
    span.style.fontWeight = "bold";
    span.textContent = user;
    li.appendChild(span);
    li.innerHTML += `:${message} - ${currentHour}:${currentMinute}`;
    document.getElementById("messageList").appendChild(li);

});

connection.start().then(function () {
    document.getElementById("sendbutton").disaabled = false;

}).catch(function (err) {
    return console.error(err.toString())
});

document.getElementById("sendbutton").addEventListener("click", function (event) {

    var user = document.getElementById("userinput").value;
    var message = document.getElementById("messageinput").value;
    connection.invoke("SendMassage", user, message).catch(function (err) {
        return console.error(err.toString());
    });

    event.preventDefault(); 
})